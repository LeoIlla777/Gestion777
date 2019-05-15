namespace Lazaro.WinMain.Errores
{
    partial class ExcepcionControlada
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcepcionControlada));
            this.BotonCerrar = new Lui.Forms.Button();
            this.EtiquetaDescripcion = new Lui.Forms.Label();
            this.EtiquetaTitulo = new Lui.Forms.Label();
            this.EtiquetaMasInformacion = new Lui.Forms.Label();
            this.label1 = new Lui.Forms.Label();
            this.PicDiablito = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicDiablito)).BeginInit();
            this.SuspendLayout();
            // 
            // BotonCerrar
            // 
            this.BotonCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonCerrar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonCerrar.Image = null;
            this.BotonCerrar.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonCerrar.Location = new System.Drawing.Point(455, 378);
            this.BotonCerrar.Name = "BotonCerrar";
            this.BotonCerrar.Size = new System.Drawing.Size(108, 32);
            this.BotonCerrar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.BotonCerrar.Subtext = "Tecla";
            this.BotonCerrar.TabIndex = 7;
            this.BotonCerrar.Text = "Continuar";
            this.BotonCerrar.Click += new System.EventHandler(this.BotonCerrar_Click);
            // 
            // EtiquetaDescripcion
            // 
            this.EtiquetaDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EtiquetaDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EtiquetaDescripcion.Location = new System.Drawing.Point(96, 63);
            this.EtiquetaDescripcion.Name = "EtiquetaDescripcion";
            this.EtiquetaDescripcion.Size = new System.Drawing.Size(468, 32);
            this.EtiquetaDescripcion.TabIndex = 6;
            this.EtiquetaDescripcion.Text = "Gestión encontró un problema.";
            // 
            // EtiquetaTitulo
            // 
            this.EtiquetaTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EtiquetaTitulo.Location = new System.Drawing.Point(96, 32);
            this.EtiquetaTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EtiquetaTitulo.Name = "EtiquetaTitulo";
            this.EtiquetaTitulo.Size = new System.Drawing.Size(468, 32);
            this.EtiquetaTitulo.TabIndex = 5;
            this.EtiquetaTitulo.Text = "Informe de error";
            this.EtiquetaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
            // 
            // EtiquetaMasInformacion
            // 
            this.EtiquetaMasInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EtiquetaMasInformacion.Location = new System.Drawing.Point(96, 112);
            this.EtiquetaMasInformacion.Name = "EtiquetaMasInformacion";
            this.EtiquetaMasInformacion.Size = new System.Drawing.Size(467, 218);
            this.EtiquetaMasInformacion.TabIndex = 9;
            this.EtiquetaMasInformacion.Text = ".";
            this.EtiquetaMasInformacion.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(96, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 40);
            this.label1.TabIndex = 10;
            this.label1.Text = "La operación ha sido cancelada. Si no puede solucionar el problema, póngase en co" +
    "ntacto con el administrador.";
            // 
            // PicDiablito
            // 
            this.PicDiablito.Image = ((System.Drawing.Image)(resources.GetObject("PicDiablito.Image")));
            this.PicDiablito.Location = new System.Drawing.Point(36, 32);
            this.PicDiablito.Name = "PicDiablito";
            this.PicDiablito.Size = new System.Drawing.Size(44, 40);
            this.PicDiablito.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicDiablito.TabIndex = 12;
            this.PicDiablito.TabStop = false;
            // 
            // ExcepcionControlada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(594, 438);
            this.ControlBox = false;
            this.Controls.Add(this.PicDiablito);
            this.Controls.Add(this.BotonCerrar);
            this.Controls.Add(this.EtiquetaMasInformacion);
            this.Controls.Add(this.EtiquetaDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EtiquetaTitulo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcepcionControlada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            ((System.ComponentModel.ISupportInitialize)(this.PicDiablito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Lui.Forms.Button BotonCerrar;
        internal Lui.Forms.Label EtiquetaDescripcion;
        protected Lui.Forms.Label EtiquetaTitulo;
        internal Lui.Forms.Label EtiquetaMasInformacion;
        protected Lui.Forms.Label label1;
        protected System.Windows.Forms.PictureBox PicDiablito;
    }
}
