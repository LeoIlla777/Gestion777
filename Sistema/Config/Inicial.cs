using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Lazaro.WinMain.Config
{
        public partial class Inicial : Lui.Forms.Form
        {
                public enum Pasos
                {
                        Inicio,
                        PruebaServidor,
                        Password,
                        DatosEmpresa,
                        Final
                }

                private Pasos Paso = Pasos.Inicio;

                public Inicial()
                {
                        InitializeComponent();
                }


                protected override void OnFormClosing(FormClosingEventArgs e)
                {
                        base.OnFormClosing(e);
                }


                private void BotonSalir_Click(object sender, EventArgs e)
                {
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.Close();
                }

                private void MostrarPaneles()
                {
                        if (Paso == Pasos.Final)
                                BotonSiguiente.Text = "Finalizar";
                        else
                                BotonSiguiente.Text = "Siguiente";

                        BotonSiguiente.Enabled = true;
                        BotonAnterior.Enabled = Paso != Pasos.Inicio;

                        PanelPassword.Visible = Paso == Inicial.Pasos.Inicio;
                        PanelPruebaServidor.Visible = Paso == Inicial.Pasos.PruebaServidor;
                        PanelDatosEmpresa.Visible = Paso == Inicial.Pasos.DatosEmpresa;
                        PanelFinal.Visible = Paso == Inicial.Pasos.Final;
                }

                private void PanelPruebaServidor_VisibleChanged(object sender, EventArgs e)
                {
                        if (PanelPruebaServidor.Visible) {
                                // Probar la conexión al servidor
                                Lfx.Workspace.Master.ConnectionParameters.ServerName = "localhost";
                                Lfx.Workspace.Master.ConnectionParameters.UserName = "root";
                                Lfx.Workspace.Master.ConnectionParameters.Password = "";
                                Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.MySql;
                                Lfx.Data.DatabaseCache.DefaultCache.SlowLink = false;
                                Lfx.Workspace.Master.ConnectionParameters.DatabaseName = "";

                                Lfx.Types.OperationResult Res = this.ProbarServidor();
                                EtiquetaPruebaResultado.Text = Res.Message;
                                BotonSiguiente.Enabled = Res.Success;
                        }
                }


                private Lfx.Types.OperationResult ProbarServidor()
                {
                        try {
                                EtiquetaPruebaResultado.Text = "Probando la conexión...";
                                EtiquetaPruebaError.Text = "";
                                System.Windows.Forms.Application.DoEvents();

                                Lfx.Workspace.Master.MasterConnection.Open();

                                bool TengoDb = false;
                                try {
                                        Lfx.Workspace.Master.MasterConnection.ExecuteNonQuery("USE excelencia");
                                        TengoDb = true;
                                } catch {
                                        try {
                                                Lfx.Workspace.Master.MasterConnection.ExecuteNonQuery("CREATE DATABASE excelencia DEFAULT CHARACTER SET utf8");
                                                Lfx.Workspace.Master.MasterConnection.ExecuteNonQuery("USE excelencia");
                                                TengoDb = true;
                                        } catch {
                                                TengoDb = false;
                                        }
                                }

                                if (string.IsNullOrEmpty(Lfx.Workspace.Master.ConnectionParameters.DatabaseName))
                                        Lfx.Workspace.Master.ConnectionParameters.DatabaseName = "excelencia";
                                Lfx.Workspace.Master.MasterConnection.Close();
                                Lfx.Workspace.Master.MasterConnection.Open();
                                if (TengoDb) {
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "DataSource", Lfx.Workspace.Master.ConnectionParameters.ServerName);
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "ConnectionType", "mysql");
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "DatabaseName", Lfx.Workspace.Master.ConnectionParameters.DatabaseName);
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "User", Lfx.Workspace.Master.ConnectionParameters.UserName);
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "Password", Lfx.Workspace.Master.ConnectionParameters.Password);
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "SlowLink", Lfx.Data.DatabaseCache.DefaultCache.SlowLink ? "1" : "0");
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Company", "Branch", 1);

                                        try {
                                                Lfx.Workspace.Master.MasterConnection.ExecuteNonQuery("GRANT ALL ON excelencia.* TO 'excelencia'@'localhost' IDENTIFIED BY ''");
                                                Lfx.Workspace.Master.MasterConnection.ExecuteNonQuery("GRANT ALL ON excelencia.* TO 'excelencia'@'%' IDENTIFIED BY ''");
                                        } catch {
                                                // No pude crear el acceso para otros usuarios... supongo que no importa
                                        }
                                } else {
                                }
                                return new Lfx.Types.SuccessOperationResult("Se realizó una prueba de la configuración del almacén de datos. Todo parece estar en orden. Haga clic en 'Siguiente' para continuar.");
                        } catch (Exception ex) {
                                EtiquetaPruebaError.Text = "El mensaje de error es: " + ex.Message;
                                return new Lfx.Types.FailureOperationResult("No se pudo conectar al almacén de datos proporcionado. Haga clic en el botón 'Anterior' para ir a la pantalla anterior y volver a intentarlo.");
                        }
                }


                private void BotonSiguiente_Click(object sender, EventArgs e)
                {
                        switch (Paso) {
                                case Inicial.Pasos.Inicio:
                                        //Se Configura la base de datos.
                                        using (Config.ConfigurarBd ConfigBD = new Config.ConfigurarBd()) {
                                            this.Hide();
                                            if (ConfigBD.ShowDialog() == DialogResult.Cancel) {
                                                    this.Show();
                                            } else {
                                                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                                    this.Close();
                                                    Paso = Inicial.Pasos.PruebaServidor;
                                            }
                                        }
                                        break;
                                case Inicial.Pasos.Password:

                                        //Paso = Inicial.Pasos.Inicio;
                                        break;
                                case Inicial.Pasos.PruebaServidor:
                                        //Prueba si el servidor se encuentra bíen
                                        if (Lfx.Workspace.Master.MasterConnection.IsOpen() && Lfx.Workspace.Master.IsPrepared()) {
                                                int PaisActual = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Pais", 0);
                                                if (PaisActual == 0)
                                                        Paso = Pasos.DatosEmpresa;
                                                else
                                                        Paso = Pasos.Final;
                                        } else {
                                                Paso = Inicial.Pasos.Final;
                                        }
                                        break;
                                case Pasos.DatosEmpresa:
                                        //Si esta bíen el servidor y es primera vez se ingresa empresa.
                                        if (EntradaPais.Elemento == null || EntradaEmpresaNombre.Text.Length < 3 || EntradaEmpresaEmail.Text.Length < 3 || EntradaEmpresaEmail.Text.IndexOf('@') < 0) {
                                                Lui.Forms.MessageBox.Show("Por favor proporcione los datos de la empresa antes de continuar.", "Error");
                                        } else {
                                                Paso = Pasos.Final;
                                        }
                                        break;
                                case Inicial.Pasos.Final:
                                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                        this.Close();
                                        return;
                        }
                        this.MostrarPaneles();
                }

                private void BotonAnterior_Click(object sender, EventArgs e)
                {
                        BotonSiguiente.Visible = true;
                        Paso = Inicial.Pasos.Inicio;
                        this.MostrarPaneles();
                }

                private bool Inited = false;
                private void Inicial_Activated(object sender, EventArgs e)
                {
                        if (Inited == false) {
                                Inited = true;
                                this.MostrarPaneles();
                        }
                }

                private void EntradaPais_TextChanged(object sender, EventArgs e)
                {
                        Lbl.Entidades.Pais Pais = EntradaPais.Elemento as Lbl.Entidades.Pais;
                        if (Pais != null) {
                                if (Pais.ClavePersonasJuridicas != null)
                                        EtiquetaClaveTributaria.Text = Pais.ClavePersonasJuridicas.ToString();
                                else
                                        EtiquetaClaveTributaria.Text = "Clave tributaria";
                        } else {
                                EtiquetaClaveTributaria.Text = "Clave tributaria";
                        }
                }

        private void btnReintentar_Click(object sender, EventArgs e)
        {

        }

        private void btnNueva_Click(object sender, EventArgs e)
        {

        }

        private void PanelDatosEmpresa_VisibleChanged(object sender, EventArgs e)
                {
                        if (PanelDatosEmpresa.Visible) {
                                // Al aparecer
                                Lfx.Workspace.Master.CurrentConfig.ClearCache();
                                EntradaEmpresaNombre.Text = Lbl.Sys.Config.Empresa.Nombre;
                                int IdPais = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Pais", 0);
                                EntradaPais.ValueInt = IdPais;
                                if (Lbl.Sys.Config.Empresa.ClaveTributaria != null)
                                        EntradaEmpresaClaveTributaria.Text = Lbl.Sys.Config.Empresa.ClaveTributaria.Valor;
                                EntradaEmpresaEmail.Text = Lbl.Sys.Config.Empresa.Email;
                                EntradaEmpresaNombre.Focus();
                        } else {
                                // Al desaparecer
                                Lbl.Entidades.Pais Pais = EntradaPais.Elemento as Lbl.Entidades.Pais;
                                if (Pais != null)
                                        Lbl.Sys.Config.CambiarPais(Pais);
                                Lbl.Sys.Config.Empresa.Nombre = EntradaEmpresaNombre.Text;
                                if (EntradaEmpresaClaveTributaria.Text.Length > 0)
                                        Lbl.Sys.Config.Empresa.ClaveTributaria = new Lbl.Personas.Claves.Cuit(EntradaEmpresaClaveTributaria.Text);
                                else
                                        Lbl.Sys.Config.Empresa.ClaveTributaria = null;
                                Lbl.Sys.Config.Empresa.Email = EntradaEmpresaEmail.Text;
                        }
                }
        }
}