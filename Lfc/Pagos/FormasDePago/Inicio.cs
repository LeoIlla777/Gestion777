using System;
using System.Collections.Generic;

namespace Lfc.Pagos.FormasDePago
{
    public class Inicio : Lfc.FormularioListado
    {
        public Inicio()
        {
            this.Definicion = new Lazaro.Pres.Listings.Listing()
            {
                ElementoTipo = typeof(Lbl.Pagos.FormaDePago),

                TableName = "formaspago",
                KeyColumn = new Lazaro.Pres.Field("formaspago.id_formapago", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                Columns = new Lazaro.Pres.FieldCollection()
                            {
                                new Lazaro.Pres.Field("formaspago.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
                                new Lazaro.Pres.Field("formaspago.tipo", "Tipo", 240, new Dictionary<int, string>() {
                                    { 1, "Efectivo" },
                                    { 2, "Cheque (propio)" },
                                    { 3, "Cuenta corriente" },
                                    { 4, "Tarjeta" },
                                    { 6, "Caja" },
                                    { 7, "Otro" },
                                    { 8, "Cheque (terceros)" }}),
                                new Lazaro.Pres.Field("formaspago.id_caja", "Caja", Lfx.Data.InputFieldTypes.Relation, 320),
                                new Lazaro.Pres.Field("formaspago.descuento", "Desc./Recargo", Lfx.Data.InputFieldTypes.Numeric, 120),
                                new Lazaro.Pres.Field("formaspago.retencion", "Retención", Lfx.Data.InputFieldTypes.Numeric, 120),
                                new Lazaro.Pres.Field("formaspago.pagos", "Pagos", Lfx.Data.InputFieldTypes.Bool, 96),
                                new Lazaro.Pres.Field("formaspago.cobros", "Cobros", Lfx.Data.InputFieldTypes.Bool, 96),
                },
                OrderBy = "formaspago.nombre"
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