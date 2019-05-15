
namespace Lfc.Pagos.FormasDePago
{
    public partial class Editar : Lcc.Edicion.ControlEdicion
    {
        public Editar()
        {
            ElementoTipo = typeof(Lbl.Pagos.FormaDePago);
            InitializeComponent();
        }

        public override void ActualizarControl()
        {
            Lbl.Pagos.FormaDePago Pag = this.Elemento as Lbl.Pagos.FormaDePago;

            EntradaNombre.Text = Pag.Nombre;
            EntradaCaja.Elemento = Pag.Caja;
            if (Pag.Registro["tipo"] != null)
                EntradaTipo.TextKey = Pag.Registro["tipo"].ToString();
            EntradaPagos.TextKey = Pag.PuedeHacerPagos ? "1" : "0";
            EntradaCobros.TextKey = Pag.PuedeHacerCobros ? "1" : "0";
            EntradaRetenciones.ValueDecimal = Pag.Retencion;
            EntradaRecargo.ValueDecimal = Pag.Descuento;
            if (Pag.Concepto_Ingreso != null)
                EntradaConceptoIngreso.ValueInt = Pag.Concepto_Ingreso.Id;
            if (Pag.Concepto_Egreso != null)
                EntradaConceptoEgreso.ValueInt = Pag.Concepto_Egreso.Id;

            base.ActualizarControl();
        }


        public override void ActualizarElemento()
        {
            Lbl.Pagos.FormaDePago Pag = this.Elemento as Lbl.Pagos.FormaDePago;

            Pag.Nombre = EntradaNombre.Text;
            Pag.Caja = EntradaCaja.Elemento as Lbl.Cajas.Caja;
            Pag.Tipo = (Lbl.Pagos.TiposFormasDePago)(Lfx.Types.Parsing.ParseInt(EntradaTipo.TextKey));
            Pag.PuedeHacerPagos = Lfx.Types.Parsing.ParseBool(EntradaPagos.TextKey);
            Pag.PuedeHacerCobros = Lfx.Types.Parsing.ParseBool(EntradaCobros.TextKey);
            Pag.Retencion = EntradaRetenciones.ValueDecimal;
            Pag.Descuento = EntradaRecargo.ValueDecimal;
            Pag.Concepto_Ingreso = EntradaConceptoIngreso.Elemento as Lbl.Cajas.Concepto;
            Pag.Concepto_Egreso = EntradaConceptoEgreso.Elemento as Lbl.Cajas.Concepto;

            base.ActualizarElemento();
        }
    }
}
