using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Personas
{
    [Lbl.Atributos.Nomenclatura(NombreSingular = "Cotiza", Grupo = "Personas")]
    [Lbl.Atributos.Datos(TablaDatos = "personas_cotiza", CampoId = "id_personacotiza")]
    [Lbl.Atributos.Presentacion()]
    public class Cotiza : ElementoDeDatos
    {

        public Cotiza(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

        public Cotiza(Lfx.Data.Connection dataBase, int itemId)
            : base(dataBase, itemId) { }

        public Cotiza(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                : base(dataBase, row) { }


        public override void OnLoad()
        {
            base.OnLoad();
        }

        public decimal PersonaCotiza
        {
            get
            {
                return this.GetFieldValue<decimal>("cotiza");
            }
            set
            {
                this.Registro["cotiza"] = value;
            }
        }

        public DateTime FechaCotiza
        {
            get
            {
                return this.GetFieldValue<DateTime>("fecha");
            }
            set
            {
                this.Registro["fecha"] = value;
            }
        }


    }
}