using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

namespace Lfx.Config
{
        /// <summary>
        /// Maneja los parámetros de configuración
        /// </summary>
        public class ConfigManager : IDisposable
        {
                private string m_ConfigFileName;
                private System.Xml.XmlDocument ConfigDocument;
                private Lfx.Data.IConnection m_Connection;

                public Lfx.Config.ProductsConfig Productos;
                public Lfx.Config.CurrencyConfig Moneda;
                public Lfx.Config.CompanyConfig Empresa;

                private Dictionary<string, string> SysConfigCache = null;
                private System.DateTime SysConfigCacheLastRefresh;

                public ConfigManager()
                {
                        ConfigFileName = Lfx.Workspace.Master.Name + ".lwf";

                        Productos = new Lfx.Config.ProductsConfig(this);
                        Moneda = new Lfx.Config.CurrencyConfig(this);
                        Empresa = new Lfx.Config.CompanyConfig(this);
                }

                public void Dispose()
                {
                        if (m_Connection != null)
                                m_Connection.Dispose();
                        GC.SuppressFinalize(this);
                }

                public string ConfigFileName
                {
                        get
                        {
                                return m_ConfigFileName;
                        }
                        set
                        {
                                m_ConfigFileName = value;

                                if (!System.IO.Path.IsPathRooted(m_ConfigFileName)) {
                                        // Si no tiene ruta, busco en la carpeta de datos
                                        // o junto al ejecutable (para aplicaciones portables)
                                        if (System.IO.File.Exists(Lfx.Environment.Folders.ApplicationFolder + m_ConfigFileName)) {
                                                m_ConfigFileName = Lfx.Environment.Folders.ApplicationFolder + m_ConfigFileName;
                                        } else {
                                                m_ConfigFileName = Lfx.Environment.Folders.ApplicationDataFolder + m_ConfigFileName;
                                        }
                                }
                        }
                }

                public Lfx.Data.IConnection Connection
                {
                        get
                        {
                                if (m_Connection == null) {
                                        m_Connection = Lfx.Workspace.Master.GetNewConnection("Administrador de configuración") as Lfx.Data.IConnection;
                                        m_Connection.RequiresTransaction = false;
                                        m_Connection.Open();
                                }
                                return m_Connection;
                        }
                }

                public void ClearCache()
                {
                        SysConfigCache = null;
                }


                public void WriteLocalSetting(string sectionName, string settingName, int settingValue)
                {
                        WriteLocalSetting(sectionName, settingName, settingValue.ToString());
                }


                public void WriteLocalSetting(string sectionName, string settingName, string settingValue)
                {
                        string sectionNameValid = RemoveInvalidXmlChars(sectionName);
                        string settingNameValid = RemoveInvalidXmlChars(settingName);
                        if (ConfigDocument == null) {
                                ConfigDocument = new System.Xml.XmlDocument();
                                if (System.IO.File.Exists(ConfigFileName))
                                        ConfigDocument.Load(ConfigFileName);
                                else
                                        ConfigDocument.AppendChild(ConfigDocument.CreateElement("LocalConfig"));
                        }

                        lock (ConfigDocument) {
                                if(ConfigDocument.DocumentElement == null) {
                                        ConfigDocument.LoadXml("<?xml version='1.0' ?><LocalConfig></LocalConfig>");
                                }

                                System.Xml.XmlAttribute Attribute;
                                System.Xml.XmlNode SectionNode = ConfigDocument.SelectSingleNode("/LocalConfig/Section[@name='" + sectionNameValid + "']");
                                if (SectionNode == null) {
                                        //Crear la sección
                                        SectionNode = ConfigDocument.CreateElement("Section");
                                        Attribute = ConfigDocument.CreateAttribute("name");
                                        Attribute.Value = sectionNameValid;
                                        SectionNode.Attributes.Append(Attribute);
                                        ConfigDocument.DocumentElement.AppendChild(SectionNode);
                                }
                                System.Xml.XmlNode SettingNode = ConfigDocument.SelectSingleNode("/LocalConfig/Section[@name='" + sectionNameValid + "']/Setting[@name='" + settingNameValid + "']");
                                if (SettingNode == null) {
                                        //Agregar el nodo
                                        SettingNode = ConfigDocument.CreateElement("Setting");
                                        Attribute = ConfigDocument.CreateAttribute("name");
                                        Attribute.Value = settingNameValid;
                                        SettingNode.Attributes.Append(Attribute);
                                        Attribute = ConfigDocument.CreateAttribute("value");
                                        Attribute.Value = settingValue;
                                        SettingNode.Attributes.Append(Attribute);
                                        SectionNode.AppendChild(SettingNode);
                                }
                                System.Xml.XmlAttribute SettingAttribute = SettingNode.Attributes["value"];
                                if (SettingAttribute != null) {
                                        SettingAttribute.Value = settingValue;
                                }
                                ConfigDocument.Save(ConfigFileName);
                        }
                }


