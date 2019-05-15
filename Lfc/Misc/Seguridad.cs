using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Misc
{
    public partial class Seguridad : Lui.Forms.DialogForm
    {
        public Seguridad()
        {
            if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Personas.Persona), Lbl.Sys.Permisos.Operaciones.Administrar) == false)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
                return;
            }

            InitializeComponent();
        }

        public override Lfx.Types.OperationResult Ok()
        {


            return base.Ok();
        }

        private void EntradaElementoOriginal_TextChanged(object sender, EventArgs e)
        {

        }

        private void EntradaElementoDuplicado_TextChanged(object sender, EventArgs e)
        {

        }

        private void EntradaCtaCte1CtaCte2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
