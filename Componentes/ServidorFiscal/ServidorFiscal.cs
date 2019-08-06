using System;
using System.Net.Mail;
using System.Windows.Forms;
using System.Data;
using Lfx;
using Lazaro.Orm.Data;
using Lfx.Data;
using Lazaro.Orm.Data.Drivers;
using System.Diagnostics;
using log4net;

namespace ServidorFiscal
{
    /// <summary>
    /// Servidor de Impresora Fiscal
    /// </summary>
    public class ServidorFiscal
    {
        public Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Impresora Impresora;
        private Lbl.Comprobantes.PuntoDeVenta m_PuntoDeVenta = null;
        private System.Timers.Timer Programador;
        private System.Timers.Timer Watchdog;
        private System.DateTime Watchdog_LastOp = System.DateTime.Now;
        private Forms.Estado FormEstado = null;
        public Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs UltimoEvento;
        private static ILog Log = LogManager.GetLogger(typeof(Application));
        public static Lfx.Workspace Master = null;

        public object Run()
        {
            try
            {
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadExceptionHandler);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            }
            catch
            {
                // Esto puede dar una excepción
                // "El modo de excepción del subproceso no se puede cambiar una vez que se creen Controles en el subproceso."
                // Simplemente la ignoramos.
            }

            try
            {
                ApplicationInitial();
                Lbl.Sys.Config.Actual.UsuarioConectado = new Lbl.Sys.Configuracion.UsuarioConectado(new Lbl.Personas.Usuario(Lfx.Workspace.Master.MasterConnection, 1));
                FormEstado = new Forms.Estado();
                FormEstado.ServidorAsociado = this;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            try
            {
                using (System.Diagnostics.Process Yo = System.Diagnostics.Process.GetCurrentProcess())
                {
                    Yo.PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
                }
            }
            catch (Exception Ex)
            {
                System.Console.WriteLine("ServidorFiscal: Imposible elevar la prioridad del proceso (" + Ex.ToString() + "). Continuando de todos modos.");
                //Seguramente no me permitió cambiar la prioridad por ser un usuario sin privilegios.
                //No es crítico, así que continúo sin problema
                Log.Error(Ex.Message);
            }

            Impresora = new Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Impresora(Lfx.Workspace.Master);

            Lfx.Workspace.Master.RunTime.IpcEvent += new Lfx.RunTimeServices.IpcEventHandler(Componente_IpcEvent);
            Impresora.Notificacion += new Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.NotificacionEventHandler(ConFiscal_EventoConexion);

            Programador = new System.Timers.Timer(1000);
            Programador.Elapsed += new System.Timers.ElapsedEventHandler(EventoProgramador);
            Programador.Start();

            Watchdog = new System.Timers.Timer(60000);
            Watchdog.Elapsed += new System.Timers.ElapsedEventHandler(EventoWatchdog);
            Watchdog.Start();

            if (true)
            {
                while (Impresora.EstadoServidor != Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Apagando
                        && Impresora.EstadoServidor != Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando)
                {
                    System.Threading.Thread.Sleep(100);
                    System.Windows.Forms.Application.DoEvents();
                }

                Log.Debug(Impresora.EstadoServidor.ToString());

                if (Impresora.EstadoServidor == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando)
                    this.End(true);
                else if (Impresora.EstadoServidor == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Apagando)
                    this.End(false);
            }

            return null;
        }

        private void ApplicationInitial()
        {
            string NombreConfig = "default";
            System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ApplicationDataFolder);
            if (Dir.GetFiles(NombreConfig + ".lwf").Length == 0 && Dir.GetFiles("*.lwf").Length >= 1)
            {
                using (Lui.Forms.WorkspaceSelectorForm SelectEspacio = new Lui.Forms.WorkspaceSelectorForm())
                {
                    if (SelectEspacio.ShowDialog() == DialogResult.OK)
                    {
                        NombreConfig = SelectEspacio.WorkspaceName;
                        if (NombreConfig == null)
                            System.Environment.Exit(0);
                    }
                    else
                    {
                        System.Environment.Exit(0);
                    }
                }
            }

