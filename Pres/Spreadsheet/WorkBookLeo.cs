using System.Collections.Generic;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.Drawing;

namespace Lazaro.Pres.Spreadsheet
{
    public class WorkBookLeo
    {
        private int rowIndex = 1;
        public byte[] StartExcel(string Titulo, string titleSheet, string titleGrid, List<ExcelReg> campos, Lfx.Data.RowCollection rows, List<HeaderLeo> createHeader = null)
        {
            ExcelPackage excelPkg = new ExcelPackage();

            excelPkg.Workbook.Properties.Author = "Excelencia Soluciones Informáticas S.R.L.";
            excelPkg.Workbook.Properties.Title = Titulo;

            ExcelWorksheet oSheet = CreateSheet(excelPkg, titleSheet);

            if (createHeader != null)
                foreach (HeaderLeo hl in createHeader)
                    CreateHeader(oSheet, campos.Count, hl);

            // 3. Setting Excel Cell Backgournd Color during Header Creation
            // 4. Setting Excel Cell Border during Header Creation
            // Creating Header
            CreateHeader(oSheet, campos);

            // Putting Data into Cells
            CreateData(oSheet, rows, campos);

            // 5. Setting Excel Formula during Footer Creation
            // Creating Footer
            //CreateFooter(oSheet, ref rowIndex, dt);

            // 6. Add Comments in Excel Cell
            //AddComment(oSheet, 5, 5, "Sample Comment", "Debopam Pal");

            // 7. Add Image in Excel Sheet
            //string imagePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)), "debopam.jpg");
            //AddImage(oSheet, 1, 10, imagePath);

            // 8. Add Custom Objects in Excel Sheet
            //AddCustomObject(oSheet, 7, 10, eShapeStyle.Ellipse, "Text inside Ellipse");

            // Writting bytes by bytes in Excel File
            //byte[] content = excelPkg.GetAsByteArray();
            //string fileName = "Sample Excel using EPPlus.xlsx";
            //string filePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)), fileName);
            //File.WriteAllBytes(filePath, content);

            // Openning the created excel file using MS Excel Application
            //ProcessStartInfo pi = new ProcessStartInfo(filePath);
            //Process.Start(pi);

            return excelPkg.GetAsByteArray();
        }

        private void CreateHeader(ExcelWorksheet sheet, int columnas, HeaderLeo headerleo)
        {
            sheet.Cells[rowIndex, 1].Value = headerleo.title;
            sheet.Cells[rowIndex, 1, rowIndex, columnas].Merge = headerleo.merge;
            sheet.Cells[rowIndex, 1, rowIndex, columnas].Style.Font.Size = headerleo.size;
            sheet.Cells[rowIndex, 1, rowIndex, columnas].Style.Font.Bold = headerleo.bold;
            switch (headerleo.alig.ToString().ToLower())
            {
                case "center":
                    sheet.Cells[rowIndex, 1, rowIndex, columnas].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    break;
                case "centercontinuous":
                    sheet.Cells[rowIndex, 1, rowIndex, columnas].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    break;
                case "distributed":
                    sheet.Cells[rowIndex, 1, rowIndex, columnas].Style.HorizontalAlignment = ExcelHorizontalAlignment.Distributed;
                    break;
                case "fill":
                    sheet.Cells[rowIndex, 1, rowIndex, columnas].Style.HorizontalAlignment = ExcelHorizontalAlignment.Fill;
                    break;
                case "general":
                    sheet.Cells[rowIndex, 1, rowIndex, columnas].Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                    break;
                case "justify":
                    sheet.Cells[rowIndex, 1, rowIndex, columnas].Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                    break;
                case "left":
                    sheet.Cells[rowIndex, 1, rowIndex, columnas].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    break;
                case "right":
                    sheet.Cells[rowIndex, 1, rowIndex, columnas].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    break;
            }

            rowIndex++;
        }

        // Creating Excel Worksheet
        private ExcelWorksheet CreateSheet(ExcelPackage excelPkg, string sheetName)
        {
            ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets.Add(sheetName);
            // Setting default font for whole sheet
            oSheet.Cells.Style.Font.Name = "Calibri";
            // Setting font size for whole sheet
            oSheet.Cells.Style.Font.Size = 11;
            return oSheet;
        }

        /// <summary>
		/// Creating formatted header of excel sheet
		/// </summary>
		/// <param name="oSheet">The ExcelWorksheet object</param>
		/// <param name="rowIndex">The row number where the header will put</param>
		/// <param name="dt">The DataTable object from where header values will come</param>
		private void CreateHeader(ExcelWorksheet oSheet, List<ExcelReg> campos)
        {
            int colIndex = 1;
            foreach (ExcelReg dc in campos)
            {
                var cell = oSheet.Cells[rowIndex, colIndex];

                // Setting the background color of header cells to Gray
                var fill = cell.Style.Fill;
                fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Gray);

                // Setting top/left, right/bottom border of header cells
                var border = cell.Style.Border;
                border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                // Setting value in cell
                cell.Value = "Heading " + dc.desc;

                colIndex++;
            }
        }

