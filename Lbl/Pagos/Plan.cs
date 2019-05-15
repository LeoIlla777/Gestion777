using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Pagos
{
        /// <summary>
        /// Representa un plan de una tarjeta de crédito (p. ej.: "Plan 12 cuotas sin interés").
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Plan", Grupo = "Cobros y pagos")]
        [Lbl.Atributos.Datos(TablaDatos = "tarjetas_planes", CampoId = "id_plan")]
        [Lbl.Atributos.Presentacion()]
	public class Plan : ElementoDeDatos
	{

                private FormaDePago m_Pago;

                //Heredar constructor
                public Plan(Lfx.Data.IConnection dataBase)
                                : base(dataBase) { }

		        public Plan(Lfx.Data.IConnection dataBase, int itemId)
			        : base(dataBase, itemId) { }

                public Plan(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public override void Crear()
                {
                    base.Crear();
                    m_Pago = null;
                }



                public override Lfx.Types.OperationResult Guardar()
                {
                    qGen.IStatement Comando;

                    if (this.Existe == false)
                    {
                        Comando = new qGen.Insert(this.TablaDatos);
                        Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                    }
                    else
                    {
                        Comando = new qGen.Update(this.TablaDatos);
                        Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                    }

                    Comando.ColumnValues.AddWithValue("nombre", this.Nombre);

                    if (this.Tarjeta != null)
                        Comando.ColumnValues.AddWithValue("id_tarjeta", this.Tarjeta.Id);
                    else
                        Comando.ColumnValues.AddWithValue("id_tarjeta", null);

                    Comando.ColumnValues.AddWithValue("cuotas", this.Cuotas);
                    Comando.ColumnValues.AddWithValue("interes", this.Interes);
                    Comando.ColumnValues.AddWithValue("comision", this.Comision);

                    Comando.ColumnValues.AddWithValue("obs", null);
                    Comando.ColumnValues.AddWithValue("estado", true);

                    this.AgregarTags(Comando);
                    this.Connection.ExecuteNonQuery(Comando);
                    return base.Guardar();
                }

                public string Nombre
                {
                    get
                    {
                        return this.GetFieldValue<string>("nombre");
                    }
                    set
                    {
                        this.Registro["nombre"] = value;
                    }
                }

                public decimal Comision
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("comision");
                        }
                        set
                        {
                                this.Registro["comision"] = value;
                        }
                }

                public decimal Interes
                {
                    get
                    {
                        return this.GetFieldValue<decimal>("interes");
                    }
                    set
                    {
                        this.Registro["interes"] = value;
                    }
                }

                public int Cuotas
                {
                    get
                    {
                        return this.GetFieldValue<int>("cuotas");
                    }
                    set
                    {
                        this.Registro["cuotas"] = value;
                    }
                }

                public FormaDePago Tarjeta
                {
                    get
                    {
                        if (m_Pago == null && this.GetFieldValue<int>("id_tarjeta") > 0)
                            m_Pago = new FormaDePago(this.Connection, this.GetFieldValue<int>("id_tarjeta"));
                        return m_Pago;
                    }
                    set
                    {
                        m_Pago = value;
                    }
                }
    }
}
