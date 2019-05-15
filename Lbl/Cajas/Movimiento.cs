using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;

namespace Lbl.Cajas
{
    [Lbl.Atributos.Nomenclatura(NombreSingular = "Movimiento de caja", Grupo = "Cuentas")]
    [Lbl.Atributos.Datos(TablaDatos = "cajas_movim", CampoId = "id_movim", CampoNombre = "concepto")]
    [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Nunca)]
    public class Movimiento : Lbl.ElementoDeDatos
    {

        private Lbl.Cajas.Caja m_Caja = null;
        private Lbl.Cajas.Concepto m_Concepto = null;
        private Lbl.Personas.Persona m_Persona = null, m_Cliente = null;

        //Heredar constructor
        public Movimiento(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

        public Movimiento(Lfx.Data.IConnection dataBase, int itemId)
            : base(dataBase, itemId) { }

        public Movimiento(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                : base(dataBase, row) { }

        public Caja Caja {
            get {
                if (m_Caja == null && this.GetFieldValue<int>("id_caja") > 0)
                    m_Caja = new Caja(this.Connection, this.GetFieldValue<int>("id_caja"));
                return m_Caja;
            }
            set {
                m_Caja = value;
                this.SetFieldValue("id_caja", value);
            }
        }

        public Concepto Concepto {
            get {
                if (m_Concepto == null && this.GetFieldValue<int>("id_concepto") > 0)
                    m_Concepto = new Concepto(this.Connection, this.GetFieldValue<int>("id_concepto"));
                return m_Concepto;
            }
            set {
                m_Concepto = value;
                this.SetFieldValue("id_concepto", value);
            }
        }

        public Personas.Persona Persona {
            get {
                if (m_Persona == null && this.GetFieldValue<int>("id_persona") > 0)
                    m_Persona = new Personas.Persona(this.Connection, this.GetFieldValue<int>("id_persona"));
                return m_Persona;
            }
            set {
                m_Persona = value;
                this.SetFieldValue("id_persona", value);
            }
        }

        public Personas.Persona Cliente {
            get {
                if (m_Cliente == null && this.GetFieldValue<int>("id_cliente") > 0)
                    m_Cliente = new Personas.Persona(this.Connection, this.GetFieldValue<int>("id_cliente"));
                return m_Persona;
            }
            set {
                m_Cliente = value;
                this.SetFieldValue("id_cliente", value);
            }
        }

        public decimal Importe {
            get {
                return this.GetFieldValue<decimal>("importe");
            }
            set {
                Registro["importe"] = value;
            }
        }

        public string ConceptoTexto {
            get {
                return this.GetFieldValue<string>("concepto");
            }
            set {
                Registro["concepto"] = value;
            }
        }

        public string Comprob {
            get {
                return this.GetFieldValue<string>("comprob");
            }
            set {
                Registro["comprob"] = value;
            }
        }

        /// <summary>
		/// Obtiene o establece un texto que representa las observaciones del elemento.
		/// </summary>
		[Column(Name = "obs")]
        public string Obs {
            get {
                if (this.Registro["obs"] == null || this.Registro["obs"] == DBNull.Value)
                    return null;
                else
                    return this.Registro["obs"].ToString();
            }
            set {
                if (value == null)
                {
                    this.Registro["obs"] = null;
                }
                else
                {
                    this.Registro["obs"] = value.Trim(new char[] { '\n', '\r', ' ' });
                }
            }
        }

        /// <summary>
        /// El saldo despues de hacer este movimiento.
        /// </summary>
        public decimal Saldo {
            get {
                return this.GetFieldValue<decimal>("saldo");
            }
            set {
                this.Registro["saldo"] = value;
            }
        }

    }
}
