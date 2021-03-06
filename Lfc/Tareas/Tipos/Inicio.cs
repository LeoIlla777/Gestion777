using System.Collections.Generic;

namespace Lfc.Tareas.Tipos
{
	public partial class Inicio : Lfc.FormularioListado
	{
                public Inicio()
                {
                        Dictionary<int, string> EstadosTickets = new Dictionary<int, string>()
                        {
                                {0, "Inactivo"},
                                {1, "Activo"}
                        };

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Tareas.Tipo),

                                TableName = "tickets_tipos",
                                KeyColumn = new Lazaro.Pres.Field("tickets_tipos.id_tipo_ticket", "Cód.", Lfx.Data.InputFieldTypes.Serial, 64),

                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("tickets_tipos.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("tickets_tipos.estado", "Estado", 160, EstadosTickets),
			        },
                                OrderBy = "tickets_tipos.nombre"
                        };

                        this.HabilitarFiltrar = true;
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