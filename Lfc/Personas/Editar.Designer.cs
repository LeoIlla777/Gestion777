using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lfc.Personas
{
    public partial class Editar
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editar));
            this.EntradaEmail = new Lui.Forms.TextBox();
            this.EntradaLocalidad = new Lcc.Entrada.CodigoDetalle();
            this.EntradaDomicilio = new Lui.Forms.TextBox();
            this.EntradaNumDoc = new Lui.Forms.TextBox();
            this.EntradaTipoDoc = new Lcc.Entrada.CodigoDetalle();
            this.EntradaApellido = new Lui.Forms.TextBox();
            this.EntradaNombre = new Lui.Forms.TextBox();
            this.EntradaClaveTributaria = new Lui.Forms.TextBox();
            this.EntradaRazonSocial = new Lui.Forms.TextBox();
            this.Label10 = new Lui.Forms.Label();
            this.Label9 = new Lui.Forms.Label();
            this.Label8 = new Lui.Forms.Label();
            this.Label6 = new Lui.Forms.Label();
            this.Label5 = new Lui.Forms.Label();
            this.Label2 = new Lui.Forms.Label();
            this.Label1 = new Lui.Forms.Label();
            this.EtiquetaClaveTributaria = new Lui.Forms.Label();
            this.Label3 = new Lui.Forms.Label();
            this.Label11 = new Lui.Forms.Label();
            this.PanelI1 = new Lui.Forms.Frame();
            this.btnCtaCte = new Lui.Forms.Button();
            this.EntradaGenero = new Lui.Forms.ComboBox();
            this.label7 = new Lui.Forms.Label();
            this.EntradaFechaNac = new Lui.Forms.TextBox();
            this.label18 = new Lui.Forms.Label();
            this.PanelD1 = new Lui.Forms.Frame();
            this.EntradaNombreFantasia = new Lui.Forms.TextBox();
            this.label27 = new Lui.Forms.Label();
            this.EntradaSituacion = new Lcc.Entrada.CodigoDetalle();
            this.EntradaTipoFac = new Lui.Forms.ComboBox();
            this.Label12 = new Lui.Forms.Label();
            this.Label15 = new Lui.Forms.Label();
            this.EntradaDomicilioTrabajo = new Lui.Forms.TextBox();
            this.label19 = new Lui.Forms.Label();
            this.PanelI2 = new Lui.Forms.Frame();
            this.EntradaVendedor = new Lcc.Entrada.CodigoDetalle();
            this.EntradaTelefono = new Lcc.Entrada.MatrizTelefonos();
            this.label23 = new Lui.Forms.Label();
            this.EntradaEstado = new Lui.Forms.ComboBox();
            this.EntradaObs = new Lui.Forms.TextBox();
            this.PanelAbajo = new Lui.Forms.Frame();
            this.EntradaFechaBaja = new Lui.Forms.TextBox();
            this.EntradaFechaAlta = new Lui.Forms.TextBox();
            this.label4 = new Lui.Forms.Label();
            this.label24 = new Lui.Forms.Label();
            this.label25 = new Lui.Forms.Label();
            this.label26 = new Lui.Forms.Label();
            this.matrizTelefonos1 = new Lcc.Entrada.MatrizTelefonos();
            this.label13 = new Lui.Forms.Label();
            this.Label14 = new Lui.Forms.Label();
            this.Label16 = new Lui.Forms.Label();
            this.label21 = new Lui.Forms.Label();
            this.label22 = new Lui.Forms.Label();
            this.label17 = new Lui.Forms.Label();
            this.EntradaEstadoCredito = new Lui.Forms.ComboBox();
            this.EtiquetaClaveBancaria = new Lui.Forms.Label();
            this.EntradaNumeroCuenta = new Lui.Forms.TextBox();
            this.EntradaTipo = new Lcc.Entrada.CodigoDetalle();
            this.EntradaLimiteCredito = new Lui.Forms.TextBox();
            this.EntradaClaveBancaria = new Lui.Forms.TextBox();
            this.EntradaGrupo = new Lcc.Entrada.CodigoDetalle();
            this.EntradaSubGrupo = new Lcc.Entrada.CodigoDetalle();
            this.EntradaTipoCuenta = new Lui.Forms.ComboBox();
            this.panelMoneda = new Lui.Forms.Frame();
            this.cotizaValor = new Lui.Forms.TextBox();
            this.label29 = new Lui.Forms.Label();
            this.monedaCotiza = new Lcc.Entrada.CodigoDetalle();
            this.label20 = new Lui.Forms.Label();
            this.label28 = new Lui.Forms.Label();
            this.PanelD2 = new Lui.Forms.Frame();
            this.frame1 = new Lui.Forms.Frame();
            this.label33 = new Lui.Forms.Label();
            this.label32 = new Lui.Forms.Label();
            this.cbHorarios = new System.Windows.Forms.CheckBox();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.label30 = new Lui.Forms.Label();
            this.dgvRubro = new System.Windows.Forms.DataGridView();
            this.cg_RubroGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cg_Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cg_Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cg_Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cg_Horario = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cg_Anular = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cg_Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cg_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cg_RubroID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescuento = new Lui.Forms.TextBox();
            this.cbRubro = new Lui.Forms.ComboBox();
            this.btnAgregarRubro = new Lui.Forms.Button();
            this.txtDetalleRubro = new Lcc.Entrada.CodigoDetalle();
            this.label31 = new Lui.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelCuentaContable = new Lui.Forms.Frame();
            this.EntradaConceptoCompra = new Lcc.Entrada.CodigoDetalle();
            this.label34 = new Lui.Forms.Label();
            this.EntradaConceptoVenta = new Lcc.Entrada.CodigoDetalle();
            this.label35 = new Lui.Forms.Label();
            this.label36 = new Lui.Forms.Label();
            this.EntradaRepresentante = new Lui.Forms.TextBox();
            this.PanelI1.SuspendLayout();
            this.PanelD1.SuspendLayout();
            this.PanelI2.SuspendLayout();
            this.PanelAbajo.SuspendLayout();
            this.panelMoneda.SuspendLayout();
            this.PanelD2.SuspendLayout();
            this.frame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubro)).BeginInit();
            this.panelCuentaContable.SuspendLayout();
            this.SuspendLayout();
            // 
            // EntradaEmail
            // 
            this.EntradaEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaEmail.ForceCase = Lui.Forms.TextCasing.LowerCase;
            this.EntradaEmail.Location = new System.Drawing.Point(128, 200);
            this.EntradaEmail.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaEmail.MaxLength = 200;
            this.EntradaEmail.Name = "EntradaEmail";
            this.EntradaEmail.Size = new System.Drawing.Size(212, 24);
            this.EntradaEmail.TabIndex = 3;
            this.EntradaEmail.Leave += new System.EventHandler(this.EntradaEmail_Leave);
            // 
            // EntradaLocalidad
            // 
            this.EntradaLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaLocalidad.AutoTab = true;
            this.EntradaLocalidad.CanCreate = true;
            this.EntradaLocalidad.Filter = "id_provincia IS NOT NULL";
            this.EntradaLocalidad.Location = new System.Drawing.Point(128, 232);
            this.EntradaLocalidad.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaLocalidad.MaxLength = 200;
            this.EntradaLocalidad.Name = "EntradaLocalidad";
            this.EntradaLocalidad.NombreTipo = "Lbl.Entidades.Localidad";
            this.EntradaLocalidad.PlaceholderText = "Sin especificar";
            this.EntradaLocalidad.Required = true;
            this.EntradaLocalidad.Size = new System.Drawing.Size(212, 24);
            this.EntradaLocalidad.TabIndex = 4;
            this.EntradaLocalidad.Text = "0";
            // 
            // EntradaDomicilio
            // 
            this.EntradaDomicilio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaDomicilio.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaDomicilio.Location = new System.Drawing.Point(128, 40);
            this.EntradaDomicilio.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaDomicilio.MaxLength = 200;
            this.EntradaDomicilio.Name = "EntradaDomicilio";
            this.EntradaDomicilio.Size = new System.Drawing.Size(212, 24);
            this.EntradaDomicilio.TabIndex = 0;
            // 
            // EntradaNumDoc
            // 
            this.EntradaNumDoc.Location = new System.Drawing.Point(208, 136);
            this.EntradaNumDoc.MaxLength = 50;
            this.EntradaNumDoc.Name = "EntradaNumDoc";
            this.EntradaNumDoc.Size = new System.Drawing.Size(136, 24);
            this.EntradaNumDoc.TabIndex = 4;
            // 
            // EntradaTipoDoc
            // 
            this.EntradaTipoDoc.AutoTab = true;
            this.EntradaTipoDoc.CanCreate = false;
            this.EntradaTipoDoc.Location = new System.Drawing.Point(208, 104);
            this.EntradaTipoDoc.MaximumSize = new System.Drawing.Size(200, 32);
            this.EntradaTipoDoc.MaxLength = 200;
            this.EntradaTipoDoc.Name = "EntradaTipoDoc";
            this.EntradaTipoDoc.NombreTipo = "Lbl.Entidades.ClaveUnica";
            this.EntradaTipoDoc.Required = true;
            this.EntradaTipoDoc.Size = new System.Drawing.Size(136, 24);
            this.EntradaTipoDoc.TabIndex = 3;
            this.EntradaTipoDoc.Text = "0";
            // 
            // EntradaApellido
            // 
            this.EntradaApellido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaApellido.ForceCase = Lui.Forms.TextCasing.Caption;
            this.EntradaApellido.Location = new System.Drawing.Point(112, 72);
            this.EntradaApellido.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaApellido.MaxLength = 200;
            this.EntradaApellido.Name = "EntradaApellido";
            this.EntradaApellido.Size = new System.Drawing.Size(232, 24);
            this.EntradaApellido.TabIndex = 2;
            this.EntradaApellido.TextChanged += new System.EventHandler(this.GenerarNombreVisible);
            // 
            // EntradaNombre
            // 
            this.EntradaNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Caption;
            this.EntradaNombre.Location = new System.Drawing.Point(112, 40);
            this.EntradaNombre.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaNombre.MaxLength = 200;
            this.EntradaNombre.Name = "EntradaNombre";
            this.EntradaNombre.Size = new System.Drawing.Size(232, 24);
            this.EntradaNombre.TabIndex = 1;
            this.EntradaNombre.TextChanged += new System.EventHandler(this.GenerarNombreVisible);
            // 
            // EntradaClaveTributaria
            // 
            this.EntradaClaveTributaria.Location = new System.Drawing.Point(129, 104);
            this.EntradaClaveTributaria.MaxLength = 50;
            this.EntradaClaveTributaria.Name = "EntradaClaveTributaria";
            this.EntradaClaveTributaria.Size = new System.Drawing.Size(142, 24);
            this.EntradaClaveTributaria.TabIndex = 2;
            this.EntradaClaveTributaria.Leave += new System.EventHandler(this.EntradaClaveTributaria_Leave);
            // 
            // EntradaRazonSocial
            // 
            this.EntradaRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaRazonSocial.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaRazonSocial.Location = new System.Drawing.Point(129, 72);
            this.EntradaRazonSocial.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaRazonSocial.MaxLength = 200;
            this.EntradaRazonSocial.Name = "EntradaRazonSocial";
            this.EntradaRazonSocial.Size = new System.Drawing.Size(212, 24);
            this.EntradaRazonSocial.TabIndex = 1;
            this.EntradaRazonSocial.TextChanged += new System.EventHandler(this.GenerarNombreVisible);
            // 
            // Label10
            // 
            this.Label10.Location = new System.Drawing.Point(8, 100);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(120, 24);
            this.Label10.TabIndex = 4;
            this.Label10.Text = "Teléfonos";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label9
            // 
            this.Label9.Location = new System.Drawing.Point(8, 232);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(120, 24);
            this.Label9.TabIndex = 8;
            this.Label9.Text = "Localidad";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(8, 40);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(120, 24);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Domicilio";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(8, 136);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(200, 24);
            this.Label6.TabIndex = 6;
            this.Label6.Text = "Número de documento";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(8, 104);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(200, 24);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Tipo de documento";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 72);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(104, 24);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Apellidos";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 40);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(104, 24);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Nombres";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EtiquetaClaveTributaria
            // 
            this.EtiquetaClaveTributaria.Location = new System.Drawing.Point(9, 104);
            this.EtiquetaClaveTributaria.Name = "EtiquetaClaveTributaria";
            this.EtiquetaClaveTributaria.Size = new System.Drawing.Size(120, 24);
            this.EtiquetaClaveTributaria.TabIndex = 2;
            this.EtiquetaClaveTributaria.Text = "Clave tributaria";
            this.EtiquetaClaveTributaria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(9, 72);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(120, 24);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Razón social";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(8, 200);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(120, 24);
            this.Label11.TabIndex = 6;
            this.Label11.Text = "E-mail";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelI1
            // 
            this.PanelI1.Controls.Add(this.btnCtaCte);
            this.PanelI1.Controls.Add(this.EntradaGenero);
            this.PanelI1.Controls.Add(this.label7);
            this.PanelI1.Controls.Add(this.EntradaNombre);
            this.PanelI1.Controls.Add(this.EntradaApellido);
            this.PanelI1.Controls.Add(this.EntradaTipoDoc);
            this.PanelI1.Controls.Add(this.EntradaFechaNac);
            this.PanelI1.Controls.Add(this.EntradaNumDoc);
            this.PanelI1.Controls.Add(this.Label1);
            this.PanelI1.Controls.Add(this.Label6);
            this.PanelI1.Controls.Add(this.Label2);
            this.PanelI1.Controls.Add(this.Label5);
            this.PanelI1.Controls.Add(this.label18);
            this.PanelI1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PanelI1.Location = new System.Drawing.Point(0, 0);
            this.PanelI1.Margin = new System.Windows.Forms.Padding(6);
            this.PanelI1.Name = "PanelI1";
            this.PanelI1.Size = new System.Drawing.Size(344, 259);
            this.PanelI1.TabIndex = 0;
            this.PanelI1.Text = "Personas físicas";
            // 
            // btnCtaCte
            // 
            this.btnCtaCte.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCtaCte.Image = null;
            this.btnCtaCte.ImagePos = Lui.Forms.ImagePositions.Top;
            this.btnCtaCte.Location = new System.Drawing.Point(208, 230);
            this.btnCtaCte.Name = "btnCtaCte";
            this.btnCtaCte.Size = new System.Drawing.Size(136, 29);
            this.btnCtaCte.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.btnCtaCte.Subtext = "Tecla";
            this.btnCtaCte.TabIndex = 11;
            this.btnCtaCte.Text = "Ver Cta.Cte.";
            this.btnCtaCte.Click += new System.EventHandler(this.btnCtaCte_Click);
            // 
            // EntradaGenero
            // 
            this.EntradaGenero.AlwaysExpanded = false;
            this.EntradaGenero.AutoSize = true;
            this.EntradaGenero.Cursor = System.Windows.Forms.Cursors.Default;
            this.EntradaGenero.Location = new System.Drawing.Point(208, 198);
            this.EntradaGenero.Name = "EntradaGenero";
            this.EntradaGenero.SetData = new string[] {
        "Sin especificar|0",
        "Masculino|1",
        "Femenino|2"};
            this.EntradaGenero.Size = new System.Drawing.Size(136, 24);
            this.EntradaGenero.TabIndex = 6;
            this.EntradaGenero.TextKey = "0";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "Género";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaFechaNac
            // 
            this.EntradaFechaNac.DataType = Lui.Forms.DataTypes.Date;
            this.EntradaFechaNac.Location = new System.Drawing.Point(208, 168);
            this.EntradaFechaNac.MaxLength = 10;
            this.EntradaFechaNac.Name = "EntradaFechaNac";
            this.EntradaFechaNac.Size = new System.Drawing.Size(136, 24);
            this.EntradaFechaNac.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(200, 24);
            this.label18.TabIndex = 8;
            this.label18.Text = "Fecha de Nacimiento";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelD1
            // 
            this.PanelD1.Controls.Add(this.EntradaNombreFantasia);
            this.PanelD1.Controls.Add(this.label27);
            this.PanelD1.Controls.Add(this.EntradaRazonSocial);
            this.PanelD1.Controls.Add(this.EntradaClaveTributaria);
            this.PanelD1.Controls.Add(this.EntradaSituacion);
            this.PanelD1.Controls.Add(this.EntradaTipoFac);
            this.PanelD1.Controls.Add(this.Label3);
            this.PanelD1.Controls.Add(this.EtiquetaClaveTributaria);
            this.PanelD1.Controls.Add(this.Label12);
            this.PanelD1.Controls.Add(this.Label15);
            this.PanelD1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PanelD1.Location = new System.Drawing.Point(360, 0);
            this.PanelD1.Margin = new System.Windows.Forms.Padding(6);
            this.PanelD1.Name = "PanelD1";
            this.PanelD1.Size = new System.Drawing.Size(344, 259);
            this.PanelD1.TabIndex = 1;
            this.PanelD1.Text = "Personas jurídicas";
            // 
            // EntradaNombreFantasia
            // 
            this.EntradaNombreFantasia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaNombreFantasia.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaNombreFantasia.Location = new System.Drawing.Point(129, 40);
            this.EntradaNombreFantasia.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaNombreFantasia.MaxLength = 200;
            this.EntradaNombreFantasia.Name = "EntradaNombreFantasia";
            this.EntradaNombreFantasia.Size = new System.Drawing.Size(212, 24);
            this.EntradaNombreFantasia.TabIndex = 0;
            this.EntradaNombreFantasia.TextChanged += new System.EventHandler(this.GenerarNombreVisible);
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(9, 40);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(120, 24);
            this.label27.TabIndex = 12;
            this.label27.Text = "Nombre fantasía";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaSituacion
            // 
            this.EntradaSituacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaSituacion.AutoTab = true;
            this.EntradaSituacion.CanCreate = false;
            this.EntradaSituacion.Location = new System.Drawing.Point(129, 136);
            this.EntradaSituacion.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaSituacion.MaxLength = 200;
            this.EntradaSituacion.Name = "EntradaSituacion";
            this.EntradaSituacion.NombreTipo = "Lbl.Impuestos.SituacionTributaria";
            this.EntradaSituacion.Required = true;
            this.EntradaSituacion.Size = new System.Drawing.Size(212, 24);
            this.EntradaSituacion.TabIndex = 3;
            this.EntradaSituacion.Text = "0";
            this.EntradaSituacion.Leave += new System.EventHandler(this.EntradaSituacion_Leave);
            // 
            // EntradaTipoFac
            // 
            this.EntradaTipoFac.AlwaysExpanded = true;
            this.EntradaTipoFac.Location = new System.Drawing.Point(129, 168);
            this.EntradaTipoFac.Name = "EntradaTipoFac";
            this.EntradaTipoFac.SetData = new string[] {
        "Predeterminada|*",
        "Factura A|A",
        "Factura B|B",
        "Factura C|C",
        "Factura E|E",
        "Ticket|T"};
            this.EntradaTipoFac.Size = new System.Drawing.Size(188, 75);
            this.EntradaTipoFac.TabIndex = 4;
            this.EntradaTipoFac.TextKey = "*";
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(9, 136);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(120, 24);
            this.Label12.TabIndex = 4;
            this.Label12.Text = "Situación trib.";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label15
            // 
            this.Label15.Location = new System.Drawing.Point(9, 168);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(120, 24);
            this.Label15.TabIndex = 6;
            this.Label15.Text = "Facturación";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaDomicilioTrabajo
            // 
            this.EntradaDomicilioTrabajo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaDomicilioTrabajo.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaDomicilioTrabajo.Location = new System.Drawing.Point(128, 72);
            this.EntradaDomicilioTrabajo.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaDomicilioTrabajo.MaxLength = 200;
            this.EntradaDomicilioTrabajo.Name = "EntradaDomicilioTrabajo";
            this.EntradaDomicilioTrabajo.Size = new System.Drawing.Size(212, 24);
            this.EntradaDomicilioTrabajo.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 72);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 24);
            this.label19.TabIndex = 2;
            this.label19.Text = "Dom. laboral";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelI2
            // 
            this.PanelI2.Controls.Add(this.EntradaRepresentante);
            this.PanelI2.Controls.Add(this.label36);
            this.PanelI2.Controls.Add(this.EntradaDomicilio);
            this.PanelI2.Controls.Add(this.EntradaVendedor);
            this.PanelI2.Controls.Add(this.EntradaDomicilioTrabajo);
            this.PanelI2.Controls.Add(this.EntradaEmail);
            this.PanelI2.Controls.Add(this.EntradaLocalidad);
            this.PanelI2.Controls.Add(this.EntradaTelefono);
            this.PanelI2.Controls.Add(this.Label8);
            this.PanelI2.Controls.Add(this.label19);
            this.PanelI2.Controls.Add(this.label23);
            this.PanelI2.Controls.Add(this.Label11);
            this.PanelI2.Controls.Add(this.Label10);
            this.PanelI2.Controls.Add(this.Label9);
            this.PanelI2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PanelI2.Location = new System.Drawing.Point(0, 271);
            this.PanelI2.Margin = new System.Windows.Forms.Padding(6);
            this.PanelI2.Name = "PanelI2";
            this.PanelI2.Size = new System.Drawing.Size(344, 323);
            this.PanelI2.TabIndex = 2;
            this.PanelI2.Text = "Datos de contacto";
            // 
            // EntradaVendedor
            // 
            this.EntradaVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaVendedor.AutoTab = true;
            this.EntradaVendedor.CanCreate = true;
            this.EntradaVendedor.Filter = "(tipo&4)=4";
            this.EntradaVendedor.Location = new System.Drawing.Point(128, 264);
            this.EntradaVendedor.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaVendedor.MaxLength = 200;
            this.EntradaVendedor.Name = "EntradaVendedor";
            this.EntradaVendedor.NombreTipo = "Lbl.Personas.Persona";
            this.EntradaVendedor.PlaceholderText = "Ninguno";
            this.EntradaVendedor.Required = false;
            this.EntradaVendedor.Size = new System.Drawing.Size(212, 24);
            this.EntradaVendedor.TabIndex = 5;
            this.EntradaVendedor.Text = "0";
            // 
            // EntradaTelefono
            // 
            this.EntradaTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaTelefono.AutoScrollMargin = new System.Drawing.Size(4, 4);
            this.EntradaTelefono.Location = new System.Drawing.Point(128, 104);
            this.EntradaTelefono.Name = "EntradaTelefono";
            this.EntradaTelefono.Size = new System.Drawing.Size(214, 88);
            this.EntradaTelefono.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 264);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(120, 24);
            this.label23.TabIndex = 10;
            this.label23.Text = "Vendedor";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaEstado
            // 
            this.EntradaEstado.AlwaysExpanded = true;
            this.EntradaEstado.AutoSize = true;
            this.EntradaEstado.Location = new System.Drawing.Point(136, 40);
            this.EntradaEstado.Name = "EntradaEstado";
            this.EntradaEstado.SetData = new string[] {
        "Inactivo|0",
        "Activo|1"};
            this.EntradaEstado.Size = new System.Drawing.Size(131, 40);
            this.EntradaEstado.TabIndex = 0;
            this.EntradaEstado.TextKey = "1";
            // 
            // EntradaObs
            // 
            this.EntradaObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaObs.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaObs.Location = new System.Drawing.Point(472, 40);
            this.EntradaObs.MultiLine = true;
            this.EntradaObs.Name = "EntradaObs";
            this.EntradaObs.Size = new System.Drawing.Size(255, 96);
            this.EntradaObs.TabIndex = 1;
            // 
            // PanelAbajo
            // 
            this.PanelAbajo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelAbajo.Controls.Add(this.EntradaEstado);
            this.PanelAbajo.Controls.Add(this.EntradaFechaBaja);
            this.PanelAbajo.Controls.Add(this.EntradaFechaAlta);
            this.PanelAbajo.Controls.Add(this.EntradaObs);
            this.PanelAbajo.Controls.Add(this.label4);
            this.PanelAbajo.Controls.Add(this.label24);
            this.PanelAbajo.Controls.Add(this.label25);
            this.PanelAbajo.Controls.Add(this.label26);
            this.PanelAbajo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PanelAbajo.Location = new System.Drawing.Point(0, 611);
            this.PanelAbajo.Margin = new System.Windows.Forms.Padding(6);
            this.PanelAbajo.Name = "PanelAbajo";
            this.PanelAbajo.Size = new System.Drawing.Size(727, 156);
            this.PanelAbajo.TabIndex = 4;
            this.PanelAbajo.Text = "Estado";
            // 
            // EntradaFechaBaja
            // 
            this.EntradaFechaBaja.DataType = Lui.Forms.DataTypes.Date;
            this.EntradaFechaBaja.Location = new System.Drawing.Point(136, 120);
            this.EntradaFechaBaja.Name = "EntradaFechaBaja";
            this.EntradaFechaBaja.ReadOnly = true;
            this.EntradaFechaBaja.Size = new System.Drawing.Size(112, 24);
            this.EntradaFechaBaja.TabIndex = 5;
            this.EntradaFechaBaja.TabStop = false;
            // 
            // EntradaFechaAlta
            // 
            this.EntradaFechaAlta.DataType = Lui.Forms.DataTypes.Date;
            this.EntradaFechaAlta.Location = new System.Drawing.Point(136, 88);
            this.EntradaFechaAlta.Name = "EntradaFechaAlta";
            this.EntradaFechaAlta.ReadOnly = true;
            this.EntradaFechaAlta.Size = new System.Drawing.Size(112, 24);
            this.EntradaFechaAlta.TabIndex = 2;
            this.EntradaFechaAlta.TabStop = false;
            this.EntradaFechaAlta.Text = "01/01/2001";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(328, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Observaciones";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 40);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(128, 24);
            this.label24.TabIndex = 0;
            this.label24.Text = "Estado";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(8, 88);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(128, 24);
            this.label25.TabIndex = 2;
            this.label25.Text = "Fecha de alta";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 120);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(128, 24);
            this.label26.TabIndex = 4;
            this.label26.Text = "Fecha de baja";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // matrizTelefonos1
            // 
            this.matrizTelefonos1.AutoScrollMargin = new System.Drawing.Size(4, 4);
            this.matrizTelefonos1.Location = new System.Drawing.Point(0, 0);
            this.matrizTelefonos1.Name = "matrizTelefonos1";
            this.matrizTelefonos1.Size = new System.Drawing.Size(536, 180);
            this.matrizTelefonos1.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 24);
            this.label13.TabIndex = 2;
            this.label13.Text = "Sub grupo";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label14
            // 
            this.Label14.Location = new System.Drawing.Point(8, 104);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(104, 24);
            this.Label14.TabIndex = 4;
            this.Label14.Text = "Funciones";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label16
            // 
            this.Label16.Location = new System.Drawing.Point(8, 40);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(104, 24);
            this.Label16.TabIndex = 0;
            this.Label16.Text = "Grupo";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(8, 232);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(168, 24);
            this.label21.TabIndex = 13;
            this.label21.Text = "Estado de crédito";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 136);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 24);
            this.label22.TabIndex = 6;
            this.label22.Text = "Nº de cuenta";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 200);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(168, 24);
            this.label17.TabIndex = 11;
            this.label17.Text = "Límite de crédito";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaEstadoCredito
            // 
            this.EntradaEstadoCredito.AlwaysExpanded = true;
            this.EntradaEstadoCredito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaEstadoCredito.AutoSize = true;
            this.EntradaEstadoCredito.Location = new System.Drawing.Point(176, 232);
            this.EntradaEstadoCredito.Name = "EntradaEstadoCredito";
            this.EntradaEstadoCredito.SetData = new string[] {
        "Normal|0",
        "En plan de pago|5",
        "Suspendido con react. automática|10",
        "Susp. con reactivación manual|100",
        "Judicializado|110"};
            this.EntradaEstadoCredito.Size = new System.Drawing.Size(172, 91);
            this.EntradaEstadoCredito.TabIndex = 7;
            this.EntradaEstadoCredito.TextKey = "100";
            // 
            // EtiquetaClaveBancaria
            // 
            this.EtiquetaClaveBancaria.Location = new System.Drawing.Point(8, 168);
            this.EtiquetaClaveBancaria.Name = "EtiquetaClaveBancaria";
            this.EtiquetaClaveBancaria.Size = new System.Drawing.Size(104, 24);
            this.EtiquetaClaveBancaria.TabIndex = 9;
            this.EtiquetaClaveBancaria.Text = "CBU";
            this.EtiquetaClaveBancaria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaNumeroCuenta
            // 
            this.EntradaNumeroCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaNumeroCuenta.Location = new System.Drawing.Point(200, 136);
            this.EntradaNumeroCuenta.MaxLength = 200;
            this.EntradaNumeroCuenta.Name = "EntradaNumeroCuenta";
            this.EntradaNumeroCuenta.Size = new System.Drawing.Size(144, 24);
            this.EntradaNumeroCuenta.TabIndex = 4;
            // 
            // EntradaTipo
            // 
            this.EntradaTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaTipo.AutoTab = true;
            this.EntradaTipo.CanCreate = false;
            this.EntradaTipo.Location = new System.Drawing.Point(112, 104);
            this.EntradaTipo.MaximumSize = new System.Drawing.Size(320, 32);
            this.EntradaTipo.MaxLength = 200;
            this.EntradaTipo.Name = "EntradaTipo";
            this.EntradaTipo.NombreTipo = "Lbl.Personas.Tipo";
            this.EntradaTipo.PlaceholderText = "Sin especificar";
            this.EntradaTipo.Required = true;
            this.EntradaTipo.Size = new System.Drawing.Size(232, 24);
            this.EntradaTipo.TabIndex = 2;
            this.EntradaTipo.Text = "0";
            this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaTipo_TextChanged);
            // 
            // EntradaLimiteCredito
            // 
            this.EntradaLimiteCredito.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaLimiteCredito.Location = new System.Drawing.Point(176, 200);
            this.EntradaLimiteCredito.MaxLength = 16;
            this.EntradaLimiteCredito.Name = "EntradaLimiteCredito";
            this.EntradaLimiteCredito.Prefijo = "$";
            this.EntradaLimiteCredito.Size = new System.Drawing.Size(120, 24);
            this.EntradaLimiteCredito.TabIndex = 6;
            this.EntradaLimiteCredito.Text = "0.00";
            // 
            // EntradaClaveBancaria
            // 
            this.EntradaClaveBancaria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaClaveBancaria.Location = new System.Drawing.Point(112, 168);
            this.EntradaClaveBancaria.Name = "EntradaClaveBancaria";
            this.EntradaClaveBancaria.Size = new System.Drawing.Size(232, 24);
            this.EntradaClaveBancaria.TabIndex = 5;
            // 
            // EntradaGrupo
            // 
            this.EntradaGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaGrupo.AutoTab = true;
            this.EntradaGrupo.CanCreate = true;
            this.EntradaGrupo.Filter = "parent IS NULL";
            this.EntradaGrupo.Location = new System.Drawing.Point(112, 40);
            this.EntradaGrupo.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaGrupo.MaxLength = 200;
            this.EntradaGrupo.Name = "EntradaGrupo";
            this.EntradaGrupo.NombreTipo = "Lbl.Personas.Grupo";
            this.EntradaGrupo.PlaceholderText = "Ninguno";
            this.EntradaGrupo.Required = false;
            this.EntradaGrupo.Size = new System.Drawing.Size(232, 24);
            this.EntradaGrupo.TabIndex = 0;
            this.EntradaGrupo.Text = "0";
            this.EntradaGrupo.TextChanged += new System.EventHandler(this.EntradaGrupo_TextChanged);
            // 
            // EntradaSubGrupo
            // 
            this.EntradaSubGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaSubGrupo.AutoTab = true;
            this.EntradaSubGrupo.CanCreate = true;
            this.EntradaSubGrupo.Filter = "parent IS NULL";
            this.EntradaSubGrupo.Location = new System.Drawing.Point(112, 72);
            this.EntradaSubGrupo.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaSubGrupo.MaxLength = 200;
            this.EntradaSubGrupo.Name = "EntradaSubGrupo";
            this.EntradaSubGrupo.NombreTipo = "Lbl.Personas.Grupo";
            this.EntradaSubGrupo.PlaceholderText = "Ninguno";
            this.EntradaSubGrupo.Required = false;
            this.EntradaSubGrupo.Size = new System.Drawing.Size(232, 24);
            this.EntradaSubGrupo.TabIndex = 1;
            this.EntradaSubGrupo.Text = "0";
            // 
            // EntradaTipoCuenta
            // 
            this.EntradaTipoCuenta.AlwaysExpanded = false;
            this.EntradaTipoCuenta.AutoSize = true;
            this.EntradaTipoCuenta.Location = new System.Drawing.Point(112, 136);
            this.EntradaTipoCuenta.Name = "EntradaTipoCuenta";
            this.EntradaTipoCuenta.SetData = new string[] {
        "Tipo Cta.|0",
        "CC $|1",
        "CA $|2",
        "CC U$S|13",
        "CA U$S|15"};
            this.EntradaTipoCuenta.Size = new System.Drawing.Size(80, 24);
            this.EntradaTipoCuenta.TabIndex = 3;
            this.EntradaTipoCuenta.TextKey = "0";
            // 
            // panelMoneda
            // 
            this.panelMoneda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMoneda.Controls.Add(this.cotizaValor);
            this.panelMoneda.Controls.Add(this.label29);
            this.panelMoneda.Controls.Add(this.monedaCotiza);
            this.panelMoneda.Controls.Add(this.label20);
            this.panelMoneda.Controls.Add(this.label28);
            this.panelMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelMoneda.Location = new System.Drawing.Point(8, 1013);
            this.panelMoneda.Margin = new System.Windows.Forms.Padding(6);
            this.panelMoneda.Name = "panelMoneda";
            this.panelMoneda.Size = new System.Drawing.Size(693, 129);
            this.panelMoneda.TabIndex = 5;
            this.panelMoneda.Text = "Moneda que cotiza";
            // 
            // cotizaValor
            // 
            this.cotizaValor.DataType = Lui.Forms.DataTypes.Currency;
            this.cotizaValor.Location = new System.Drawing.Point(124, 96);
            this.cotizaValor.MaxLength = 16;
            this.cotizaValor.Name = "cotizaValor";
            this.cotizaValor.Prefijo = "$";
            this.cotizaValor.Size = new System.Drawing.Size(120, 24);
            this.cotizaValor.TabIndex = 12;
            this.cotizaValor.Text = "0.00";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(3, 96);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(89, 24);
            this.label29.TabIndex = 11;
            this.label29.Text = "Cotiza a";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // monedaCotiza
            // 
            this.monedaCotiza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monedaCotiza.AutoTab = true;
            this.monedaCotiza.CanCreate = true;
            this.monedaCotiza.Location = new System.Drawing.Point(124, 64);
            this.monedaCotiza.MaximumSize = new System.Drawing.Size(480, 32);
            this.monedaCotiza.MaxLength = 200;
            this.monedaCotiza.Name = "monedaCotiza";
            this.monedaCotiza.NombreTipo = "Lbl.Entidades.Moneda";
            this.monedaCotiza.PlaceholderText = "Sin especificar";
            this.monedaCotiza.Required = true;
            this.monedaCotiza.Size = new System.Drawing.Size(480, 24);
            this.monedaCotiza.TabIndex = 9;
            this.monedaCotiza.Text = "0";
            this.monedaCotiza.TextChanged += new System.EventHandler(this.monedaCotiza_TextChanged);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(4, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 24);
            this.label20.TabIndex = 10;
            this.label20.Text = "Moneda";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(3, 33);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(654, 27);
            this.label28.TabIndex = 0;
            this.label28.Text = "Solo sirve en caso de los proveedores, para indicar a que moneda cotiza sus produ" +
    "ctos";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelD2
            // 
            this.PanelD2.Controls.Add(this.EntradaTipoCuenta);
            this.PanelD2.Controls.Add(this.EntradaSubGrupo);
            this.PanelD2.Controls.Add(this.EntradaGrupo);
            this.PanelD2.Controls.Add(this.EntradaClaveBancaria);
            this.PanelD2.Controls.Add(this.EntradaLimiteCredito);
            this.PanelD2.Controls.Add(this.EntradaTipo);
            this.PanelD2.Controls.Add(this.EntradaNumeroCuenta);
            this.PanelD2.Controls.Add(this.EtiquetaClaveBancaria);
            this.PanelD2.Controls.Add(this.EntradaEstadoCredito);
            this.PanelD2.Controls.Add(this.label17);
            this.PanelD2.Controls.Add(this.label22);
            this.PanelD2.Controls.Add(this.label21);
            this.PanelD2.Controls.Add(this.Label16);
            this.PanelD2.Controls.Add(this.Label14);
            this.PanelD2.Controls.Add(this.label13);
            this.PanelD2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PanelD2.Location = new System.Drawing.Point(360, 271);
            this.PanelD2.Margin = new System.Windows.Forms.Padding(6);
            this.PanelD2.Name = "PanelD2";
            this.PanelD2.Size = new System.Drawing.Size(344, 328);
            this.PanelD2.TabIndex = 3;
            this.PanelD2.Text = "Otros datos";
            // 
            // frame1
            // 
            this.frame1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frame1.Controls.Add(this.label33);
            this.frame1.Controls.Add(this.label32);
            this.frame1.Controls.Add(this.cbHorarios);
            this.frame1.Controls.Add(this.dtHasta);
            this.frame1.Controls.Add(this.dtDesde);
            this.frame1.Controls.Add(this.label30);
            this.frame1.Controls.Add(this.dgvRubro);
            this.frame1.Controls.Add(this.txtDescuento);
            this.frame1.Controls.Add(this.cbRubro);
            this.frame1.Controls.Add(this.btnAgregarRubro);
            this.frame1.Controls.Add(this.txtDetalleRubro);
            this.frame1.Controls.Add(this.label31);
            this.frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.frame1.Location = new System.Drawing.Point(6, 764);
            this.frame1.Margin = new System.Windows.Forms.Padding(6);
            this.frame1.Name = "frame1";
            this.frame1.Size = new System.Drawing.Size(693, 244);
            this.frame1.TabIndex = 6;
            this.frame1.Text = "Descuentos";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(210, 64);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(54, 24);
            this.label33.TabIndex = 21;
            this.label33.Text = "Hasta";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(6, 65);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(54, 24);
            this.label32.TabIndex = 20;
            this.label32.Text = "Desde";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbHorarios
            // 
            this.cbHorarios.AutoSize = true;
            this.cbHorarios.Location = new System.Drawing.Point(9, 95);
            this.cbHorarios.Name = "cbHorarios";
            this.cbHorarios.Size = new System.Drawing.Size(337, 21);
            this.cbHorarios.TabIndex = 19;
            this.cbHorarios.Text = "Solo manejar horario en el periodo seleccionado.\r\n";
            this.toolTip1.SetToolTip(this.cbHorarios, resources.GetString("cbHorarios.ToolTip"));
            this.cbHorarios.UseVisualStyleBackColor = true;
            // 
            // dtHasta
            // 
            this.dtHasta.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHasta.Location = new System.Drawing.Point(270, 66);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(138, 23);
            this.dtHasta.TabIndex = 18;
            // 
            // dtDesde
            // 
            this.dtDesde.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDesde.Location = new System.Drawing.Point(66, 65);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(138, 23);
            this.dtDesde.TabIndex = 17;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(423, 36);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(123, 24);
            this.label30.TabIndex = 16;
            this.label30.Text = "Descuento %";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvRubro
            // 
            this.dgvRubro.AllowUserToAddRows = false;
            this.dgvRubro.AllowUserToDeleteRows = false;
            this.dgvRubro.AllowUserToOrderColumns = true;
            this.dgvRubro.AllowUserToResizeRows = false;
            this.dgvRubro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRubro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cg_RubroGeneral,
            this.cg_Descuento,
            this.cg_Desde,
            this.cg_Hasta,
            this.cg_Horario,
            this.cg_Anular,
            this.cg_Estado,
            this.cg_ID,
            this.cg_RubroID});
            this.dgvRubro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRubro.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvRubro.EnableHeadersVisualStyles = false;
            this.dgvRubro.Location = new System.Drawing.Point(0, 122);
            this.dgvRubro.MultiSelect = false;
            this.dgvRubro.Name = "dgvRubro";
            this.dgvRubro.ReadOnly = true;
            this.dgvRubro.RowHeadersVisible = false;
            this.dgvRubro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRubro.Size = new System.Drawing.Size(693, 122);
            this.dgvRubro.TabIndex = 7;
            this.dgvRubro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRubro_CellClick);
            // 
            // cg_RubroGeneral
            // 
            this.cg_RubroGeneral.Frozen = true;
            this.cg_RubroGeneral.HeaderText = "Rubro/General";
            this.cg_RubroGeneral.Name = "cg_RubroGeneral";
            this.cg_RubroGeneral.ReadOnly = true;
            this.cg_RubroGeneral.Width = 180;
            // 
            // cg_Descuento
            // 
            this.cg_Descuento.Frozen = true;
            this.cg_Descuento.HeaderText = "Desc. %";
            this.cg_Descuento.Name = "cg_Descuento";
            this.cg_Descuento.ReadOnly = true;
            this.cg_Descuento.Width = 65;
            // 
            // cg_Desde
            // 
            this.cg_Desde.Frozen = true;
            this.cg_Desde.HeaderText = "Desde";
            this.cg_Desde.Name = "cg_Desde";
            this.cg_Desde.ReadOnly = true;
            this.cg_Desde.Width = 130;
            // 
            // cg_Hasta
            // 
            this.cg_Hasta.Frozen = true;
            this.cg_Hasta.HeaderText = "Hasta";
            this.cg_Hasta.Name = "cg_Hasta";
            this.cg_Hasta.ReadOnly = true;
            this.cg_Hasta.Width = 130;
            // 
            // cg_Horario
            // 
            this.cg_Horario.Frozen = true;
            this.cg_Horario.HeaderText = "Horario";
            this.cg_Horario.Name = "cg_Horario";
            this.cg_Horario.ReadOnly = true;
            this.cg_Horario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cg_Horario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cg_Horario.Width = 50;
            // 
            // cg_Anular
            // 
            this.cg_Anular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cg_Anular.Frozen = true;
            this.cg_Anular.HeaderText = "Anular";
            this.cg_Anular.Name = "cg_Anular";
            this.cg_Anular.ReadOnly = true;
            this.cg_Anular.Text = "Anular";
            this.cg_Anular.Width = 120;
            // 
            // cg_Estado
            // 
            this.cg_Estado.Frozen = true;
            this.cg_Estado.HeaderText = "Estado";
            this.cg_Estado.Name = "cg_Estado";
            this.cg_Estado.ReadOnly = true;
            this.cg_Estado.Width = 80;
            // 
            // cg_ID
            // 
            this.cg_ID.Frozen = true;
            this.cg_ID.HeaderText = "ID";
            this.cg_ID.Name = "cg_ID";
            this.cg_ID.ReadOnly = true;
            this.cg_ID.Visible = false;
            // 
            // cg_RubroID
            // 
            this.cg_RubroID.Frozen = true;
            this.cg_RubroID.HeaderText = "RubroID";
            this.cg_RubroID.Name = "cg_RubroID";
            this.cg_RubroID.ReadOnly = true;
            this.cg_RubroID.Visible = false;
            // 
            // txtDescuento
            // 
            this.txtDescuento.DataType = Lui.Forms.DataTypes.Currency;
            this.txtDescuento.DecimalPlaces = 2;
            this.txtDescuento.Location = new System.Drawing.Point(552, 36);
            this.txtDescuento.MaximumSize = new System.Drawing.Size(88, 24);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(88, 24);
            this.txtDescuento.TabIndex = 15;
            this.txtDescuento.Text = "0.00";
            // 
            // cbRubro
            // 
            this.cbRubro.AlwaysExpanded = false;
            this.cbRubro.Location = new System.Drawing.Point(306, 36);
            this.cbRubro.MaximumSize = new System.Drawing.Size(95, 24);
            this.cbRubro.Name = "cbRubro";
            this.cbRubro.SetData = new string[] {
        "Por Rubro|0",
        "General|1"};
            this.cbRubro.Size = new System.Drawing.Size(95, 24);
            this.cbRubro.TabIndex = 13;
            this.cbRubro.TextKey = "0";
            // 
            // btnAgregarRubro
            // 
            this.btnAgregarRubro.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAgregarRubro.Image = null;
            this.btnAgregarRubro.ImagePos = Lui.Forms.ImagePositions.Top;
            this.btnAgregarRubro.Location = new System.Drawing.Point(423, 66);
            this.btnAgregarRubro.Name = "btnAgregarRubro";
            this.btnAgregarRubro.Size = new System.Drawing.Size(107, 32);
            this.btnAgregarRubro.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.btnAgregarRubro.Subtext = "Tecla";
            this.btnAgregarRubro.TabIndex = 12;
            this.btnAgregarRubro.Text = "Agregar";
            this.btnAgregarRubro.Click += new System.EventHandler(this.btnAgregarRubro_Click);
            // 
            // txtDetalleRubro
            // 
            this.txtDetalleRubro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetalleRubro.AutoTab = true;
            this.txtDetalleRubro.CanCreate = true;
            this.txtDetalleRubro.Location = new System.Drawing.Point(64, 36);
            this.txtDetalleRubro.MaximumSize = new System.Drawing.Size(236, 24);
            this.txtDetalleRubro.MaxLength = 200;
            this.txtDetalleRubro.Name = "txtDetalleRubro";
            this.txtDetalleRubro.NombreTipo = "Lbl.Articulos.Rubro";
            this.txtDetalleRubro.PlaceholderText = "Sin especificar";
            this.txtDetalleRubro.Required = true;
            this.txtDetalleRubro.Size = new System.Drawing.Size(236, 24);
            this.txtDetalleRubro.TabIndex = 9;
            this.txtDetalleRubro.Text = "0";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(4, 36);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(54, 24);
            this.label31.TabIndex = 10;
            this.label31.Text = "Rubros";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // panelCuentaContable
            // 
            this.panelCuentaContable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCuentaContable.Controls.Add(this.EntradaConceptoCompra);
            this.panelCuentaContable.Controls.Add(this.label34);
            this.panelCuentaContable.Controls.Add(this.EntradaConceptoVenta);
            this.panelCuentaContable.Controls.Add(this.label35);
            this.panelCuentaContable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panelCuentaContable.Location = new System.Drawing.Point(15, 1142);
            this.panelCuentaContable.Margin = new System.Windows.Forms.Padding(6);
            this.panelCuentaContable.Name = "panelCuentaContable";
            this.panelCuentaContable.Size = new System.Drawing.Size(693, 104);
            this.panelCuentaContable.TabIndex = 7;
            this.panelCuentaContable.Text = "Cuenta Contable Relacionada";
            // 
            // EntradaConceptoCompra
            // 
            this.EntradaConceptoCompra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaConceptoCompra.AutoTab = true;
            this.EntradaConceptoCompra.CanCreate = true;
            this.EntradaConceptoCompra.Location = new System.Drawing.Point(140, 71);
            this.EntradaConceptoCompra.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaConceptoCompra.MaxLength = 200;
            this.EntradaConceptoCompra.Name = "EntradaConceptoCompra";
            this.EntradaConceptoCompra.NombreTipo = "Lbl.Cajas.Concepto";
            this.EntradaConceptoCompra.PlaceholderText = "Sin especificar";
            this.EntradaConceptoCompra.Required = true;
            this.EntradaConceptoCompra.Size = new System.Drawing.Size(480, 24);
            this.EntradaConceptoCompra.TabIndex = 11;
            this.EntradaConceptoCompra.Text = "0";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(4, 69);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(130, 24);
            this.label34.TabIndex = 12;
            this.label34.Text = "Concepto Compra";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaConceptoVenta
            // 
            this.EntradaConceptoVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaConceptoVenta.AutoTab = true;
            this.EntradaConceptoVenta.CanCreate = true;
            this.EntradaConceptoVenta.Location = new System.Drawing.Point(140, 41);
            this.EntradaConceptoVenta.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaConceptoVenta.MaxLength = 200;
            this.EntradaConceptoVenta.Name = "EntradaConceptoVenta";
            this.EntradaConceptoVenta.NombreTipo = "Lbl.Cajas.Concepto";
            this.EntradaConceptoVenta.PlaceholderText = "Sin especificar";
            this.EntradaConceptoVenta.Required = true;
            this.EntradaConceptoVenta.Size = new System.Drawing.Size(480, 24);
            this.EntradaConceptoVenta.TabIndex = 9;
            this.EntradaConceptoVenta.Text = "0";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(4, 39);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(110, 24);
            this.label35.TabIndex = 10;
            this.label35.Text = "Concepto Venta";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(8, 294);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(120, 24);
            this.label36.TabIndex = 12;
            this.label36.Text = "Representante";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaRepresentante
            // 
            this.EntradaRepresentante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaRepresentante.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaRepresentante.Location = new System.Drawing.Point(128, 294);
            this.EntradaRepresentante.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaRepresentante.MaxLength = 100;
            this.EntradaRepresentante.Name = "EntradaRepresentante";
            this.EntradaRepresentante.Size = new System.Drawing.Size(212, 24);
            this.EntradaRepresentante.TabIndex = 13;
            // 
            // Editar
            // 
            this.Controls.Add(this.panelCuentaContable);
            this.Controls.Add(this.frame1);
            this.Controls.Add(this.panelMoneda);
            this.Controls.Add(this.PanelD2);
            this.Controls.Add(this.PanelD1);
            this.Controls.Add(this.PanelI1);
            this.Controls.Add(this.PanelI2);
            this.Controls.Add(this.PanelAbajo);
            this.MinimumSize = new System.Drawing.Size(731, 1229);
            this.Name = "Editar";
            this.Size = new System.Drawing.Size(731, 1252);
            this.PanelI1.ResumeLayout(false);
            this.PanelI1.PerformLayout();
            this.PanelD1.ResumeLayout(false);
            this.PanelD1.PerformLayout();
            this.PanelI2.ResumeLayout(false);
            this.PanelI2.PerformLayout();
            this.PanelAbajo.ResumeLayout(false);
            this.PanelAbajo.PerformLayout();
            this.panelMoneda.ResumeLayout(false);
            this.panelMoneda.PerformLayout();
            this.PanelD2.ResumeLayout(false);
            this.PanelD2.PerformLayout();
            this.frame1.ResumeLayout(false);
            this.frame1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubro)).EndInit();
            this.panelCuentaContable.ResumeLayout(false);
            this.panelCuentaContable.PerformLayout();
            this.ResumeLayout(false);

        }


        internal Lui.Forms.TextBox EntradaEmail;
        internal Lcc.Entrada.CodigoDetalle EntradaLocalidad;
        internal Lui.Forms.TextBox EntradaDomicilio;
        internal Lui.Forms.TextBox EntradaNumDoc;
        internal Lcc.Entrada.CodigoDetalle EntradaTipoDoc;
        internal Lui.Forms.TextBox EntradaApellido;
        internal Lui.Forms.TextBox EntradaNombre;
        internal Lui.Forms.TextBox EntradaClaveTributaria;
        internal Lui.Forms.TextBox EntradaRazonSocial;
        internal Lui.Forms.Label Label10;
        internal Lui.Forms.Label Label9;
        internal Lui.Forms.Label Label8;
        internal Lui.Forms.Label Label6;
        internal Lui.Forms.Label Label5;
        internal Lui.Forms.Label Label2;
        internal Lui.Forms.Label Label1;
        internal Lui.Forms.Label EtiquetaClaveTributaria;
        internal Lui.Forms.Label Label3;
        internal Lui.Forms.Label Label11;
        internal Lui.Forms.Frame PanelI1;
        internal Lui.Forms.Frame PanelD1;
        internal Lcc.Entrada.CodigoDetalle EntradaSituacion;
        internal Lui.Forms.Label Label12;
        internal Lui.Forms.Label Label15;
        internal Lui.Forms.ComboBox EntradaTipoFac;
        internal Lui.Forms.Label label18;
        internal Lui.Forms.TextBox EntradaFechaNac;
        internal Lui.Forms.TextBox EntradaDomicilioTrabajo;
        internal Lui.Forms.Label label19;
        private Lui.Forms.Frame PanelI2;
        private Lui.Forms.TextBox EntradaObs;
        internal Lcc.Entrada.CodigoDetalle EntradaVendedor;
        private Lui.Forms.Frame PanelAbajo;
        internal Lui.Forms.TextBox EntradaFechaBaja;
        internal Lui.Forms.TextBox EntradaFechaAlta;
        internal Lui.Forms.ComboBox EntradaEstado;
        private Lcc.Entrada.MatrizTelefonos matrizTelefonos1;
        private Lcc.Entrada.MatrizTelefonos EntradaTelefono;
        internal Lui.Forms.Label label23;
        internal Lui.Forms.Label label26;
        internal Lui.Forms.Label label25;
        internal Lui.Forms.Label label24;
        internal Lui.Forms.Label label4;
        internal Lui.Forms.ComboBox EntradaGenero;
        internal Lui.Forms.Label label7;
        internal Lui.Forms.Label label13;
        internal Lui.Forms.Label Label14;
        internal Lui.Forms.Label Label16;
        internal Lui.Forms.Label label21;
        internal Lui.Forms.Label label22;
        internal Lui.Forms.Label label17;
        internal Lui.Forms.ComboBox EntradaEstadoCredito;
        internal Lui.Forms.Label EtiquetaClaveBancaria;
        internal Lui.Forms.TextBox EntradaNumeroCuenta;
        public Lcc.Entrada.CodigoDetalle EntradaTipo;
        internal Lui.Forms.TextBox EntradaLimiteCredito;
        internal Lui.Forms.TextBox EntradaClaveBancaria;
        internal Lcc.Entrada.CodigoDetalle EntradaGrupo;
        internal Lcc.Entrada.CodigoDetalle EntradaSubGrupo;
        internal Lui.Forms.ComboBox EntradaTipoCuenta;
        private Lui.Forms.Frame PanelD2;
        internal Lui.Forms.TextBox EntradaNombreFantasia;
        internal Lui.Forms.Label label27;
        private Lui.Forms.Frame panelMoneda;
        internal Lui.Forms.Label label28;
        internal Lui.Forms.TextBox cotizaValor;
        internal Lui.Forms.Label label29;
        internal Lcc.Entrada.CodigoDetalle monedaCotiza;
        internal Lui.Forms.Label label20;
        private Lui.Forms.Frame frame1;
        internal Lcc.Entrada.CodigoDetalle txtDetalleRubro;
        internal Lui.Forms.Label label31;
        private Lui.Forms.Button btnAgregarRubro;
        private Lui.Forms.TextBox txtDescuento;
        private Lui.Forms.ComboBox cbRubro;
        private DataGridView dgvRubro;
        internal Lui.Forms.Label label30;
        internal Lui.Forms.Label label33;
        internal Lui.Forms.Label label32;
        private CheckBox cbHorarios;
        private ToolTip toolTip1;
        private DateTimePicker dtHasta;
        private DateTimePicker dtDesde;
        private DataGridViewTextBoxColumn cg_RubroGeneral;
        private DataGridViewTextBoxColumn cg_Descuento;
        private DataGridViewTextBoxColumn cg_Desde;
        private DataGridViewTextBoxColumn cg_Hasta;
        private DataGridViewCheckBoxColumn cg_Horario;
        private DataGridViewButtonColumn cg_Anular;
        private DataGridViewTextBoxColumn cg_Estado;
        private DataGridViewTextBoxColumn cg_ID;
        private DataGridViewTextBoxColumn cg_RubroID;
        private Lui.Forms.Frame panelCuentaContable;
        internal Lcc.Entrada.CodigoDetalle EntradaConceptoVenta;
        internal Lui.Forms.Label label35;
        internal Lcc.Entrada.CodigoDetalle EntradaConceptoCompra;
        internal Lui.Forms.Label label34;
        private Lui.Forms.Button btnCtaCte;
        internal Lui.Forms.TextBox EntradaRepresentante;
        internal Lui.Forms.Label label36;
    }
}
