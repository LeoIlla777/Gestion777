namespace Lfc.Misc
{
    partial class Seguridad
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
            this.label5 = new Lui.Forms.Label();
            this.textBox1 = new Lui.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(30, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(580, 69);
            this.label5.TabIndex = 51;
            this.label5.Text = "Ingrese contraseña de seguridad para acceder a la configuración de la base de dat" +
    "os o instalación del programa.\r\n";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 24);
            this.textBox1.TabIndex = 52;
            this.textBox1.Text = "textBox1";
            // 
            // Seguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(634, 262);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Seguridad";
            this.Text = "Seguridad";
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private Lui.Forms.Label label5;
        private Lui.Forms.TextBox textBox1;
    }
}
