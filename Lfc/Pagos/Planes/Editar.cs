using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Pagos.Planes
{
    public partial class Editar : Lcc.Edicion.ControlEdicion
    {
        public Editar()
        {
            ElementoTipo = typeof(Lbl.Pagos.Plan);
            InitializeComponent();
        }

        public override void ActualizarControl()
        {
            Lbl.Pagos.Plan Pla = this.Elemento as Lbl.Pagos.Plan;

            EntradaNombre.Text = Pla.Nombre;
            EntradaTarjeta.Elemento = Pla.Tarjeta;
            EntradaCuotas.ValueDecimal = Pla.Cuotas;
            EntradaInteres.ValueDecimal = Pla.Interes;
            EntradaComision.ValueDecimal = Pla.Comision;

            base.ActualizarControl();
        }


        public override void ActualizarElemento()
        {
            Lbl.Pagos.Plan Pla = this.Elemento as Lbl.Pagos.Plan;

            Pla.Nombre = EntradaNombre.Text;
            Pla.Tarjeta = EntradaTarjeta.Elemento as Lbl.Pagos.FormaDePago;
            Pla.Cuotas = EntradaCuotas.ValueInt;
            Pla.Interes = EntradaInteres.ValueDecimal;
            Pla.Comision = EntradaComision.ValueDecimal;

            base.ActualizarElemento();
        }
    }
}
