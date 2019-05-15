using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Compra
{
    public class Inicio : Lfc.FormularioListado
    {
        private int m_Estado = -2;
        private string m_Tipo = "FP";
        private Lbl.Personas.Persona m_Proveedor;
        private Lfx.Types.DateRange m_Fechas = new Lfx.Types.DateRange("mes-0");
        private List<ExcelReg> excReg = new List<ExcelReg>();
        //Requiere permisos de comprobantes con articulos 
        public Inicio()
        {
            NombrePagina = "FacturaCompra";
            int limitOpciones = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingInt("Paginar", NombrePagina, 999999);
            this.Limit = limitOpciones;
            this.Definicion = new Lazaro.Pres.Listings.Listing()
            {
                ElementoTipo = typeof(Lbl.Comprobantes.ComprobanteDeCompra),

                TableName = "comprob",
                Joins = new qGen.JoinCollection() {
                                        new qGen.Join("comprob_detalle", "comprob.id_comprob=comprob_detalle.id_comprob"),
                                        new qGen.Join("personas", "comprob.id_cliente=personas.id_persona")
                                },
                KeyColumn = new Lazaro.Pres.Field("comprob.id_comprob", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                GroupBy = new Lazaro.Pres.Field("comprob.id_comprob", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                OrderBy = "comprob.fecha DESC",
                Paging = true,
                Acciones = new List<string[]>() { new string[] { "Exportar a Excel", "ExportarExcel" } },
                Columns = new Lazaro.Pres.FieldCollection()
                    {
                        new Lazaro.Pres.Field("comprob.tipo_fac", "Tipo", Lfx.Data.InputFieldTypes.Text, 48),
                        new Lazaro.Pres.Field("comprob.pv", "PV", Lfx.Data.InputFieldTypes.Integer, 80),
                        new Lazaro.Pres.Field("comprob.numero", "Número", Lfx.Data.InputFieldTypes.Integer, 120),
                        new Lazaro.Pres.Field("comprob.fecha", "Fecha", Lfx.Data.InputFieldTypes.Date, 96),
                        new Lazaro.Pres.Field("personas.nombre_visible", "Proveedor", Lfx.Data.InputFieldTypes.Relation, 160),
                        new Lazaro.Pres.Field("comprob.total", "Total", Lfx.Data.InputFieldTypes.Currency, 96),
                                        new Lazaro.Pres.Field("comprob.total-comprob.cancelado AS pendiente", "Pendiente", Lfx.Data.InputFieldTypes.Currency, 96),
                        new Lazaro.Pres.Field("comprob.estado", "Estado", Lfx.Data.InputFieldTypes.Text, 0),
                                        new Lazaro.Pres.Field("comprob.id_formapago", "Pago", Lfx.Data.InputFieldTypes.Text, 0)
                    },

                ExtraSearchColumns = new Lazaro.Pres.FieldCollection()
                    {
                        new Lazaro.Pres.Field("comprob_detalle.series", "Números de Serie", Lfx.Data.InputFieldTypes.Text, 0),
                        new Lazaro.Pres.Field("comprob.obs", "Observaciones", Lfx.Data.InputFieldTypes.Memo, 0)
                    },

                Filters = new Lazaro.Pres.Filters.FilterCollection()
                                {
                                        new Lazaro.Pres.Filters.SetFilter("Tipo", "comprob.tipo_fac", new string[] {
                                                "Notas de Pedido|NP",
                                                "Pedidos|PD",
                                                "Remitos|R",
                                                "Facturas A|FA",
                                                "Facturas B|FB",
                                                "Facturas C|FC",
                                                "Facturas E|FE",
                                                "Facturas M|FM",
                                                "Tickets|T",
                                                "Notas de Crédito|NC",
                                                "Notas de Débito|ND",
                                                "Facturas (todas)|FP",
                                                "Todo|*" }, "NP"),
                                        new Lazaro.Pres.Filters.SetFilter("Estado", "comprob.estado", new string[] {
                                                "Todos|-2",
                                                "No pedidos|-1",
                                                "Pedidos|100",
                                                "Cancelados|200" }, "-2"),
                                        new Lazaro.Pres.Filters.RelationFilter("Proveedor", new Lazaro.Orm.Data.Relation("comprob.id_cliente", "personas", "id_persona", "nombre_visible"), new qGen.Where("(tipo&2)=2")),
                                        new Lazaro.Pres.Filters.DateRangeFilter("Fecha", "comprob.fecha", new Lfx.Types.DateRange("mes-0"), true)
                                }
            };

            this.Tipo = "FP";
            this.Estado = -2;
            this.Fechas = new Lfx.Types.DateRange("mes-0");
            this.Fechas.ConHora = true;
            this.FixedFilters.AddWithValue("comprob.anulada", 0);
            this.Contadores.Add(new Contador("Total", Lui.Forms.DataTypes.Currency));
            this.Contadores.Add(new Contador("Pendiente", Lui.Forms.DataTypes.Currency));

            this.HabilitarFiltrar = true;
            this.HabilitarBorrar = true;
            this.Text = "Listado de Factura de Compras";
        }


        public Inicio(string comando)
                : this()
        {
            this.Tipo = comando;
        }


        public override void OnFiltersChanged(Lazaro.Pres.Filters.FilterCollection filters)
        {
            this.Tipo = this.Definicion.Filters["comprob.tipo_fac"].Value as string;
            this.Estado = Lfx.Types.Parsing.ParseInt(this.Definicion.Filters["comprob.estado"].Value as string);
            this.Proveedor = this.Definicion.Filters["comprob.id_cliente"].Value as Lbl.Personas.Persona;
            this.Fechas = this.Definicion.Filters["comprob.fecha"].Value as Lfx.Types.DateRange;

            base.OnFiltersChanged(filters);
        }


        public string Tipo {
            get {
                return m_Tipo;
            }
            set {
                if (value != m_Tipo)
                {
                    Lazaro.Pres.Filters.SetFilter SetFil = this.Definicion.Filters["comprob.estado"] as Lazaro.Pres.Filters.SetFilter;
                    switch (value)
                    {
                        case "NP":
                            SetFil.SetData = new string[] {
                                                                "Todos|-2",
                                                                "No pedidos|-1",
                                                                "Pedidos|100",
                                                                "Cancelados|200"
                                    };
                            this.Estado = -2;
                            break;
                        case "PD":
                            SetFil.SetData = new string[] {
                                        "Todos|-2",
                                        "Sin especificar|0",
                                        "No recibidos|-1",
                                        "Recibidos|100"
                                    };
                            this.Estado = -2;
                            break;
                        default:
                            SetFil.SetData = new string[] { "Todos|-2" };
                            this.Estado = -2;
                            break;
                    }
                }

                m_Tipo = value;
                this.Definicion.Filters["comprob.tipo_fac"].Value = value;
            }
        }

        public int Estado {
            get {
                return m_Estado;
            }
            set {
                m_Estado = value;
                this.Definicion.Filters["comprob.estado"].Value = value.ToString();
            }
        }


        public Lfx.Types.DateRange Fechas {
            get {
                return m_Fechas;
            }
            set {
                m_Fechas = value;
                this.Definicion.Filters["comprob.fecha"].Value = value;
            }
        }


        public Lbl.Personas.Persona Proveedor {
            get {
                return m_Proveedor;
            }
            set {
                m_Proveedor = value;
                this.Definicion.Filters["comprob.id_cliente"].Value = value;
            }
        }


        public override Lbl.IElementoDeDatos Crear()
        {
            Lbl.IElementoDeDatos Res = base.Crear();
            if (Res is Lbl.Comprobantes.ComprobanteDeCompra)
            {
                string Tipo = this.Tipo;
                using (Crear FormCrear = new Crear())
                {
                    FormCrear.TipoComprob = Tipo;
                    if (FormCrear.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Tipo = FormCrear.TipoComprob;
                    }
                    else
                    {
                        return null;
                    }
                }
                Lbl.Comprobantes.ComprobanteDeCompra Comprob = Res as Lbl.Comprobantes.ComprobanteDeCompra;

                switch (Tipo)
                {
                    case "FP":
                        Tipo = "FA";
                        break;
                    case "NC":
                        Tipo = "NCA";
                        break;
                    case "ND":
                        Tipo = "NDA";
                        break;
                }

                if (Lbl.Comprobantes.Tipo.TodosPorLetra.ContainsKey(Tipo))
                {
                    Comprob.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra[Tipo];
                }
                else
                {

                    throw new InvalidOperationException("No se puede crear el tipo " + Tipo);
                }
            }
            return Res;
        }


        protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
        {
            item.SubItems["comprob.pv"].Text = row.Fields["comprob.pv"].ValueInt.ToString("0000");
            item.SubItems["comprob.numero"].Text = row.Fields["comprob.numero"].ValueInt.ToString("00000000");
            Contadores[0].AddValue(row.Fields["comprob.total"].ValueDecimal);
            Contadores[1].AddValue(row.Fields["pendiente"].ValueDecimal);

            //Lfx.Data.Row Persona = this.Connection.Tables["personas"].FastRows[row.Fields["comprob.id_cliente"].ValueInt];
            //if (Persona != null)
            //        item.SubItems["comprob.id_cliente"].Text = Persona.Fields["personas.nombre_visible"].ToString();

            switch (row.Fields["comprob.estado"].ValueInt)
            {
                case 50:
                    item.ForeColor = Color.DarkOrange;//A Pedir//En Camino
                    break;
                case 100:
                    item.ForeColor = Color.DarkGreen;//Pedidos//Recibidos
                    break;
                case 200:
                    item.ForeColor = Color.DarkRed;//Cancelados
                    item.Font = new Font(item.Font, System.Drawing.FontStyle.Strikeout);
                    break;
            }

            if (row.Fields["comprob.id_formapago"] != null)
            {
                switch (row.Fields["id_formapago"].ValueInt)
                {
                    case 3:
                        //Controla Pago
                        break;
                    default:
                        item.SubItems["comprob.total-comprob.cancelado AS pendiente"].Text = "";
                        break;
                }
            }
        }


        protected override void OnBeginRefreshList()
        {
            this.CustomFilters.Clear();
            this.CustomFilters.AddWithValue("compra", 1);
            switch (Tipo)
            {
                case "NP":
                    this.CustomFilters.AddWithValue("comprob.tipo_fac", "NP");
                    if (this.Estado == -1)
                        this.CustomFilters.AddWithValue("(comprob.estado<=50)");
                    this.Text = "Listado Notas de Pedidos";
                    break;

                case "PD":
                    this.CustomFilters.AddWithValue("comprob.tipo_fac", "PD");
                    if (this.Estado == -1)
                        this.CustomFilters.AddWithValue("(comprob.estado<=50)");
                    this.Text = "Listado de Pedidos";
                    break;

                case "FP":
                    this.CustomFilters.AddWithValue("comprob.tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM')");
                    this.Text = "Listado de Compras";
                    break;

                case "NC":
                    this.CustomFilters.AddWithValue("comprob.tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM')");
                    this.Text = "Listado de NC Proveedor";
                    break;

                case "ND":
                    this.CustomFilters.AddWithValue("comprob.tipo_fac IN ('NDA', 'NDB', 'NDC', 'NDE', 'NDM')");
                    this.Text = "Listado de ND Proveedor";
                    break;

                case "RP":
                    this.CustomFilters.AddWithValue("comprob.tipo_fac", "R");
                    this.Text = "Listado de Remitos Compras";
                    break;
                case "FA":
                case "FB":
                case "FC":
                case "FE":
                case "FM":
                default:
                    this.CustomFilters.AddWithValue("comprob.tipo_fac", Tipo);
                    break;
            }

            if (this.Proveedor != null)
                this.CustomFilters.AddWithValue("comprob.id_cliente", this.Proveedor.Id);

            if (this.Estado >= 0)
                this.CustomFilters.AddWithValue("comprob.estado", this.Estado);

            if (this.Fechas.HasRange)
            {
                if (this.Fechas.ConHora)
                    this.CustomFilters.AddWithValue("(comprob.fecha BETWEEN '" + Lfx.Types.Formatting.FormatDateTimeSql(this.Fechas.From) + "' AND '" + Lfx.Types.Formatting.FormatDateTimeSql(this.Fechas.To) + "')");
                else
                    this.CustomFilters.AddWithValue("(comprob.fecha BETWEEN '" + Lfx.Types.Formatting.FormatDateSql(this.Fechas.From) + " 00:00:00' AND '" + Lfx.Types.Formatting.FormatDateSql(this.Fechas.To) + " 23:59:59')");
            }


            base.OnBeginRefreshList();
        }


        public override Lfx.Types.OperationResult SolicitudEliminacion(Lbl.ListaIds codigos)
        {
            Lfx.Workspace.Master.RunTime.Execute("INSTANCIAR Lfc.Comprobantes.Facturas.Anular " + codigos[0].ToString() + "®1");
            return new Lfx.Types.SuccessOperationResult();
        }

        public void ExportarExcel(object sender, System.EventArgs e)
        {
            if (Listado.SelectedItems.Count > 0)
            {
                int ID = int.Parse(Listado.SelectedItems[0].Text);


                SaveFileDialog DialogoGuardar = new SaveFileDialog();
                DialogoGuardar.OverwritePrompt = true;
                DialogoGuardar.ValidateNames = true;
                DialogoGuardar.CheckPathExists = true;
                DialogoGuardar.DefaultExt = ".xlsx";
                DialogoGuardar.Filter = "Microsoft Excel 2007-2013|*.xlsx";
                DialogoGuardar.FileName = this.Text.Replace(":", "");
                if (DialogoGuardar.ShowDialog() == DialogResult.OK)
                {
                    Lazaro.Pres.Spreadsheet.Workbook Workbook = ToWorkbookDetalle(ID);
                    Lazaro.Pres.Spreadsheet.WorkBookLeo typeByte = new Lazaro.Pres.Spreadsheet.WorkBookLeo();
                    //typeByte.StartExcel();
                    string FileName = DialogoGuardar.FileName;
                    try
                    {
                        Workbook.SaveTo(FileName, Lazaro.Pres.Spreadsheet.SaveFormats.Excel);
                        //System.IO.File.WriteAllBytes(FileName, content);
                    }
                    catch (Exception ex)
                    {
                        Lfx.Workspace.Master.RunTime.Toast("No se puede guardar el archivo. " + ex.Message, "Error");
                    }
                }

            }
        }

        public virtual Lazaro.Pres.Spreadsheet.Workbook ToWorkbookDetalle(int IDComprobante)
        {
            Lbl.Comprobantes.Factura selComprobante = new Lbl.Comprobantes.Factura(this.Connection, IDComprobante);

            Lazaro.Pres.Spreadsheet.Workbook Res = new Lazaro.Pres.Spreadsheet.Workbook();
            Lazaro.Pres.Spreadsheet.Sheet Sheet = new Lazaro.Pres.Spreadsheet.Sheet(this.Text + " Comprobante");
            Res.Sheets.Add(Sheet);


            int OrderColumn = -1;
            if (selComprobante != null)
            {
                for (int i = 0; i < 9; i++)
                {
                    ExcelReg nexc = new ExcelReg();
                    switch (i)
                    {
                        case 0:
                            nexc.name = "id_articulo";
                            nexc.desc = "Código";
                            nexc.alig = Lfx.Types.StringAlignment.Near;
                            nexc.width = 100;
                            nexc.fieldtype = Lfx.Data.InputFieldTypes.Integer;
                            break;
                        case 1:
                            nexc.name = "nombre";
                            nexc.desc = "Nombre";
                            nexc.alig = Lfx.Types.StringAlignment.Near;
                            nexc.width = 300;
                            nexc.fieldtype = Lfx.Data.InputFieldTypes.Text;
                            break;
                        case 2:
                            nexc.name = "descripcion";
                            nexc.desc = "Descripción";
                            nexc.alig = Lfx.Types.StringAlignment.Near;
                            nexc.width = 150;
                            nexc.fieldtype = Lfx.Data.InputFieldTypes.Text;
                            break;
                        case 3:
                            nexc.name = "cantidad";
                            nexc.desc = "Cantidad";
                            nexc.alig = Lfx.Types.StringAlignment.Near;
                            nexc.width = 80;
                            nexc.fieldtype = Lfx.Data.InputFieldTypes.Numeric;
                            break;
                        case 4:
                            nexc.name = "costo";
                            nexc.desc = "Costo";
                            nexc.alig = Lfx.Types.StringAlignment.Near;
                            nexc.width = 90;
                            nexc.fieldtype = Lfx.Data.InputFieldTypes.Currency;
                            break;
                        case 5:
                            nexc.name = "precio";
                            nexc.desc = "Precio Uni.";
                            nexc.alig = Lfx.Types.StringAlignment.Near;
                            nexc.width = 120;
                            nexc.fieldtype = Lfx.Data.InputFieldTypes.Currency;
                            break;
                        case 6:
                            nexc.name = "importe";
                            nexc.desc = "Importe";
                            nexc.alig = Lfx.Types.StringAlignment.Near;
                            nexc.width = 120;
                            nexc.fieldtype = Lfx.Data.InputFieldTypes.Currency;
                            break;
                        case 7:
                            nexc.name = "recargo";
                            nexc.desc = "Recargo";
                            nexc.alig = Lfx.Types.StringAlignment.Near;
                            nexc.width = 100;
                            nexc.fieldtype = Lfx.Data.InputFieldTypes.Currency;
                            break;
                        case 8:
                            nexc.name = "total";
                            nexc.desc = "Total";
                            nexc.alig = Lfx.Types.StringAlignment.Near;
                            nexc.width = 120;
                            nexc.fieldtype = Lfx.Data.InputFieldTypes.Currency;

                            break;
                    }
                    Lazaro.Pres.Spreadsheet.ColumnHeader ColHead = new Lazaro.Pres.Spreadsheet.ColumnHeader(nexc.desc, nexc.width);
                    ColHead.Name = Lazaro.Orm.Data.ColumnValue.GetNameOnly(nexc.name);
                    ColHead.TextAlignment = nexc.alig; ColHead.DataType = nexc.fieldtype; ColHead.Format = nexc.format; ColHead.Printable = true;
                    if (i == 8)
                        ColHead.TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.Sum;
                    Sheet.ColumnHeaders.Add(ColHead);
                    excReg.Add(nexc);

                }
            }

            // Exporto los renglones
            Lbl.Comprobantes.ColeccionDetalleArticulos detArt = selComprobante.Articulos;
            foreach (Lbl.Comprobantes.DetalleArticulo DtRow in detArt)
            {
                Lazaro.Pres.Spreadsheet.Row Reng = this.FormatArt(Sheet, DtRow);
                Sheet.Rows.Add(Reng);
            }

            if (OrderColumn >= 0)
            {
                if (m_GroupingColumnName != null)
                {
                    Sheet.SortByGroupAndColumn(OrderColumn, true);
                }
                else
                {
                    if (OrderColumn >= 0)
                        Sheet.Sort(OrderColumn, true);
                }
            }

            return Res;
        }

        protected Lazaro.Pres.Spreadsheet.Row FormatArt(Lazaro.Pres.Spreadsheet.Sheet sheet, Lbl.Comprobantes.DetalleArticulo useField)
        {
            Lazaro.Pres.Spreadsheet.Row Reng = new Lazaro.Pres.Spreadsheet.Row(sheet);

            int id_articulo = useField.Articulo == null ? 0 : useField.Articulo.Id;
            Lazaro.Pres.Spreadsheet.Cell NewCell = Reng.Cells.Add();
            ExcelReg e = excReg.Find(t => t.name == "id_articulo");
            NewCell = GetContent(NewCell, e, id_articulo);

            string nombre = useField.Nombre;
            NewCell = Reng.Cells.Add();
            e = excReg.Find(t => t.name == "nombre");
            NewCell = GetContent(NewCell, e, nombre);

            string descripcion = useField.Descripcion;

            NewCell = Reng.Cells.Add();
            e = excReg.Find(t => t.name == "descripcion");
            NewCell = GetContent(NewCell, e, descripcion);

            decimal cantidad = useField.Cantidad;
            NewCell = Reng.Cells.Add();
            e = excReg.Find(t => t.name == "cantidad");
            NewCell = GetContent(NewCell, e, cantidad);

            decimal costo = useField.Costo;
            NewCell = Reng.Cells.Add();
            e = excReg.Find(t => t.name == "costo");
            NewCell = GetContent(NewCell, e, costo);

            decimal precio = useField.ImporteUnitario;
            NewCell = Reng.Cells.Add();
            e = excReg.Find(t => t.name == "precio");
            NewCell = GetContent(NewCell, e, precio);

            decimal importe = useField.ImporteUnitarioFinal;
            NewCell = Reng.Cells.Add();
            e = excReg.Find(t => t.name == "importe");
            NewCell = GetContent(NewCell, e, importe);

            decimal recargo = useField.Recargo;
            NewCell = Reng.Cells.Add();
            e = excReg.Find(t => t.name == "recargo");
            NewCell = GetContent(NewCell, e, recargo);

            decimal total = useField.ImporteAImprimir;
            NewCell = Reng.Cells.Add();
            e = excReg.Find(t => t.name == "total");
            NewCell = GetContent(NewCell, e, total);

            return Reng;
        }

        protected Lazaro.Pres.Spreadsheet.Cell GetContent(Lazaro.Pres.Spreadsheet.Cell NewCell, ExcelReg e, object campo)
        {
            switch (e.fieldtype)
            {
                case Lfx.Data.InputFieldTypes.Integer:
                case Lfx.Data.InputFieldTypes.Serial:
                    if (campo == null || campo is DBNull)
                        NewCell.Content = null;
                    else if (e.format != "")
                        NewCell.Content = System.Convert.ToInt32(campo.ToString()).ToString(e.format);
                    else
                        NewCell.Content = campo.ToString();
                    break;

                case Lfx.Data.InputFieldTypes.Relation:
                case Lfx.Data.InputFieldTypes.Text:
                case Lfx.Data.InputFieldTypes.Memo:
                    if (campo == null)
                        NewCell.Content = null;
                    else if (campo is System.Byte[])
                        NewCell.Content = System.Text.Encoding.Default.GetString(((System.Byte[])(campo)));
                    else
                        NewCell.Content = campo.ToString();
                    break;

                case Lfx.Data.InputFieldTypes.Currency:
                    double ValorCur = (campo == null || campo is DBNull) ? 0 : System.Convert.ToDouble(campo.ToString());
                    NewCell.Content = ValorCur;
                    break;

                case Lfx.Data.InputFieldTypes.Numeric:
                    if (campo == null || campo is DBNull)
                        NewCell.Content = null;
                    else
                        NewCell.Content = System.Convert.ToDouble(campo.ToString());
                    break;

                case Lfx.Data.InputFieldTypes.Date:
                    if (campo != null)
                        NewCell.Content = campo.ToString();
                    break;

                case Lfx.Data.InputFieldTypes.DateTime:
                    NewCell.Content = campo;
                    break;

                case Lfx.Data.InputFieldTypes.Bool:
                    if (System.Convert.ToBoolean(campo))
                        NewCell.Content = "Sí";
                    else
                        NewCell.Content = "No";
                    break;
                default:
                    NewCell.Content = campo;
                    break;
            }
            return NewCell;
        }

    }

    public class ExcelReg
    {
        public string name { get; set; }
        public string desc { get; set; }
        public string format { get; set; }
        public int width { get; set; }
        public Lfx.Types.StringAlignment alig { get; set; }
        public Lfx.Data.InputFieldTypes fieldtype { get; set; }
    }
}
