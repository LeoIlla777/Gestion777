namespace Lfc
{
	partial class FormularioCuenta
	{
		#region Código generado por el Diseñador de Windows Forms

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


                private System.ComponentModel.IContainer components = null;

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioCuenta));
            this.EtiquetaTitulo = new Lui.Forms.Label();
            this.PanelContadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).BeginInit();
            this.SuspendLayout();
            // 
            // EtiquetaTitulo
            // 
            this.EtiquetaTitulo.Location = new System.Drawing.Point(8, 8);
            this.EtiquetaTitulo.Name = "EtiquetaTitulo";
            this.EtiquetaTitulo.Size = new System.Drawing.Size(208, 64);
            this.EtiquetaTitulo.TabIndex = 68;
            this.EtiquetaTitulo.Text = "Cuentas corrientes";
            this.EtiquetaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
            this.EtiquetaTitulo.UseMnemonic = false;
            // 
            // FormularioCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(864, 441);
            this.Controls.Add(this.EtiquetaTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormularioCuenta";
            this.Text = "Caja";
            this.Controls.SetChildIndex(this.PanelContadores, 0);
            this.Controls.SetChildIndex(this.PicEsperar, 0);
            this.Controls.SetChildIndex(this.EtiquetaCantidad, 0);
            this.Controls.SetChildIndex(this.Listado, 0);
            this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
            this.PanelContadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).EndInit();
            this.ResumeLayout(false);

		}


		#endregion

                internal Lui.Forms.Label EtiquetaTitulo;

        }
}
