using System;
using System.Collections.Generic;

namespace Lfc.Moneda
{
    public class Inicio : Lfc.FormularioListado
    {
        public Inicio()
        {
            this.Definicion = new Lazaro.Pres.Listings.Listing()
            {
                ElementoTipo = typeof(Lbl.Entidades.Moneda),

                TableName = "monedas",
                KeyColumn = new Lazaro.Pres.Field("monedas.id_moneda", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                Columns = new Lazaro.Pres.FieldCollection()
                    {
                        new Lazaro.Pres.Field("monedas.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
                        new Lazaro.Pres.Field("monedas.signo", "Signo", Lfx.Data.InputFieldTypes.Text, 80),
                        new Lazaro.Pres.Field("monedas.iso", "ISO", Lfx.Data.InputFieldTypes.Text, 80),
                        new Lazaro.Pres.Field("monedas.cotizacion", "Cotización", Lfx.Data.InputFieldTypes.Currency, 160),
                        new Lazaro.Pres.Field("monedas.decimales", "Decimales", Lfx.Data.InputFieldTypes.Numeric, 80)
                    },
                OrderBy = "monedas.nombre"
            };
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.PanelContadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).BeginInit();
            this.SuspendLayout();
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(864, 447);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.PanelContadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).EndInit();
            this.ResumeLayout(false);

        }
    }
}