                public int ReadLocalSettingInt(string sectionName, string settingName, int defaultValue)
                {
                        return Lfx.Types.Parsing.ParseInt(ReadLocalSettingString(sectionName, settingName, defaultValue.ToString()));
                }


                public string ReadLocalSettingString(string sectionName, string settingName, string defaultValue)
                {
                        string sectionNameValid = RemoveInvalidXmlChars(sectionName);
                        string settingNameValid = RemoveInvalidXmlChars(settingName);

                        string Result = defaultValue;
                        if (System.IO.File.Exists(ConfigFileName)) {
                                //Intento obtener el valor del archivo de configuración Xml
                                if (ConfigDocument == null) {
                                        ConfigDocument = new System.Xml.XmlDocument();
                                        try {
                                                ConfigDocument.Load(ConfigFileName);
                                        }
                                        catch {
                                                // El archivo de configuración está vacío o dañado
                                                return null;
                                        }
                                }

                                System.Xml.XmlNode SettingNode = ConfigDocument.SelectSingleNode("/LocalConfig/Section[@name='" + sectionNameValid + "']/Setting[@name='" + settingNameValid + "']");
                                if (SettingNode != null) {
                                        System.Xml.XmlAttribute SettingAttribute = SettingNode.Attributes["value"];
                                        if (SettingAttribute != null)
                                                Result = SettingAttribute.Value;
                                }

                        }
                        return Result;
                }


                public T ReadGlobalSetting<T>(string settingName, T defaultValue)
                {
                        return this.ReadGlobalSetting<T>(settingName, defaultValue, null, 0);
                }


                public T ReadGlobalSetting<T>(string settingName, T defaultValue, string terminalName, int sucursal)
                {
                        string Val = ReadGlobalSettingString(settingName, null, terminalName, sucursal);
                        if (Val == null)
                                return defaultValue;

                        object Res;
                        if (typeof(T) == typeof(string)) {
                                Res = Val;
                        } else if (typeof(T) == typeof(int)) {
                                Res = Lfx.Types.Parsing.ParseInt(Val);
                        } else if (typeof(T) == typeof(decimal)) {
                                Res = Lfx.Types.Parsing.ParseDecimal(Val);
                        } else if (typeof(T) == typeof(DateTime)) {
                                Res = Lfx.Types.Parsing.ParseSqlDateTime(Val);
                        } else if (typeof(T) == typeof(DbDateTime)) {
                                if (string.IsNullOrWhiteSpace(Val)) {
                                        Res = null;
                                } else {
                                        Res = new DbDateTime(Lfx.Types.Parsing.ParseSqlDateTime(Val));
                                }
                        } else {
                                Res = null;
                        }

                        return (T)Res;
                }

                private string ReadGlobalSettingString(string settingName, string defaultValue, string terminalName, int sucursal)
                {
                        //Si el caché es muy viejo, lo vacío
                        if (SysConfigCache != null && System.DateTime.Now > SysConfigCacheLastRefresh.AddMinutes(10)) {
                                this.ClearCache();
                        }

                        if (SysConfigCache == null) {
                                SysConfigCache = new Dictionary<string, string>();

                                qGen.Select SelectConfig = new qGen.Select("sys_config");
                                SelectConfig.Columns = new qGen.SqlIdentifierCollection() { "nombre", "valor", "estacion", "id_sucursal" };
                                System.Data.DataTable TablaSysConfig = null;
                                int Intentos = 3;
                                while (true) {
                                        try {
                                                TablaSysConfig = this.Connection.Select(SelectConfig);
                                                break;
                                        }
                                        catch (Exception ex) {
                                                Intentos--;
                                                System.Threading.Thread.Sleep(1000);
                                                if (Intentos <= 0)
                                                        throw ex;
                                        }
                                }

                                foreach (System.Data.DataRow CfgRow in TablaSysConfig.Rows) {
                                        string Sucu;
                                        if (CfgRow["id_sucursal"] == null)
                                                Sucu = "0";
                                        else
                                                Sucu = CfgRow["id_sucursal"].ToString();
                                        string VarName = CfgRow["estacion"].ToString() + "/" + Sucu + "/" + CfgRow["nombre"].ToString();
                                        SysConfigCache.Add(VarName, CfgRow["valor"].ToString());
                                }
                                SysConfigCacheLastRefresh = System.DateTime.Now;
                        }

                        string Busco;

                        //Busco una variable para la estación y la sucursal
                        Busco = (terminalName == null ? Lfx.Environment.SystemInformation.MachineName : terminalName) + "/" + sucursal.ToString() + "/" + settingName;
                        if (sucursal != 0 && SysConfigCache.ContainsKey(Busco)) {
                                string Res = (string)SysConfigCache[Busco];
                                return Res;
                        }

                        //Busco una variable para la estación
                        Busco = (terminalName == null ? Lfx.Environment.SystemInformation.MachineName : terminalName) + "/0/" + settingName;
                        if (sucursal == 0 && SysConfigCache.ContainsKey(Busco)) {
                                string Res = (string)SysConfigCache[Busco];
                                return Res;
                        }

                        //Busco una variable para la sucursal
                        Busco = "*/" + Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual.ToString() + "/" + Connection.EscapeString(settingName);
                        if (terminalName == null && SysConfigCache.ContainsKey(Busco)) {
                                string Res = (string)SysConfigCache[Busco];
                                return Res;
                        }

                        if (sucursal == 0 && terminalName == null) {
                                //Busco una variable global
                                Busco = "*/0/" + Connection.EscapeString(settingName);
                                if (SysConfigCache.ContainsKey(Busco)) {
                                        string Res = (string)SysConfigCache[Busco];
                                        return Res;
                                }
                        }

                        return defaultValue;
                }

