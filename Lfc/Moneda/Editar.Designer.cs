namespace Lfc.Moneda
{
    partial class Editar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label1 = new Lui.Forms.Label();
            this.EntradaNombre = new Lui.Forms.TextBox();
            this.label2 = new Lui.Forms.Label();
            this.EntradaSigno = new Lui.Forms.TextBox();
            this.label3 = new Lui.Forms.Label();
            this.EntradaISO = new Lui.Forms.TextBox();
            this.EntradaCotizacion = new Lui.Forms.TextBox();
            this.label17 = new Lui.Forms.Label();
            this.EntradaDecimales = new Lui.Forms.TextBox();
            this.label4 = new Lui.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(6, 16);
            this.Label1.Margin = new System.Windows.Forms.Padding(0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(96, 24);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Nombre";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaNombre
            // 
            this.EntradaNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaNombre.Location = new System.Drawing.Point(102, 16);
            this.EntradaNombre.MaxLength = 50;
            this.EntradaNombre.Name = "EntradaNombre";
            this.EntradaNombre.Size = new System.Drawing.Size(575, 24);
            this.EntradaNombre.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Signo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaSigno
            // 
            this.EntradaSigno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaSigno.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaSigno.Location = new System.Drawing.Point(102, 46);
            this.EntradaSigno.MaxLength = 50;
            this.EntradaSigno.Name = "EntradaSigno";
            this.EntradaSigno.Size = new System.Drawing.Size(231, 24);
            this.EntradaSigno.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "ISO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaISO
            // 
            this.EntradaISO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaISO.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaISO.Location = new System.Drawing.Point(102, 76);
            this.EntradaISO.MaxLength = 50;
            this.EntradaISO.Name = "EntradaISO";
            this.EntradaISO.Size = new System.Drawing.Size(231, 24);
            this.EntradaISO.TabIndex = 9;
            // 
            // EntradaCotizacion
            // 
            this.EntradaCotizacion.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaCotizacion.Location = new System.Drawing.Point(102, 106);
            this.EntradaCotizacion.MaxLength = 16;
            this.EntradaCotizacion.Name = "EntradaCotizacion";
            this.EntradaCotizacion.Prefijo = "$";
            this.EntradaCotizacion.Size = new System.Drawing.Size(116, 24);
            this.EntradaCotizacion.TabIndex = 12;
            this.EntradaCotizacion.Text = "0.00";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 106);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 24);
            this.label17.TabIndex = 13;
            this.label17.Text = "Cotización";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaDecimales
            // 
            this.EntradaDecimales.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaDecimales.Location = new System.Drawing.Point(102, 136);
            this.EntradaDecimales.MaxLength = 10;
            this.EntradaDecimales.Name = "EntradaDecimales";
            this.EntradaDecimales.Size = new System.Drawing.Size(116, 24);
            this.EntradaDecimales.TabIndex = 15;
            this.EntradaDecimales.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Decimales";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Editar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EntradaDecimales);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EntradaCotizacion);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EntradaISO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EntradaSigno);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.EntradaNombre);
            this.Name = "Editar";
            this.Size = new System.Drawing.Size(744, 194);
            this.Text = "Editar";
            this.ResumeLayout(false);

        }

        #endregion

        internal Lui.Forms.Label Label1;
        internal Lui.Forms.TextBox EntradaNombre;
        internal Lui.Forms.Label label2;
        internal Lui.Forms.TextBox EntradaSigno;
        internal Lui.Forms.Label label3;
        internal Lui.Forms.TextBox EntradaISO;
        internal Lui.Forms.TextBox EntradaCotizacion;
        internal Lui.Forms.Label label17;
        internal Lui.Forms.TextBox EntradaDecimales;
        internal Lui.Forms.Label label4;
    }
}