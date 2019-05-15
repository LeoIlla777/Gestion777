namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "TicketX")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Nunca)]
        public class TicketX : ComprobanteFacturable
        {
                //Heredar constructor
                public TicketX(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public TicketX(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public TicketX(Lfx.Data.IConnection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["TX"];
                }
        }
}
