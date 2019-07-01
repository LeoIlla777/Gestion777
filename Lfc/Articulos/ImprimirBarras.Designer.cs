using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Articulos
{
    public partial class ImprimirBarras
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.Label2 = new Lui.Forms.Label();
            this.Label4 = new Lui.Forms.Label();
            this.EntradaMovimiento = new Lui.Forms.ComboBox();
            this.EntradaCantidad = new Lui.Forms.TextBox();
            this.label10 = new Lui.Forms.Label();
            this.EtiquetaTitulo = new Lui.Forms.Label();
            this.VistaPrevia = new System.Windows.Forms.PrintPreviewControl();
            this.documento1 = new System.Drawing.Printing.PrintDocument();
            this.imprimir = new System.Windows.Forms.PrintDialog();
            this.btnZoomPlus = new Lui.Forms.Button();
            this.btnZoomMinus = new Lui.Forms.Button();
            this.txtWidth = new Lui.Forms.TextBox();
            this.label1 = new Lui.Forms.Label();
            this.txtHeight = new Lui.Forms.TextBox();
            this.label3 = new Lui.Forms.Label();
            this.cbEncoding = new Lui.Forms.ComboBox();
            this.btnAplicar = new Lui.Forms.Button();
            this.cbHoja = new Lui.Forms.ComboBox();
            this.label5 = new Lui.Forms.Label();
            this.cbNombre = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(312, 100);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(112, 24);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Cantidad";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(24, 100);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(112, 24);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Código";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaMovimiento
            // 
            this.EntradaMovimiento.AlwaysExpanded = true;
            this.EntradaMovimiento.AutoSize = true;
            this.EntradaMovimiento.Location = new System.Drawing.Point(136, 100);
            this.EntradaMovimiento.Name = "EntradaMovimiento";
            this.EntradaMovimiento.SetData = new string[] {
        "Código Interno|0",
        "Código 1|1",
        "Código 2|2",
        "Código 3|3",
        "Código 4|4"};
            this.EntradaMovimiento.Size = new System.Drawing.Size(150, 91);
            this.EntradaMovimiento.TabIndex = 3;
            this.EntradaMovimiento.TextKey = "0";
            // 
            // EntradaCantidad
            // 
            this.EntradaCantidad.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaCantidad.Location = new System.Drawing.Point(424, 100);
            this.EntradaCantidad.MaxLength = 10;
            this.EntradaCantidad.Name = "EntradaCantidad";
            this.EntradaCantidad.Size = new System.Drawing.Size(96, 24);
            this.EntradaCantidad.TabIndex = 7;
            this.EntradaCantidad.Text = "1";
            this.EntradaCantidad.TextChanged += new System.EventHandler(this.EntradaCantidad_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(24, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(668, 33);
            this.label10.TabIndex = 1;
            this.label10.Text = "Seleccione por cual código desea imprimir";
            // 
            // EtiquetaTitulo
            // 
            this.EtiquetaTitulo.AutoSize = true;
            this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
            this.EtiquetaTitulo.Name = "EtiquetaTitulo";
            this.EtiquetaTitulo.Size = new System.Drawing.Size(261, 30);
            this.EtiquetaTitulo.TabIndex = 0;
            this.EtiquetaTitulo.Text = "Imprimir Código de Barra";
            this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
            // 
            // VistaPrevia
            // 
            this.VistaPrevia.AutoZoom = false;
            this.VistaPrevia.Document = this.documento1;
            this.VistaPrevia.Location = new System.Drawing.Point(12, 197);
            this.VistaPrevia.Name = "VistaPrevia";
            this.VistaPrevia.Size = new System.Drawing.Size(699, 261);
            this.VistaPrevia.TabIndex = 101;
            this.VistaPrevia.Zoom = 0.5D;
            // 
            // documento1
            // 
            this.documento1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.documento1_PrintPage);
            // 
            // imprimir
            // 
            this.imprimir.UseEXDialog = true;
            // 
            // btnZoomPlus
            // 
            this.btnZoomPlus.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnZoomPlus.Image = null;
            this.btnZoomPlus.ImagePos = Lui.Forms.ImagePositions.Top;
            this.btnZoomPlus.Location = new System.Drawing.Point(575, 168);
            this.btnZoomPlus.Name = "btnZoomPlus";
            this.btnZoomPlus.Size = new System.Drawing.Size(65, 23);
            this.btnZoomPlus.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.btnZoomPlus.Subtext = "Tecla";
            this.btnZoomPlus.TabIndex = 102;
            this.btnZoomPlus.Text = "Zoom +";
            this.btnZoomPlus.Click += new System.EventHandler(this.btnZoomPlus_Click);
            // 
            // btnZoomMinus
            // 
            this.btnZoomMinus.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnZoomMinus.Image = null;
            this.btnZoomMinus.ImagePos = Lui.Forms.ImagePositions.Top;
            this.btnZoomMinus.Location = new System.Drawing.Point(646, 168);
            this.btnZoomMinus.Name = "btnZoomMinus";
            this.btnZoomMinus.Size = new System.Drawing.Size(65, 23);
            this.btnZoomMinus.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.btnZoomMinus.Subtext = "Tecla";
            this.btnZoomMinus.TabIndex = 103;
            this.btnZoomMinus.Text = "Zoom -";
            this.btnZoomMinus.Click += new System.EventHandler(this.btnZoomMinus_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.DataType = Lui.Forms.DataTypes.Integer;
            this.txtWidth.Location = new System.Drawing.Point(424, 133);
            this.txtWidth.MaxLength = 10;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(96, 24);
            this.txtWidth.TabIndex = 105;
            this.txtWidth.Text = "62";
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(312, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 24);
            this.label1.TabIndex = 104;
            this.label1.Text = "Ancho (mm)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHeight
            // 
            this.txtHeight.DataType = Lui.Forms.DataTypes.Integer;
            this.txtHeight.Location = new System.Drawing.Point(606, 133);
            this.txtHeight.MaxLength = 10;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(86, 24);
            this.txtHeight.TabIndex = 107;
            this.txtHeight.Text = "20";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(534, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 106;
            this.label3.Text = "Alto (mm)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbEncoding
            // 
            this.cbEncoding.AlwaysExpanded = false;
            this.cbEncoding.Location = new System.Drawing.Point(537, 100);
            this.cbEncoding.Name = "cbEncoding";
            this.cbEncoding.SetData = new string[] {
        "UPC-A|0",
        "UPC-E|1",
        "UPC 2 Digit Ext.|2",
        "UPC 5 Digit Ext.|3",
        "EAN-13|4",
        "JAN-13|5",
        "EAN-8|6",
        "ITF-14|7",
        "Interleaved 2 of 5|8",
        "Standard 2 of 5|9",
        "Codabar|10",
        "PostNet|11",
        "Bookland/ISBN|12",
        "Code 11|13",
        "Code 39|14",
        "Code 39 Extended|15",
        "Code 39 Mod 43|16",
        "Code 93|17",
        "Code 128|18",
        "Code 128-A|19",
        "Code 128-B|20",
        "Code 128-C|21",
        "LOGMARS|22",
        "MSI|23",
        "Telepen|24",
        "FIM|25",
        "Pharmacode|26"};
            this.cbEncoding.Size = new System.Drawing.Size(174, 24);
            this.cbEncoding.TabIndex = 108;
            this.cbEncoding.TextKey = "0";
            // 
            // btnAplicar
            // 
            this.btnAplicar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAplicar.Image = null;
            this.btnAplicar.ImagePos = Lui.Forms.ImagePositions.Top;
            this.btnAplicar.Location = new System.Drawing.Point(397, 168);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(123, 23);
            this.btnAplicar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.btnAplicar.Subtext = "Tecla";
            this.btnAplicar.TabIndex = 109;
            this.btnAplicar.Text = "Aplicar Cambios";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // cbHoja
            // 
            this.cbHoja.AlwaysExpanded = false;
            this.cbHoja.Location = new System.Drawing.Point(537, 65);
            this.cbHoja.Name = "cbHoja";
            this.cbHoja.SetData = new string[] {
        "A4|0",
        "Ticket|1"};
            this.cbHoja.Size = new System.Drawing.Size(174, 24);
            this.cbHoja.TabIndex = 110;
            this.cbHoja.TextKey = "0";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(466, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 24);
            this.label5.TabIndex = 111;
            this.label5.Text = "Hoja";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbNombre
            // 
            this.cbNombre.AutoSize = true;
            this.cbNombre.Checked = true;
            this.cbNombre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNombre.Location = new System.Drawing.Point(315, 68);
            this.cbNombre.Name = "cbNombre";
            this.cbNombre.Size = new System.Drawing.Size(129, 21);
            this.cbNombre.TabIndex = 112;
            this.cbNombre.Text = "Imprimir Nombre";
            this.cbNombre.UseVisualStyleBackColor = true;
            // 
            // ImprimirBarras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(723, 528);
            this.Controls.Add(this.cbNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbHoja);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.cbEncoding);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnZoomMinus);
            this.Controls.Add(this.btnZoomPlus);
            this.Controls.Add(this.VistaPrevia);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.EtiquetaTitulo);
            this.Controls.Add(this.EntradaCantidad);
            this.Controls.Add(this.EntradaMovimiento);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label2);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ImprimirBarras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Artículos: Imprimir código de barra";
            this.Load += new System.EventHandler(this.ImprimirBarras_Load);
            this.Controls.SetChildIndex(this.Label2, 0);
            this.Controls.SetChildIndex(this.Label4, 0);
            this.Controls.SetChildIndex(this.EntradaMovimiento, 0);
            this.Controls.SetChildIndex(this.EntradaCantidad, 0);
            this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.VistaPrevia, 0);
            this.Controls.SetChildIndex(this.btnZoomPlus, 0);
            this.Controls.SetChildIndex(this.btnZoomMinus, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtWidth, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtHeight, 0);
            this.Controls.SetChildIndex(this.cbEncoding, 0);
            this.Controls.SetChildIndex(this.btnAplicar, 0);
            this.Controls.SetChildIndex(this.cbHoja, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cbNombre, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal Lui.Forms.Label Label2;
        internal Lui.Forms.Label Label4;
        internal Lui.Forms.ComboBox EntradaMovimiento;
        internal Lui.Forms.TextBox EntradaCantidad;
        private Lui.Forms.Label label10;
        private Lui.Forms.Label EtiquetaTitulo;
        private System.Windows.Forms.PrintPreviewControl VistaPrevia;
        private System.Drawing.Printing.PrintDocument documento1;
        private System.Windows.Forms.PrintDialog imprimir;
        private Lui.Forms.Button btnZoomPlus;
        private Lui.Forms.Button btnZoomMinus;
        internal Lui.Forms.TextBox txtWidth;
        internal Lui.Forms.Label label1;
        internal Lui.Forms.TextBox txtHeight;
        internal Lui.Forms.Label label3;
        private Lui.Forms.ComboBox cbEncoding;
        private Lui.Forms.Button btnAplicar;
        private Lui.Forms.ComboBox cbHoja;
        internal Lui.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbNombre;
    }
}
