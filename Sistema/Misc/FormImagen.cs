using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
namespace Lazaro
{
	public class FormImagen : Lui.Forms.Form
	{

		#region Código generado por el Diseñador de Windows Forms

		public FormImagen()
			: base()
		{


			// Necesario para admitir el Diseñador de Windows Forms
			InitializeComponent();

			// agregar código de constructor después de llamar a InitializeComponent

		}

		// Limpiar los recursos que se estén utilizando.
		protected override void Dispose(bool disposing)
		{
			if(disposing) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


		// Requerido por el Diseñador de Windows Forms
		private System.ComponentModel.IContainer components = null;

		// NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
		// Puede modificarse utilizando el Diseñador de Windows Forms. 
		// No lo modifique con el editor de código.
		internal System.Windows.Forms.PictureBox Imagen;

		private void InitializeComponent()
		{
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImagen));
                        this.Imagen = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.Imagen)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // Imagen
                        // 
                        this.Imagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Imagen.Location = new System.Drawing.Point(4, 4);
                        this.Imagen.Name = "Imagen";
                        this.Imagen.Size = new System.Drawing.Size(464, 376);
                        this.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.Imagen.TabIndex = 0;
                        this.Imagen.TabStop = false;
                        // 
                        // FormImagen
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(472, 385);
                        this.Controls.Add(this.Imagen);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "FormImagen";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Imagen";
                        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormImagen_KeyPress);
                        ((System.ComponentModel.ISupportInitialize)(this.Imagen)).EndInit();
                        this.ResumeLayout(false);

		}


		#endregion

		private void FormImagen_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(System.Text.Encoding.ASCII.GetBytes(System.Convert.ToString(e.KeyChar))[0] == System.Convert.ToByte(Keys.Escape)) {
				e.Handled = true;
				this.Close();
			}
		}

	}
}
