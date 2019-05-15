using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Personas
{
        /// <summary>
        /// Representa una persona física o jurídica.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Persona")]
        [Lbl.Atributos.Datos(TablaDatos = "personas", CampoId = "id_persona", CampoNombre = "nombre_visible", TablaImagenes = "personas_imagenes")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Siempre)]

        [Entity(TableName = "personas", IdFieldName = "id_persona")]
        public class Persona : ElementoDeDatos, IElementoConImagen, ICamposBaseEstandar, IEstadosEstandar
        {
                private Entidades.Localidad m_Localidad = null;
                private Grupo m_Grupo = null, m_SubGrupo = null;
                private int m_Moneda = 0;
                private decimal m_Cotiza = 0;
                private List<Descuentos> m_Descuentos = null;
                private Lbl.Impuestos.SituacionTributaria m_SituacionTributaria = null;

                //private Accesos.ListaDeAccesos m_Accesos = null;
                private Lbl.CuentasCorrientes.CuentaCorriente m_CuentaCorriente = null;
                private Lbl.Personas.Persona m_Vendedor = null;
                private Lbl.Cajas.Concepto m_ConceptoVenta = null, m_ConceptoCompra = null;
                public int ClienteFree = 0;
                public string nameClienteFree = "";

        // Heredar constructores
        public Persona(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Persona(Lfx.Data.IConnection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public Persona(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


        public string LoadClienteFree()
        {
            if (this.Id == 998 && ClienteFree > 0)
            {
                if (nameClienteFree == "")
                {
                    Lbl.Comprobantes.ClienteFree clientefree = new Comprobantes.ClienteFree(this.Connection, ClienteFree);
                    if (clientefree != null)
                        nameClienteFree = clientefree.Nombre;
                }
                this.Registro[CampoNombre] = nameClienteFree;
                return nameClienteFree;
            }
            return "";
        }

                /// <summary>
                /// Obtiene o establece el nombre del elemento.
                /// </summary>
                [Column(Name = "nombre", Type = ColumnTypes.VarChar, Length = 200, Nullable = false)]
                public virtual string Nombre
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


                [Column(Name = "fecha")]
                public DateTime Fecha
                {
                        get
                        {
                                return this.GetFieldValue<DateTime>("fecha");
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
                        m_CuentaCorriente = null;

                        m_CuentaCorriente = null;
                        this.Vendedor = null;
                        this.Tipo = 1;
                        int IdGrupoPredet = this.Connection.FieldInt("SELECT id_grupo FROM personas_grupos WHERE predet=1");
                        if (IdGrupoPredet != 0)
                                this.Grupo = new Lbl.Personas.Grupo(this.Connection, IdGrupoPredet);
                        this.SubGrupo = null;
                        if (Lbl.Sys.Config.Pais != null)
                        {
                                if (Lbl.Sys.Config.Pais.ClavePersonasFisicas != null)
                                        this.TipoDocumento = Lbl.Sys.Config.Pais.ClavePersonasFisicas;
                                if (Lbl.Sys.Config.Pais.ClavePersonasFisicas != null)
                                        this.TipoClaveTributaria = Lbl.Sys.Config.Pais.ClavePersonasJuridicas;
                        }
                        this.SituacionTributaria = new Lbl.Impuestos.SituacionTributaria(this.Connection, 1);
                        this.Localidad = new Lbl.Entidades.Localidad(this.Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.IdLocalidad);
                        this.Estado = 1;
                        //this.Contrasena = new System.Random().Next(100000, 999999).ToString();
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;

                        if (this.Existe == false)
                        {
                                Comando = new qGen.Insert(this.TablaDatos);
                                Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                                Comando.ColumnValues.AddWithValue("fechaalta", new qGen.SqlExpression("NOW()"));
                        }
                        else
                        {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("tipo", this.Tipo);
                        if (this.Grupo == null)
                                Comando.ColumnValues.AddWithValue("id_grupo", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_grupo", this.Grupo.Id);
                        if (this.SubGrupo == null)
                                Comando.ColumnValues.AddWithValue("id_subgrupo", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_subgrupo", this.SubGrupo.Id);
                        Comando.ColumnValues.AddWithValue("nombre", this.Nombres);
                        Comando.ColumnValues.AddWithValue("apellido", this.Apellido);
                        Comando.ColumnValues.AddWithValue("nombre_fantasia", this.NombreFantasia);
                        Comando.ColumnValues.AddWithValue("razon_social", this.RazonSocial);
                        Comando.ColumnValues.AddWithValue("nombre_visible", this.Nombre);
                        if (this.TipoDocumento == null)
                                Comando.ColumnValues.AddWithValue("id_tipo_doc", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_tipo_doc", this.TipoDocumento.Id);
                        if (this.TipoClaveTributaria == null)
                                Comando.ColumnValues.AddWithValue("id_tipo_cuit", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_tipo_cuit", this.TipoClaveTributaria.Id);
                        if (this.NumeroDocumento == null)
                                Comando.ColumnValues.AddWithValue("num_doc", "");
                        else
                                Comando.ColumnValues.AddWithValue("num_doc", this.NumeroDocumento.Replace(".", "").Replace(",", "").Replace(" ", ""));
                        if (this.ClaveTributaria == null)
                                Comando.ColumnValues.AddWithValue("cuit", null);
                        else
                                Comando.ColumnValues.AddWithValue("cuit", this.ClaveTributaria.Valor);
                        if (this.SituacionTributaria == null)
                                Comando.ColumnValues.AddWithValue("id_situacion", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_situacion", this.SituacionTributaria.Id);
                        Comando.ColumnValues.AddWithValue("tipo_fac", this.FacturaPreferida);
                        Comando.ColumnValues.AddWithValue("domicilio", this.Domicilio);
                        Comando.ColumnValues.AddWithValue("domiciliotrabajo", this.DomicilioLaboral);
                        if (this.Localidad == null)
                                Comando.ColumnValues.AddWithValue("id_ciudad", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_ciudad", this.Localidad.Id);
                        if (this.Vendedor == null)
                                Comando.ColumnValues.AddWithValue("id_vendedor", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_vendedor", this.Vendedor.Id);
                        Comando.ColumnValues.AddWithValue("representante", this.Representante);
                        Comando.ColumnValues.AddWithValue("telefono", this.Telefono);
                        Comando.ColumnValues.AddWithValue("email", this.Email);
                        Comando.ColumnValues.AddWithValue("url", this.Url);
                        Comando.ColumnValues.AddWithValue("obs", this.Obs);
                        Comando.ColumnValues.AddWithValue("estado", this.Estado);
                        if (this.Estado == 0 && this.Existe && System.Convert.ToInt32(this.RegistroOriginal["estado"]) != 0)
                                // Esta dado de baja y antes no lo estaba
                                Comando.ColumnValues.AddWithValue("fechabaja", new qGen.SqlExpression("NOW()"));
                        Comando.ColumnValues.AddWithValue("limitecredito", this.LimiteCredito);
                        if (this.Existe) {
                                if (this.RegistroOriginal == null && (decimal)this.RegistroOriginal["limitecredito"] != this.LimiteCredito) {
                                        //Guardo la fecha en la cual se modifico el limite de credito
                                        Comando.ColumnValues.AddWithValue("limitecreditofecha", new qGen.SqlExpression("NOW()"));
                                }
                        } else {
                                if (this.LimiteCredito > 0) {
                                        Comando.ColumnValues.AddWithValue("limitecreditofecha", new qGen.SqlExpression("NOW()"));
                                }
                        }
                        Comando.ColumnValues.AddWithValue("fechanac", this.FechaNacimiento);
                        Comando.ColumnValues.AddWithValue("tipocuenta", (int)(this.TipoCuenta));
                        Comando.ColumnValues.AddWithValue("numerocuenta", this.NumeroCuenta);
                        Comando.ColumnValues.AddWithValue("cbu", this.ClaveBancaria);
                        Comando.ColumnValues.AddWithValue("estadocredito", this.EstadoCredito);

                        if (this.ConceptoVenta == null)
                            Comando.ColumnValues.AddWithValue("id_conceptoventa", null);
                        else
                            Comando.ColumnValues.AddWithValue("id_conceptoventa", this.ConceptoVenta.Id);
                        if (this.ConceptoCompra == null)
                            Comando.ColumnValues.AddWithValue("id_conceptocompra", null);
                        else
                            Comando.ColumnValues.AddWithValue("id_conceptocompra", this.ConceptoCompra.Id);

                        Comando.ColumnValues.AddWithValue("genero", this.Genero);

                        if (this.Existe == false)
                        {
                                // Si estoy creando una persona, le asigno una contraseña aleatoria de 6 digitos
                                string Contrasena = new System.Random().Next(100000, 999999).ToString();
                                Comando.ColumnValues.AddWithValue("contrasena", Contrasena);
                                Comando.ColumnValues.AddWithValue("contrasena_sal", null);
                                Comando.ColumnValues.AddWithValue("contrasena_fecha", new qGen.SqlExpression("NOW()"));
                        }

                        this.AgregarTags(Comando);
                        this.Connection.ExecuteNonQuery(Comando);

                        if (this.Existe)
                        {
                            qGen.IStatement cot_upd_Comando = new qGen.Update("personas_cotiza");
                            cot_upd_Comando.WhereClause = new qGen.Where("id_persona", this.Id);
                            cot_upd_Comando.ColumnValues.AddWithValue("estado", 0);
                            this.Connection.ExecuteNonQuery(cot_upd_Comando);
                        }


                        int IdPersona = this.Id;
                        if (IdPersona == 0)
                            IdPersona = this.Connection.FieldInt("select last_insert_id()");
                        if (IdPersona != 0 && this.Moneda != 0)
                        {
                            qGen.IStatement cot_ins_Comando = new qGen.Insert("personas_cotiza");
                            cot_ins_Comando.ColumnValues.AddWithValue("id_persona", IdPersona);
                            cot_ins_Comando.ColumnValues.AddWithValue("id_moneda", this.Moneda);
                            cot_ins_Comando.ColumnValues.AddWithValue("cotiza", this.CotizaA);
                            cot_ins_Comando.ColumnValues.AddWithValue("estado", 1);
                            cot_ins_Comando.ColumnValues.AddWithValue("fecha", DateTime.Now);
                            this.Connection.ExecuteNonQuery(cot_ins_Comando);
                        }

                        foreach (Descuentos de1 in this.Descuentos)
                        {
                            qGen.IStatement des_Comando = new qGen.Update("personas_descuentos");
                            if (de1.Existe)
                                des_Comando.WhereClause = new qGen.Where("id_personadescuento", de1.Id);
                            else
                                des_Comando = new qGen.Insert("personas_descuentos");

                            des_Comando.ColumnValues.AddWithValue("id_persona", this.Id);
                            if (de1.Rubro != 0)
                                des_Comando.ColumnValues.AddWithValue("id_rubro", de1.Rubro);
                            des_Comando.ColumnValues.AddWithValue("descuento", de1.Descuento);
                            des_Comando.ColumnValues.AddWithValue("estado", de1.Estado);
                            des_Comando.ColumnValues.AddWithValue("desde", de1.Desde);
                            des_Comando.ColumnValues.AddWithValue("hasta", de1.Hasta);
                            des_Comando.ColumnValues.AddWithValue("horario", de1.Horario);
                            this.Connection.ExecuteNonQuery(des_Comando);
                        }

                        return base.Guardar();
                }


                public override void OnLoad()
                {
                        m_CuentaCorriente = null;
                        m_Etiquetas = null;
                        m_EtiquetasOriginal = null;
                        m_Grupo = null;
                        m_Localidad = null;
                        m_SituacionTributaria = null;
                        m_SubGrupo = null;
                        m_Vendedor = null;
                        base.OnLoad();
                }


                [Column(Name = "genero")]
                public int Genero
                {
                        get
                        {
                                return this.GetFieldValue<int>("genero");
                        }
                        set
                        {
                                this.Registro["genero"] = value;
                        }
                }


                [Column(Name = "numerocuenta")]
                public string NumeroCuenta
                {
                        get
                        {
                                return this.GetFieldValue<string>("numerocuenta");
                        }
                        set
                        {
                                this.Registro["numerocuenta"] = value;
                        }
                }


                [Column(Name = "cbu")]
                public string ClaveBancaria
                {
                        get
                        {
                                return this.GetFieldValue<string>("cbu");
                        }
                        set
                        {
                                this.Registro["cbu"] = value;
                        }
                }


                [Column(Name = "id_tipo_cuit")]
                public Lbl.Entidades.ClaveUnica TipoClaveTributaria
                {
                        get
                        {
                                if (Registro["id_tipo_cuit"] == null)
                                        return null;
                                else
                                        return this.GetFieldValue<Entidades.ClaveUnica>("id_tipo_cuit");
                        }
                        set
                        {
                                this.SetFieldValue("id_tipo_cuit", value);
                        }
                }


                public string Cbu
                {
                        get
                        {
                                if (this.ClaveBancaria == null)
                                        return "";
                                else
                                        return this.ClaveBancaria.ToString();
                        }
                }


                public string Cuit
                {
                        get
                        {
                                if (this.ClaveTributaria == null)
                                        return "";
                                else
                                        return this.ClaveTributaria.ToString();
                        }
                }


                [Column(Name = "cuit")]
                public IIdentificadorUnico ClaveTributaria
                {
                        get
                        {
                                if (this.GetFieldValue<string>("cuit") == null)
                                        return null;
                                else
                                        return new Claves.Cuit(this.GetFieldValue<string>("cuit"));
                        }
                        set
                        {
                                if (value == null)
                                        this.Registro["cuit"] = null;
                                else
                                        this.Registro["cuit"] = value.Valor;
                        }
                }

                public Impuestos.SituacionIva ObtenerSituacionIva()
                {
                        if (this.SituacionTributaria != null && this.SituacionTributaria.Id == 5)
                                return Impuestos.SituacionIva.Exento;
                        else if (this.Localidad == null)
                                return Impuestos.SituacionIva.Predeterminado;
                        else
                                return this.Localidad.ObtenerIva();
                }


                [Column(Name = "estadocredito")]
                public EstadoCredito EstadoCredito
                {
                        get
                        {
                                return (EstadoCredito)(this.GetFieldValue<int>("estadocredito"));
                        }
                        set
                        {
                                this.SetFieldValue("estadocredito", (int)value);
                        }
                }


                [Column(Name = "tipocuenta")]
                public TiposCuenta TipoCuenta
                {
                        get
                        {
                                return (TiposCuenta)(this.GetFieldValue<int>("tipocuenta"));
                        }
                        set
                        {
                                this.SetFieldValue("tipocuenta", (int)value);
                        }
                }


                [Column(Name = "tipo_fac")]
                public string FacturaPreferida
                {
                        get
                        {
                                if (this.Registro["tipo_fac"] == null || this.Registro["tipo_fac"] == DBNull.Value || this.Registro["tipo_fac"].ToString().Length == 0)
                                        return null;
                                else
                                        return this.Registro["tipo_fac"].ToString();
                        }
                        set
                        {
                                this.Registro["tipo_fac"] = value;
                        }
                }

                public Comprobantes.Tipo ObtenerTipoComprobante()
                {
                        string TipoComprob;
                        if (this.FacturaPreferida != null)
                        {
                                TipoComprob = "F" + this.FacturaPreferida;
                        }
                        else if (this.SituacionTributaria != null)
                        {
                                TipoComprob = "F" + this.SituacionTributaria.ObtenerLetraPredeterminada();
                        }
                        else
                        {
                                TipoComprob = "F" + this.LetraPredeterminada();
                        }

                        if (Lbl.Comprobantes.Tipo.TodosPorLetra.ContainsKey(TipoComprob))
                                return Lbl.Comprobantes.Tipo.TodosPorLetra[TipoComprob];
                        else
                                throw new InvalidOperationException("No se reconoce el tipo de comprobante " + TipoComprob + " para " + this.ToString());
                }


                [Column(Name = "id_tipo_doc")]
                public Lbl.Entidades.ClaveUnica TipoDocumento
                {
                        get
                        {
                                if (Registro["id_tipo_doc"] == null)
                                        return null;
                                else
                                        return this.GetFieldValue<Entidades.ClaveUnica>("id_tipo_doc");
                        }
                        set
                        {
                                this.SetFieldValue("id_tipo_doc", value);
                        }
                }


                [Column(Name = "num_doc")]
                public string NumeroDocumento
                {
                        get
                        {
                                return this.GetFieldValue<string>("num_doc");
                        }
                        set
                        {
                                this.Registro["num_doc"] = value;
                        }
                }


                [Column(Name = "tipo")]
                public int Tipo
                {
                        get
                        {
                                return this.GetFieldValue<int>("tipo");
                        }
                        set
                        {
                                this.Registro["tipo"] = value;
                        }
                }


                [Column(Name = "apellido")]
                public string Apellido
                {
                        get
                        {
                                return this.GetFieldValue<string>("apellido");
                        }
                        set
                        {
                                this.Registro["apellido"] = value;
                        }
                }


                /// <summary>
                /// El nombre de pila.
                /// </summary>
                [Column(Name = "nombre")]
                public virtual string Nombres
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


                [Column(Name = "nombre_fantasia")]
                public string NombreFantasia
                {
                        get
                        {
                                return this.GetFieldValue<string>("nombre_fantasia");
                        }
                        set
                        {
                                this.Registro["nombre_fantasia"] = value;
                        }
                }


                [Column(Name = "razon_social")]
                public string RazonSocial
                {
                        get
                        {
                                return this.GetFieldValue<string>("razon_social");
                        }
                        set
                        {
                                this.Registro["razon_social"] = value;
                        }
                }


                [Column(Name = "domicilio")]
                public string Domicilio
                {
                        get
                        {
                                return this.GetFieldValue<string>("domicilio");
                        }
                        set
                        {
                                this.Registro["domicilio"] = value;
                        }
                }


                [Column(Name = "domiciliotrabajo")]
                public string DomicilioLaboral
                {
                        get
                        {
                                return this.GetFieldValue<string>("domiciliotrabajo");
                        }
                        set
                        {
                                this.Registro["domiciliotrabajo"] = value;
                        }
                }


                [Column(Name = "telefono")]
                public string Telefono
                {
                        get
                        {
                                return this.GetFieldValue<string>("telefono");
                        }
                        set
                        {
                                this.Registro["telefono"] = value;
                        }
                }

                [Column(Name = "representante")]
                public string Representante
                {
                        get
                        {
                                return this.GetFieldValue<string>("representante");
                        }
                        set
                        {
                                this.Registro["representante"] = value;
                        }
                }


                [Column(Name = "email")]
                public string Email
                {
                        get
                        {
                                return this.GetFieldValue<string>("email");
                        }
                        set
                        {
                                this.Registro["email"] = value;
                        }
                }


                [Column(Name = "url")]
                public string Url
                {
                        get
                        {
                                return this.GetFieldValue<string>("url");
                        }
                        set
                        {
                                this.Registro["url"] = value;
                        }
                }


                public int Moneda
                {
                    get
                    {
                        if (m_Moneda == 0)
                            m_Moneda = this.GetFieldValue<int>("id_moneda");

                        return m_Moneda;
                    }
                    set
                    {
                        m_Moneda = value;
                        this.SetFieldValue("id_moneda", value);
                    }
                }

                public decimal CotizaA
                {
                    get
                    {
                        if (m_Cotiza == 0)
                            m_Cotiza = this.GetFieldValue<decimal>("cotiza");

                        return m_Cotiza;
                    }
                    set
                    {
                        m_Cotiza = value;
                        this.SetFieldValue("cotiza", value);
                    }
                }

        [Column(Name = "fechanac")]
                public DbDateTime FechaNacimiento
                {
                        get
                        {
                                return this.FieldDateTime("fechanac");
                        }
                        set
                        {
                                this.Registro["fechanac"] = value;
                        }
                }


                [Column(Name = "fechaalta")]
                public DbDateTime FechaAlta
                {
                        get
                        {
                                return this.FieldDateTime("fechaalta");
                        }
                        set
                        {
                                this.Registro["fechaalta"] = value;
                        }
                }


                [Column(Name = "fechabaja")]
                public DbDateTime FechaBaja
                {
                        get
                        {
                                return this.FieldDateTime("fechabaja");
                        }
                        set
                        {
                                this.Registro["fechabaja"] = value;
                        }
                }


                [Column(Name = "extra1")]
                public string Extra1
                {
                        get
                        {
                                return this.GetFieldValue<string>("extra1");
                        }
                        set
                        {
                                this.Registro["extra1"] = value;
                        }
                }


                [Column(Name = "limitecredito")]
                public decimal LimiteCredito
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("limitecredito");
                        }
                        set
                        {
                                this.Registro["limitecredito"] = value;
                        }
                }


                [Column(Name = "limitecreditofecha")]
                public DbDateTime LimiteCreditoFecha
                {
                        get
                        {
                                return this.FieldDateTime("limitecreditofecha");
                        }
                        set
                        {
                                this.Registro["limitecreditofecha"] = value;
                        }
                }


                [Column(Name = "id_grupo")]
                public Lbl.Personas.Grupo Grupo
                {
                        get
                        {
                                if (m_Grupo == null && this.GetFieldValue<int>("id_grupo") > 0)
                                        m_Grupo = this.GetFieldValue<Grupo>("id_grupo");

                                return m_Grupo;
                        }
                        set
                        {
                                m_Grupo = value;
                                this.SetFieldValue("id_grupo", value);
                        }
                }


                [Column(Name = "id_subgrupo")]
                public Lbl.Personas.Grupo SubGrupo
                {
                        get
                        {
                                if (m_SubGrupo == null && this.GetFieldValue<int>("id_subgrupo") > 0)
                                        m_SubGrupo = this.GetFieldValue<Grupo>("id_subgrupo");

                                return m_SubGrupo;
                        }
                        set
                        {
                                m_SubGrupo = value;
                                this.SetFieldValue("id_subgrupo", value);
                        }
                }


                [Column(Name = "id_localidad")]
                public Lbl.Entidades.Localidad Localidad
                {
                        get
                        {
                                if (m_Localidad == null)
                                {
                                        if (this.Id == 999)
                                                // El cliente especial "Consumidor Final" está siempre en la ciudad actual
                                                m_Localidad = Lbl.Sys.Config.Empresa.SucursalActual.Localidad;
                                        else if (this.GetFieldValue<int>("id_ciudad") > 0)
                                                m_Localidad = this.GetFieldValue<Lbl.Entidades.Localidad>("id_ciudad");
                                }
                                return m_Localidad;
                        }
                        set
                        {
                                m_Localidad = value;
                                this.SetFieldValue("id_ciudad", m_Localidad);
                        }
                }


                [Column(Name = "id_situacion")]
                public Lbl.Impuestos.SituacionTributaria SituacionTributaria
                {
                        get
                        {
                                if (m_SituacionTributaria == null && this.GetFieldValue<int>("id_situacion") > 0)
                                        m_SituacionTributaria = this.GetFieldValue<Lbl.Impuestos.SituacionTributaria>("id_situacion");

                                return m_SituacionTributaria;
                        }
                        set
                        {
                                m_SituacionTributaria = value;
                                this.SetFieldValue("id_situacion", value);
                        }
                }

                public List<Descuentos> Descuentos
                {
                    get
                    {
                        if (m_Descuentos == null)
                        {
                            m_Descuentos = new List<Descuentos>();
                            using (System.Data.DataTable TablaListaItem = this.Connection.Select("SELECT id_personadescuento FROM personas_descuentos WHERE id_persona=" + this.Id.ToString() + " ORDER BY id_personadescuento desc"))
                            {
                                foreach (System.Data.DataRow RowItem in TablaListaItem.Rows)
                                {
                                    m_Descuentos.Add(new Descuentos(this.Connection, System.Convert.ToInt32(RowItem["id_personadescuento"])));
                                }
                            }
                        }
                        return m_Descuentos;
                    }
                    set
                    {
                        m_Descuentos = value;
                        this.SetFieldValue("Descuentos", value);
                    }
                }

                public string LetraPredeterminada()
                {
                        if (this.FacturaPreferida == null)
                        {
                                if (this.SituacionTributaria == null)
                                {
                                        if (Lbl.Sys.Config.Empresa.SituacionTributaria == 4)
                                                // Soy monotributista
                                                return "C";
                                        else if (Lbl.Sys.Config.Pais.Id == 1)
                                                return "B";
                                        else
                                                // TODO: poder seleccionar el tipo de factura predeterminado para cada país
                                                return "A";
                                }
                                else
                                {
                                        return this.SituacionTributaria.ObtenerLetraPredeterminada();
                                }
                        }
                        else
                        {
                                return this.FacturaPreferida;
                        }
                }

                public Lbl.CuentasCorrientes.CuentaCorriente CuentaCorriente
                {
                        get
                        {
                                if (m_CuentaCorriente == null)
                                        m_CuentaCorriente = new Lbl.CuentasCorrientes.CuentaCorriente(this);
                                return m_CuentaCorriente;
                        }
                }


                [Column(Name = "id_vendedor")]
                public Lbl.Personas.Persona Vendedor
                {
                        get
                        {
                                if (m_Vendedor == null && this.GetFieldValue<int>("id_vendedor") != 0)
                                        m_Vendedor = this.GetFieldValue<Lbl.Personas.Persona>("id_vendedor");
                                return m_Vendedor;
                        }
                        set
                        {
                                m_Vendedor = value;
                                this.SetFieldValue("id_vendedor", value);
                        }
                }

                [Column(Name = "id_conceptoventa")]
                public Lbl.Cajas.Concepto ConceptoVenta {
                    get {
                        if (m_ConceptoVenta == null && this.GetFieldValue<int>("id_conceptoventa") != 0)
                            m_ConceptoVenta = this.GetFieldValue<Lbl.Cajas.Concepto>("id_conceptoventa");
                        return m_ConceptoVenta;
                    }
                    set {
                        m_ConceptoVenta = value;
                        this.SetFieldValue("id_conceptoventa", value);
                    }
                }

                [Column(Name = "id_conceptocompra")]
                public Lbl.Cajas.Concepto ConceptoCompra {
                    get {
                        if (m_ConceptoCompra == null && this.GetFieldValue<int>("id_conceptocompra") != 0)
                            m_ConceptoCompra = this.GetFieldValue<Lbl.Cajas.Concepto>("id_conceptocompra");
                        return m_ConceptoCompra;
                    }
                    set {
                        m_ConceptoCompra = value;
                        this.SetFieldValue("id_conceptocompra", value);
                    }
                }

        public override string ToString()
        {
            string nomFree = LoadClienteFree();
            if (nomFree != "")
                return nomFree;
            return this.GetFieldValue<string>(this.CampoNombre);
        }

        public void Activar(bool activar)
                {
                        this.Estado = activar ? 1 : 0;
                        qGen.Update ActCmd = new qGen.Update(this.TablaDatos);
                        ActCmd.ColumnValues.AddWithValue("estado", this.Estado);
                        ActCmd.ColumnValues.AddWithValue("fechabaja", new qGen.SqlExpression("NOW()"));
                        ActCmd.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        this.Connection.ExecuteNonQuery(ActCmd);
                        Lbl.Sys.Config.ActionLog(this.Connection, Lbl.Sys.Log.Acciones.Delete, this, activar ? "Activar" : "Desactivar");
                }
        }
}