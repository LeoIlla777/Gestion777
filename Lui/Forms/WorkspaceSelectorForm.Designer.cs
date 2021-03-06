using System.Windows.Forms;

namespace Lui.Forms
{
        public partial class WorkspaceSelectorForm
        {
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null)
                                        components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                private System.ComponentModel.IContainer components = null;

                #region Código generado por el diseñador

                private void InitializeComponent()
                {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkspaceSelectorForm));
            this.label1 = new Lui.Forms.Label();
            this.Espacios = new System.Windows.Forms.ListBox();
            this.PanelLogo = new Lui.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(124, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el espacio de trabajo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
            // 
            // Espacios
            // 
            this.Espacios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Espacios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Espacios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Espacios.IntegralHeight = false;
            this.Espacios.ItemHeight = 17;
            this.Espacios.Location = new System.Drawing.Point(124, 57);
            this.Espacios.Name = "Espacios";
            this.Espacios.Size = new System.Drawing.Size(400, 176);
            this.Espacios.Sorted = true;
            this.Espacios.TabIndex = 1;
            this.Espacios.SelectedValueChanged += new System.EventHandler(this.Espacios_SelectedValueChanged);
            this.Espacios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Espacios_KeyDown);
            // 
            // PanelLogo
            // 
            this.PanelLogo.BackColor = System.Drawing.Color.White;
            this.PanelLogo.Controls.Add(this.PictureBox1);
            this.PanelLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLogo.Location = new System.Drawing.Point(0, 0);
            this.PanelLogo.Name = "PanelLogo";
            this.PanelLogo.Size = new System.Drawing.Size(100, 252);
            this.PanelLogo.TabIndex = 52;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::Lui.Properties.Resources.Winrar;
            this.PictureBox1.Location = new System.Drawing.Point(12, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(83, 243);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 51;
            this.PictureBox1.TabStop = false;
            // 
            // WorkspaceSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(546, 316);
            this.Controls.Add(this.Espacios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PanelLogo);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WorkspaceSelectorForm";
            this.Text = "Espacio de trabajo";
            this.Controls.SetChildIndex(this.PanelLogo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.Espacios, 0);
            this.PanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

                }
                #endregion

                private Lui.Forms.Label label1;
                private System.Windows.Forms.ListBox Espacios;
                private Lui.Forms.Panel PanelLogo;
                internal PictureBox PictureBox1;
        }
}
