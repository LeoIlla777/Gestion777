namespace Lfc.Tarjetas.Cupones
{
        public partial class Inicio
        {
                #region Código generado por el Diseñador de Windows Forms

                private void InitializeComponent()
                {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.BotonAnular = new Lui.Forms.Button();
            this.BotonAcreditar = new Lui.Forms.Button();
            this.BotonPresentar = new Lui.Forms.Button();
            this.PanelContadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).BeginInit();
            this.SuspendLayout();
            // 
            // Listado
            // 
            this.Listado.Size = new System.Drawing.Size(1080, 472);
            // 
            // BotonAnular
            // 
            this.BotonAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BotonAnular.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonAnular.Image = null;
            this.BotonAnular.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonAnular.Location = new System.Drawing.Point(180, 61);
            this.BotonAnular.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.BotonAnular.MaximumSize = new System.Drawing.Size(160, 64);
            this.BotonAnular.MinimumSize = new System.Drawing.Size(96, 32);
            this.BotonAnular.Name = "BotonAnular";
            this.BotonAnular.Size = new System.Drawing.Size(136, 32);
            this.BotonAnular.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
            this.BotonAnular.Subtext = "F6";
            this.BotonAnular.TabIndex = 7;
            this.BotonAnular.Text = "Anular";
            this.BotonAnular.Click += new System.EventHandler(this.BotonAnular_Click);
            // 
            // BotonAcreditar
            // 
            this.BotonAcreditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BotonAcreditar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonAcreditar.Image = null;
            this.BotonAcreditar.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonAcreditar.Location = new System.Drawing.Point(180, 23);
            this.BotonAcreditar.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.BotonAcreditar.MaximumSize = new System.Drawing.Size(160, 64);
            this.BotonAcreditar.MinimumSize = new System.Drawing.Size(96, 32);
            this.BotonAcreditar.Name = "BotonAcreditar";
            this.BotonAcreditar.Size = new System.Drawing.Size(136, 32);
            this.BotonAcreditar.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
            this.BotonAcreditar.Subtext = "F4";
            this.BotonAcreditar.TabIndex = 6;
            this.BotonAcreditar.Text = "Acreditar";
            this.BotonAcreditar.Click += new System.EventHandler(this.BotonAcreditar_Click);
            // 
            // BotonPresentar
            // 
            this.BotonPresentar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BotonPresentar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonPresentar.Image = null;
            this.BotonPresentar.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonPresentar.Location = new System.Drawing.Point(180, 99);
            this.BotonPresentar.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.BotonPresentar.MaximumSize = new System.Drawing.Size(160, 64);
            this.BotonPresentar.MinimumSize = new System.Drawing.Size(96, 32);
            this.BotonPresentar.Name = "BotonPresentar";
            this.BotonPresentar.Size = new System.Drawing.Size(136, 32);
            this.BotonPresentar.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
            this.BotonPresentar.Subtext = "F3";
            this.BotonPresentar.TabIndex = 5;
            this.BotonPresentar.Text = "Presentar";
            this.BotonPresentar.Click += new System.EventHandler(this.BotonPresentar_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(864, 447);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.Text = "Cobros con Cupón";
            this.PanelContadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                internal Lui.Forms.Button BotonAcreditar;
                internal Lui.Forms.Button BotonPresentar;
                internal Lui.Forms.Button BotonAnular;
        }
}
