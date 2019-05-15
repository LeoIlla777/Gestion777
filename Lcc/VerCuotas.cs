using System;
using System.Windows.Forms;

namespace Lcc
{
    public partial class VerCuotas : Lui.Forms.ChildDialogForm
    {
        public VerCuotas()
        {
            InitializeComponent();
            this.OkButton.Visible = false;
            ColInteres.Width = ColTotal.Width = 1;
        }

        public void Mostrar(string detalle, decimal monto)
        {
            this.EtiquetaTitulo.Text = detalle;

            ListaConformacion.BeginUpdate();
            ListaConformacion.Items.Clear();
            string condiWhere = "id_tarjeta is null";
            System.Data.DataTable Planes = this.Connection.Select("SELECT id_plan, nombre, interes, cuotas FROM tarjetas_planes WHERE " + condiWhere + " order by cuotas");

            foreach (System.Data.DataRow plan in Planes.Rows)
            {
                //ListViewGroup Grupo = ListaConformacion.Groups.Add(plan["id_plan"].ToString(), plan["nombre"].ToString());
                ListViewItem Itm = ListaConformacion.Items.Add(plan["id_plan"].ToString());
                Itm.SubItems[0].Text = plan["nombre"].ToString();
                decimal Interes = (decimal)plan["interes"];
                Itm.SubItems.Add(Interes.ToString());
                decimal totalInter = 1 + (Interes / 100);
                decimal total = totalInter * monto;
                int cuotas = int.Parse(plan["cuotas"].ToString());
                if (cuotas == 0)
                    cuotas = 1;
                Itm.SubItems.Add((total / cuotas).ToString("C2"));
                //Itm.Group = Grupo;
            }

            ListaConformacion.EndUpdate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ColInteres.Width = cbInteres.Checked ? 120 : 1;
        }

        private void cbTotal_CheckedChanged(object sender, EventArgs e)
        {
            ColTotal.Width = cbTotal.Checked ? 120 : 1;
        }
    }
}