                public bool DeleteGlobalSetting(string settingName, int branch)
                {
                        if (branch == 0)
                                branch = Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual;

                        qGen.Delete DeleteCommand = new qGen.Delete("sys_config");
                        DeleteCommand.WhereClause = new qGen.Where(qGen.AndOr.And);
                        DeleteCommand.WhereClause.Add(new qGen.ComparisonCondition("nombre", settingName));
                        DeleteCommand.WhereClause.Add(new qGen.ComparisonCondition("id_sucursal", branch));
                        Connection.Delete(DeleteCommand);

                        string CacheSettingName = "*/" + branch.ToString() + "/" + settingName;

                        if (this.SysConfigCache.ContainsKey(CacheSettingName))
                                this.SysConfigCache.Remove(CacheSettingName);
                        return true;
                }

                public bool DeleteGlobalSetting(string settingName, string terminalName)
                {
                        if (terminalName == null || terminalName.Length == 0)
                                terminalName = Lfx.Environment.SystemInformation.MachineName;

                        qGen.Delete DeleteCommand = new qGen.Delete("sys_config");
                        DeleteCommand.WhereClause = new qGen.Where();
                        DeleteCommand.WhereClause.Operator = qGen.AndOr.And;
                        DeleteCommand.WhereClause.Add(new qGen.ComparisonCondition("nombre", settingName));
                        DeleteCommand.WhereClause.Add(new qGen.ComparisonCondition("estacion", terminalName));
                        Connection.Delete(DeleteCommand);

                        string CacheSettingName = terminalName + "/0/" + settingName;

                        if (this.SysConfigCache.ContainsKey(CacheSettingName))
                                this.SysConfigCache.Remove(CacheSettingName);
                        return true;
                }


                public bool WriteGlobalSetting(string settingName, int intValue)
                {
                        return WriteGlobalSetting(settingName, intValue.ToString());
                }

                public bool WriteGlobalSetting(string settingName, DbDateTime dateTimeValue)
                {
                        if (dateTimeValue == null) {
                                return WriteGlobalSetting(settingName, "");
                        } else {
                                return WriteGlobalSetting(settingName, Lfx.Types.Formatting.FormatDateTimeSql(dateTimeValue));
                        }
                }

                public bool WriteGlobalSetting(string settingName, decimal decimalValue)
                {
                        return WriteGlobalSetting(settingName, Lfx.Types.Formatting.FormatNumber(decimalValue, 8));
                }


                public bool WriteGlobalSetting(string settingName, string stringValue)
                {
                        return WriteGlobalSetting(settingName, stringValue, "*");
                }

