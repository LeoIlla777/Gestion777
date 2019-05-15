using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Pagos
{
        /// <summary>
        /// Representa una forma de pago. Tanto para emitir pagos como para recibir pagos.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Forma de pago", Grupo = "Cobros y pagos")]
        [Lbl.Atributos.Datos(TablaDatos = "formaspago", CampoId = "id_formapago")]
        [Lbl.Atributos.Presentacion()]
        public class FormaDePago : ElementoDeDatos
        {
                private Lbl.Cajas.Caja m_Caja;
                private Lbl.Cajas.Concepto m_Ingreso, m_Egreso;

                //Heredar constructor
		        public FormaDePago(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public FormaDePago(Lfx.Data.IConnection dataBase, int itemId)
			            : base(dataBase, itemId) { }

                public FormaDePago(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public FormaDePago(Lfx.Data.IConnection dataBase, TiposFormasDePago tipoFormaPago)
                        : this(dataBase)
                {
                        m_ItemId = (int)tipoFormaPago;
                }

		
                public override void Crear()
                {
                        base.Crear();
                        m_Caja = null;
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

                    //if (this.Numero > 0)
                    //    Comando.Fields.AddWithValue("id_formapago", this.Numero);

                    Comando.ColumnValues.AddWithValue("nombre", this.Nombre);

                    if (this.Registro["tipo"] != null)
                        Comando.ColumnValues.AddWithValue("tipo", this.Registro["tipo"].ToString());

                    if (this.Caja == null)
                        Comando.ColumnValues.AddWithValue("id_caja", null);
                    else
                        Comando.ColumnValues.AddWithValue("id_caja", this.Caja.Id);

                    if (Concepto_Ingreso != null)
                        Comando.ColumnValues.AddWithValue("id_concepto", this.Concepto_Ingreso.Id);
                    if (Concepto_Egreso != null)
                        Comando.ColumnValues.AddWithValue("id_concepto_egreso", this.Concepto_Egreso.Id);
                    Comando.ColumnValues.AddWithValue("descuento", this.Descuento);
                    Comando.ColumnValues.AddWithValue("retencion", this.Retencion);
                    Comando.ColumnValues.AddWithValue("autopres", this.AutoPresentacion);
                    Comando.ColumnValues.AddWithValue("autoacred", this.AutoAcreditacion);
                    Comando.ColumnValues.AddWithValue("adelantacuotas", false);
                    Comando.ColumnValues.AddWithValue("dias_acred", this.DiasAcreditacion);
                    Comando.ColumnValues.AddWithValue("pagos", this.PuedeHacerPagos);
                    Comando.ColumnValues.AddWithValue("cobros", this.PuedeHacerCobros);
                    Comando.ColumnValues.AddWithValue("obs", null);
                    Comando.ColumnValues.AddWithValue("estado", true);

                    this.AgregarTags(Comando);
                    this.Connection.ExecuteNonQuery(Comando);
                    return base.Guardar();
                }

                public override Lfx.Types.OperationResult Cargar()
                {
                        Lfx.Types.OperationResult Res = base.Cargar();
                        if (Res.Success) {
                                if (Registro["id_caja"] == null)
                                        m_Caja = null;
                                else
                                        m_Caja = new Lbl.Cajas.Caja(this.Connection, System.Convert.ToInt32(Registro["id_caja"]));
                        }

                        return Res;
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

                public TiposFormasDePago Tipo
                {
                        get
                        {
                                return ((TiposFormasDePago)(this.GetFieldValue<int>("tipo")));
                        }
                        set
                        {
                                this.Registro["tipo"] = (int)value;
                        }
                }

                public decimal Descuento
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("descuento");
                        }
                        set
                        {
                                this.Registro["descuento"] = value;
                        }
                }

                public decimal Retencion
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("retencion");
                        }
                        set
                        {
                                this.Registro["retencion"] = value;
                        }
                }

                public int DiasAcreditacion
                {
                        get
                        {
                                return this.GetFieldValue<int>("dias_acred");
                        }
                        set
                        {
                                this.Registro["dias_acred"] = value;
                        }
                }

                public bool AutoAcreditacion
                {
                        get
                        {
                                return this.GetFieldValue<int>("autoacred") == 1;
                        }
                        set
                        {
                                this.Registro["autoacred"] = value ? 1 : 0;
                        }
                }

                public bool AutoPresentacion
                {
                        get
                        {
                                return this.GetFieldValue<int>("autopres") == 1;
                        }
                        set
                        {
                                this.Registro["autopres"] = value ? 1 : 0;
                        }
                }

                public bool PuedeHacerPagos
                {
                        get
                        {
                                return this.GetFieldValue<int>("pagos") == 1;
                        }
                        set
                        {
                                this.Registro["pagos"] = value ? 1 : 0;
                        }
                }

                public bool PuedeHacerCobros
                {
                        get
                        {
                                return this.GetFieldValue<int>("cobros") == 1;
                        }
                        set
                        {
                                this.Registro["cobros"] = value ? 1 : 0;
                        }
                }

                public Lbl.Cajas.Caja Caja
                {
                        get
                        {
                                if (m_Caja == null && this.GetFieldValue<int>("id_caja") > 0)
                                        m_Caja = new Lbl.Cajas.Caja(this.Connection, this.GetFieldValue<int>("id_caja"));
                                return m_Caja;
                        }
                        set
                        {
                                m_Caja = value;
                        }
                }

                public Lbl.Cajas.Concepto Concepto_Ingreso {
                    get {
                        if (m_Ingreso == null && this.GetFieldValue<int>("id_concepto") > 0)
                            m_Ingreso = new Lbl.Cajas.Concepto(this.Connection, this.GetFieldValue<int>("id_concepto"));
                        return m_Ingreso;
                    }
                    set {
                        m_Ingreso = value;
                    }
                }

                public Lbl.Cajas.Concepto Concepto_Egreso {
                    get {
                        if (m_Egreso == null && this.GetFieldValue<int>("id_concepto_egreso") > 0)
                                m_Egreso = new Lbl.Cajas.Concepto(this.Connection, this.GetFieldValue<int>("id_concepto_egreso"));
                        return m_Egreso;
                    }
                    set {
                            m_Egreso = value;
                    }
                }
    }
}