        /// <summary>
		/// Putting Data into Excel Cells
		/// </summary>
		/// <param name="oSheet">The ExcelWorksheet object</param>
		/// <param name="rowIndex">The row number from where data will put</param>
		/// <param name="dt">The DataTable object from where data will come</param>
		private void CreateData(ExcelWorksheet oSheet, Lfx.Data.RowCollection dt, List<ExcelReg> campos)
        {
            int colIndex = 0;
            foreach (Lfx.Data.Row dr in dt)
            {
                colIndex = 1;
                rowIndex++;

                foreach (ExcelReg dc in campos)
                {
                    var cell = oSheet.Cells[rowIndex, colIndex];
                    // Setting value in the cell
                    cell.Value = dr[dc.name];
                    // Setting border of the cell
                    var border = cell.Style.Border;
                    border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                    colIndex++;
                }
            }
        }

        //      /// <summary>
        ///// Creating formatted footer in the excel sheet
        ///// </summary>
        ///// <param name="oSheet">The ExcelWorksheet object</param>
        ///// <param name="rowIndex">The row number where the footer will put</param>
        ///// <param name="dt">The DataTable object from where footer values will come</param>
        //private void CreateFooter(ExcelWorksheet oSheet, ref int rowIndex, DataTable dt)
        //      {
        //          int colIndex = 0;
        //          // Creating Formula in Footer
        //          foreach (DataColumn dc in dt.Columns)
        //          {
        //              colIndex++;
        //              var cell = oSheet.Cells[rowIndex, colIndex];

        //              // Setting Sum Formula for each cell
        //              // Usage: Sum(From_Addres:To_Address)
        //              // e.g. - Sum(A3:A6) -> Sums the value of Column 'A' From Row 3 to Row 6
        //              cell.Formula = "Sum(" + oSheet.Cells[3, colIndex].Address + ":" + oSheet.Cells[rowIndex - 1, colIndex].Address + ")";

        //              // Setting Background Fill color to Gray
        //              cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //              cell.Style.Fill.BackgroundColor.SetColor(Color.Gray);
        //          }
        //      }

        //      /// <summary>
        //      /// Adding custom comment in specified cell of specified excel sheet
        //      /// </summary>
        //      /// <param name="oSheet">The ExcelWorksheet object</param>
        //      /// <param name="rowIndex">The row number of the cell where comment will put</param>
        //      /// <param name="colIndex">The column number of the cell where comment will put</param>
        //      /// <param name="comment">The comment text</param>
        //      /// <param name="author">The author name</param>
        //      private void AddComment(ExcelWorksheet oSheet, int rowIndex, int colIndex, string comment, string author)
        //      {
        //          // Adding a comment to a Cell
        //          oSheet.Cells[rowIndex, colIndex].AddComment(comment, author);
        //      }

        //      /// <summary>
        //      /// Adding custom image in spcified cell of specified excel sheet
        //      /// </summary>
        //      /// <param name="oSheet">The ExcelWorksheet object</param>
        //      /// <param name="rowIndex">The row number of the cell where the image will put</param>
        //      /// <param name="colIndex">The column number of the cell where the image will put</param>
        //      /// <param name="imagePath">The path of the image file</param>
        //      private void AddImage(ExcelWorksheet oSheet, int rowIndex, int colIndex, string imagePath)
        //      {
        //          Bitmap image = new Bitmap(imagePath);
        //          ExcelPicture excelImage = null;
        //          if (image != null)
        //          {
        //              excelImage = oSheet.Drawings.AddPicture("Debopam Pal", image);
        //              excelImage.From.Column = colIndex;
        //              excelImage.From.Row = rowIndex;
        //              excelImage.SetSize(100, 100);
        //              // 2x2 px space for better alignment
        //              excelImage.From.ColumnOff = Pixel2MTU(2);
        //              excelImage.From.RowOff = Pixel2MTU(2);
        //          }
        //      }

        //      /// <summary>
        ///// Adding custom shape or object in specifed cell of specified excel sheet
        ///// </summary>
        ///// <param name="oSheet">The ExcelWorksheet object</param>
        ///// <param name="rowIndex">The row number of the cell where the object will put</param>
        ///// <param name="colIndex">The column number of the cell where the object will put</param>
        ///// <param name="shapeStyle">The style of the shape of the object</param>
        ///// <param name="text">Text inside the object</param>
        //private void AddCustomObject(ExcelWorksheet oSheet, int rowIndex, int colIndex, eShapeStyle shapeStyle, string text)
        //      {
        //          ExcelShape excelShape = oSheet.Drawings.AddShape("Custom Object", shapeStyle);
        //          excelShape.From.Column = colIndex;
        //          excelShape.From.Row = rowIndex;
        //          excelShape.SetSize(100, 100);
        //          // 5x5 px space for better alignment
        //          excelShape.From.RowOff = Pixel2MTU(5);
        //          excelShape.From.ColumnOff = Pixel2MTU(5);
        //          // Adding text into the shape
        //          excelShape.RichText.Add(text);
        //      }

        //      public int Pixel2MTU(int pixels)
        //      {
        //          int mtus = pixels * 9525;
        //          return mtus;
        //      }
    }
}
