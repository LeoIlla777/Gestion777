namespace Lfc.Inicio
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.PanelWeb = new Lui.Forms.Panel();
            this.logoEmpresa = new System.Windows.Forms.PictureBox();
            this.ControlTareas = new Lfc.Inicio.ControlTareas();
            this.PanelVentas = new Lfc.Inicio.ControlVentas();
            this.PanelCompras = new Lfc.Inicio.ControlCompras();
            this.PanelPersonas = new Lfc.Inicio.ControlPersonas();
            this.PanelArticulos = new Lfc.Inicio.ControlArticulos();
            this.PanelWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelWeb
            // 
            this.PanelWeb.BackColor = System.Drawing.Color.White;
            this.PanelWeb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelWeb.Controls.Add(this.logoEmpresa);
            this.PanelWeb.Location = new System.Drawing.Point(48, 438);
            this.PanelWeb.Name = "PanelWeb";
            this.PanelWeb.Size = new System.Drawing.Size(608, 119);
            this.PanelWeb.TabIndex = 9;
            // 
            // logoEmpresa
            // 
            this.logoEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoEmpresa.Image = global::Lfc.Properties.Resources.logo;
            this.logoEmpresa.Location = new System.Drawing.Point(0, 0);
            this.logoEmpresa.Name = "logoEmpresa";
            this.logoEmpresa.Size = new System.Drawing.Size(604, 115);
            this.logoEmpresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoEmpresa.TabIndex = 0;
            this.logoEmpresa.TabStop = false;
            // 
            // ControlTareas
            // 
            this.ControlTareas.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ControlTareas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlTareas.ForeColor = System.Drawing.Color.White;
            this.ControlTareas.Image = ((System.Drawing.Image)(resources.GetObject("ControlTareas.Image")));
            this.ControlTareas.Location = new System.Drawing.Point(48, 362);
            this.ControlTareas.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.ControlTareas.Name = "ControlTareas";
            this.ControlTareas.Size = new System.Drawing.Size(1042, 70);
            this.ControlTareas.TabIndex = 10;
            this.ControlTareas.Text = "Tareas";
            // 
            // PanelVentas
            // 
            this.PanelVentas.BackColor = System.Drawing.Color.DarkSlateGray;
            this.PanelVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelVentas.ForeColor = System.Drawing.Color.White;
            this.PanelVentas.Image = ((System.Drawing.Image)(resources.GetObject("PanelVentas.Image")));
            this.PanelVentas.Location = new System.Drawing.Point(48, 126);
            this.PanelVentas.Margin = new System.Windows.Forms.Padding(5);
            this.PanelVentas.Name = "PanelVentas";
            this.PanelVentas.Size = new System.Drawing.Size(1042, 70);
            this.PanelVentas.TabIndex = 2;
            this.PanelVentas.Text = "Ventas";
            // 
            // PanelCompras
            // 
            this.PanelCompras.BackColor = System.Drawing.Color.DarkSlateGray;
            this.PanelCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelCompras.ForeColor = System.Drawing.Color.White;
            this.PanelCompras.Image = ((System.Drawing.Image)(resources.GetObject("PanelCompras.Image")));
            this.PanelCompras.Location = new System.Drawing.Point(48, 204);
            this.PanelCompras.Margin = new System.Windows.Forms.Padding(5);
            this.PanelCompras.Name = "PanelCompras";
            this.PanelCompras.Size = new System.Drawing.Size(1042, 70);
            this.PanelCompras.TabIndex = 2;
            this.PanelCompras.Text = "Compras";
            // 
            // PanelPersonas
            // 
            this.PanelPersonas.BackColor = System.Drawing.Color.DarkSlateGray;
            this.PanelPersonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelPersonas.ForeColor = System.Drawing.Color.White;
            this.PanelPersonas.Image = ((System.Drawing.Image)(resources.GetObject("PanelPersonas.Image")));
            this.PanelPersonas.Location = new System.Drawing.Point(48, 284);
            this.PanelPersonas.Margin = new System.Windows.Forms.Padding(5);
            this.PanelPersonas.Name = "PanelPersonas";
            this.PanelPersonas.Size = new System.Drawing.Size(1042, 70);
            this.PanelPersonas.TabIndex = 1;
            this.PanelPersonas.Text = "Personas";
            // 
            // PanelArticulos
            // 
            this.PanelArticulos.BackColor = System.Drawing.Color.DarkSlateGray;
            this.PanelArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelArticulos.ForeColor = System.Drawing.Color.White;
            this.PanelArticulos.Image = ((System.Drawing.Image)(resources.GetObject("PanelArticulos.Image")));
            this.PanelArticulos.Location = new System.Drawing.Point(48, 46);
            this.PanelArticulos.Margin = new System.Windows.Forms.Padding(5);
            this.PanelArticulos.Name = "PanelArticulos";
            this.PanelArticulos.Size = new System.Drawing.Size(1042, 70);
            this.PanelArticulos.TabIndex = 0;
            this.PanelArticulos.Text = "Artículos";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 685);
            this.Controls.Add(this.ControlTareas);
            this.Controls.Add(this.PanelWeb);
            this.Controls.Add(this.PanelVentas);
            this.Controls.Add(this.PanelCompras);
            this.Controls.Add(this.PanelPersonas);
            this.Controls.Add(this.PanelArticulos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.Padding = new System.Windows.Forms.Padding(32, 34, 32, 34);
            this.Text = "Inicio";
            this.PanelWeb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoEmpresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlArticulos PanelArticulos;
        private ControlPersonas PanelPersonas;
        private ControlVentas PanelVentas;
        private ControlCompras PanelCompras;
        private Lui.Forms.Panel PanelWeb;
        private ControlTareas ControlTareas;
        private System.Windows.Forms.PictureBox logoEmpresa;
    }
}
