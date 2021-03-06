using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lazaro.WinMain.Errores
{
    public partial class ExcepcionNoControlada : Lui.Forms.Form
    {
        public string ErrorMsg {
            get {
                return lblError.Text;
            }
            set {
                lblError.Text = value;
            }
        }
        public ExcepcionNoControlada()
        {
            this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
            InitializeComponent();
        }

        private void BotonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
