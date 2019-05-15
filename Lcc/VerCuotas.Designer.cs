namespace Lcc
{
    partial class VerCuotas
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
            this.ListaConformacion = new Lui.Forms.ListView();
            this.ColCuotas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColInteres = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColImporte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EtiquetaTitulo = new Lui.Forms.Label();
            this.cbInteres = new System.Windows.Forms.CheckBox();
            this.ColTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbTotal = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ListaConformacion
            // 
            this.ListaConformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaConformacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListaConformacion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCuotas,
            this.ColInteres,
            this.ColImporte,
            this.ColTotal});
            this.ListaConformacion.FieldName = null;
            this.ListaConformacion.FullRowSelect = true;
            this.ListaConformacion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListaConformacion.LabelWrap = false;
            this.ListaConformacion.Location = new System.Drawing.Point(12, 104);
            this.ListaConformacion.MultiSelect = false;
            this.ListaConformacion.Name = "ListaConformacion";
            this.ListaConformacion.ReadOnly = false;
            this.ListaConformacion.Size = new System.Drawing.Size(614, 280);
            this.ListaConformacion.TabIndex = 0;
            this.ListaConformacion.UseCompatibleStateImageBehavior = false;
            this.ListaConformacion.View = System.Windows.Forms.View.Details;
            // 
            // ColCuotas
            // 
            this.ColCuotas.Text = "Cuotas";
            this.ColCuotas.Width = 240;
            // 
            // ColInteres
            // 
            this.ColInteres.Text = "Interes";
            this.ColInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColInteres.Width = 120;
            // 
            // ColImporte
            // 
            this.ColImporte.Text = "Total por Cuotas";
            this.ColImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColImporte.Width = 130;
            // 
            // EtiquetaTitulo
            // 
            this.EtiquetaTitulo.AutoSize = true;
            this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
            this.EtiquetaTitulo.Name = "EtiquetaTitulo";
            this.EtiquetaTitulo.Size = new System.Drawing.Size(320, 30);
            this.EtiquetaTitulo.TabIndex = 105;
            this.EtiquetaTitulo.Text = "Conformación de las existencias";
            this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
            // 
            // cbInteres
            // 
            this.cbInteres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInteres.AutoSize = true;
            this.cbInteres.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbInteres.Location = new System.Drawing.Point(546, 387);
            this.cbInteres.Name = "cbInteres";
            this.cbInteres.Size = new System.Drawing.Size(80, 17);
            this.cbInteres.TabIndex = 106;
            this.cbInteres.Text = "Ver Interes";
            this.cbInteres.UseVisualStyleBackColor = true;
            this.cbInteres.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ColTotal
            // 
            this.ColTotal.Text = "Total";
            this.ColTotal.Width = 120;
            // 
            // cbTotal
            // 
            this.cbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTotal.AutoSize = true;
            this.cbTotal.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbTotal.Location = new System.Drawing.Point(462, 387);
            this.cbTotal.Name = "cbTotal";
            this.cbTotal.Size = new System.Drawing.Size(69, 17);
            this.cbTotal.TabIndex = 107;
            this.cbTotal.Text = "Ver Total";
            this.cbTotal.UseVisualStyleBackColor = true;
            this.cbTotal.CheckedChanged += new System.EventHandler(this.cbTotal_CheckedChanged);
            // 
            // VerCuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(638, 473);
            this.Controls.Add(this.cbTotal);
            this.Controls.Add(this.cbInteres);
            this.Controls.Add(this.EtiquetaTitulo);
            this.Controls.Add(this.ListaConformacion);
            this.Name = "VerCuotas";
            this.Text = "Interes por cuotas";
            this.Controls.SetChildIndex(this.ListaConformacion, 0);
            this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
            this.Controls.SetChildIndex(this.cbInteres, 0);
            this.Controls.SetChildIndex(this.cbTotal, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Lui.Forms.ListView ListaConformacion;
        private System.Windows.Forms.ColumnHeader ColCuotas;
        private System.Windows.Forms.ColumnHeader ColInteres;
        private Lui.Forms.Label EtiquetaTitulo;
        private System.Windows.Forms.ColumnHeader ColImporte;
        private System.Windows.Forms.CheckBox cbInteres;
        private System.Windows.Forms.ColumnHeader ColTotal;
        private System.Windows.Forms.CheckBox cbTotal;
    }
}