using Lazaro.Orm;
using Lazaro.Orm.Data;
using Lazaro.Orm.Data.Drivers;
using Lazaro.Orm.Mapping;
using Lfx.Data;
using Lfx.DependencyInjection;
using log4net;
using qGen;
using System;
using System.Collections.Generic;

namespace Lfx
{
        /// <summary>
        /// Proporciona un espacio de trabajo que incluye acceso a los datos y a la configuración.
        /// </summary>
        public class Workspace : System.MarshalByRefObject, IDisposable, IConnectionFactory, IContainer
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(Workspace));

                public static Lfx.Workspace Master = null;
                private Lfx.Data.IConnection m_MasterConnection = null;
                public Data.Structure Structure = new Data.Structure();

                public const int VersionUltima = 25;
                public System.Globalization.CultureInfo CultureInfo = new System.Globalization.CultureInfo("es-ar");

                private string m_Name;

                public Lfx.Config.ConfigManager CurrentConfig;
                public Services.Scheduler DefaultScheduler;
                public RunTimeServices RunTime;
                public int ConnectionCount = 0;
                public bool DebugMode { get; set; }
                public bool WebAppMode { get; set; }
                public List<Data.Connection> ActiveConnections = new List<Data.Connection>();
                public string ServerVersion { get; set; }
                public object MainForm { get; set; }

                public IDriver Driver { get; set; }
                public IFormatter Formatter { get; set; }
                public ConnectionParameters ConnectionParameters { get; set; }
                public AnnotationMetadataFactory MetadataFactory { get; set; }

                private TableCollection m_Tables = null;

                public Workspace()
                        : this("default")
                {
                }

                public Workspace(string workspaceName)
                        : this(workspaceName, true, false)
                {
                }


                public Workspace(string workspaceName, bool openConnection, bool webAppMode)
                {
                        if (Lfx.Workspace.Master == null)
                                Lfx.Workspace.Master = this;

                        this.WebAppMode = webAppMode;
                        m_Name = workspaceName;

                        this.CurrentConfig = new Lfx.Config.ConfigManager();

                        if (this.WebAppMode == false) {
                                this.DefaultScheduler = new Lfx.Services.Scheduler(this);
                                this.RunTime = new Lfx.RunTimeServices();
                        }

                        this.Bootstrap();

                        if (openConnection) {
                                m_MasterConnection.Open();
                        }

                        // Personalizo los valores de CultureInfo
                        this.CultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
                        this.CultureInfo.NumberFormat.CurrencyDecimalDigits = 2;
                        this.CultureInfo.NumberFormat.CurrencyGroupSeparator = "";
                        this.CultureInfo.NumberFormat.CurrencySymbol = "$";

                        this.CultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                        this.CultureInfo.NumberFormat.NumberGroupSeparator = "";

                        this.CultureInfo.DateTimeFormat.FullDateTimePattern = Lfx.Types.Formatting.DateTime.FullDateTimePattern;
                        this.CultureInfo.DateTimeFormat.LongDatePattern = Lfx.Types.Formatting.DateTime.LongDatePattern;
                        this.CultureInfo.DateTimeFormat.ShortDatePattern = Lfx.Types.Formatting.DateTime.ShortDatePattern;
                        this.CultureInfo.DateTimeFormat.ShortTimePattern = "HH:mm";
                        this.CultureInfo.DateTimeFormat.LongTimePattern = "HH:mm:ss";

                        System.Threading.Thread.CurrentThread.CurrentCulture = this.CultureInfo;
                        System.Threading.Thread.CurrentThread.CurrentUICulture = this.CultureInfo;

                        this.MetadataFactory = new Lazaro.Orm.Mapping.AnnotationMetadataFactory();
                        this.MetadataFactory.ScanFolder(System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location), true);
                }


                protected void Bootstrap()
                {
                        if (Lfx.Data.DatabaseCache.DefaultCache == null)
                                Lfx.Data.DatabaseCache.DefaultCache = new Lfx.Data.DatabaseCache(m_MasterConnection);

                        if (this.MasterConnection == null) {
                                switch (this.CurrentConfig.ReadLocalSettingString(@"Data", "ConnectionType", "mysql")) {
                                        case "odbc":
                                                Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.Odbc;
                                                break;

                                        case "myodbc":
                                        case "mysql":
                                                Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.MySql;
                                                break;

                                        case "npgsql":
                                                Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.Npgsql;
                                                break;

                                        case "mssql":
                                                Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.MSSql;
                                                break;

                                        case "sqlite":
                                                Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.SQLite;
                                                break;
                                }
                        }

                        if (this.ConnectionParameters == null) {

                                string pass = Encrypt.EncryptString("donjuan2e2", "donjuan3e3"); 
                                pass = this.CurrentConfig.ReadLocalSettingString("Data", "Password", string.Empty);
                                if (pass != String.Empty)
                                    pass = Encrypt.DecryptString(pass, "donjuan3e3");

                                this.ConnectionParameters = new ConnectionParameters()
                                {
                                        ServerName = this.CurrentConfig.ReadLocalSettingString("Data", "DataSource", "localhost"),
                                        DatabaseName = this.CurrentConfig.ReadLocalSettingString("Data", "DatabaseName", "excelencia"),
                                        UserName = this.CurrentConfig.ReadLocalSettingString("Data", "User", "root"),
                                        Password = pass
                                };
                                //Lfx.Data.DatabaseCache.DefaultCache.ServerName = this.CurrentConfig.ReadLocalSettingString("Data", "DataSource", "localhost");
                                //Lfx.Data.DatabaseCache.DefaultCache.DatabaseName = this.CurrentConfig.ReadLocalSettingString("Data", "DatabaseName", "lazaro");
                                //Lfx.Data.DatabaseCache.DefaultCache.UserName = this.CurrentConfig.ReadLocalSettingString("Data", "User", "lazaro");
                                //Lfx.Data.DatabaseCache.DefaultCache.Password = this.CurrentConfig.ReadLocalSettingString("Data", "Password", string.Empty);
                                //Lfx.Data.DatabaseCache.DefaultCache.Pooling = this.CurrentConfig.ReadLocalSettingInt("Data", "Pooling", 1) != 0;
                        }

                        var IpLocal1 = new System.Text.RegularExpressions.Regex(@"^192\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
                        var IpLocal2 = new System.Text.RegularExpressions.Regex(@"^10\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
                        if (Lfx.Workspace.Master.ConnectionParameters.ServerName.Contains(".") == false || IpLocal1.IsMatch(Lfx.Workspace.Master.ConnectionParameters.ServerName) || IpLocal2.IsMatch(Lfx.Workspace.Master.ConnectionParameters.ServerName)) {
                                Lfx.Data.DatabaseCache.DefaultCache.SlowLink = false;
                        } else {
                                Lfx.Data.DatabaseCache.DefaultCache.SlowLink = true;
                        }

                        if (m_MasterConnection == null) {
                                m_MasterConnection = this.GetNewConnection(this.Name) as Lfx.Data.IConnection;
                                m_MasterConnection.RequiresTransaction = false;
                                Lfx.Data.DatabaseCache.DefaultCache.Connection = m_MasterConnection;
                        }
                }


                public TableCollection Tables
                {
                        get
                        {
                                if (m_Tables == null) {
                                        m_Tables = Lfx.Workspace.Master.MasterConnection.GetTables();
                                }
                                return m_Tables;
                        }
                }


                public string Name
                {
                        get
                        {
                                return m_Name;
                        }
                }

                public override string ToString()
                {
                        return this.Name;
                }

                public Lfx.Data.IConnection MasterConnection
                {
                        get
                        {
                                return m_MasterConnection;
                        }
                }

                public bool Disposing = false;
                public void Dispose()
                {
                        this.Disposing = true;

                        if (this.CurrentConfig != null)
                                this.CurrentConfig.Dispose();

                        if (this.DefaultScheduler != null)
                                this.DefaultScheduler.Dispose();

                        // Tengo que clonar this.ActiveConnections porque .Dispose() va a modificar la lista mientras la estoy recorriendo
                        var Dbs = new List<Data.Connection>();
                        Dbs.AddRange(this.ActiveConnections);

                        foreach (Lfx.Data.Connection Db in Dbs) {
                                Db.Dispose();
                        }

                        m_MasterConnection.Dispose();

                        this.ActiveConnections.Clear();

                        GC.SuppressFinalize(this);
                }

                public EntityManager GetEntityManager()
                {
                        return this.GetEntityManager(null);
                }

                public EntityManager GetEntityManager(string ownerName)
                {
                        var Res = new EntityManager(this.GetNewConnection(ownerName), this.MetadataFactory);

                        return Res;
                }


                public Lazaro.Orm.Data.IConnection GetNewConnection(string ownerName)
                {
                        var Res = new Lfx.Data.Connection(this, ownerName);

                        switch (Lfx.Data.DatabaseCache.DefaultCache.AccessMode) {
                                case AccessModes.MySql:
                                        if (this.Driver == null) {
                                                this.Driver = new Lazaro.Orm.Data.Drivers.MySqlDriver();
                                                this.Formatter = new qGen.SqlFormatter();
                                                Lfx.Data.DatabaseCache.DefaultCache.OdbcDriver = null;
                                                Lfx.Data.DatabaseCache.DefaultCache.Mars = false;
                                                Lfx.Data.DatabaseCache.DefaultCache.SqlMode = qGen.SqlModes.MySql;
                                        }
                                        break;
                                case AccessModes.Npgsql:
                                        throw new NotImplementedException("Soporte PostgreSQL no implementado");
                                case AccessModes.MSSql:
                                        throw new NotImplementedException("Soporte SQL Server no implementado");
                                case AccessModes.Odbc:
                                        throw new NotImplementedException("Soporte ODBC no implementado");
                        }

                        this.ActiveConnections.Add(Res);

                        return Res;
                }


                public bool SlowLink
                {
                        get
                        {
                                return Lfx.Data.DatabaseCache.DefaultCache.SlowLink;
                        }
                }


                /// <summary>
                /// Notifica sobre un cambio de una tabla de datos
                /// </summary>
                /// <param name="table">Tabla en la cual se produjo un cambio</param>
                /// <param name="id">id del objeto cambiado</param>
                public void NotifyTableChange(string table, int id)
                {
                        //TODO: podría directamente modificar el caché en memoria, si quien notifica el cambio me pasara una copia del nuevo registro
                        //(p. ej. Lbl.ElementoDeDatos puede hacerlo). Por el momento voy a lo seguro y elimino del caché.
                        Lfx.Data.DatabaseCache.DefaultCache.Tables[table].FastRows.RemoveFromCache(id);
                }


                /// <summary>
                /// Devuelve Verdadero si la base de datos está lista para ser utilizaza.
                /// Si devuelve Falso, significa que el servidor debe prepararse antes (con Prepare)
                /// </summary>
                /// <returns></returns>
                public bool IsPrepared()
                {
                        try {
                                return Lfx.Workspace.Master.MasterConnection.FieldInt("SELECT id_tipo_doc FROM tipo_doc WHERE id_tipo_doc=1") == 1;
                        } catch {
                                return false;
                        }
                }

                /// <summary>
                /// Prepara un servidor para ser utilizado por Lázaro. Crea estructuras y realiza una carga inicial de datos.
                /// </summary>
                /// <param name="progreso">El objeto OperationProgress donde notificar el progreso</param>
                public Lfx.Types.OperationResult Prepare(Lfx.Types.OperationProgress progreso)
                {
                        bool MiProgreso = false;
                        if (progreso == null) {
                                progreso = new Types.OperationProgress("Preparando el almacén de datos", "Se están creando las tablas de datos y se va realizar una carga inicial de datos. Esta operación puede demorar varios minutos.")
                                {
                                        Modal = true
                                };
                                progreso.Begin();
                                MiProgreso = true;
                        }

                        // Creación de tablas
                        progreso.ChangeStatus("Creando estructuras");
                        this.CheckAndUpdateDatabaseStructure(this.MasterConnection, true, progreso);

                        this.MasterConnection.EnableConstraints(false);

                        string Sql = "";
                        using (System.IO.Stream RecursoSql = ObtenerRecurso(@"Data.Struct.dbdata.sql")) {
                                using (System.IO.StreamReader Lector = new System.IO.StreamReader(RecursoSql, System.Text.Encoding.UTF8)) {
                                        // Carga inicial de datos
                                        Sql = this.MasterConnection.CustomizeSql(Lector.ReadToEnd());
                                        Lector.Close();
                                        RecursoSql.Close();
                                }
                        }

                        // Si hay archivos adicionales de datos para la carga inicial, los incluyo
                        // Estos suelen tener datos personalizados de esta instalación en partícular
                        if (System.IO.File.Exists(Lfx.Environment.Folders.ApplicationFolder + "default.alf")) {
                                using (System.IO.StreamReader Lector = new System.IO.StreamReader(Lfx.Environment.Folders.ApplicationFolder + "default.alf", System.Text.Encoding.UTF8)) {
                                        Sql += Lfx.Types.ControlChars.CrLf;
                                        Sql += this.MasterConnection.CustomizeSql(Lector.ReadToEnd());
                                        Lector.Close();
                                }
                        }

                        progreso.ChangeStatus("Carga inicial de datos");
                        progreso.Max = Sql.Length;
                        //this.MasterConnection.ExecuteSql(Sql);
                        
                        do {
                                string Comando = Lfx.Data.Connection.GetNextCommand(ref Sql);
                                try {
                                        this.MasterConnection.ExecuteNonQuery(Comando);
                                } catch {
                                        // Hubo errores, pero continúo
                                }
                                progreso.ChangeStatus(progreso.Max - Sql.Length);
                        }
                        while (Sql.Length > 0);

                        progreso.ChangeStatus("Carga de TagList");
                        // Cargar TagList y volver a verificar la estructura
                        Lfx.Workspace.Master.Structure.TagList.Clear();
                        Lfx.Workspace.Master.Structure.LoadBuiltIn();

                        this.CheckAndUpdateDatabaseStructure(this.MasterConnection, false, progreso);

                        this.MasterConnection.EnableConstraints(true);
                        this.CurrentConfig.WriteGlobalSetting("Sistema.DB.Version", Lfx.Workspace.VersionUltima);

                        if (MiProgreso)
                                progreso.End();
                        return new Lfx.Types.SuccessOperationResult();
                }

                /// <summary>
                /// Obtiene un stream a un recurso.
                /// </summary>
                /// <param name="nombre">Nombre del recurso, incluyendo la ruta.</param>
                private static System.IO.Stream ObtenerRecurso(string nombre)
                {
                        return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Lfx." + nombre);
                }

                private static void InyectarSqlDesdeRecurso(Lfx.Data.IConnection dataBase, string archivo)
                {
                        dataBase.RequiresTransaction = false;
                        System.IO.Stream RecursoActualizacion = Lfx.Workspace.ObtenerRecurso(archivo);
                        if (RecursoActualizacion != null) {
                                System.IO.StreamReader Lector = new System.IO.StreamReader(RecursoActualizacion);
                                string SqlActualizacion = dataBase.CustomizeSql(Lector.ReadToEnd());
                                RecursoActualizacion.Close();
                                try {
                                        dataBase.ExecuteNonQuery(SqlActualizacion);
                                } catch {
                                        // Falló la ejecución... intento los comandos SQL de a uno, ignorando el que de un error
                                        do {
                                                string Comando = Data.Connection.GetNextCommand(ref SqlActualizacion);
                                                try {
                                                        dataBase.ExecuteNonQuery(Comando);
                                                } catch {
                                                        if (Lfx.Environment.SystemInformation.DesignMode)
                                                                throw;
                                                }
                                        }
                                        while (SqlActualizacion.Length > 0);
                                }
                        }
                }

                /// <summary>
                /// Verifica la estructura de la base de datos actual y si es necesario modifica para que esté conforme
                /// al diseño de referencia.
                /// </summary>
                /// <param name="connection">PrintDatabase mediante el cual se accede a la base de datos.</param>
                /// <param name="omitPreAndPostSql">Omitir la ejecución de comandos Pre- y Post-actualización de estructura. Esto es útil cuando se actualiza una estructura vacía, por ejemplo al crear una base de datos nueva.</param>
                /// /// <param name="progreso">El objeto sobre el cual reportar el progreso.</param>
                public void CheckAndUpdateDatabaseStructure(Lfx.Data.IConnection connection, bool omitPreAndPostSql, Lfx.Types.OperationProgress progreso)
                {
                        progreso.ChangeStatus("Verificando estructuras de datos");

                        bool MustEnableConstraints = false;
                        if (connection.ConstraintsEnabled) {
                                connection.EnableConstraints(false);
                                MustEnableConstraints = true;
                        }

                        if (omitPreAndPostSql == false) {
                                progreso.ChangeStatus("Ejecutando guión previo...");
                                InyectarSqlDesdeRecurso(connection, @"Data.Struct.db_upd_pre.sql");
                        }

                        //Primero borro claves foráneas (deleteOnly = true)
                        progreso.ChangeStatus("Eliminando reglas obsoletas...");
                        connection.SetConstraints(Lfx.Workspace.Master.Structure.Constraints, true);

                        try {
                                connection.ExecuteNonQuery("FLUSH TABLES");
                        } catch {
                                // No tengo permiso... no importa
                        }
                        progreso.Max = Lfx.Workspace.Master.Structure.Tables.Count;
                        foreach (Lfx.Data.TableStructure Tab in Lfx.Workspace.Master.Structure.Tables.Values) {
                                string TableLabel = Tab.Label;
                                if (Tab.Label == null)
                                        TableLabel = Tab.Name.ToTitleCase();
                                progreso.ChangeStatus(progreso.Value + 1, "Verificando " + TableLabel);
                                connection.SetTableStructure(Tab);
                        }

                        //Ahora creo claves nuevas (deleteOnly = false)
                        progreso.ChangeStatus("Estableciendo reglas de integridad");
                        try {
                                connection.ExecuteNonQuery("FLUSH TABLES");
                        } catch {
                                // No tengo permiso... no importa
                        }
                        connection.SetConstraints(Lfx.Workspace.Master.Structure.Constraints, false);

                        if (omitPreAndPostSql == false) {
                                progreso.ChangeStatus("Ejecutando guión posterior...");
                                InyectarSqlDesdeRecurso(connection, @"Data.Struct.db_upd_post.sql");
                        }

                        if (MustEnableConstraints)
                                connection.EnableConstraints(true);
                }
        }
}