using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Pagos
{
    /// <summary>
    /// Describe un pago con un cupón (por ejemplo pagos con tarjeta de crédito, vales, mutuales, etc.)
    /// </summary>
    [Lbl.Atributos.Nomenclatura(NombreSingular = "Cupón", Grupo = "Pagos y Cobros")]
    [Lbl.Atributos.Datos(TablaDatos = "tarjetas_cupones", CampoId = "id_cupon")]
    [Lbl.Atributos.Presentacion()]
    public class Cupon : ElementoDeDatos
    {
        private Pagos.FormaDePago m_FormaDePago;
        private Pagos.Plan m_Plan;
        private Lbl.Comprobantes.Recibo m_Recibo;
        private Lbl.Comprobantes.ComprobanteConArticulos m_Factura;
        private Cajas.Concepto m_Concepto;
        private Personas.Persona m_Cliente, m_Vendedor;

        //Heredar constructor
        public Cupon(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

        public Cupon(Lfx.Data.IConnection dataBase, int itemId)
    : base(dataBase, itemId) { }

        public Cupon(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                : base(dataBase, row) { }

        /* public Cupon(Lfx.Data.IConnection dataBase, Lbl.Comprobantes.ComprobanteConArticulos factura)
                : this(dataBase)
        {
                m_ItemId = dataBase.FieldInt("SELECT MAX(id_cupon) FROM tarjetas_cupones WHERE id_comprob=" + factura.Id.ToString());
                this.Cargar();
        } */

        public Cupon(Lfx.Data.IConnection dataBase, decimal importe, Pagos.FormaDePago tarjeta, Pagos.Plan plan, string numero, string autorizacion)
    : this(dataBase)
        {
            Importe = importe;
            FormaDePago = tarjeta;
            Plan = plan;
            Numero = numero;
            Autorizacion = autorizacion;
        }


        /// <summary>
        /// Devuelve o establece el estado del elemento. El valor de esta propiedad tiene diferentes significados para cada clase derivada.
        /// </summary>
        [Column(Name = "estado")]
        public int Estado {
            get {
                return this.GetFieldValue<int>("estado");
            }
            set {
                this.Registro["estado"] = value;
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


        public string Numero {
            get {
                return this.GetFieldValue<string>("numero");
            }
            set {
                this.Registro["numero"] = value;
            }
        }

        public string ConceptoTexto {
            get {
                return this.GetFieldValue<string>("concepto");
            }
            set {
                this.Registro["concepto"] = value;
            }
        }

        public string Autorizacion {
            get {
                return this.GetFieldValue<string>("autorizacion");
            }
            set {
                this.Registro["autorizacion"] = value;
            }
        }

        public DbDateTime FechaPresentacion {
            get {
                return this.FieldDateTime("fecha_pres");
            }
            set {
                this.Registro["fecha_pres"] = value;
            }
        }

        public DbDateTime FechaAcreditacion {
            get {
                return this.FieldDateTime("fecha_acred");
            }
            set {
                this.Registro["fecha_acred"] = value;
            }
        }

        public decimal Importe {
            get {
                return this.GetFieldValue<decimal>("importe");
            }
            set {
                this.Registro["importe"] = value;
            }
        }

        public bool Anulado {
            get {
                return this.Estado == ((int)(Lbl.Pagos.EstadosCupones.Anulado));
            }
        }

        public Pagos.FormaDePago FormaDePago {
            get {
                if (m_FormaDePago == null && this.GetFieldValue<int>("id_tarjeta") > 0)
                    m_FormaDePago = new Pagos.FormaDePago(this.Connection, this.GetFieldValue<int>("id_tarjeta"));

                return m_FormaDePago;
            }
            set {
                m_FormaDePago = value;
                this.SetFieldValue("id_tarjeta", m_FormaDePago);
            }
        }


        public Cajas.Concepto Concepto {
            get {
                if (m_Concepto == null && this.GetFieldValue<int>("id_concepto") > 0)
                    m_Concepto = new Cajas.Concepto(this.Connection, this.GetFieldValue<int>("id_concepto"));

                return m_Concepto;
            }
            set {
                m_Concepto = value;
                this.SetFieldValue("id_concepto", m_Concepto);
            }
        }


        public Plan Plan {
            get {
                if (m_Plan == null && this.GetFieldValue<int>("id_plan") > 0)
                    m_Plan = new Plan(this.Connection, this.GetFieldValue<int>("id_plan"));

                return m_Plan;
            }
            set {
                m_Plan = value;
                this.SetFieldValue("id_plan", m_Plan);
            }
        }


        public Comprobantes.Recibo Recibo {
            get {
                if (m_Recibo == null && this.GetFieldValue<int>("id_recibo") > 0)
                    m_Recibo = new Comprobantes.Recibo(this.Connection, this.GetFieldValue<int>("id_recibo"));

                return m_Recibo;
            }
            set {
                m_Recibo = value;
                this.SetFieldValue("id_recibo", m_Recibo);
            }
        }


        public Comprobantes.ComprobanteConArticulos Factura {
            get {
                if (m_Factura == null && this.GetFieldValue<int>("id_comprob") > 0)
                    m_Factura = new Comprobantes.ComprobanteConArticulos(this.Connection, this.GetFieldValue<int>("id_comprob"));

                return m_Factura;
            }
            set {
                m_Factura = value;
                this.SetFieldValue("id_comprob", m_Factura);
            }
        }


        public Personas.Persona Cliente {
            get {
                if (m_Cliente == null && this.GetFieldValue<int>("id_cliente") > 0)
                    m_Cliente = new Personas.Persona(this.Connection, this.GetFieldValue<int>("id_cliente"));

                return m_Cliente;
            }
            set {
                m_Cliente = value;
                this.SetFieldValue("id_cliente", m_Cliente);
            }
        }

        public Personas.Persona Vendedor {
            get {
                if (m_Vendedor == null && this.GetFieldValue<int>("id_vendedor") > 0)
                    m_Vendedor = new Personas.Persona(this.Connection, this.GetFieldValue<int>("id_vendedor"));

                return m_Vendedor;
            }
            set {
                m_Vendedor = value;
                this.SetFieldValue("id_vendedor", m_Vendedor);
            }
        }


        public void Presentar()
        {
            qGen.Update ActualizarEstado = new qGen.Update(this.TablaDatos);
            ActualizarEstado.ColumnValues.AddWithValue("estado", 10);
            ActualizarEstado.ColumnValues.AddWithValue("fecha_pres", new qGen.SqlExpression("NOW()"));
            ActualizarEstado.WhereClause = new qGen.Where(this.CampoId, this.Id);
            this.Connection.ExecuteNonQuery(ActualizarEstado);
        }


        public void Acreditar()
        {
            qGen.Update ActualizarEstado = new qGen.Update(this.TablaDatos);
            ActualizarEstado.ColumnValues.AddWithValue("estado", 20);
            ActualizarEstado.ColumnValues.AddWithValue("fecha_acred", new qGen.SqlExpression("NOW()"));
            ActualizarEstado.WhereClause = new qGen.Where(this.CampoId, this.Id);
            this.Connection.ExecuteNonQuery(ActualizarEstado);
        }


        public override string ToString()
        {
            string Res = this.Registro["numero"].ToString();
            if (FormaDePago != null)
                Res += " de " + FormaDePago.ToString();

            return Res;
        }

        public override Lfx.Types.OperationResult Guardar()
        {
            if (this.Existe == false)
            {
                if (this.FormaDePago != null && this.FormaDePago.AutoPresentacion)
                {
                    this.Estado = 10;
                    this.FechaPresentacion = System.DateTime.Now;
                }
            }

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

            Comando.ColumnValues.AddWithValue("nombre", this.Numero + " de " + this.FormaDePago.ToString());
            Comando.ColumnValues.AddWithValue("numero", this.Numero);

            if (this.Concepto == null)
                Comando.ColumnValues.AddWithValue("id_concepto", null);
            else
                Comando.ColumnValues.AddWithValue("id_concepto", this.Concepto.Id);

            if (this.ConceptoTexto == null || this.ConceptoTexto.Length == 0)
            {
                if (this.Concepto == null)
                    Comando.ColumnValues.AddWithValue("concepto", "");
                else
                    Comando.ColumnValues.AddWithValue("concepto", this.Concepto.Nombre);
            }
            else
            {
                Comando.ColumnValues.AddWithValue("concepto", this.ConceptoTexto);
            }

            Comando.ColumnValues.AddWithValue("autorizacion", this.Autorizacion);

            if (this.FormaDePago != null)
                Comando.ColumnValues.AddWithValue("id_tarjeta", this.FormaDePago.Id);
            else
                Comando.ColumnValues.AddWithValue("id_tarjeta", null);

            if (this.Plan != null)
                Comando.ColumnValues.AddWithValue("id_plan", this.Plan.Id);
            else
                Comando.ColumnValues.AddWithValue("id_plan", null);

            if (this.Cliente != null)
                Comando.ColumnValues.AddWithValue("id_cliente", this.Cliente.Id);
            else if (this.Recibo != null && this.Recibo.Cliente != null)
                Comando.ColumnValues.AddWithValue("id_cliente", this.Recibo.Cliente.Id);
            else
                Comando.ColumnValues.AddWithValue("id_cliente", null);

            if (this.Vendedor != null)
                Comando.ColumnValues.AddWithValue("id_vendedor", this.Vendedor.Id);
            else if (this.Recibo != null && this.Recibo.Vendedor != null)
                Comando.ColumnValues.AddWithValue("id_vendedor", this.Recibo.Vendedor.Id);
            else
                Comando.ColumnValues.AddWithValue("id_vendedor", null);

            if (this.Recibo != null)
                Comando.ColumnValues.AddWithValue("id_recibo", this.Recibo.Id);
            else
                Comando.ColumnValues.AddWithValue("id_recibo", null);

            if (this.Factura == null)
                Comando.ColumnValues.AddWithValue("id_comprob", null);
            else
                Comando.ColumnValues.AddWithValue("id_comprob", this.Factura.Id);

            Comando.ColumnValues.AddWithValue("importe", this.Importe);
            Comando.ColumnValues.AddWithValue("obs", this.Obs);

            if (this.FechaAcreditacion != null)
                Comando.ColumnValues.AddWithValue("fecha_acred", this.FechaAcreditacion.Value);
            else
                Comando.ColumnValues.AddWithValue("fecha_acred", null);

            if (this.FechaPresentacion != null)
                Comando.ColumnValues.AddWithValue("fecha_pres", this.FechaPresentacion.Value);
            else
                Comando.ColumnValues.AddWithValue("fecha_pres", null);

            Comando.ColumnValues.AddWithValue("estado", this.Estado);

            this.AgregarTags(Comando);

            this.Connection.ExecuteNonQuery(Comando);

            return new Lfx.Types.SuccessOperationResult();
        }

        public void Anular()
        {
            if (this.Anulado == false)
            {
                // Marco el cheque como anulado
                qGen.Update Act = new qGen.Update(this.TablaDatos);
                Act.ColumnValues.AddWithValue("estado", 1);
                Act.WhereClause = new qGen.Where(this.CampoId, this.Id);
                this.Connection.ExecuteNonQuery(Act);

                Lbl.Sys.Config.ActionLog(this.Connection, Lbl.Sys.Log.Acciones.Delete, this, null);
            }
        }
    }
}