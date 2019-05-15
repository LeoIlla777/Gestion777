namespace Lfc
{
        partial class FormularioListado
        {
                protected Lui.Forms.TextBox EntradaBuscar;
                protected System.Windows.Forms.Timer TimerBuscar;
                protected Lui.Forms.Label EtiquetaListadoVacio;
                protected Lui.Forms.Button BotonCrear;

                // Requerido por el Diseñador de Windows Forms
                private System.ComponentModel.IContainer components = null;

                // Limpiar los recursos que se estén utilizando.
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }

                        base.Dispose(disposing);
                }

                private void InitializeComponent()
                {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioListado));
            this.EntradaBuscar = new Lui.Forms.TextBox();
            this.TimerBuscar = new System.Windows.Forms.Timer(this.components);
            this.EtiquetaListadoVacio = new Lui.Forms.Label();
            this.BotonCrear = new Lui.Forms.Button();
            this.PanelContadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).BeginInit();
            this.SuspendLayout();
            // 
            // Listado
            // 
            this.Listado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Listado_KeyDown);
            // 
            // EtiquetaCantidad
            // 
            this.EtiquetaCantidad.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.EtiquetaCantidad.Size = new System.Drawing.Size(184, 26);
            // 
            // EntradaBuscar
            // 
            this.EntradaBuscar.Location = new System.Drawing.Point(8, 8);
            this.EntradaBuscar.Name = "EntradaBuscar";
            this.EntradaBuscar.PlaceholderText = "Buscar (F3)";
            this.EntradaBuscar.Size = new System.Drawing.Size(212, 24);
            this.EntradaBuscar.TabIndex = 1;
            this.EntradaBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaBuscar_KeyDown);
            this.EntradaBuscar.TextChanged += new System.EventHandler(this.EntradaBuscar_TextChanged);
            // 
            // TimerBuscar
            // 
            this.TimerBuscar.Interval = 500;
            this.TimerBuscar.Tick += new System.EventHandler(this.TimerBuscar_Tick);
            // 
            // EtiquetaListadoVacio
            // 
            this.EtiquetaListadoVacio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EtiquetaListadoVacio.AutoEllipsis = true;
            this.EtiquetaListadoVacio.Location = new System.Drawing.Point(332, 192);
            this.EtiquetaListadoVacio.Margin = new System.Windows.Forms.Padding(0);
            this.EtiquetaListadoVacio.Name = "EtiquetaListadoVacio";
            this.EtiquetaListadoVacio.Size = new System.Drawing.Size(380, 80);
            this.EtiquetaListadoVacio.TabIndex = 70;
            this.EtiquetaListadoVacio.Text = "El listado no contiene datos.\r\nHaga clic en el botón \'Crear\' para añadir nuevos e" +
    "lementos.";
            this.EtiquetaListadoVacio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EtiquetaListadoVacio.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Info;
            this.EtiquetaListadoVacio.UseMnemonic = false;
            this.EtiquetaListadoVacio.Visible = false;
            this.EtiquetaListadoVacio.Click += new System.EventHandler(this.EtiquetaListadoVacio_Click);
            // 
            // BotonCrear
            // 
            this.BotonCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BotonCrear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonCrear.Image = null;
            this.BotonCrear.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonCrear.Location = new System.Drawing.Point(180, 137);
            this.BotonCrear.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.BotonCrear.MaximumSize = new System.Drawing.Size(160, 64);
            this.BotonCrear.MinimumSize = new System.Drawing.Size(96, 32);
            this.BotonCrear.Name = "BotonCrear";
            this.BotonCrear.Size = new System.Drawing.Size(136, 40);
            this.BotonCrear.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
            this.BotonCrear.Subtext = "F6";
            this.BotonCrear.TabIndex = 71;
            this.BotonCrear.Text = "Crear";
            this.BotonCrear.Click += new System.EventHandler(this.BotonCrear_Click);
            // 
            // FormularioListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(864, 447);
            this.Controls.Add(this.EtiquetaListadoVacio);
            this.Controls.Add(this.EntradaBuscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(795, 486);
            this.Name = "FormularioListado";
            this.Text = "Listado";
            this.Controls.SetChildIndex(this.PanelContadores, 0);
            this.Controls.SetChildIndex(this.PicEsperar, 0);
            this.Controls.SetChildIndex(this.EntradaBuscar, 0);
            this.Controls.SetChildIndex(this.EtiquetaCantidad, 0);
            this.Controls.SetChildIndex(this.Listado, 0);
            this.Controls.SetChildIndex(this.EtiquetaListadoVacio, 0);
            this.PanelContadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).EndInit();
            this.ResumeLayout(false);

                }
        }
}
