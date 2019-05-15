using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Moneda
{
    public partial class Editar : Lcc.Edicion.ControlEdicion
    {
        private bool reiniciar = false;
        public Editar()
        {
            ElementoTipo = typeof(Lbl.Entidades.Moneda);

            InitializeComponent();
        }

        public override void ActualizarControl()
        {
            Lbl.Entidades.Moneda Mon = this.Elemento as Lbl.Entidades.Moneda;

            EntradaNombre.Text = Mon.Nombre;
            EntradaSigno.Text = Mon.Simbolo;
            EntradaISO.Text = Mon.NomenclaturaIso;
            EntradaCotizacion.ValueDecimal = Mon.Cotizacion;
            EntradaDecimales.ValueInt = Mon.Decimales;
            EntradaCotizacion.DecimalPlaces = Mon.Decimales;

            base.ActualizarControl();
        }


        public override void ActualizarElemento()
        {
            Lbl.Entidades.Moneda Mon = this.Elemento as Lbl.Entidades.Moneda;

            Mon.Nombre = EntradaNombre.Text;
            Mon.Simbolo = EntradaSigno.Text;
            Mon.NomenclaturaIso = EntradaISO.Text;
            Mon.Cotizacion = EntradaCotizacion.ValueDecimal;
            Mon.Decimales = EntradaDecimales.ValueInt;
            Mon.ActualizarProductos = 0;


            Lfx.Data.Row RowProdConMoneda = this.Connection.FirstRowFromSelect("SELECT id_articulocotiza FROM articulos_cotiza WHERE id_moneda=" + Mon.Id + " AND estado=1");
            if (RowProdConMoneda != null)
            {
                Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("¿Desea actualizar los productos que cotizan con esta moneda?", "¿Actualización de Productos?");
                Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                if (Pregunta.ShowDialog() == DialogResult.OK)
                {
                    Mon.ActualizarProductos = 1;
                    reiniciar = true;
                }
            }

            base.ActualizarElemento();
            //Lfx.Workspace.Master.RunTime.Execute("REBOOT");
        }

        public override void AfterSave(IDbTransaction transaction)
        {
            base.AfterSave(transaction);
            if (reiniciar)
            {
                Lui.Forms.MessageBox.Show("Reiniciar la aplicación para que termine el proceso de actualización.", "¡Atención!");
            }
        }
    }
}
