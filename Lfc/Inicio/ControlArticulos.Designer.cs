namespace Lfc.Inicio
{
    partial class ControlArticulos
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlArticulos));
            this.PanelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.BotonListado = new Lfc.Inicio.Boton();
            this.BotonCrearArticulo = new Lfc.Inicio.Boton();
            this.BotonCrearCategoria = new Lfc.Inicio.Boton();
            this.PanelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelBotones
            // 
            this.PanelBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBotones.BackColor = System.Drawing.Color.Teal;
            this.PanelBotones.Controls.Add(this.BotonListado);
            this.PanelBotones.Controls.Add(this.BotonCrearArticulo);
            this.PanelBotones.Controls.Add(this.BotonCrearCategoria);
            this.PanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.PanelBotones.Location = new System.Drawing.Point(238, 6);
            this.PanelBotones.Margin = new System.Windows.Forms.Padding(4);
            this.PanelBotones.Name = "PanelBotones";
            this.PanelBotones.Size = new System.Drawing.Size(800, 60);
            this.PanelBotones.TabIndex = 2;
            // 
            // BotonListado
            // 
            this.BotonListado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonListado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonListado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonListado.Image = ((System.Drawing.Image)(resources.GetObject("BotonListado.Image")));
            this.BotonListado.Location = new System.Drawing.Point(678, 5);
            this.BotonListado.Margin = new System.Windows.Forms.Padding(5);
            this.BotonListado.Name = "BotonListado";
            this.BotonListado.Size = new System.Drawing.Size(117, 51);
            this.BotonListado.TabIndex = 0;
            this.BotonListado.Text = "Listado";
            this.BotonListado.Click += new System.EventHandler(this.BotonListado_Click);
            // 
            // BotonCrearArticulo
            // 
            this.BotonCrearArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonCrearArticulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonCrearArticulo.Image = ((System.Drawing.Image)(resources.GetObject("BotonCrearArticulo.Image")));
            this.BotonCrearArticulo.Location = new System.Drawing.Point(494, 5);
            this.BotonCrearArticulo.Margin = new System.Windows.Forms.Padding(5);
            this.BotonCrearArticulo.Name = "BotonCrearArticulo";
            this.BotonCrearArticulo.Size = new System.Drawing.Size(174, 51);
            this.BotonCrearArticulo.TabIndex = 1;
            this.BotonCrearArticulo.Text = "Nuevo artículo";
            this.BotonCrearArticulo.Click += new System.EventHandler(this.BotonCrearArticulo_Click);
            // 
            // BotonCrearCategoria
            // 
            this.BotonCrearCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonCrearCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonCrearCategoria.Image = ((System.Drawing.Image)(resources.GetObject("BotonCrearCategoria.Image")));
            this.BotonCrearCategoria.Location = new System.Drawing.Point(299, 5);
            this.BotonCrearCategoria.Margin = new System.Windows.Forms.Padding(5);
            this.BotonCrearCategoria.Name = "BotonCrearCategoria";
            this.BotonCrearCategoria.Size = new System.Drawing.Size(185, 51);
            this.BotonCrearCategoria.TabIndex = 2;
            this.BotonCrearCategoria.Text = "Nueva categoría";
            this.BotonCrearCategoria.Click += new System.EventHandler(this.BotonCrearCategoria_Click);
            // 
            // ControlArticulos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.PanelBotones);
            this.ForeColor = System.Drawing.Color.White;
            this.Image = ((System.Drawing.Image)(resources.GetObject("$this.Image")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ControlArticulos";
            this.Size = new System.Drawing.Size(1042, 70);
            this.Text = "Artículos";
            this.Controls.SetChildIndex(this.PanelBotones, 0);
            this.PanelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelBotones;
        private Boton BotonListado;
        private Boton BotonCrearArticulo;
        private Boton BotonCrearCategoria;
    }
}
