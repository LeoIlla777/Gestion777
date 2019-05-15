using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Inicio
{
    public partial class ControlCompras : ControlTablero
    {
        public ControlCompras()
        {
            InitializeComponent();
        }

        private void BotonCrearRecibo_Click(object sender, EventArgs e)
        {
            Lfx.Workspace.Master.RunTime.Execute("CREAR", new string[] { "Lbl.Comprobantes.ReciboDePago" });
        }

        private void BotonCrearFactura_Click(object sender, EventArgs e)
        {
            Lfx.Workspace.Master.RunTime.Execute("CREAR", new string[] { "Lbl.Comprobantes.ComprobanteDeCompra" });
        }

        private void BotonListadoRecibos_Click(object sender, EventArgs e)
        {
            Lfx.Workspace.Master.RunTime.Execute("LISTAR", new string[] { "Lbl.Comprobantes.ReciboDePago" });
        }

        private void BotonListadoFacturas_Click(object sender, EventArgs e)
        {
            Lfx.Workspace.Master.RunTime.Execute("LISTAR", new string[] { "Lbl.Comprobantes.ComprobanteDeCompra FP" });
        }
    }
}
