using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Lfc.Articulos
{
    public partial class Editar : Lcc.Edicion.ControlEdicion
    {
        private bool CustomName = false;
        private decimal Rendimiento;
        private string UnidadRendimiento = "";
        private Lbl.Articulos.Margen Margen = null;
        private Lbl.ColeccionGenerica<Lbl.Articulos.Margen> Margenes = null;

        public Editar()
        {
            ElementoTipo = typeof(Lbl.Articulos.Articulo);
            IgnorarMargenChanged = 1;
            InitializeComponent();
        }



        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this.Connection != null)
            {
                EntradaStockActual.DecimalPlaces = Lbl.Sys.Config.Articulos.Decimales;
                EntradaStockMinimo.DecimalPlaces = Lbl.Sys.Config.Articulos.Decimales;
                EntradaCosto.DecimalPlaces = Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesCosto;
                EntradaPvp.DecimalPlaces = Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales;

                Lfx.Data.Row Nombre = null;

                Nombre = Lfx.Workspace.Master.Tables["articulos_codigos"].FastRows[1];
                if (Nombre != null)
                    EtiquetaCodigo1.Text = Nombre["nombre"].ToString();

                Nombre = Lfx.Workspace.Master.Tables["articulos_codigos"].FastRows[2];
                if (Nombre != null)
                    EtiquetaCodigo2.Text = Nombre["nombre"].ToString();

                Nombre = Lfx.Workspace.Master.Tables["articulos_codigos"].FastRows[3];
                if (Nombre != null)
                    EtiquetaCodigo3.Text = Nombre["nombre"].ToString();

                Nombre = Lfx.Workspace.Master.Tables["articulos_codigos"].FastRows[4];
                if (Nombre != null)
                    EtiquetaCodigo4.Text = Nombre["nombre"].ToString();

            }

            EntradaCodigo1.Focus();
        }


        private void EntradaCategoriaMarcaModeloSerie_TextChanged(System.Object sender, System.EventArgs e)
        {
            var Cat = EntradaCategoria.Elemento as Lbl.Articulos.Categoria;

            if (sender == EntradaCategoria)
            {
                var Alic = this.ObtenerAlicuota();
                if (Alic != null)
                {
                    EtiquetaAlicuota.Text = Alic.Porcentaje.ToString("#0.00") + "%, " + Alic.Nombre;
                }
                else
                {
                    EtiquetaAlicuota.Text = "";
                }

                EntradaPvp_TextChanged(sender, e);
            }

            if (CustomName == false)
            {
                string NombreSing = "";
                if (Cat != null)
                    NombreSing = Cat.NombreSingular;
                string Texto = (NombreSing + " " + EntradaMarca.TextDetail + " " + EntradaModelo.Text + " " + EntradaSerie.Text).Trim();
                if (Texto.Length > 0)
                    EntradaNombre.Text = Texto;
            }

            EntradaSeguimiento_TextChanged(sender, e);
        }

        private void EntradaNombre_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CustomName = true;
        }


        private void BotonMasInfo_Click(object sender, System.EventArgs e)
        {
            Articulos.MasInfo FormMasInfo = new Articulos.MasInfo();
            FormMasInfo.MdiParent = this.ParentForm.MdiParent;
            FormMasInfo.Articulo = this.Elemento as Lbl.Articulos.Articulo;
            FormMasInfo.Show();
        }

        private int IgnorarCostoMargenPvpPvpIvaTextChanged, IgnorarMargenChanged;
        private void EntradaCostoMargen_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (this.Connection == null)
                return;

            if (EntradaCosto.ValueDecimal < 0)
                EntradaCosto.ErrorText = "El costo no debería ser menor que cero.";
            else
                EntradaCosto.ErrorText = "";

            if (IgnorarCostoMargenPvpPvpIvaTextChanged <= 0)
            {
                IgnorarCostoMargenPvpPvpIvaTextChanged++;
                decimal CostoConvertido = EntradaCosto.ValueDecimal;
                switch (EntradaCotizaPor.TextKey)
                {
                    case "1":
                    case "2":
                        CostoConvertido = EntradaCotiza.ValueDecimal * CostoConvertido;
                        break;
                }
                if (EntradaMargen.ValueInt > 0)
                {
                    this.Margen = this.Margenes.GetById(EntradaMargen.ValueInt);

                    if (Margen != null)
                    {
                        decimal Pvp = CostoConvertido;
                        //Pvp += Margen.Sumar;
                        decimal MargenCompleto = Math.Round(Margen.Porcentaje, Lbl.Sys.Config.Moneda.DecimalesFinal);
                        Pvp *= (1 + MargenCompleto / 100);
                        //Pvp += Margen.Sumar2;
                        if (EntradaPvp.ValueDecimal != Pvp)
                        {
                            EntradaPvp.ValueDecimal = Math.Round(Pvp, Lbl.Sys.Config.Moneda.DecimalesFinal);
                        }
                    }
                }
                else
                {
                    this.Margen = null;
                    //EntradaPvp_TextChanged(sender, e);
                }
                IgnorarCostoMargenPvpPvpIvaTextChanged--;
            }
        }


        public override Lfx.Types.OperationResult ValidarControl()
        {
            Lfx.Types.OperationResult Res = new Lfx.Types.SuccessOperationResult();

            if (EntradaNombre.Text.Length < 2)
            {
                Res.Success = false;
                Res.Message += "Por favor escriba el nombre del artículo." + Environment.NewLine;
            }

            if (EntradaCodigo1.Text.Length > 0)
            {
                Lfx.Data.Row Articulo = this.Connection.FirstRowFromSelect("SELECT id_articulo FROM articulos WHERE codigo1='" + EntradaCodigo1.Text + "' AND id_articulo<>" + this.Elemento.Id.ToString());

                if (Articulo != null)
                {
                    Res.Success = false;
                    Res.Message += "Ya existe un artículo con el mismo código (" + EtiquetaCodigo1.Text + " " + EntradaCodigo1.Text + ") en la base de datos." + Environment.NewLine;
                }
            }

            if (EntradaCodigo2.Text.Length > 0)
            {
                Lfx.Data.Row Articulo = this.Connection.FirstRowFromSelect("SELECT id_articulo FROM articulos WHERE codigo2='" + EntradaCodigo2.Text + "' AND id_articulo<>" + this.Elemento.Id.ToString());

                if (Articulo != null)
                {
                    Res.Success = false;
                    Res.Message += "Ya existe un artículo con el mismo código (" + EtiquetaCodigo2.Text + " " + EntradaCodigo2.Text + ") en la base de datos." + Environment.NewLine;
                }
            }

            if (EntradaCodigo3.Text.Length > 0)
            {
                Lfx.Data.Row Articulo = this.Connection.FirstRowFromSelect("SELECT id_articulo FROM articulos WHERE codigo3='" + EntradaCodigo3.Text + "' AND id_articulo<>" + this.Elemento.Id.ToString());

                if (Articulo != null)
                {
                    Res.Success = false;
                    Res.Message += "Ya existe un artículo con el mismo código (" + EtiquetaCodigo3.Text + " " + EntradaCodigo3.Text + ") en la base de datos." + Environment.NewLine;
                }
            }

            if (EntradaCodigo4.Text.Length > 0)
            {
                Lfx.Data.Row Articulo = this.Connection.FirstRowFromSelect("SELECT id_articulo FROM articulos WHERE codigo4='" + EntradaCodigo4.Text + "' AND id_articulo<>" + this.Elemento.Id.ToString());

                if (Articulo != null)
                {
                    Res.Success = false;
                    Res.Message += "Ya existe un artículo con el mismo código (" + EtiquetaCodigo4.Text + " " + EntradaCodigo4.Text + ") en la base de datos." + Environment.NewLine;
                }
            }

            return Res;
        }


        private void EntradaCosto_GotFocus(object sender, System.EventArgs e)
        {
            if (this.Elemento.Existe)
            {
                string Res = "";

                decimal PrecioUltComp = this.Connection.FieldDecimal("SELECT comprob_detalle.precio FROM comprob, comprob_detalle WHERE comprob.id_comprob=comprob_detalle.id_comprob AND comprob.tipo_fac IN ('R', 'FA', 'FB', 'FC', 'FE', 'FM') AND comprob.compra=1 AND id_articulo=" + this.Elemento.Id.ToString() + " GROUP BY comprob.id_comprob ORDER BY comprob_detalle.id_comprob_detalle DESC");
                decimal PrecioUltFlete = this.Connection.FieldDecimal("SELECT (comprob.gastosenvio+comprob.otrosgastos)*(comprob_detalle.precio/comprob.total) FROM comprob, comprob_detalle WHERE comprob.id_comprob=comprob_detalle.id_comprob AND comprob.tipo_fac IN ('R', 'FA', 'FB', 'FC', 'FE', 'FM') AND comprob.compra=1 AND id_articulo=" + this.Elemento.Id.ToString() + " GROUP BY comprob.id_comprob ORDER BY comprob_detalle.id_comprob_detalle DESC");
                Res += "Costo de la última compra (sin gastos): " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(PrecioUltComp, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesCosto) + Environment.NewLine;
                Res += "Costo de la última compra (con gastos): " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(PrecioUltComp + PrecioUltFlete, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesCosto) + Environment.NewLine;

                // Podría hacer esto con una subconsulta, pero la versión de MySql que estamos utilizando
                // no permite la cláusula LIMIT dentro de una subconsulta IN ()
                decimal PrecioUlt5Comps = 0;
                System.Data.DataTable UltimasCompras = this.Connection.Select("SELECT comprob_detalle.precio, comprob.id_comprob FROM comprob, comprob_detalle WHERE comprob.id_comprob=comprob_detalle.id_comprob AND comprob.compra=1 AND comprob.tipo_fac IN ('R', 'FA', 'FB', 'FC', 'FE', 'FM') AND comprob.compra=1 AND comprob_detalle.id_articulo=" + this.Elemento.Id.ToString() + " ORDER BY comprob.fecha DESC LIMIT 5");

                if (UltimasCompras.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow Compra in UltimasCompras.Rows)
                    {
                        PrecioUlt5Comps += System.Convert.ToDecimal(Compra["precio"]);
                    }

                    PrecioUlt5Comps = PrecioUlt5Comps / UltimasCompras.Rows.Count;
                    Res += "Promedio de las últimas " + UltimasCompras.Rows.Count.ToString() + " compras (sin gastos): " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(PrecioUlt5Comps, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesCosto);
                }

                // TODO: EntradaCosto.ShowBalloon(Res, "Precio de Compra", 60);
            }
        }

        private void EntradaStockActual_TextChanged(object sender, System.EventArgs e)
        {
            if (Lfx.Types.Parsing.ParseStock(EntradaStockActual.Text) < Lfx.Types.Parsing.ParseStock(EntradaStockMinimo.Text))
                EntradaStockActual.ErrorText = "El stock actual está por debajo del mínimo.";
            else
                EntradaStockActual.ErrorText = "";
        }


        private void BotonUnidad_Click(object sender, EventArgs e)
        {
            Rendimiento FormRend = new Rendimiento();
            FormRend.EntradaUnidad.TextKey = EntradaUnidad.TextKey;
            FormRend.EntradaRendimiento.ValueDecimal = Rendimiento;
            FormRend.EntradaUnidadRend.TextKey = UnidadRendimiento;
            if (FormRend.ShowDialog() == DialogResult.OK)
            {
                EntradaUnidad.TextKey = FormRend.EntradaUnidad.TextKey;
                Rendimiento = FormRend.EntradaRendimiento.ValueDecimal;
                UnidadRendimiento = FormRend.EntradaUnidadRend.TextKey;
            }
        }

        private void EntradaPvp_Enter(object sender, EventArgs e)
        {
            if (EntradaUnidad.TextKey.Length > 0 && UnidadRendimiento != null && UnidadRendimiento.Length > 0)
            {
                // TODO: EntradaPvp.ShowBalloon("En " + EntradaUnidad.TextKey + " de " + Rendimiento.ToString() + " " + UnidadRendimiento + " a razón de " + Lbl.Sys.Config.Moneda.Simbolo + Lfx.Types.Formatting.FormatCurrency(EntradaPvp.ValueDecimal / Rendimiento, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales) + " (PVP) el " + UnidadRendimiento + ".");
            }
        }

        private void CompletarMargenes()
        {
            this.Margenes = new Lbl.ColeccionGenerica<Lbl.Articulos.Margen>(this.Connection, Lfx.Workspace.Master.Tables["margenes"]);

            int i = 0;
            string[] ListaMargenes = new string[this.Margenes.Count + 1];

            foreach (Lbl.Articulos.Margen Mg in this.Margenes)
            {
                ListaMargenes[i] = Mg.Nombre + " (" + Lfx.Types.Formatting.FormatNumber(Mg.Porcentaje, 2) + "%)|" + Mg.Id.ToString();
                i++;
            }
            ListaMargenes[i] = "Otro|0";
            EntradaMargen.SetData = ListaMargenes;
        }

        public override void ActualizarControl()
        {
            Lbl.Articulos.Articulo Art = this.Elemento as Lbl.Articulos.Articulo;

            EntradaCodigo1.Text = Art.Codigo1;
            EntradaCodigo2.Text = Art.Codigo2;
            EntradaCodigo3.Text = Art.Codigo3;
            EntradaCodigo4.Text = Art.Codigo4;
            EntradaCategoria.Elemento = Art.Categoria;
            EntradaMarca.Elemento = Art.Marca;
            EntradaCaja.Elemento = Art.Caja;
            EntradaModelo.Text = Art.Modelo;
            EntradaSerie.Text = Art.Serie;
            EntradaNombre.Text = Art.Nombre;
            EntradaUrl.Text = Art.Url;
            EntradaProveedor.Elemento = Art.Proveedor;
            EntradaDescripcion.Text = Art.Descripcion;
            EntradaDescripcion2.Text = Art.Descripcion2;
            EntradaDestacado.ValueInt = Art.Destacado ? 1 : 0;
            EntradaWeb.ValueInt = ((int)(Art.Publicacion));
            if (IgnorarCostoMargenPvpPvpIvaTextChanged == 0)
                IgnorarCostoMargenPvpPvpIvaTextChanged++;
            EntradaCosto.ValueDecimal = Art.Costo;
            CompletarMargenes();//Carga los margenes antes de asignar.(//LEO)
            if (Art.Margen == null)
                EntradaMargen.ValueInt = 0;
            else
                EntradaMargen.ValueInt = Art.Margen.Id;

            EntradaPvp.ValueDecimal = Art.Pvp;

            IgnorarCostoMargenPvpPvpIvaTextChanged--;

            EntradaTipoDeArticulo.ValueInt = (int)(Art.TipoDeArticulo);
            EntradaSeguimiento.ValueInt = (int)(Art.Seguimiento);
            EntradaPeriodicidad.ValueInt = (int)(Art.Periodicidad);
            EntradaSeguimiento.ReadOnly = Art.Existe && Art.Existencias != 0;
            EntradaStockActual.ValueDecimal = Art.Existencias;
            EntradaStockActual.ReadOnly = Art.Existe;
            EntradaUnidad.TextKey = Art.Unidad;
            Rendimiento = Art.Rendimiento;
            UnidadRendimiento = Art.UnidadRendimiento;
            EntradaStockMinimo.ValueDecimal = Art.PuntoDeReposicion;
            EntradaGarantia.ValueInt = Art.Garantia;
            CustomName = Art.Existe;

            EntradaTipoDeArticulo_TextChanged(this, null);
            EntradaCategoriaMarcaModeloSerie_TextChanged(EntradaCategoria, null);

            EntradaCotizaPor.TextKey = Art.ConOtraMoneda.ToString();
            groupBox1.Enabled = EntradaCotizaPor.TextKey == "0" ? false : true;
            EntradaCotiza.ValueDecimal = Art.Cotiza;
            EntradaMoneda.ValueInt = Art.Moneda;
            EntradaEstante.Text = Art.Estante;
            EntradaEstanteria.Text = Art.Estanteria;

            EntradaConceptoVenta.Elemento = Art.ConceptoVenta;
            EntradaConceptoCompra.Elemento = Art.ConceptoCompra;

            btnImprimir.Enabled = Art.Existe;

            base.ActualizarControl();

            EntradaCodigo1.Focus();
            IgnorarMargenChanged = 0;
        }

        public override void ActualizarElemento()
        {
            Lbl.Articulos.Articulo Art = this.Elemento as Lbl.Articulos.Articulo;

            Art.Codigo1 = EntradaCodigo1.Text;
            Art.Codigo2 = EntradaCodigo2.Text;
            Art.Codigo3 = EntradaCodigo3.Text;
            Art.Codigo4 = EntradaCodigo4.Text;
            Art.Categoria = EntradaCategoria.Elemento as Lbl.Articulos.Categoria;
            Art.Marca = EntradaMarca.Elemento as Lbl.Articulos.Marca;
            Art.Caja = EntradaCaja.Elemento as Lbl.Cajas.Caja;
            Art.Modelo = EntradaModelo.Text;
            Art.Serie = EntradaSerie.Text;
            Art.Nombre = EntradaNombre.Text;
            Art.Url = EntradaUrl.Text;
            Art.Proveedor = EntradaProveedor.Elemento as Lbl.Personas.Persona;
            Art.Descripcion = EntradaDescripcion.Text;
            Art.Descripcion2 = EntradaDescripcion2.Text;
            Art.Destacado = EntradaDestacado.ValueInt != 0;
            Art.Costo = EntradaCosto.ValueDecimal;

            if (EntradaMargen.ValueInt > 0)
                Art.Margen = this.Margenes.GetById(EntradaMargen.ValueInt);
            else
                Art.Margen = null;

            Art.Pvp = EntradaPvp.ValueDecimal;
            Art.TipoDeArticulo = (Lbl.Articulos.TiposDeArticulo)(EntradaTipoDeArticulo.ValueInt);
            Art.Seguimiento = (Lbl.Articulos.Seguimientos)(EntradaSeguimiento.ValueInt);
            Art.Periodicidad = (Lbl.Articulos.Periodicidad)(EntradaPeriodicidad.ValueInt);
            Art.PuntoDeReposicion = Lfx.Types.Parsing.ParseStock(EntradaStockMinimo.Text);
            Art.Unidad = EntradaUnidad.TextKey;
            Art.Rendimiento = Rendimiento;
            Art.UnidadRendimiento = UnidadRendimiento;
            Art.Estado = 1;
            Art.Garantia = EntradaGarantia.ValueInt;
            Art.Publicacion = ((Lbl.Articulos.Publicacion)(EntradaWeb.ValueInt));
            if (Art.Existe == false)
                Art.ExistenciasInicial = EntradaStockActual.ValueDecimal;

            if (EntradaCotizaPor.TextKey != "0" && (EntradaMoneda.Elemento == null || EntradaMoneda.ValueInt == 0))
            {
                Art.ConOtraMoneda = 0;
                Art.Cotiza = 0;
                Art.Moneda = 0;
            }
            else
            {
                Art.ConOtraMoneda = Lfx.Types.Parsing.ParseInt(EntradaCotizaPor.TextKey);
                Art.Cotiza = EntradaCotiza.ValueDecimal;
                Art.Moneda = EntradaMoneda.ValueInt;
            }

            Art.Estante = EntradaEstante.Text;
            Art.Estanteria = EntradaEstanteria.Text;

            Art.ConceptoVenta = EntradaConceptoVenta.Elemento as Lbl.Cajas.Concepto;
            Art.ConceptoCompra = EntradaConceptoCompra.Elemento as Lbl.Cajas.Concepto;

            Lbl.Articulos.Seguimientos Seg = Art.ObtenerSeguimiento();
            if (Seg != Lbl.Articulos.Seguimientos.Ninguno)
            {
                // Verificar que los datos de seguimiento actual coincidan con el stock actual
            }

            base.ActualizarElemento();

            EntradaCodigo1.Focus();
        }


        private void EntradaTipoDeArticulo_TextChanged(object sender, EventArgs e)
        {
            BotonReceta.Visible = EntradaTipoDeArticulo.ValueInt == 2;
            EntradaCosto.Enabled = EntradaTipoDeArticulo.ValueInt != 2;

            PanelServicio.Visible = EntradaTipoDeArticulo.ValueInt == 0;
            PanelProducto.Visible = EntradaTipoDeArticulo.ValueInt != 0;
            this.ActualizarCostoYStockSegunReceta();
        }

        private void BotonReceta_Click(object sender, EventArgs e)
        {
            if (EntradaTipoDeArticulo.TextKey == "2")
            {
                Lbl.Articulos.Articulo Art = this.Elemento as Lbl.Articulos.Articulo;
                Receta FormReceta = new Receta();
                FormReceta.ReadOnly = this.TemporaryReadOnly;
                FormReceta.Articulo = Art;
                if (FormReceta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Changed = true;
                    this.ActualizarCostoYStockSegunReceta();
                }
            }
        }

        private void ActualizarCostoYStockSegunReceta()
        {
            Lbl.Articulos.Articulo Art = this.Elemento as Lbl.Articulos.Articulo;

            if (EntradaTipoDeArticulo.ValueInt == 2)
            {
                if (Art.Receta == null)
                    EntradaCosto.ValueDecimal = 0;
                else
                    EntradaCosto.ValueDecimal = Art.Receta.Costo;

                EntradaStockActual.ValueDecimal = Art.ObtenerExistencias();
            }
        }


        private void VerHistorial()
        {
            Articulos.VerMovimientos FormularioDetalles = new Articulos.VerMovimientos();
            FormularioDetalles.MdiParent = this.ParentForm.MdiParent;
            FormularioDetalles.Mostrar(this.Elemento as Lbl.Articulos.Articulo);
            FormularioDetalles.Show();
        }

        private void VerConformacion()
        {
            Articulos.VerConformacion FormularioDetalles = new Articulos.VerConformacion();
            FormularioDetalles.MdiParent = this.ParentForm.MdiParent;
            FormularioDetalles.Mostrar(this.Elemento as Lbl.Articulos.Articulo);
            FormularioDetalles.Show();
        }

        private void EntradaSeguimiento_TextChanged(object sender, EventArgs e)
        {
            Lbl.Articulos.Seguimientos Seg = (Lbl.Articulos.Seguimientos)(EntradaSeguimiento.ValueInt);
            if (Seg == Lbl.Articulos.Seguimientos.Predeterminado)
            {
                Lbl.Articulos.Categoria Cat = EntradaCategoria.Elemento as Lbl.Articulos.Categoria;
                if (Cat != null)
                    Seg = Cat.ObtenerSeguimiento();
            }

            EntradaStockActual.ReadOnly = Seg == Lbl.Articulos.Seguimientos.Ninguno;
            if (EntradaStockActual.ReadOnly)
            {
                // El stock no editable
                if (this.Elemento.Existe)
                    // Para artículos existentes, muestro el stock actual real
                    EntradaStockActual.ValueDecimal = this.Connection.FieldDecimal("SELECT stock_actual FROM articulos WHERE id_articulo=" + this.Elemento.Id.ToString());
                else
                    // Para artículos nuevos, muestro cero
                    EntradaStockActual.ValueDecimal = 0;
            }
        }


        public override Lazaro.Pres.Forms.FormActionCollection GetFormActions()
        {
            Lazaro.Pres.Forms.FormActionCollection Res = base.GetFormActions();
            if (this.Elemento != null && this.Elemento.Existe)
            {
                Res.Add(new Lazaro.Pres.Forms.FormAction("Movimientos", "F7", "movimientos", 20, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                Res.Add(new Lazaro.Pres.Forms.FormAction("Conformación", "F5", "conformacion", 10, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
            }
            return Res;
        }


        public override Lfx.Types.OperationResult PerformFormAction(string name)
        {
            switch (name)
            {
                case "movimientos":
                    VerHistorial();
                    return new Lfx.Types.SuccessOperationResult();
                case "conformacion":
                    VerConformacion();
                    return new Lfx.Types.SuccessOperationResult();
                default:
                    return base.PerformFormAction(name);
            }
        }


        public override Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle {
            get {
                return Lazaro.Pres.DisplayStyles.Template.Current.Articulos;
            }
        }


        private void EntradaPvp_TextChanged(object sender, System.EventArgs e)
        {
            if (true || IgnorarCostoMargenPvpPvpIvaTextChanged <= 0)
            {
                //IgnorarCostoMargenPvpPvpIvaTextChanged++;
                if (this.Margenes != null)
                {
                    decimal PorcentajeActual;
                    if (EntradaCosto.ValueDecimal != 0)
                    {
                        decimal newCosto = EntradaCosto.ValueDecimal;
                        switch (EntradaCotizaPor.TextKey)
                        {
                            case "1":
                            case "2":
                                newCosto = EntradaCotiza.ValueDecimal * newCosto;
                                break;
                        }
                        if (newCosto == 0)
                            newCosto = 1;
                        else
                            newCosto = Math.Round(newCosto, Lbl.Sys.Config.Moneda.DecimalesFinal);
                        PorcentajeActual = Math.Round(EntradaPvp.ValueDecimal / newCosto * 100m - 100m, Lbl.Sys.Config.Moneda.DecimalesFinal);
                    }
                    else
                        PorcentajeActual = 0;

                    if (IgnorarMargenChanged != 1)
                    {
                        int IdMargen = 0;
                        foreach (Lbl.Articulos.Margen Mg in this.Margenes)
                        {
                            if (Math.Abs(Mg.Porcentaje - PorcentajeActual) < 0.12M)
                            {
                                IdMargen = Mg.Id;
                                if (EntradaMargen.ValueInt == IdMargen)//Controlo que sea el margen seleccionado en caso de que haya mas de uno con el mismo porcentaje.
                                    break;
                            }
                        }

                        if (EntradaMargen.ValueInt != IdMargen)
                        {
                            EntradaMargen.ValueInt = IdMargen;
                        }

                        if (IdMargen == 0)
                        {
                            if (EntradaCosto.ValueDecimal == 0m)
                            {
                                EntradaMargen.Text = "N/A";
                            }
                            else
                            {
                                EntradaMargen.Text = "Otro (" + Lfx.Types.Formatting.FormatNumber(PorcentajeActual, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesCosto) + "%)";
                            }
                        }
                    }
                }

                var Alic = this.ObtenerAlicuota();
                if (Alic == null)
                {
                    if (Math.Abs(EntradaPvpIva.ValueDecimal - EntradaPvp.ValueDecimal) > 0.01m)
                    {
                        EntradaPvpIva.ValueDecimal = EntradaPvp.ValueDecimal;
                    }
                }
                else
                {
                    decimal PvpIva = Math.Round(EntradaPvp.ValueDecimal * (1m + Alic.Porcentaje / 100m), 4);
                    if (Math.Abs(EntradaPvpIva.ValueDecimal - PvpIva) > 0.01m)
                    {
                        EntradaPvpIva.ValueDecimal = PvpIva;
                    }
                }

                //IgnorarCostoMargenPvpPvpIvaTextChanged--;
            }
        }


        private void EntradaPvpIva_TextChanged(object sender, EventArgs e)
        {
            if (IgnorarCostoMargenPvpPvpIvaTextChanged <= 0)
            {
                //IgnorarCostoMargenPvpPvpIvaTextChanged++;
                var Alic = this.ObtenerAlicuota();
                if (Alic == null)
                {
                    if (EntradaPvp.ValueDecimal != EntradaPvpIva.ValueDecimal)
                    {
                        EntradaPvp.ValueDecimal = EntradaPvpIva.ValueDecimal;
                    }
                }
                else
                {
                    decimal Pvp = Math.Round(EntradaPvpIva.ValueDecimal / (1m + Alic.Porcentaje / 100m), Lbl.Sys.Config.Moneda.DecimalesFinal);
                    if (Math.Abs(EntradaPvp.ValueDecimal - Pvp) > 0.01m)
                    {
                        EntradaPvp.ValueDecimal = Pvp;
                    }
                }
                //IgnorarCostoMargenPvpPvpIvaTextChanged--;
            }
        }


        protected Lbl.Impuestos.Alicuota ObtenerAlicuota()
        {
            var Categ = EntradaCategoria.Elemento as Lbl.Articulos.Categoria;
            Lbl.Impuestos.Alicuota Res = null;

            if (Categ != null)
            {
                if (Categ.Alicuota != null)
                    Res = Categ.Alicuota;
                else if (Categ.Rubro != null && Categ.Rubro.Alicuota != null)
                    Res = Categ.Rubro.Alicuota;
                else
                    Res = Lbl.Sys.Config.Empresa.AlicuotaPredeterminada;
            }
            else
            {
                Res = Lbl.Sys.Config.Empresa.AlicuotaPredeterminada;
            }

            return Res;
        }

        private void EntradaCotizaPor_TextChanged(object sender, EventArgs e)
        {
            EntradaCotizaPor.ErrorText = "";
            switch (EntradaCotizaPor.TextKey)
            {
                case "0":
                    groupBox1.Enabled = false;
                    EntradaMoneda.Elemento = null;
                    EntradaMoneda.Text = "";
                    EntradaCotiza.ValueDecimal = 0;
                    break;
                case "1":
                    groupBox1.Enabled = true;

                    Lfx.Data.Row rowMon = this.Connection.FirstRowFromSelect("SELECT id_moneda,cotiza FROM articulos_cotiza WHERE estado=1 AND id_articulo=" + this.Elemento.Id.ToString());
                    if (rowMon != null)
                    {
                        if (rowMon.Fields["id_moneda"].ValueInt != 0)
                        {
                            Lbl.Entidades.Moneda mon = new Lbl.Entidades.Moneda(this.Connection, rowMon.Fields["id_moneda"].ValueInt);
                            EntradaMoneda.Elemento = mon;
                            EntradaCotiza.ValueDecimal = rowMon.Fields["cotiza"].ValueDecimal;
                        }
                    }
                    break;
                case "2":
                    groupBox1.Enabled = false;
                    if (EntradaProveedor.Elemento != null)
                    {
                        Lfx.Data.Row rowProv = this.Connection.FirstRowFromSelect("SELECT id_moneda,cotiza FROM personas_cotiza WHERE estado=1 AND id_persona=" + EntradaProveedor.Elemento.Id.ToString());
                        if (rowProv != null)
                        {
                            if (rowProv.Fields["id_moneda"].ValueInt != 0)
                            {
                                Lbl.Entidades.Moneda mon = new Lbl.Entidades.Moneda(this.Connection, rowProv.Fields["id_moneda"].ValueInt);
                                EntradaMoneda.Elemento = mon;
                                EntradaCotiza.ValueDecimal = rowProv.Fields["cotiza"].ValueDecimal;
                            }
                        }
                    }
                    else
                    {
                        EntradaCotizaPor.ErrorText = "Debe seleccionar un proveedor";
                        EntradaMoneda.Elemento = null;
                        EntradaMoneda.Text = "";
                        EntradaCotiza.ValueDecimal = 0;
                    }

                    break;
            }
            switch (EntradaCotizaPor.TextKey)
            {
                case "0":
                    EntradaCosto.Focus();
                    break;
                case "1":
                    EntradaMoneda.Focus();
                    break;
                case "2":
                    if (EntradaProveedor.Elemento != null)
                        EntradaMargen.Focus();
                    else
                        EntradaProveedor.Focus();
                    break;
            }
        }

        private void EntradaMoneda_TextChanged(object sender, EventArgs e)
        {
            if (EntradaMoneda.Enabled && EntradaMoneda.Elemento != null)
            {
                Lfx.Data.Row rowCotiza = this.Connection.FirstRowFromSelect("SELECT cotizacion FROM monedas WHERE id_moneda=" + this.EntradaMoneda.Elemento.Id.ToString());
                if (rowCotiza != null)
                {
                    EntradaCotiza.ValueDecimal = Convert.ToDecimal(rowCotiza["cotizacion"]);
                    EntradaCosto.Focus();
                }
            }
        }

        private void EntradaCotiza_TextChanged(object sender, EventArgs e)
        {
            if (IgnorarCostoMargenPvpPvpIvaTextChanged != 0)
                IgnorarCostoMargenPvpPvpIvaTextChanged--;
            EntradaCostoMargen_TextChanged(sender, e);
        }

        private void EntradaProveedor_TextChanged(object sender, EventArgs e)
        {
            if (EntradaProveedor.Elemento != null)
            {
                Lfx.Data.Row rowProv = this.Connection.FirstRowFromSelect("SELECT id_moneda,cotiza FROM personas_cotiza WHERE estado=1 AND id_persona=" + EntradaProveedor.Elemento.Id.ToString());
                if (rowProv != null)
                {
                    Lbl.Entidades.Moneda mon = new Lbl.Entidades.Moneda(this.Connection, rowProv.Fields["id_moneda"].ValueInt);
                    EntradaMoneda.Elemento = mon;
                    EntradaCotiza.ValueDecimal = rowProv.Fields["cotiza"].ValueDecimal;

                }
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var formBarra = new ImprimirBarras();
            string nomart = EntradaModelo.TextRaw != "" ? EntradaModelo.TextRaw : EntradaNombre.TextRaw;
            formBarra.ArticuloaImprimir = new ImprimirArticulo(this.Elemento.Id, nomart, EntradaCodigo1.TextRaw, EntradaCodigo2.TextRaw, EntradaCodigo3.TextRaw, EntradaCodigo4.TextRaw);
            formBarra.ShowDialog();
        }
    }
}