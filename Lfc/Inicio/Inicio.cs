using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Inicio
{
    public partial class Inicio : Lui.Forms.ChildForm
    {
        public Inicio()
        {
            InitializeComponent();
            this.StockImage = "inicio";

            if (string.Compare(Lfx.Workspace.Master.ConnectionParameters.ServerName, "localhost", true) == 0 || string.Compare(Lfx.Workspace.Master.ConnectionParameters.ServerName, "127.0.0.1") == 0)
            {
                if (Lfx.Workspace.Master.MasterConnection.ServerVersion.Contains("MariaDB") == false || Lfx.Workspace.Master.MasterConnection.ServerVersion.StartsWith("5.")
                        || Lfx.Workspace.Master.MasterConnection.ServerVersion.StartsWith("10.0") || Lfx.Workspace.Master.MasterConnection.ServerVersion.StartsWith("10.1"))
                {
                    // Si estoy usando MySQL o MariaDB < 10.2, le sugiero actualizar a MariaDB 10.2
                    //PanelActualizarAlmacen.Visible = true;
                }
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
            base.OnFormClosing(e);
        }
    }
}