#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;
using System.Security.Permissions;

#endregion

[assembly: AssemblyTitle("Gestión777")]
[assembly: AssemblyVersion("2.0.*")]
[assembly: AssemblyDescription("Sistema de gestión comercial Gestión777")]
[assembly: AssemblyCompany("Excelencia Soluciones Informáticas S.R.L.")]
[assembly: AssemblyProduct("Gestión777")]
[assembly: AssemblyCopyright("Copyright 2020 ")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: CLSCompliant(true)]

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]