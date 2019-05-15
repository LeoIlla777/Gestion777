namespace Lfc
{
        public partial class FormularioListadoTexto
        {
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

                // Requerido por el Diseñador de Windows Forms
                private System.ComponentModel.IContainer components = null;

                // NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
                // Puede modificarse utilizando el Diseñador de Windows Forms. 
                // No lo modifique con el editor de código.
                internal Lui.Forms.ButtonPanel LowerPanel;
                internal Lui.Forms.Button CancelCommandButton;
                internal Lui.Forms.Button BotonMostrar;
                internal Lui.Forms.Button PrintButton;
                internal Lui.Forms.Button BotonCopiar;

                private void InitializeComponent()
                {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioListadoTexto));
            this.LowerPanel = new Lui.Forms.ButtonPanel();
            this.BotonCopiar = new Lui.Forms.Button();
            this.PrintButton = new Lui.Forms.Button();
            this.BotonMostrar = new Lui.Forms.Button();
            this.CancelCommandButton = new Lui.Forms.Button();
            this.LowerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LowerPanel
            // 
            this.LowerPanel.Controls.Add(this.BotonCopiar);
            this.LowerPanel.Controls.Add(this.PrintButton);
            this.LowerPanel.Controls.Add(this.BotonMostrar);
            this.LowerPanel.Controls.Add(this.CancelCommandButton);
            this.LowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LowerPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.LowerPanel.Location = new System.Drawing.Point(0, 413);
            this.LowerPanel.Name = "LowerPanel";
            this.LowerPanel.Padding = new System.Windows.Forms.Padding(12);
            this.LowerPanel.Size = new System.Drawing.Size(792, 60);
            this.LowerPanel.TabIndex = 50;
            // 
            // BotonCopiar
            // 
            this.BotonCopiar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonCopiar.Image = null;
            this.BotonCopiar.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonCopiar.Location = new System.Drawing.Point(664, 12);
            this.BotonCopiar.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.BotonCopiar.MaximumSize = new System.Drawing.Size(160, 64);
            this.BotonCopiar.MinimumSize = new System.Drawing.Size(96, 32);
            this.BotonCopiar.Name = "BotonCopiar";
            this.BotonCopiar.Padding = new System.Windows.Forms.Padding(2);
            this.BotonCopiar.Size = new System.Drawing.Size(104, 36);
            this.BotonCopiar.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
            this.BotonCopiar.Subtext = "F7";
            this.BotonCopiar.TabIndex = 2;
            this.BotonCopiar.Text = "Copiar";
            this.BotonCopiar.Click += new System.EventHandler(this.BotonCopiar_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.PrintButton.Image = null;
            this.PrintButton.ImagePos = Lui.Forms.ImagePositions.Top;
            this.PrintButton.Location = new System.Drawing.Point(554, 12);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.PrintButton.MaximumSize = new System.Drawing.Size(160, 64);
            this.PrintButton.MinimumSize = new System.Drawing.Size(96, 32);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Padding = new System.Windows.Forms.Padding(2);
            this.PrintButton.Size = new System.Drawing.Size(104, 36);
            this.PrintButton.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
            this.PrintButton.Subtext = "F8";
            this.PrintButton.TabIndex = 3;
            this.PrintButton.Text = "Imprimir";
            // 
            // BotonMostrar
            // 
            this.BotonMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonMostrar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonMostrar.Image = null;
            this.BotonMostrar.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonMostrar.Location = new System.Drawing.Point(444, 12);
            this.BotonMostrar.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.BotonMostrar.MaximumSize = new System.Drawing.Size(160, 64);
            this.BotonMostrar.MinimumSize = new System.Drawing.Size(96, 32);
            this.BotonMostrar.Name = "BotonMostrar";
            this.BotonMostrar.Padding = new System.Windows.Forms.Padding(2);
            this.BotonMostrar.Size = new System.Drawing.Size(104, 36);
            this.BotonMostrar.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
            this.BotonMostrar.Subtext = "F9";
            this.BotonMostrar.TabIndex = 0;
            this.BotonMostrar.Text = "Mostrar";
            this.BotonMostrar.Click += new System.EventHandler(this.BotonMostrar_Click);
            // 
            // CancelCommandButton
            // 
            this.CancelCommandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelCommandButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.CancelCommandButton.Image = null;
            this.CancelCommandButton.ImagePos = Lui.Forms.ImagePositions.Top;
            this.CancelCommandButton.Location = new System.Drawing.Point(334, 12);
            this.CancelCommandButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.CancelCommandButton.MaximumSize = new System.Drawing.Size(160, 64);
            this.CancelCommandButton.MinimumSize = new System.Drawing.Size(96, 32);
            this.CancelCommandButton.Name = "CancelCommandButton";
            this.CancelCommandButton.Padding = new System.Windows.Forms.Padding(2);
            this.CancelCommandButton.Size = new System.Drawing.Size(104, 36);
            this.CancelCommandButton.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
            this.CancelCommandButton.Subtext = "Esc";
            this.CancelCommandButton.TabIndex = 1;
            this.CancelCommandButton.Text = "Volver";
            this.CancelCommandButton.Click += new System.EventHandler(this.BotonCancelar_Click);
            // 
            // FormularioListadoTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.Controls.Add(this.LowerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormularioListadoTexto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado";
            this.LowerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

                }
        }
}