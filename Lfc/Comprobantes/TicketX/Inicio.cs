using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.TicketX
{
    public class Inicio : Lfc.FormularioListado
    {
        private Lbl.Personas.Persona m_Proveedor;
        private Lfx.Types.DateRange m_Fechas = new Lfx.Types.DateRange("mes-0");
        private double totalRenglon = 0;
        //Requiere permisos de comprobantes con articulos 
        public Inicio()
        {
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
                Columns = new Lazaro.Pres.FieldCollection()
                    {
                        new Lazaro.Pres.Field("comprob.pv", "PV", Lfx.Data.InputFieldTypes.Integer, 80),
                        new Lazaro.Pres.Field("comprob.numero", "Número", Lfx.Data.InputFieldTypes.Integer, 120),
                        new Lazaro.Pres.Field("comprob.fecha", "Fecha", Lfx.Data.InputFieldTypes.Date, 96),
                        new Lazaro.Pres.Field("personas.nombre_visible", "Persona", Lfx.Data.InputFieldTypes.Relation, 160),
                        new Lazaro.Pres.Field("comprob.cancelado AS total", "Total", Lfx.Data.InputFieldTypes.Currency, 96),
                        new Lazaro.Pres.Field("comprob.estado", "Estado", Lfx.Data.InputFieldTypes.Text, 0),
                        new Lazaro.Pres.Field("comprob.id_formapago", "Pago", Lfx.Data.InputFieldTypes.Text, 96)
                    },

                Filters = new Lazaro.Pres.Filters.FilterCollection()
                    {
                            new Lazaro.Pres.Filters.RelationFilter("Persona", new Lazaro.Orm.Data.Relation("comprob.id_cliente", "personas", "id_persona", "nombre_visible")),
                            new Lazaro.Pres.Filters.DateRangeFilter("Fecha", "comprob.fecha", new Lfx.Types.DateRange("mes-0"), false)
                    }
            };

            this.Fechas = new Lfx.Types.DateRange("mes-0");
            this.Fechas.ConHora = true;
            this.FixedFilters.AddWithValue("comprob.anulada", 0);
            this.Contadores.Add(new Contador("Total", Lui.Forms.DataTypes.Currency));

            this.HabilitarCrear = false;
            this.HabilitarFiltrar = true;
            this.HabilitarBorrar = false;
            this.Text = "Listado de Cobranzas";
        }


        public Inicio(string comando)
                : this()
        {
        }


        public override void OnFiltersChanged(Lazaro.Pres.Filters.FilterCollection filters)
        {
            this.Proveedor = this.Definicion.Filters["comprob.id_cliente"].Value as Lbl.Personas.Persona;
            this.Fechas = this.Definicion.Filters["comprob.fecha"].Value as Lfx.Types.DateRange;

            base.OnFiltersChanged(filters);
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



        protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
        {
            item.SubItems["comprob.pv"].Text = row.Fields["comprob.pv"].ValueInt.ToString("0000");
            item.SubItems["comprob.numero"].Text = row.Fields["comprob.numero"].ValueInt.ToString("00000000");
            Contadores[0].AddValue(row.Fields["pendiente"].ValueDecimal);

            if (row.Fields["comprob.id_formapago"] != null)
            {
                int idFormPago = row.Fields["id_formapago"].ValueInt;
                Lfx.Data.Row formPago = Lfx.Workspace.Master.Tables["formaspago"].FastRows[idFormPago];
                switch (idFormPago)
                {
                    case 1:
                    case 3:
                        //Controla Pago
                        break;
                    default:
                        item.SubItems["comprob.cancelado AS total"].Text = "";
                        break;
                }
                if (formPago != null)
                    item.SubItems["comprob.id_formapago"].Text = formPago.Fields["nombre"].Value.ToString();
            }
        }

        protected override Lfx.Types.OperationResult OnEdit(int itemId)
        {
            return new Lfx.Types.SuccessOperationResult();
        }

        protected override void OnBeginRefreshList()
        {
            this.CustomFilters.Clear();
            this.CustomFilters.AddWithValue("comprob.tipo_fac", "TX");


            if (this.Proveedor != null)
                this.CustomFilters.AddWithValue("comprob.id_cliente", this.Proveedor.Id);

            if (this.Fechas.HasRange)
            {
                if (this.Fechas.RangeType == Lfx.Types.DateRangeTypes.Day)
                    this.CustomFilters.AddWithValue("(comprob.fecha BETWEEN '" + Lfx.Types.Formatting.FormatDateSql(m_Fechas.From) + " 00:00:00' AND '" + Lfx.Types.Formatting.FormatDateSql(m_Fechas.To) + " 23:59:59')");
                else if (this.Fechas.ConHora)
                    this.CustomFilters.AddWithValue("(comprob.fecha BETWEEN '" + Lfx.Types.Formatting.FormatDateTimeSql(this.Fechas.From) + "' AND '" + Lfx.Types.Formatting.FormatDateTimeSql(this.Fechas.To) + "')");
                else
                    this.CustomFilters.AddWithValue("(comprob.fecha BETWEEN '" + Lfx.Types.Formatting.FormatDateSql(this.Fechas.From) + " 00:00:00' AND '" + Lfx.Types.Formatting.FormatDateSql(this.Fechas.To) + " 23:59:59')");
            }


            base.OnBeginRefreshList();
        }

        protected override void ShowExportDialog()
        {
            if (Listado.Items.Count == 0)
            {
                Lfx.Workspace.Master.RunTime.Toast("No se puede imprimir o exportar el listado porque no contiene datos.", "Listado");
                return;
            }

            using (Lfc.FormularioListadoExportar FormExportar = new Lfc.FormularioListadoExportar())
            {
                if (FormExportar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FormatoExportar Formato = FormExportar.SaveFormat;
                    if (Formato == FormatoExportar.Imprimir)
                    {
                        this.OnPrint(false);
                    }
                    else if (Formato == FormatoExportar.ImprimirAvanzado)
                    {
                        this.OnPrint(true);
                    }
                    else
                    {
                        SaveFileDialog DialogoGuardar = new SaveFileDialog();
                        DialogoGuardar.OverwritePrompt = true;
                        DialogoGuardar.ValidateNames = true;
                        DialogoGuardar.CheckPathExists = true;
                        switch (Formato)
                        {
                            case FormatoExportar.Html:
                                DialogoGuardar.DefaultExt = ".html";
                                DialogoGuardar.Filter = "Formato HTML|*.htm;*.html";
                                break;
                            case FormatoExportar.Excel:
                                DialogoGuardar.DefaultExt = ".xlsx";
                                DialogoGuardar.Filter = "Microsoft Excel 2007-2013|*.xlsx";
                                break;
                        }

                        DialogoGuardar.FileName = this.Text.Replace(":", "");
                        if (DialogoGuardar.ShowDialog() == DialogResult.OK)
                        {
                            Lazaro.Pres.Spreadsheet.Workbook Workbook = this.ToWorkbook();
                            string FileName = DialogoGuardar.FileName;
                            this.OnExport(FileName, Formato);
                            try
                            {
                                switch (Formato)
                                {
                                    case FormatoExportar.Html:
                                        Workbook.SaveTo(FileName, Lazaro.Pres.Spreadsheet.SaveFormats.Html);
                                        break;
                                    case FormatoExportar.Excel:
                                        Workbook.SaveTo(FileName, Lazaro.Pres.Spreadsheet.SaveFormats.Excel);
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Lfx.Workspace.Master.RunTime.Toast("No se puede guardar el archivo. " + ex.Message, "Error");
                            }
                        }
                    }
                }
            }
        }

        public override Lfx.Types.OperationResult OnPrint(bool selectPrinter)
        {
            if (Listado.Items.Count == 0)
                return new Lfx.Types.FailureOperationResult("El listado está vacío");

            Lazaro.Pres.Spreadsheet.Workbook Workbook = this.ToWorkbook();
            Lazaro.Base.Util.Impresion.ImpresorListado Impresor = new Lazaro.Base.Util.Impresion.ImpresorListado(Workbook.Sheets[0], null);

            if (selectPrinter)
            {
                using (Lui.Printing.PrinterSelectionDialog SeleccionarImpresroa = new Lui.Printing.PrinterSelectionDialog())
                {
                    if (SeleccionarImpresroa.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Impresor.Impresora = SeleccionarImpresroa.SelectedPrinter;
                    }
                    else
                    {
                        return new Lfx.Types.CancelOperationResult();
                    }
                }
                using (PageSetupDialog PreferenciasDeImpresion = new PageSetupDialog())
                {
                    //PreferenciasDeImpresion.PrinterSettings = Impresor.PrinterSettings;
                    PreferenciasDeImpresion.Document = Impresor;
                    PreferenciasDeImpresion.AllowPrinter = true;
                    PreferenciasDeImpresion.AllowPaper = true;
                    if (PreferenciasDeImpresion.ShowDialog(this) == DialogResult.OK)
                    {
                        return Impresor.Imprimir();
                    }
                    else
                    {
                        return new Lfx.Types.CancelOperationResult();
                    }
                }
            }
            else
            {
                // Sin diálogo de selección de impresora
                return Impresor.Imprimir();
            }
        }

        public override Lazaro.Pres.Spreadsheet.Workbook ToWorkbook(Lazaro.Pres.FieldCollection useFields)
        {
            Lazaro.Pres.Spreadsheet.Workbook Res = new Lazaro.Pres.Spreadsheet.Workbook();
            Lazaro.Pres.Spreadsheet.Sheet Sheet = new Lazaro.Pres.Spreadsheet.Sheet(this.Text);
            Res.Sheets.Add(Sheet);

            // Exporto los encabezados de columna
            if (this.Definicion.KeyColumn.Printable)
            {
                Sheet.ColumnHeaders.Add(new Lazaro.Pres.Spreadsheet.ColumnHeader(this.Definicion.KeyColumn.Label, this.Definicion.KeyColumn.Width));
                Sheet.ColumnHeaders[0].DataType = this.Definicion.KeyColumn.DataType;
                Sheet.ColumnHeaders[0].Format = this.Definicion.KeyColumn.Format;
                Sheet.ColumnHeaders[0].Printable = this.Definicion.KeyColumn.Printable;
            }

            int OrderColumn = -1;
            if (useFields != null)
            {
                for (int i = 0; i <= useFields.Count - 1; i++)
                {
                    if (useFields[i].Printable)
                    {
                        Lazaro.Pres.Spreadsheet.ColumnHeader ColHead = new Lazaro.Pres.Spreadsheet.ColumnHeader(useFields[i].Label, useFields[i].Width);
                        ColHead.Name = Lazaro.Orm.Data.ColumnValue.GetNameOnly(useFields[i].Name);
                        ColHead.TextAlignment = useFields[i].Alignment;
                        ColHead.DataType = useFields[i].DataType;
                        ColHead.Format = useFields[i].Format;
                        ColHead.TotalFunction = useFields[i].TotalFunction;
                        ColHead.Printable = useFields[i].Printable;
                        Sheet.ColumnHeaders.Add(ColHead);

                        if (ColHead.Name == this.Definicion.OrderBy)
                            OrderColumn = Sheet.ColumnHeaders.Count - 1;

                        if (ColHead.Name == this.GroupingColumnName)
                            Sheet.ColumnHeaders.GroupingColumn = Sheet.ColumnHeaders.Count - 1;
                    }
                }
            }

            // Exporto los renglones
            System.Data.DataTable Tabla = this.Connection.Select(this.SelectCommand());
            int lastItemId = -1;
            foreach (System.Data.DataRow DtRow in Tabla.Rows)
            {
                Lfx.Data.Row Registro = (Lfx.Data.Row)DtRow;

                string NombreCampoId = Lazaro.Orm.Data.ColumnValue.GetNameOnly(this.Definicion.KeyColumn.Name);
                int ItemId = Registro.Fields[NombreCampoId].ValueInt;
                lastItemId = ItemId;
                Lazaro.Pres.Spreadsheet.Row Reng = this.FormatRow(ItemId, Registro, Sheet, useFields);

                Sheet.Rows.Add(Reng);
            }

            Lazaro.Pres.Spreadsheet.Row RengSum = this.FormatRowSum(Sheet, useFields);

            Sheet.Rows.Add(RengSum);

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
            //Sheet.Workbook.Sheets.Find("").Rows.tot

            return Res;
        }

        protected override Lazaro.Pres.Spreadsheet.Row FormatRow(int itemId, Lfx.Data.Row row, Lazaro.Pres.Spreadsheet.Sheet sheet, Lazaro.Pres.FieldCollection useFields)
        {
            Lazaro.Pres.Spreadsheet.Row Reng = new Lazaro.Pres.Spreadsheet.Row(sheet);

            if (this.Definicion.KeyColumn != null && this.Definicion.KeyColumn.Printable)
            {
                Lazaro.Pres.Spreadsheet.Cell KeyCell = Reng.Cells.Add();
                KeyCell.Content = itemId;
            }

            for (int FieldNum = 0; FieldNum < useFields.Count; FieldNum++)
            {
                if (useFields[FieldNum].Printable)
                {

                    string FieldName = Lazaro.Orm.Data.ColumnValue.GetNameOnly(useFields[FieldNum].Name);

                    if (FieldNum >= 0)
                    {
                        Lazaro.Pres.Spreadsheet.Cell NewCell = Reng.Cells.Add();

                        switch (useFields[FieldNum].DataType)
                        {
                            case Lfx.Data.InputFieldTypes.Integer:
                            case Lfx.Data.InputFieldTypes.Serial:
                                if (row[FieldName] == null || row[FieldName] is DBNull)
                                    NewCell.Content = null;
                                else if (useFields[FieldNum].Format != null)
                                    NewCell.Content = System.Convert.ToInt32(row[FieldName]).ToString(useFields[FieldNum].Format);
                                else
                                    NewCell.Content = row[FieldName].ToString();
                                break;

                            case Lfx.Data.InputFieldTypes.Relation:
                            case Lfx.Data.InputFieldTypes.Text:
                            case Lfx.Data.InputFieldTypes.Memo:
                                if (row[FieldName] == null)
                                    NewCell.Content = null;
                                else if (FieldName == "comprob.id_formapago")
                                {
                                    Lfx.Data.Row formPago = Lfx.Workspace.Master.Tables["formaspago"].FastRows[System.Convert.ToInt32(row[FieldName])];
                                    if (formPago != null)
                                        NewCell.Content = formPago.Fields["nombre"].Value.ToString();
                                    else
                                        NewCell.Content = row.Fields[FieldName].Value.ToString();
                                }
                                else if (row[FieldName] is System.Byte[])
                                    NewCell.Content = System.Text.Encoding.Default.GetString(((System.Byte[])(row[FieldName])));
                                else
                                    NewCell.Content = row.Fields[FieldName].Value.ToString();
                                break;

                            case Lfx.Data.InputFieldTypes.Currency:
                                double ValorCur = (row[FieldName] == null || row[FieldName] is DBNull) ? 0 : System.Convert.ToDouble(row[FieldName]);
                                NewCell.Content = ValorCur;
                                if (FieldName == "total")
                                    totalRenglon += ValorCur;
                                break;

                            case Lfx.Data.InputFieldTypes.Numeric:
                                if (row[FieldName] == null || row[FieldName] is DBNull)
                                    NewCell.Content = null;
                                else
                                    NewCell.Content = System.Convert.ToDouble(row[FieldName]);
                                break;

                            case Lfx.Data.InputFieldTypes.Date:
                                if (row.Fields[FieldName].Value != null)
                                    NewCell.Content = row.Fields[FieldName].ValueDateTime;
                                break;

                            case Lfx.Data.InputFieldTypes.DateTime:
                                NewCell.Content = row[FieldName];
                                break;

                            case Lfx.Data.InputFieldTypes.Bool:
                                if (System.Convert.ToBoolean(row[FieldName]))
                                    NewCell.Content = "Sí";
                                else
                                    NewCell.Content = "No";
                                break;

                            case Lfx.Data.InputFieldTypes.Set:
                                int SetValue = System.Convert.ToInt32(row[FieldName]);
                                if (useFields[FieldNum] != null && useFields[FieldNum].SetValues != null & useFields[FieldNum].SetValues.ContainsKey(SetValue))
                                    NewCell.Content = useFields[FieldNum].SetValues[SetValue];
                                else
                                    NewCell.Content = "???";
                                break;

                            default:
                                NewCell.Content = row[FieldName];
                                break;
                        }
                    }
                }
            }

            return Reng;
        }

        private Lazaro.Pres.Spreadsheet.Row FormatRowSum(Lazaro.Pres.Spreadsheet.Sheet sheet, Lazaro.Pres.FieldCollection useFields)
        {
            Lazaro.Pres.Spreadsheet.Row Reng = new Lazaro.Pres.Spreadsheet.Row(sheet);

            if (this.Definicion.KeyColumn != null && this.Definicion.KeyColumn.Printable)
            {
                Lazaro.Pres.Spreadsheet.Cell KeyCell = Reng.Cells.Add();
                KeyCell.Content = "-->";
            }

            for (int FieldNum = 0; FieldNum < useFields.Count; FieldNum++)
            {
                if (useFields[FieldNum].Printable)
                {

                    string FieldName = Lazaro.Orm.Data.ColumnValue.GetNameOnly(useFields[FieldNum].Name);

                    if (FieldNum >= 0)
                    {
                        Lazaro.Pres.Spreadsheet.Cell NewCell = Reng.Cells.Add();
                        if (FieldName == "total")
                            NewCell.Content = totalRenglon;
                        else
                            NewCell.Content = "";
                    }
                }
            }

            return Reng;
        }

    }
}