                public bool WriteGlobalSetting(string settingName, string stringValue, int branch)
                {
                        string CurrentValue = ReadGlobalSetting<string>(settingName, null, null, branch);
                        if (CurrentValue == null) {
                                //Crear el valor
                                qGen.Insert InsertCommand = new qGen.Insert("sys_config");
                                InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("id_sucursal", Lazaro.Orm.ColumnTypes.Integer, branch));
                                InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("estacion", Lazaro.Orm.ColumnTypes.VarChar, "*"));
                                InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("nombre", Lazaro.Orm.ColumnTypes.VarChar, settingName));
                                InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("valor", Lazaro.Orm.ColumnTypes.VarChar, stringValue));
                                Connection.Insert(InsertCommand);
                        } else {
                                //Actualizar el valor
                                qGen.Update UpdateCommand = new qGen.Update("sys_config");
                                UpdateCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("valor", Lazaro.Orm.ColumnTypes.VarChar, stringValue));
                                UpdateCommand.WhereClause = new qGen.Where();
                                UpdateCommand.WhereClause.Operator = qGen.AndOr.And;
                                UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("nombre", settingName));
                                UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("id_sucursal", branch));
                                Connection.Update(UpdateCommand);
                        }

                        string CacheSettingName = "*/" + branch.ToString() + "/" + settingName;

                        if (this.SysConfigCache.ContainsKey(CacheSettingName))
                                this.SysConfigCache[CacheSettingName] = stringValue;
                        else
                                this.SysConfigCache.Add(CacheSettingName, stringValue);

                        return true;
                }

                public bool WriteGlobalSetting(string settingName, string stringValue, string terminalName)
                {
                        if (terminalName == null || terminalName.Length == 0)
                                terminalName = Lfx.Environment.SystemInformation.MachineName;

                        string CurrentValue = ReadGlobalSetting<string>(settingName, null, terminalName, 0);
                        if (CurrentValue == null) {
                                //Crear el valor
                                qGen.Insert InsertCommand = new qGen.Insert("sys_config");
                                InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("estacion", Lazaro.Orm.ColumnTypes.VarChar, terminalName));
                                InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("nombre", Lazaro.Orm.ColumnTypes.VarChar, settingName));
                                InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("valor", Lazaro.Orm.ColumnTypes.VarChar, stringValue));
                                Connection.Insert(InsertCommand);
                        } else {
                                //Actualizar el valor
                                qGen.Update UpdateCommand = new qGen.Update("sys_config");
                                UpdateCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("valor", Lazaro.Orm.ColumnTypes.VarChar, stringValue));
                                UpdateCommand.WhereClause = new qGen.Where();
                                UpdateCommand.WhereClause.Operator = qGen.AndOr.And;
                                UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("nombre", settingName));
                                UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("estacion", terminalName));
                                Connection.Update(UpdateCommand);
                        }

                        string CacheSettingName = terminalName + "/0/" + settingName;

                        if (this.SysConfigCache.ContainsKey(CacheSettingName))
                                this.SysConfigCache[CacheSettingName] = stringValue;
                        else
                                this.SysConfigCache.Add(CacheSettingName, stringValue);

                        return true;
                }

                public bool WriteGlobalSetting(string settingName, string stringValue, string terminalName, int sucursal)
                {
                    if (terminalName == null || terminalName.Length == 0)
                        terminalName = Lfx.Environment.SystemInformation.MachineName;

                    string CurrentValue = ReadGlobalSetting<string>(settingName, null, terminalName, sucursal);
                    if (CurrentValue == null)
                    {
                        //Crear el valor
                        qGen.Insert InsertCommand = new qGen.Insert("sys_config");
                        InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("estacion", Lazaro.Orm.ColumnTypes.VarChar, terminalName));
                        InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("id_sucursal", Lazaro.Orm.ColumnTypes.Integer, sucursal));
                        InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("nombre", Lazaro.Orm.ColumnTypes.VarChar, settingName));
                        InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("valor", Lazaro.Orm.ColumnTypes.VarChar, stringValue));
                        Connection.Insert(InsertCommand);
                    }
                    else
                    {
                        //Actualizar el valor
                        qGen.Update UpdateCommand = new qGen.Update("sys_config");
                        UpdateCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("valor", Lazaro.Orm.ColumnTypes.VarChar, stringValue));
                        UpdateCommand.WhereClause = new qGen.Where();
                        UpdateCommand.WhereClause.Operator = qGen.AndOr.And;
                        UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("nombre", settingName));
                        UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("estacion", terminalName));
                        UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("id_sucursal", sucursal));
                        Connection.Update(UpdateCommand);
                    }

                    string CacheSettingName = terminalName + "/" + sucursal.ToString() + "/" + settingName;

                    if (this.SysConfigCache.ContainsKey(CacheSettingName))
                        this.SysConfigCache[CacheSettingName] = stringValue;
                    else
                        this.SysConfigCache.Add(CacheSettingName, stringValue);

                    return true;
                }

                public void InvalidateConfigCache()
                {
                        SysConfigCache = null;
                }

                static string RemoveInvalidXmlChars(string text)
                {
                        var validXmlChars = text.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray();
                        return new string(validXmlChars);
                }
        }
}