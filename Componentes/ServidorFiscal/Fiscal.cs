using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServidorFiscal
{
    public partial class Fiscal : Form
    {
        public Fiscal()
        {
            InitializeComponent();
            ServidorFiscal ser = new ServidorFiscal();
            ser.Run();
        }

        private void Fiscal_Load(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
