namespace Lfc.Inicio
{
    partial class ControlVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlVentas));
            this.PanelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.BotonListadoFacturas = new Lfc.Inicio.Boton();
            this.BotonListadoRecibos = new Lfc.Inicio.Boton();
            this.BotonCrearFactura = new Lfc.Inicio.Boton();
            this.BotonCrearRecibo = new Lfc.Inicio.Boton();
            this.PanelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelBotones
            // 
            this.PanelBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBotones.BackColor = System.Drawing.Color.Teal;
            this.PanelBotones.Controls.Add(this.BotonListadoFacturas);
            this.PanelBotones.Controls.Add(this.BotonListadoRecibos);
            this.PanelBotones.Controls.Add(this.BotonCrearFactura);
            this.PanelBotones.Controls.Add(this.BotonCrearRecibo);
            this.PanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.PanelBotones.Location = new System.Drawing.Point(238, 6);
            this.PanelBotones.Margin = new System.Windows.Forms.Padding(4);
            this.PanelBotones.Name = "PanelBotones";
            this.PanelBotones.Size = new System.Drawing.Size(800, 60);
            this.PanelBotones.TabIndex = 2;
            // 
            // BotonListadoFacturas
            // 
            this.BotonListadoFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonListadoFacturas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonListadoFacturas.Image = ((System.Drawing.Image)(resources.GetObject("BotonListadoFacturas.Image")));
            this.BotonListadoFacturas.Location = new System.Drawing.Point(678, 5);
            this.BotonListadoFacturas.Margin = new System.Windows.Forms.Padding(5);
            this.BotonListadoFacturas.Name = "BotonListadoFacturas";
            this.BotonListadoFacturas.Size = new System.Drawing.Size(117, 51);
            this.BotonListadoFacturas.TabIndex = 0;
            this.BotonListadoFacturas.Text = "Listado";
            this.BotonListadoFacturas.Click += new System.EventHandler(this.BotonListadoFacturas_Click);
            // 
            // BotonListadoRecibos
            // 
            this.BotonListadoRecibos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonListadoRecibos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonListadoRecibos.Image = ((System.Drawing.Image)(resources.GetObject("BotonListadoRecibos.Image")));
            this.BotonListadoRecibos.Location = new System.Drawing.Point(531, 5);
            this.BotonListadoRecibos.Margin = new System.Windows.Forms.Padding(5);
            this.BotonListadoRecibos.Name = "BotonListadoRecibos";
            this.BotonListadoRecibos.Size = new System.Drawing.Size(137, 51);
            this.BotonListadoRecibos.TabIndex = 1;
            this.BotonListadoRecibos.Text = "Recibos";
            this.BotonListadoRecibos.Click += new System.EventHandler(this.BotonListadoRecibos_Click);
            // 
            // BotonCrearFactura
            // 
            this.BotonCrearFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonCrearFactura.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonCrearFactura.Image = ((System.Drawing.Image)(resources.GetObject("BotonCrearFactura.Image")));
            this.BotonCrearFactura.Location = new System.Drawing.Point(353, 5);
            this.BotonCrearFactura.Margin = new System.Windows.Forms.Padding(5);
            this.BotonCrearFactura.Name = "BotonCrearFactura";
            this.BotonCrearFactura.Size = new System.Drawing.Size(168, 51);
            this.BotonCrearFactura.TabIndex = 2;
            this.BotonCrearFactura.Text = "Nueva factura";
            this.BotonCrearFactura.Click += new System.EventHandler(this.BotonCrearFactura_Click);
            // 
            // BotonCrearRecibo
            // 
            this.BotonCrearRecibo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonCrearRecibo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonCrearRecibo.Image = ((System.Drawing.Image)(resources.GetObject("BotonCrearRecibo.Image")));
            this.BotonCrearRecibo.Location = new System.Drawing.Point(158, 5);
            this.BotonCrearRecibo.Margin = new System.Windows.Forms.Padding(5);
            this.BotonCrearRecibo.Name = "BotonCrearRecibo";
            this.BotonCrearRecibo.Size = new System.Drawing.Size(185, 51);
            this.BotonCrearRecibo.TabIndex = 3;
            this.BotonCrearRecibo.Text = "Nuevo recibo";
            this.BotonCrearRecibo.Click += new System.EventHandler(this.BotonCrearRecibo_Click);
            // 
            // ControlVentas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.PanelBotones);
            this.ForeColor = System.Drawing.Color.White;
            this.Image = ((System.Drawing.Image)(resources.GetObject("$this.Image")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ControlVentas";
            this.Size = new System.Drawing.Size(1042, 70);
            this.Text = "Ventas";
            this.Controls.SetChildIndex(this.PanelBotones, 0);
            this.PanelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelBotones;
        private Boton BotonListadoFacturas;
        private Boton BotonListadoRecibos;
        private Boton BotonCrearFactura;
        private Boton BotonCrearRecibo;
    }
}
