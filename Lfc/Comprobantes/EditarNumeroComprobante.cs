using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
    public partial class EditarNumeroComprobante : Lui.Forms.DialogForm
    {
        public string OldNumber = "", NewNumber = "";
        private void EntradaNumero_Leave(object sender, EventArgs e)
        {
            if (EntradaNumero.ValueInt > 0)
                EntradaNumero.Text = EntradaNumero.ValueInt.ToString("00000000");
        }

        private void EntradaNumero_TextChanged(object sender, EventArgs e)
        {
            NewNumber = EntradaPV.ValueInt.ToString("0000") + "-" + EntradaNumero.Text;
        }

        private void EditarNumeroComprobante_Load(object sender, EventArgs e)
        {
            EntradaComprobante.Text = OldNumber;
            string[] split = OldNumber.Split('-');
            if (split.Length > 1)
                EntradaPV.ValueInt = int.Parse(split[0]);
        }

        public EditarNumeroComprobante()
        {
            InitializeComponent();
        }
    }
}