            Lfx.Workspace.Master = new Lfx.Workspace(NombreConfig, false, false);
            IniciarDatos();
        }

        /// <summary>
        /// Inicia el acceso al almacén de datos.
        /// </summary>
        private static void IniciarDatos()
        {
            Lfx.Types.OperationResult Res = AbrirConexion();
            // Habilito el gestor de configuración
            Lbl.Sys.Config.Actual = new Lbl.Sys.Configuracion.Global();
            Lbl.Sys.Config.Cargar();

            // Habilito la recuperación de conexiones
            Lfx.Workspace.Master.MasterConnection.EnableRecover = true;
        }

        /// <summary>
        /// Inicia una conexión con la base de datos y verifica si la versión de la la misma es la última disponible. En caso contrario la actualiza.
        /// </summary>
        internal static Lfx.Types.OperationResult AbrirConexion()
        {
            Lfx.Types.OperationResult iniciarReturn = new Lfx.Types.SuccessOperationResult();

            //Si el servidor SQL es esta misma PC, intento iniciar el servidor
            if (Lfx.Environment.SystemInformation.Platform == Lfx.Environment.SystemInformation.Platforms.Windows && Lfx.Workspace.Master.ConnectionParameters.ServerName.ToUpperInvariant() == "LOCALHOST")
            {
                switch (Lfx.Data.DatabaseCache.DefaultCache.AccessMode)
                {
                    case Lfx.Data.AccessModes.MySql:
                        Lfx.Environment.Shell.Execute("net", "start mysql", ProcessWindowStyle.Hidden, true);
                        break;
                    case Lfx.Data.AccessModes.Npgsql:
                        // FIXME: detectar el nombre del servicio.
                        Lfx.Environment.Shell.Execute("net", "start postgresql-9.0", ProcessWindowStyle.Hidden, true);
                        break;
                }
            }

            try
            {
                Lfx.Workspace.Master.MasterConnection.Open();
            }
            catch (Exception ex)
            {
                return new Lfx.Types.FailureOperationResult(ex.Message);
            }

            if (Lfx.Workspace.Master.IsPrepared() == false)
            {
                using (Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog(@"Aparentemente es la primera vez que utiliza este almacén de datos. Antes de poder utilizarlo debe prepararlo con una carga inicial de datos.
Responda 'Sí' sólamente si es la primera vez que utiliza Gestión o está restaurando desde una copia de seguridad.", @"¿Desea preparar el almacén de datos?"))
                {
                    Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                    if (Pregunta.ShowDialog() == DialogResult.OK)
                    {
                        Lfx.Types.OperationResult Res;
                        using (var Connection = Lfx.Workspace.Master.GetNewConnection("Preparar almacén de datos") as Lfx.Data.Connection)
                        {
                            Connection.RequiresTransaction = false;
                            Res = Lfx.Workspace.Master.Prepare(null);
                        }
                        if (Res.Success == false)
                            return Res;
                    }
                    else
                    {
                        return new Lfx.Types.FailureOperationResult("Debe preparar el almacén de datos.");
                    }
                }
            }

            // Configuro el nivel de aislación predeterminado
            // FIXME: no puedo obtener esto de la BD (System.Data.IsolationLevel)(Enum.Parse(typeof(System.Data.IsolationLevel), Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Datos.Aislacion", "Serializable")));
            Lfx.Data.DatabaseCache.DefaultCache.DefaultIsolationLevel = System.Data.IsolationLevel.Serializable;

            return iniciarReturn;
        }

        public Lbl.Comprobantes.PuntoDeVenta PuntoDeVenta {
            get {
                if (m_PuntoDeVenta == null)
                {
                    int NumeroPv = this.Impresora.Connection.FieldInt("SELECT id_pv FROM pvs WHERE UPPER(estacion)='" + Lfx.Environment.SystemInformation.MachineName.ToUpperInvariant() + "' AND tipo=2 AND id_sucursal=" + Lbl.Sys.Config.Empresa.SucursalActual.Id.ToString());
                    if (NumeroPv > 0)
                    {
                        m_PuntoDeVenta = new Lbl.Comprobantes.PuntoDeVenta(this.Impresora.Connection, NumeroPv);
                        if (m_PuntoDeVenta.Existe == false)
                            m_PuntoDeVenta = null;
                        this.Impresora.PuntoDeVenta = m_PuntoDeVenta;
                    }
                }

                return m_PuntoDeVenta;
            }
            set {
                m_PuntoDeVenta = value;
            }
        }

        public void ConFiscal_EventoConexion(object sender, Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs e)
        {
            UltimoEvento = e;
            switch (e.EventType)
            {
                case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs.EventTypes.Inicializada:
                    FormEstado.MostrarEstado("Inicializado");
                    break;
                case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs.EventTypes.Estado:
                    FormEstado.MostrarEstado(e.MensajeEstado);
                    break;
                case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs.EventTypes.InicioImpresion:
                    FormEstado.MostrarEstado("Se inició el proceso de impresión");
                    break;
                case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs.EventTypes.FinImpresion:
                    FormEstado.MostrarEstado("Finalizó el proceso de impresión");
                    break;
            }
        }

        public void Componente_IpcEvent(object sender, ref Lfx.RunTimeServices.IpcEventArgs e)
        {
            if (e.Destination == "servidorfiscal")
            {
                switch (e.Verb)
                {
                    case "END":
                        Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Apagando;
                        break;

                    case "REBOOT":
                        Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando;
                        break;
                }
            }
        }

        private void EventoWatchdog(object source, System.Timers.ElapsedEventArgs e)
        {
            //Hace un minuto que no se dispara un evento. Reinicio el servidor fiscal.
            if (System.DateTime.Now > Watchdog_LastOp.AddMinutes(5))
            {
                System.IO.BinaryWriter wr = new System.IO.BinaryWriter(new System.IO.FileStream(Lfx.Environment.Folders.ApplicationDataFolder + "watchdog.log", System.IO.FileMode.Append));
                wr.Write("ServidorFiscal: REBOOT " + System.DateTime.Now.ToString() + System.Environment.NewLine);
                wr.Close();

                Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando;
                Application.Restart();
            }
        }

        private int PV {
            get {
                if (this.PuntoDeVenta == null)
                    return 0;
                else
                    return this.PuntoDeVenta.Numero;
            }
        }

        private int PVenta {
            get {
                if (this.PuntoDeVenta == null)
                    return 0;
                else
                    return this.PuntoDeVenta.Id;
            }
        }

        private void EventoProgramador(object source, System.Timers.ElapsedEventArgs e)
        {
            Programador.Stop();
            Watchdog_LastOp = System.DateTime.Now;

            //Busco un PV que corresponda a esta terminal
            if (this.PV == 0)
            {
                Programador.Start();
                return;
            }

            Watchdog.Stop();

            UpdatePV("lsa");

            Lfx.Services.Task ProximaTarea = Lfx.Workspace.Master.DefaultScheduler.GetNextTask("fiscal" + this.PV.ToString());
            if (ProximaTarea != null)
            {
                string Comando = ProximaTarea.Command;
                string SubComando = Lfx.Types.Strings.GetNextToken(ref Comando, " ").Trim().ToUpper();

                Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Res;
                switch (SubComando)
                {
                    case "REBOOT":
                        FormEstado.MostrarEstado("Reiniciando...");
                        Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando;
                        this.End(true);
                        break;

                    case "END":
                        FormEstado.MostrarEstado("Cerrando...");
                        Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Apagando;
                        //this.End(false);
                        break;

                    case "CIERRE":
                        FormEstado.MostrarEstado("Imprimiendo cierre...");
                        Res = Impresora.ObtenerEstadoImpresora();
                        if (Res.EstadoFiscal.DocumentoFiscalAbierto)
                        {
                            Res = Impresora.CancelarDocumentoFiscal();
                            System.Threading.Thread.Sleep(500);
                        }
                        else if (Res.Error == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok)
                        {
                            string SubComandoCierre = Lfx.Types.Strings.GetNextToken(ref Comando, " ").Trim().ToUpper();
                            Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta ResultadoCierre = Impresora.Cierre(SubComandoCierre, true);
                            if (SubComandoCierre == "Z" && ResultadoCierre.Error == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok)
                            {
                                UpdatePV();
                            }
                            if (ResultadoCierre.Error != Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok)
                            {
                                MostrarErrorFiscal(ResultadoCierre);
                            }
                            System.Threading.Thread.Sleep(100);
                        }
                        else if (Res.HacerCierreZ)
                        {
                            Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta ResultadoCierre = Impresora.Cierre("Z", true);
                            System.Threading.Thread.Sleep(500);
                            if (ResultadoCierre.Error == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok)
                                UpdatePV();
                        }
                        break;

                    case "CANCELAR":
                        FormEstado.MostrarEstado("Cancelando comprobante...");
                        string ItemCancelar = Lfx.Types.Strings.GetNextToken(ref Comando, " ").Trim().ToUpper();
                        switch (ItemCancelar)
                        {
                            case "FISCAL":
                                Impresora.CancelarDocumentoFiscal();
                                System.Threading.Thread.Sleep(500);
                                break;
                        }
                        break;

                    case "IMPRIMIR":
                        FormEstado.MostrarEstado("Imprimiendo...");
                        int IdFactura = 0;
                        try
                        {
                            IdFactura = Lfx.Types.Parsing.ParseInt(Lfx.Types.Strings.GetNextToken(ref Comando, " ").Trim());
                        }
                        catch (Exception eco)
                        {
                            Log.Error(eco);
                        }
                        try
                        {
                            Res = Impresora.ObtenerEstadoImpresora();
                            if (Res.EstadoFiscal.DocumentoFiscalAbierto)
                            {
                                Res = Impresora.CancelarDocumentoFiscal();
                                System.Threading.Thread.Sleep(500);
                            }

                            if (Res.HacerCierreZ)
                            {
                                Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Hacer Cierre Z", "Es obligatorio hacer un Cierre Z antes de continuar. ¿Desea hacer el cierre ahora?");
                                Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;

                                if (Pregunta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    // Hago el cierre, y Res es el resultado del cierre
                                    Res = Impresora.Cierre("Z", true);
                                    System.Threading.Thread.Sleep(500);
                                }
                                else
                                {
                                    // No quiso hacer el cierre. Devuelvo un error
                                    Programador.Start();
                                    Watchdog.Start();
                                    return;
                                }
                            }
                            if (Res.Error == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok)
                                Res = Impresora.ImprimirComprobante(IdFactura);

                            if (Res.Error != Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok)
                            {
                                MostrarErrorFiscal(Res);
                                FormEstado.MostrarEstado("Cancelando documento...");
                                if (Res.EstadoFiscal.DocumentoFiscalAbierto)
                                    Res = Impresora.CancelarDocumentoFiscal();
                                Programador.Start();
                                Watchdog.Start();
                                return;
                            }
                        }
                        catch (Exception eIm)
                        {
                            Log.Error(eIm);
                        }
                        break;
                }
            }
            Programador.Start();
            Watchdog.Start();
        }

        private void UpdatePV(string campo = "ultimoz")
        {
            try
            {
                //Si hizo un cierre Z correctamente, actualizo la variable LCZ
                using (IDbTransaction Trans = this.Impresora.Connection.BeginTransaction())
                {
                    qGen.Update Actualizar = new qGen.Update("pvs", new qGen.Where("id_pv", this.PVenta));
                    Actualizar.ColumnValues.AddWithValue(campo, new qGen.SqlExpression("NOW()"));
                    this.Impresora.Connection.ExecuteNonQuery(Actualizar);
                    Trans.Commit();
                    Trans.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        private void MostrarErrorFiscal(Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Res)
        {
            FormError FormFiscalError = new FormError();
            FormFiscalError.Mostrar(Res);
            FormFiscalError.ShowDialog();
        }

        public void End(bool reboot)
        {
            Programador.Stop();

            if (this.PV != 0)
            {
                try
                {
                    using (System.Data.IDbTransaction Trans = this.Impresora.Connection.BeginTransaction())
                    {
                        qGen.Update Actualizar = new qGen.Update("pvs", new qGen.Where("id_pv", this.PVenta));
                        Actualizar.ColumnValues.AddWithValue("lsa", null);
                        this.Impresora.Connection.ExecuteNonQuery(Actualizar);
                        Trans.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }
            }

            Impresora.Terminar();
            FormEstado.Close();

            if (reboot)
            {
                Lfx.Environment.Shell.Execute(System.Environment.CommandLine, string.Join(" ", System.Environment.GetCommandLineArgs()), System.Diagnostics.ProcessWindowStyle.Minimized, false);
            }
            System.Windows.Forms.Application.Exit();
        }

        public static void ThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            UnknownExceptionHandler(e.Exception);
        }

        private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            UnknownExceptionHandler(args.ExceptionObject as Exception);
            Application.Exit();
        }

        /// <summary>
        /// Manejador de excepciones desconocidas. Presenta una ventana con el error y envía un informe por correo electrónico.
        /// </summary>
        /// <param name="ex">La excepción a reportar.</param>
        public static void UnknownExceptionHandler(Exception ex)
        {
            try
            {
                System.Text.StringBuilder Texto = new System.Text.StringBuilder();
                Texto.AppendLine("Lugar   : " + ex.Source);
                try
                {
                    System.Diagnostics.StackTrace Traza = new System.Diagnostics.StackTrace(ex, true);
                    Texto.AppendLine("Línea   : " + Traza.GetFrame(0).GetFileLineNumber());
                    Texto.AppendLine("Columna : " + Traza.GetFrame(0).GetFileColumnNumber());
                }
                catch
                {
                    //Nada
                }
                Texto.AppendLine("Equipo  : " + Lfx.Environment.SystemInformation.MachineName);
                Texto.AppendLine("Plataf. : " + Lfx.Environment.SystemInformation.PlatformName);
                Texto.AppendLine("RunTime : " + Lfx.Environment.SystemInformation.RuntimeName);
                Texto.AppendLine("Excepción no controlada: " + ex.ToString());
                Texto.AppendLine("");

                Texto.AppendLine("Gestion versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(Lfx.Environment.Folders.ApplicationFolder + "Gestión777.exe").ProductVersion + " del " + new System.IO.FileInfo(Lfx.Environment.Folders.ApplicationFolder + "Gestión777.exe").LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ApplicationFolder);
                foreach (System.IO.FileInfo DirItem in Dir.GetFiles("*.dll"))
                {
                    Texto.AppendLine(DirItem.Name + " versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(DirItem.FullName).ProductVersion + " del " + new System.IO.FileInfo(DirItem.FullName).LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                }

                Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ComponentsFolder);
                foreach (System.IO.FileInfo DirItem in Dir.GetFiles("*.dll"))
                {
                    Texto.AppendLine(DirItem.Name + " versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(DirItem.FullName).ProductVersion + " del " + new System.IO.FileInfo(DirItem.FullName).LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                }

                Texto.AppendLine("Traza:");
                Texto.AppendLine(ex.StackTrace);

                MailMessage Mensaje = new MailMessage();
                Mensaje.To.Add(new MailAddress("leoilla777@gmail.com"));
                Mensaje.From = new MailAddress(Lbl.Sys.Config.Empresa.Email, Lbl.Sys.Config.Actual.UsuarioConectado.Nombre + " en " + Lbl.Sys.Config.Empresa.Nombre);
                try
                {
                    //No sé por qué, pero una vez dió un error al poner el asunto
                    Mensaje.Subject = ex.Message;
                }
                catch
                {
                    Mensaje.Subject = "Excepción no controlada";
                    Texto.Insert(0, ex.Message + System.Environment.NewLine);
                }

                Mensaje.Body = Texto.ToString();

                SmtpClient Cliente = new SmtpClient("smtp.gmail.com", 587);
                Cliente.EnableSsl = true;
                Cliente.Credentials = new System.Net.NetworkCredential("leonardoillanez@alumnos.materiabiz.com", "donjuan2e");
                Cliente.Send(Mensaje);
            }
            catch (Exception error)
            {
                Log.Fatal(error);
            }
        }
    }
}