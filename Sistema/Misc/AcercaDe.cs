using System;
using System.Windows.Forms;

namespace Lazaro.WinMain.Misc
{
	public partial class AcercaDe : Lui.Forms.Form
	{
                
                public AcercaDe()
                {
                        InitializeComponent();
                }


                private void FormAcercaDe_Load(object sender, System.EventArgs e)
                {
                        ListaComponentes.BackColor = this.BackColor;

                        EtiquetaUsuario.Text = Lbl.Sys.Config.Actual.UsuarioConectado.Id.ToString() + " (" + Lbl.Sys.Config.Actual.UsuarioConectado.Persona.Nombre + ") / " + System.Environment.MachineName;

                        ListaComponentes.Items.Add("Gestión777 versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(Lfx.Environment.Folders.ApplicationFolder + "Gestión777.exe").ProductVersion + " del " + new System.IO.FileInfo(Lfx.Environment.Folders.ApplicationFolder + "Gestión777.exe").LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                        System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ApplicationFolder);
                        foreach (System.IO.FileInfo DirItem in Dir.GetFiles("*.dll")) {
                                ListaComponentes.Items.Add(DirItem.Name + " versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(DirItem.FullName).ProductVersion + " del " + new System.IO.FileInfo(DirItem.FullName).LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                        }

                        Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ComponentsFolder);
                        foreach (System.IO.FileInfo DirItem in Dir.GetFiles("*.dll", System.IO.SearchOption.AllDirectories)) {
                                ListaComponentes.Items.Add(DirItem.Name + " versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(DirItem.FullName).ProductVersion + " del " + new System.IO.FileInfo(DirItem.FullName).LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                        }

                        EtiquetaFramework.Text = Lfx.Environment.SystemInformation.RuntimeName;
                        if (System.Runtime.InteropServices.Marshal.SizeOf(typeof(System.IntPtr)) == 8)
                                EtiquetaFramework.Text += " (64 bits)";

                        EtiquetaAlmacen.Text = Lfx.Workspace.Master.ServerVersion;
                }

		private void OkButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

                private void BotonWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        Help.ShowHelp(this, "http://www.excelenciadigital.net/gestion777");
                }
        
	}
}