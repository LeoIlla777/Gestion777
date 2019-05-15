using System;
using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Entidades
{
        /// <summary>
        /// Representa una moneda (divisa).
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Moneda", Grupo = "Cuentas")]
        [Lbl.Atributos.Datos(TablaDatos = "monedas", CampoId = "id_moneda")]
        [Lbl.Atributos.Presentacion()]

        [Entity(TableName = "monedas", IdFieldName = "id_moneda")]
        public class Moneda : ElementoDeDatos
        {
                //Heredar constructor
                public Moneda(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Moneda(Lfx.Data.IConnection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public Moneda(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                
                public override void Crear()
                {
                    base.Crear();

                }

                /// <summary>
                /// Obtiene o establece el nombre del elemento.
                /// </summary>
                [Column(Name = "nombre", Type = ColumnTypes.VarChar, Length = 50, Nullable = false)]
                public string Nombre
                {
                    get
                    {
                        return this.GetFieldValue<string>(CampoNombre);
                    }
                    set
                    {
                        this.Registro[CampoNombre] = value;
                    }
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
                    Comando.ColumnValues.AddWithValue("signo", this.Simbolo);
                    Comando.ColumnValues.AddWithValue("iso", this.NomenclaturaIso);
                    Comando.ColumnValues.AddWithValue("estado", 1);
                    Comando.ColumnValues.AddWithValue("cotizacion", this.Cotizacion);
                    Comando.ColumnValues.AddWithValue("decimales", this.Decimales);

                    this.AgregarTags(Comando);

                    this.Connection.ExecuteNonQuery(Comando);

                    if (this.ActualizarProductos == 1)
                    {
                        System.Data.DataTable dtArticulos = this.Connection.Select("SELECT id_articulo,cotiza,id_moneda,id_categoria,id_margen,costo FROM articulos WHERE id_moneda=" + this.Id + " AND conotramoneda=1");
                        Lbl.Impuestos.Alicuota Ali = Lbl.Sys.Config.Empresa.AlicuotaPredeterminada;
                        foreach(System.Data.DataRow dr in dtArticulos.Rows)
                        {
                            qGen.IStatement cmdUpdateProd = new qGen.Update("articulos");
                            cmdUpdateProd.WhereClause = new qGen.Where("id_articulo", dr["id_articulo"]);
                            cmdUpdateProd.ColumnValues.AddWithValue("cotiza", this.Cotizacion);

                            decimal costoActual = 0;
                            if (!decimal.TryParse(dr["costo"].ToString(), out costoActual))
                                costoActual = 0;

                            int idMargen = -1;
                            if (!int.TryParse(dr["id_margen"].ToString(), out idMargen))
                                idMargen = -1;

                            decimal MargenCompleto = 0;
                            if (idMargen != -1)
                            {
                                Lbl.Articulos.Margen Margen = new Articulos.Margen(this.Connection, idMargen);
                                if (Margen != null)
                                {
                                    MargenCompleto = Math.Round(Margen.Porcentaje, Lbl.Sys.Config.Moneda.DecimalesFinal);
                                }
                            }
                            decimal margenCotizado = 1;
                            if (MargenCompleto != 0)
                                margenCotizado = 1 + MargenCompleto / 100;
                            decimal pvpNew = (costoActual * this.Cotizacion) * margenCotizado;

                            cmdUpdateProd.ColumnValues.AddWithValue("pvp", pvpNew);
                            this.Connection.ExecuteNonQuery(cmdUpdateProd);

                            //Anulo el estado anterior de artículo cotiza.
                            qGen.IStatement cot_upd_Comando = new qGen.Update("articulos_cotiza");
                            cot_upd_Comando.WhereClause = new qGen.Where("id_articulo", dr["id_articulo"]);
                            cot_upd_Comando.ColumnValues.AddWithValue("estado", 0);
                            this.Connection.ExecuteNonQuery(cot_upd_Comando);

                            //Agrego nuevo estado a artículo cotiza
                            qGen.IStatement cot_ins_Comando = new qGen.Insert("articulos_cotiza");
                            cot_ins_Comando.ColumnValues.AddWithValue("id_articulo", dr["id_articulo"]);
                            cot_ins_Comando.ColumnValues.AddWithValue("id_moneda", this.Id);
                            cot_ins_Comando.ColumnValues.AddWithValue("cotiza", this.Cotizacion);
                            cot_ins_Comando.ColumnValues.AddWithValue("estado", 1);
                            cot_ins_Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                            this.Connection.ExecuteNonQuery(cot_ins_Comando);
                        }
                    }

                    return base.Guardar();
                }


                public string Simbolo
                {
                        get
                        {
                                return this.GetFieldValue<string>("signo");
                        }
                        set
                        {
                                this.Registro["signo"] = value;
                        }
                }

                public string NomenclaturaIso
                {
                        get
                        {
                                return this.GetFieldValue<string>("iso");
                        }
                        set
                        {
                                this.Registro["iso"] = value;
                        }
                }

                public decimal Cotizacion
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("cotizacion");
                        }
                        set
                        {
                                this.Registro["cotizacion"] = value;
                        }
                }


                public int Decimales
                {
                        get
                        {
                                return this.GetFieldValue<int>("decimales");
                        }
                        set
                        {
                                this.Registro["decimales"] = value;
                        }
                }

                public int ActualizarProductos
                {
                    get
                    {
                        return this.GetFieldValue<int>("actualizar");
                    }
                    set
                    {
                        this.Registro["actualizar"] = (int)value;
                    }
                }

                public int EstadoMoneda
                {
                    get
                    {
                        return this.GetFieldValue<int>("estado");
                    }
                    set
                    {
                        this.Registro["estado"] = (int)value;
                    }
                }
    }
}
