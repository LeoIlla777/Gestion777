using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Impresion
{
        /// <summary>
        /// Representa una impresora configurada en Gestión. Puede ser una impresora de Windows,
        /// un controlador fiscal o una impresora nula.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Impresora")]
        [Lbl.Atributos.Datos(TablaDatos = "impresoras", CampoId = "id_impresora")]
        [Lbl.Atributos.Presentacion()]
        public class Impresora : ElementoDeDatos
        {
                //Heredar constructor
		public Impresora(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public Impresora(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Impresora(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                /// <summary>
                /// Obtiene o establece el nombre del elemento.
                /// </summary>
                [Column(Name = "nombre", Type = ColumnTypes.VarChar, Length = 200, Nullable = false)]
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


                /// <summary>
                /// Obtiene o establece un texto que representa las observaciones del elemento.
                /// </summary>
                [Column(Name = "obs")]
                public string Obs
                {
                        get
                        {
                                if (this.Registro["obs"] == null || this.Registro["obs"] == DBNull.Value)
                                        return null;
                                else
                                        return this.Registro["obs"].ToString();
                        }
                        set
                        {
                                if (value == null) {
                                        this.Registro["obs"] = null;
                                } else {
                                        this.Registro["obs"] = value.Trim(new char[] { '\n', '\r', ' ' });
                                }
                        }
                }


                /// <summary>
                /// Devuelve o establece el estado del elemento. El valor de esta propiedad tiene diferentes significados para cada clase derivada.
                /// </summary>
                [Column(Name = "estado")]
                public int Estado
                {
                        get
                        {
                                return this.GetFieldValue<int>("estado");
                        }
                        set
                        {
                                this.Registro["estado"] = value;
                        }
                }


                public override void Crear()
                {
                        base.Crear();
                        this.Clase = ClasesImpresora.Papel;
                }


                public bool EsVistaPrevia
                {
                        get
                        {
                                return this.Dispositivo == "Gestion!preview";
                        }
                }


                public bool EsLocalPredeterminada
                {
                        get
                        {
                                return this.Dispositivo == "Gestion!default";
                        }
                }

                public bool EsLocal
                {
                        get
                        {
                                return this.Estacion == null || this.Estacion.ToUpperInvariant() == Lfx.Environment.SystemInformation.MachineName;
                        }
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;
                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                                Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        } else {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        Comando.ColumnValues.AddWithValue("estacion", this.Estacion);
                        Comando.ColumnValues.AddWithValue("dispositivo", this.Dispositivo);
                        Comando.ColumnValues.AddWithValue("bandeja", this.Bandeja);
                        Comando.ColumnValues.AddWithValue("ubicacion", this.Ubicacion);
                        
                        Comando.ColumnValues.AddWithValue("tipo", (int)this.Clase);
                        Comando.ColumnValues.AddWithValue("carga", (int)this.CargaPapel);
                        Comando.ColumnValues.AddWithValue("talonario", this.UsaTalonario ? 1 : 0);

                        Comando.ColumnValues.AddWithValue("fiscal_modelo", (int)this.FiscalModelo);
                        Comando.ColumnValues.AddWithValue("fiscal_bps", this.FiscalBps);
                        
                        Comando.ColumnValues.AddWithValue("obs", this.Obs);

                        this.AgregarTags(Comando);

                        Connection.ExecuteNonQuery(Comando);

                        return base.Guardar();
                }


                public string Estacion
                {
                        get
                        {
                                return this.GetFieldValue<string>("estacion");
                        }
                        set
                        {
                                this.Registro["estacion"] = value;
                        }
                }

                public string Dispositivo
                {
                        get
                        {
                                return this.GetFieldValue<string>("dispositivo");
                        }
                        set
                        {
                                this.Registro["dispositivo"] = value;
                        }
                }


                public string DispositivoUnc
                {
                        get
                        {
                                if (this.Estacion != null)
                                        return @"\\" + this.Estacion + @"\" + this.Dispositivo;
                                else
                                        return this.Dispositivo;
                        }
                }


                public string Bandeja
                {
                        get
                        {
                                return this.GetFieldValue<string>("bandeja");
                        }
                        set
                        {
                                this.Registro["bandeja"] = value;
                        }
                }

                public string Ubicacion
                {
                        get
                        {
                                return this.GetFieldValue<string>("ubicacion");
                        }
                        set
                        {
                                this.Registro["ubicacion"] = value;
                        }
                }

                public bool UsaTalonario
                {
                        get
                        {
                                return this.GetFieldValue<int>("usatalonario") != 0;
                        }
                        set
                        {
                                this.Registro["usatalonario"] = value ? 1 : 0;
                        }
                }

                public ClasesImpresora Clase
                {
                        get
                        {
                                return (ClasesImpresora)this.GetFieldValue<int>("tipo");
                        }
                        set
                        {
                                this.Registro["tipo"] = (int)value;
                        }
                }

                public CargasPapel CargaPapel
                {
                        get
                        {
                                return (CargasPapel)this.GetFieldValue<int>("carga");
                        }
                        set
                        {
                                this.Registro["carga"] = (int)value;
                        }
                }

                public Lbl.Impresion.ModelosFiscales FiscalModelo
                {
                        get
                        {
                                return (Lbl.Impresion.ModelosFiscales)this.GetFieldValue<int>("fiscal_modelo");
                        }
                        set
                        {
                                this.Registro["fiscal_modelo"] = (int)value;
                        }
                }

                public int FiscalBps
                {
                        get
                        {
                                return this.GetFieldValue<int>("fiscal_bps");
                        }
                        set
                        {
                                this.Registro["fiscal_bps"] = value;
                        }
                }

                public static Lbl.Impresion.Impresora InstanciarImpresoraLocal(Lfx.Data.IConnection dataBase, string nombreImpresora)
                {
                        Lbl.Impresion.Impresora Impr = new Lbl.Impresion.Impresora(dataBase);
                        Impr.Clase = Lbl.Impresion.ClasesImpresora.Papel;
                        Impr.Nombre = nombreImpresora;
                        Impr.Estacion = Lfx.Environment.SystemInformation.MachineName;
                        Impr.CargaPapel = Lbl.Impresion.CargasPapel.Automatica;
                        Impr.Dispositivo = nombreImpresora;
                        Impr.Estado = 1;

                        return Impr;
                }
        }
}
