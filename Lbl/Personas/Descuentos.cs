using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lbl.Personas
{
    [Lbl.Atributos.Nomenclatura(NombreSingular = "Descuento", Grupo = "Personas")]
    [Lbl.Atributos.Datos(TablaDatos = "personas_descuentos", CampoId = "id_personadescuento")]
    [Lbl.Atributos.Presentacion()]
    public class Descuentos : ElementoDeDatos
    {

        public Descuentos(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

        public Descuentos(Lfx.Data.IConnection dataBase, int itemId)
            : base(dataBase, itemId) { }

        public Descuentos(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                : base(dataBase, row) { }


        public override void OnLoad()
        {
            base.OnLoad();
        }

        [Column(Name = "id_persona")]
        public int Persona {
            get {
                return System.Convert.ToInt32(this.Registro["id_persona"]);
            }
            set {
                this.Registro["id_persona"] = value;
            }
        }

        [Column(Name = "id_rubro")]
        public int Rubro {
            get {
                return System.Convert.ToInt32(this.Registro["id_rubro"]);
            }
            set {
                this.Registro["id_rubro"] = value;
            }
        }

        [Column(Name = "descuento")]
        public decimal Descuento {
            get {
                return System.Convert.ToDecimal(this.Registro["descuento"]);
            }
            set {
                this.Registro["descuento"] = value;
            }
        }

        [Column(Name = "estado")]
        public short Estado {
            get {
                return System.Convert.ToInt16(this.Registro["estado"]);
            }
            set {
                this.Registro["estado"] = value;
            }
        }

        [Column(Name = "desde")]
        public DateTime Desde {
            get {
                return System.Convert.ToDateTime(this.Registro["desde"]);
            }
            set {
                this.Registro["desde"] = value;
            }
        }

        [Column(Name = "hasta")]
        public DateTime Hasta {
            get {
                return System.Convert.ToDateTime(this.Registro["hasta"]);
            }
            set {
                this.Registro["hasta"] = value;
            }
        }

        [Column(Name = "horario")]
        public short Horario {
            get {
                return System.Convert.ToInt16(this.Registro["horario"]);
            }
            set {
                this.Registro["horario"] = value;
            }
        }
    }
}
