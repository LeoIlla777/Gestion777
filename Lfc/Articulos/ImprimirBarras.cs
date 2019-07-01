using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Articulos
{
    public partial class ImprimirBarras : Lui.Forms.ChildDialogForm
    {
        private const int HojaA4 = 210;
        private const int HojaTicket = 62;
        protected Lbl.Articulos.CodBar codigobarra = new Lbl.Articulos.CodBar();
        protected bool TieneRegistro = false, actualizaImpresora = false;
        protected string terminalName = Lfx.Environment.SystemInformation.MachineName;
        protected string sucursalActual = Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual.ToString();

        public ImprimirBarras()
        {
            InitializeComponent();
            CargoDatos();
            if (codigobarra != null && codigobarra.Impresora != null && TieneRegistro)
            {
                cbHoja.ValueInt = codigobarra.Hoja;
                cbNombre.Checked = codigobarra.Nombre;
                EntradaCantidad.ValueInt = codigobarra.Cantidad;
                cbEncoding.ValueInt = codigobarra.TipoCodBar;
                txtWidth.ValueInt = codigobarra.Width;
                txtHeight.ValueInt = codigobarra.Height;
                actualizaImpresora = false;
                btnAplicar_Click(null, null);
                actualizaImpresora = true;
            }
        }

        protected void CargoDatos()
        {
            qGen.Select SelectConfig = new qGen.Select("sys_config");
            SelectConfig.Columns = new qGen.SqlIdentifierCollection() { "nombre", "valor", "estacion", "id_sucursal" };
            SelectConfig.WhereClause = new qGen.Where("Grupo='L'");
            System.Data.DataTable TablaSysConfig = null;
            int Intentos = 3;
            while (true)
            {
                try
                {
                    TablaSysConfig = this.Connection.Select(SelectConfig);
                    break;
                }
                catch (Exception ex)
                {
                    Intentos--;
                    System.Threading.Thread.Sleep(1000);
                    if (Intentos <= 0)
                        throw ex;
                }
            }

            if (TablaSysConfig.Rows.Count > 0)
            {
                TieneRegistro = true;
                foreach (System.Data.DataRow CfgRow in TablaSysConfig.Rows)
                {
                    string Sucu;
                    if (CfgRow["id_sucursal"] == null)
                        Sucu = "0";
                    else
                        Sucu = CfgRow["id_sucursal"].ToString();

                    if (Sucu == "0" || (Sucu == sucursalActual))
                    {
                        string estacion = CfgRow["estacion"].ToString();
                        if (estacion == "*" || estacion == terminalName)
                            switch (CfgRow["nombre"].ToString())
                            {
                                case "CodBar.Impresora":
                                    codigobarra.Impresora = CfgRow["valor"].ToString();
                                    break;
                                case "CodBar.Nombre":
                                    codigobarra.Nombre = CfgRow["valor"].ToString() == "1" ? true : false;
                                    break;
                                case "CodBar.Width":
                                    codigobarra.Width = int.Parse(CfgRow["valor"].ToString());
                                    break;
                                case "CodBar.Height":
                                    codigobarra.Height = int.Parse(CfgRow["valor"].ToString());
                                    break;
                                case "CodBar.Cantidad":
                                    codigobarra.Cantidad = int.Parse(CfgRow["valor"].ToString());
                                    break;
                                case "CodBar.Hoja":
                                    codigobarra.Hoja = int.Parse(CfgRow["valor"].ToString());
                                    break;
                                case "CodBar.TipoCodBar":
                                    codigobarra.TipoCodBar = int.Parse(CfgRow["valor"].ToString());
                                    break;
                            }
                    }
                }
            }
        }

        public override Lfx.Types.OperationResult Ok()
        {
            PrintDialog print = new PrintDialog();
            print.Document = VistaPrevia.Document;
            print.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            //print.PrinterSettings.Copies
            print.PrinterSettings.PrinterName = codigobarra.Impresora;
            print.ShowDialog();

            documento1.PrinterSettings = print.PrinterSettings;
            documento1.Print();

            return new Lfx.Types.SuccessOperationResult();
        }

        private void ImprimirBarras_Load(object sender, EventArgs e)
        {
            this.cbEncoding.ValueInt = 14;
            this.cbHoja.TextKey = "1";
        }

        private void documento1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (actualizaImpresora)
            {
                codigobarra.Impresora = documento1.PrinterSettings.PrinterName;
                UpdateData();
            }
            BarCodeLeo.BarCodeLeo barcode = new BarCodeLeo.BarCodeLeo();

            string codigo = "";
            switch (EntradaMovimiento.ValueInt)
            {
                case 0:
                    codigo = ArticuloaImprimir.id_articulo.ToString();
                    break;
                case 1:
                    codigo = ArticuloaImprimir.Codigo1.ToString();
                    break;
                case 2:
                    codigo = ArticuloaImprimir.Codigo2.ToString();
                    break;
                case 3:
                    codigo = ArticuloaImprimir.Codigo3.ToString();
                    break;
                case 4:
                    codigo = ArticuloaImprimir.Codigo4.ToString();
                    break;
            }
            if (codigo.Trim().Length < 4)
            {
                Lui.Forms.MessageBox.Show("El código seleccionado es 3 carácteres, por favor seleccione otro donde sea de 4 o más", "Código Incorrecto!");
                return;
            }
            barcode.Alignment = BarCodeLeo.AlignmentPositions.CENTER;

            BarCodeLeo.TYPE typeBarCode = BarCodeLeo.TYPE.UNSPECIFIED;
            switch (cbEncoding.TextRaw.Trim())
            {
                case "UPC-A": typeBarCode = BarCodeLeo.TYPE.UPCA; break;
                case "UPC-E": typeBarCode = BarCodeLeo.TYPE.UPCE; break;
                case "UPC 2 Digit Ext.": typeBarCode = BarCodeLeo.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                case "UPC 5 Digit Ext.": typeBarCode = BarCodeLeo.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                case "EAN-13": typeBarCode = BarCodeLeo.TYPE.EAN13; break;
                case "JAN-13": typeBarCode = BarCodeLeo.TYPE.JAN13; break;
                case "EAN-8": typeBarCode = BarCodeLeo.TYPE.EAN8; break;
                case "ITF-14": typeBarCode = BarCodeLeo.TYPE.ITF14; break;
                case "Codabar": typeBarCode = BarCodeLeo.TYPE.Codabar; break;
                case "PostNet": typeBarCode = BarCodeLeo.TYPE.PostNet; break;
                case "Bookland/ISBN": typeBarCode = BarCodeLeo.TYPE.BOOKLAND; break;
                case "Code 11": typeBarCode = BarCodeLeo.TYPE.CODE11; break;
                case "Code 39": typeBarCode = BarCodeLeo.TYPE.CODE39; break;
                case "Code 39 Extended": typeBarCode = BarCodeLeo.TYPE.CODE39Extended; break;
                case "Code 39 Mod 43": typeBarCode = BarCodeLeo.TYPE.CODE39_Mod43; break;
                case "Code 93": typeBarCode = BarCodeLeo.TYPE.CODE93; break;
                case "LOGMARS": typeBarCode = BarCodeLeo.TYPE.LOGMARS; break;
                case "MSI": typeBarCode = BarCodeLeo.TYPE.MSI_Mod10; break;
                case "Interleaved 2 of 5": typeBarCode = BarCodeLeo.TYPE.Interleaved2of5; break;
                case "Standard 2 of 5": typeBarCode = BarCodeLeo.TYPE.Standard2of5; break;
                case "Code 128": typeBarCode = BarCodeLeo.TYPE.CODE128; break;
                case "Code 128-A": typeBarCode = BarCodeLeo.TYPE.CODE128A; break;
                case "Code 128-B": typeBarCode = BarCodeLeo.TYPE.CODE128B; break;
                case "Code 128-C": typeBarCode = BarCodeLeo.TYPE.CODE128C; break;
                case "Telepen": typeBarCode = BarCodeLeo.TYPE.TELEPEN; break;
                case "FIM": typeBarCode = BarCodeLeo.TYPE.FIM; break;
                case "Pharmacode": typeBarCode = BarCodeLeo.TYPE.PHARMACODE; break;
                default: MessageBox.Show("Please specify the encoding type."); break;
            }//switch


            barcode.AspectRatio = barcode.BarWidth = null;
            barcode.IncludeLabel = true;
            barcode.LabelPosition = BarCodeLeo.LabelPositions.BOTTOMCENTER;

            int x = 10;
            int y = 30;
            int width = (int)(txtWidth.ValueInt / 0.254);//2.54
            int height = (int)(txtHeight.ValueInt / 0.254);
            int RestaW = 10;
            int RestaH = 30;
            if (cbHoja.ValueInt == 1)
            {
                RestaW = (width / 2) / 4;
                RestaH = height / 2;
            }
            Image newImage = barcode.Encode(typeBarCode, codigo.Trim(), Color.Black, Color.White, width - RestaW, height - RestaH);
            string nombreArt = ArticuloaImprimir.Descripcion;
            if (nombreArt.Length > 30)
                nombreArt = nombreArt.Substring(0, 29);
            Font fntString = new Font("Times New Roman", cbHoja.ValueInt == 0 ? 8 : 7, FontStyle.Bold);
            for (int i = 0; i < EntradaCantidad.ValueInt; i++)
            {

                if (cbHoja.ValueInt == 0)
                {
                    if (cbNombre.Checked)
                        e.Graphics.DrawString(nombreArt, fntString, Brushes.Black, x, y - 10);
                    e.Graphics.DrawImage(newImage, x, y, width, height);
                }
                else
                {
                    if (cbNombre.Checked)
                        e.Graphics.DrawString(nombreArt, fntString, Brushes.Black, x, y - 25);
                    int newWid, newHei, newY;
                    newWid = width - (cbNombre.Checked ? 20 : 1);
                    newHei = height - (cbNombre.Checked ? 30 : 1);
                    newY = y - (cbNombre.Checked ? 5 : 25);
                    e.Graphics.DrawImage(newImage, x - 5, newY);//, newWid, newHei);
                }
                x += 150;
                if (cbHoja.ValueInt == 0 && x > (HojaA4 - width))
                {
                    x = 10;
                    y += height + 30;
                }
                else if (cbHoja.ValueInt == 1 && x > (HojaTicket - width))
                {
                    x = 10;
                    y += height + 30;
                }
            }
        }


        public ImprimirArticulo ArticuloaImprimir {
            get; set;
        }

        private void EntradaCantidad_TextChanged(object sender, EventArgs e)
        {

            //if (cbHoja.ValueInt != 0)
            //{
            //    System.Drawing.Printing.PaperSize paperSize = new System.Drawing.Printing.PaperSize("Ticket", 244, 45 * EntradaCantidad.ValueInt);
            //    documento1.DefaultPageSettings.PaperSize = paperSize;
            //}
            //VistaPrevia.Document = documento1;
            //VistaPrevia.Refresh();
        }

        private void btnZoomPlus_Click(object sender, EventArgs e)
        {
            if (VistaPrevia.Zoom < 1)
                VistaPrevia.Zoom += 0.1;
        }

        private void btnZoomMinus_Click(object sender, EventArgs e)
        {
            if (VistaPrevia.Zoom > 0.1)
                VistaPrevia.Zoom -= 0.1;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (cbHoja.ValueInt == 0)
            {
                System.Drawing.Printing.PaperSize paperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169);
                documento1.DefaultPageSettings.PaperSize = paperSize;
            }
            else
            {
                System.Drawing.Printing.PaperSize paperSize = new System.Drawing.Printing.PaperSize("Ticket", (int)(this.txtWidth.ValueInt / 0.254), (int)(this.txtHeight.ValueInt / 0.254) * EntradaCantidad.ValueInt);

                documento1.DefaultPageSettings.PaperSize = paperSize;
            }
            VistaPrevia.Document = documento1;
            VistaPrevia.Refresh();
            UpdateData();

        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
        }

        protected bool UpdateData()
        {
            bool correct = false;
            try
            {
                string stringValue = "";
                if (TieneRegistro)
                {
                    //Actualizar el valor
                    qGen.Update UpdateCommand = new qGen.Update("sys_config");
                    foreach (string field in codigobarra.Fields())
                    {
                        UpdateCommand.ColumnValues.Clear();
                        if (UpdateCommand.WhereClause != null)
                            UpdateCommand.WhereClause.Clear();

                        stringValue = ReturnValue(field);
                        UpdateCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("valor", Lazaro.Orm.ColumnTypes.VarChar, stringValue));
                        UpdateCommand.WhereClause = new qGen.Where();
                        UpdateCommand.WhereClause.Operator = qGen.AndOr.And;
                        UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("nombre", field));
                        UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("id_sucursal", sucursalActual));
                        UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("estacion", terminalName));
                        UpdateCommand.WhereClause.Add(new qGen.ComparisonCondition("Grupo", "L"));
                        Connection.Update(UpdateCommand);
                    }
                }
                else
                {
                    //Crear el valor
                    qGen.Insert InsertCommand = new qGen.Insert("sys_config");
                    foreach (string field in codigobarra.Fields())
                    {
                        InsertCommand.ColumnValues.Clear();

                        stringValue = ReturnValue(field);
                        InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("id_sucursal", Lazaro.Orm.ColumnTypes.Integer, sucursalActual));
                        InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("estacion", Lazaro.Orm.ColumnTypes.VarChar, terminalName));
                        InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("Grupo", Lazaro.Orm.ColumnTypes.VarChar, "L"));
                        InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("nombre", Lazaro.Orm.ColumnTypes.VarChar, field));
                        InsertCommand.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("valor", Lazaro.Orm.ColumnTypes.VarChar, stringValue));
                        Connection.Insert(InsertCommand);
                    }
                }
                correct = true;
            }
            catch (Exception exc)
            {
                correct = false;
                MessageBox.Show(exc.Message);
            }
            return correct;
        }

        protected string ReturnValue(string field)
        {
            string returVal = "";
            switch (field)
            {
                case "CodBar.Impresora":
                    returVal = codigobarra.Impresora == null ? "" : codigobarra.Impresora;
                    break;
                case "CodBar.Nombre":
                    codigobarra.Nombre = cbNombre.Checked;
                    if (cbNombre.Checked)
                        returVal = "1";
                    else
                        returVal = "0";
                    break;
                case "CodBar.Width":
                    codigobarra.Width = txtWidth.ValueInt;
                    returVal = txtWidth.ValueInt.ToString();
                    break;
                case "CodBar.Height":
                    codigobarra.Height = txtHeight.ValueInt;
                    returVal = txtHeight.ValueInt.ToString();
                    break;
                case "CodBar.Cantidad":
                    codigobarra.Cantidad = EntradaCantidad.ValueInt;
                    returVal = EntradaCantidad.ValueInt.ToString();
                    break;
                case "CodBar.Hoja":
                    codigobarra.Hoja = cbHoja.ValueInt;
                    returVal = cbHoja.ValueInt.ToString();
                    break;
                case "CodBar.TipoCodBar":
                    codigobarra.TipoCodBar = cbEncoding.ValueInt;
                    returVal = cbEncoding.ValueInt.ToString();
                    break;
            }
            return returVal;
        }
    }

    public class ImprimirArticulo
    {
        public int id_articulo { get; set; }
        public string Descripcion { get; set; }
        public string Codigo1 { get; set; }
        public string Codigo2 { get; set; }
        public string Codigo3 { get; set; }
        public string Codigo4 { get; set; }

        public ImprimirArticulo(int id, string des, string cod1, string cod2, string cod3, string cod4)
        {
            id_articulo = id;
            Descripcion = des;
            Codigo1 = cod1;
            Codigo2 = cod2;
            Codigo3 = cod3;
            Codigo4 = cod4;
        }
    }
}