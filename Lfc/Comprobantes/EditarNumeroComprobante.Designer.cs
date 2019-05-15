namespace Lfc.Comprobantes
{
    partial class EditarNumeroComprobante
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.EntradaComprobante = new Lui.Forms.TextBox();
            this.label1 = new Lui.Forms.Label();
            this.label3 = new Lui.Forms.Label();
            this.label4 = new Lui.Forms.Label();
            this.EntradaNumero = new Lui.Forms.TextBox();
            this.EntradaPV = new Lui.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EntradaComprobante
            // 
            this.EntradaComprobante.Location = new System.Drawing.Point(142, 72);
            this.EntradaComprobante.Name = "EntradaComprobante";
            this.EntradaComprobante.ReadOnly = true;
            this.EntradaComprobante.Size = new System.Drawing.Size(316, 24);
            this.EntradaComprobante.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "Actual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 27);
            this.label3.TabIndex = 58;
            this.label3.Text = "Número de Comprobante";
            this.label3.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(23, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 24);
            this.label4.TabIndex = 59;
            this.label4.Text = "Nº a cambiar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaNumero
            // 
            this.EntradaNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaNumero.Location = new System.Drawing.Point(203, 102);
            this.EntradaNumero.Name = "EntradaNumero";
            this.EntradaNumero.Size = new System.Drawing.Size(100, 24);
            this.EntradaNumero.TabIndex = 1;
            this.EntradaNumero.TextChanged += new System.EventHandler(this.EntradaNumero_TextChanged);
            this.EntradaNumero.Leave += new System.EventHandler(this.EntradaNumero_Leave);
            // 
            // EntradaPV
            // 
            this.EntradaPV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaPV.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPV.Location = new System.Drawing.Point(143, 102);
            this.EntradaPV.Name = "EntradaPV";
            this.EntradaPV.Size = new System.Drawing.Size(56, 24);
            this.EntradaPV.TabIndex = 0;
            this.EntradaPV.Text = "0";
            this.EntradaPV.TextChanged += new System.EventHandler(this.EntradaNumero_TextChanged);
            // 
            // EditarNumeroComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(474, 238);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EntradaNumero);
            this.Controls.Add(this.EntradaPV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EntradaComprobante);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "EditarNumeroComprobante";
            this.Text = "Cambiar N° Comprobante";
            this.Load += new System.EventHandler(this.EditarNumeroComprobante_Load);
            this.Controls.SetChildIndex(this.EntradaComprobante, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.EntradaPV, 0);
            this.Controls.SetChildIndex(this.EntradaNumero, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Lui.Forms.TextBox EntradaComprobante;
        private Lui.Forms.Label label1;
        private Lui.Forms.Label label3;
        internal Lui.Forms.Label label4;
        internal Lui.Forms.TextBox EntradaNumero;
        internal Lui.Forms.TextBox EntradaPV;
    }
}
