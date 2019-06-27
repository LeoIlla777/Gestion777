using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lfc.Articulos
{
    public partial class Inicio : Lfc.FormularioListado
    {
        protected Lui.Forms.Button BotonCambioMasivoPrecios;

        private void InitializeComponent()
        {
            this.BotonCambioMasivoPrecios = new Lui.Forms.Button();
            this.EntradaBuscarExtra = new Lui.Forms.TextBox();
            this.PanelContadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).BeginInit();
            this.SuspendLayout();
            // 
            // EtiquetaListadoVacio
            // 
            this.EtiquetaListadoVacio.Size = new System.Drawing.Size(466, 80);
            // 
            // Listado
            // 
            this.Listado.Margin = new System.Windows.Forms.Padding(2);
            this.Listado.Size = new System.Drawing.Size(554, 441);
            // 
            // BotonCambioMasivoPrecios
            // 
            this.BotonCambioMasivoPrecios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BotonCambioMasivoPrecios.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonCambioMasivoPrecios.Image = null;
            this.BotonCambioMasivoPrecios.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonCambioMasivoPrecios.Location = new System.Drawing.Point(44, 0);
            this.BotonCambioMasivoPrecios.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.BotonCambioMasivoPrecios.MaximumSize = new System.Drawing.Size(160, 64);
            this.BotonCambioMasivoPrecios.MinimumSize = new System.Drawing.Size(96, 32);
            this.BotonCambioMasivoPrecios.Name = "BotonCambioMasivoPrecios";
            this.BotonCambioMasivoPrecios.Size = new System.Drawing.Size(136, 40);
            this.BotonCambioMasivoPrecios.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
            this.BotonCambioMasivoPrecios.Subtext = "F7";
            this.BotonCambioMasivoPrecios.TabIndex = 49;
            this.BotonCambioMasivoPrecios.Text = "Precios";
            this.BotonCambioMasivoPrecios.Click += new System.EventHandler(this.BotonCambioMasivoPrecios_Click);
            // 
            // EntradaBuscarExtra
            //
            this.EntradaBuscarExtra.Location = new System.Drawing.Point(8, 48);
            this.EntradaBuscarExtra.Name = "EntradaBuscarExtra";
            this.EntradaBuscarExtra.PlaceholderText = "Buscar Extra";
            this.EntradaBuscarExtra.Size = new System.Drawing.Size(212, 24);
            this.EntradaBuscarExtra.TabIndex = 1;
            this.EntradaBuscarExtra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaBuscarExtra_KeyDown);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(779, 447);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.PanelAcciones.Controls.Add(this.BotonCambioMasivoPrecios);
            this.Controls.Add(this.EntradaBuscarExtra);
            this.MinimumSize = new System.Drawing.Size(639, 397);
            this.Name = "Inicio";
            this.PanelContadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).EndInit();
            this.ResumeLayout(false);

        }

        protected Lui.Forms.TextBox EntradaBuscarExtra;
    }
}
