namespace Lfc.Inicio
{
    partial class ControlTareas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlTareas));
            this.PanelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.BotonListado = new Lfc.Inicio.Boton();
            this.BotonCrearTarea = new Lfc.Inicio.Boton();
            this.PanelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelBotones
            // 
            this.PanelBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBotones.BackColor = System.Drawing.Color.Teal;
            this.PanelBotones.Controls.Add(this.BotonListado);
            this.PanelBotones.Controls.Add(this.BotonCrearTarea);
            this.PanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.PanelBotones.Location = new System.Drawing.Point(238, 6);
            this.PanelBotones.Margin = new System.Windows.Forms.Padding(4);
            this.PanelBotones.Name = "PanelBotones";
            this.PanelBotones.Size = new System.Drawing.Size(800, 60);
            this.PanelBotones.TabIndex = 2;
            // 
            // BotonListado
            // 
            this.BotonListado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonListado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonListado.Image = ((System.Drawing.Image)(resources.GetObject("BotonListado.Image")));
            this.BotonListado.Location = new System.Drawing.Point(688, 5);
            this.BotonListado.Margin = new System.Windows.Forms.Padding(5);
            this.BotonListado.Name = "BotonListado";
            this.BotonListado.Size = new System.Drawing.Size(107, 51);
            this.BotonListado.TabIndex = 0;
            this.BotonListado.Text = "Listado";
            this.BotonListado.Click += new System.EventHandler(this.BotonListado_Click);
            // 
            // BotonCrearTarea
            // 
            this.BotonCrearTarea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BotonCrearTarea.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonCrearTarea.Image = ((System.Drawing.Image)(resources.GetObject("BotonCrearTarea.Image")));
            this.BotonCrearTarea.Location = new System.Drawing.Point(519, 5);
            this.BotonCrearTarea.Margin = new System.Windows.Forms.Padding(5);
            this.BotonCrearTarea.Name = "BotonCrearTarea";
            this.BotonCrearTarea.Size = new System.Drawing.Size(159, 51);
            this.BotonCrearTarea.TabIndex = 1;
            this.BotonCrearTarea.Text = "Nueva tarea";
            this.BotonCrearTarea.Click += new System.EventHandler(this.BotonCrearTarea_Click);
            // 
            // ControlTareas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.PanelBotones);
            this.ForeColor = System.Drawing.Color.White;
            this.Image = ((System.Drawing.Image)(resources.GetObject("$this.Image")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ControlTareas";
            this.Size = new System.Drawing.Size(1042, 70);
            this.Controls.SetChildIndex(this.PanelBotones, 0);
            this.PanelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelBotones;
        private Boton BotonListado;
        private Boton BotonCrearTarea;
    }
}
