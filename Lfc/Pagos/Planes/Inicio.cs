using System;
using System.Collections.Generic;

namespace Lfc.Pagos.Planes
{
    public class Inicio : Lfc.FormularioListado
    {
        public Inicio()
        {
            this.Definicion = new Lazaro.Pres.Listings.Listing()
            {
                ElementoTipo = typeof(Lbl.Pagos.Plan),

                TableName = "tarjetas_planes",
                KeyColumn = new Lazaro.Pres.Field("tarjetas_planes.id_plan", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                Columns = new Lazaro.Pres.FieldCollection()
                                    {
                                        new Lazaro.Pres.Field("tarjetas_planes.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
                                                        new Lazaro.Pres.Field("tarjetas_planes.cuotas", "Cuotas", Lfx.Data.InputFieldTypes.Integer, 96),
                                                        new Lazaro.Pres.Field("tarjetas_planes.interes", "Desc./Recargo", Lfx.Data.InputFieldTypes.Numeric, 120),
                                                        new Lazaro.Pres.Field("tarjetas_planes.comision", "Retención", Lfx.Data.InputFieldTypes.Numeric, 120)
                                    },
                OrderBy = "tarjetas_planes.nombre"
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