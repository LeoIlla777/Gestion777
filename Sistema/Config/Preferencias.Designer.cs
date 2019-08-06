namespace Lazaro.WinMain.Config
{
	public partial class Preferencias
	{
                #region Código generado por el Diseñador de Windows Forms

		// Limpiar los recursos que se están utilizando.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferencias));
            this.BotonAceptar = new Lui.Forms.Button();
            this.CancelCommandButton = new Lui.Forms.Button();
            this.EntradaEmpresaSituacion = new Lcc.Entrada.CodigoDetalle();
            this.Label19 = new Lui.Forms.Label();
            this.EntradaEmpresaClaveTributaria = new Lui.Forms.TextBox();
            this.EtiquetaClaveTributaria = new Lui.Forms.Label();
            this.EntradaEmpresaNombre = new Lui.Forms.TextBox();
            this.Label17 = new Lui.Forms.Label();
            this.FrmGeneral = new Lui.Forms.Frame();
            this.panel1 = new Lui.Forms.Panel();
            this.EntradaInicioActividades = new Lui.Forms.TextBox();
            this.label39 = new Lui.Forms.Label();
            this.EntradaIngresosBrutos = new Lui.Forms.TextBox();
            this.label38 = new Lui.Forms.Label();
            this.label37 = new Lui.Forms.Label();
            this.EntradaLogo = new Lcc.Entrada.Imagen();
            this.label29 = new Lui.Forms.Label();
            this.label36 = new Lui.Forms.Label();
            this.EntradaSucursal = new Lcc.Entrada.CodigoDetalle();
            this.BotonCambiarPais = new Lui.Forms.Button();
            this.label33 = new Lui.Forms.Label();
            this.EntradaEmpresaId = new Lui.Forms.TextBox();
            this.EntradaPais = new Lcc.Entrada.CodigoDetalle();
            this.label2 = new Lui.Forms.Label();
            this.EntradaEmpresaRazonSocial = new Lui.Forms.TextBox();
            this.label1 = new Lui.Forms.Label();
            this.EntradaProvincia = new Lcc.Entrada.CodigoDetalle();
            this.EntradaLocalidad = new Lcc.Entrada.CodigoDetalle();
            this.label32 = new Lui.Forms.Label();
            this.label31 = new Lui.Forms.Label();
            this.EntradaEmpresaEmail = new Lui.Forms.TextBox();
            this.label28 = new Lui.Forms.Label();
            this.EntradaActualizaciones = new Lui.Forms.ComboBox();
            this.label30 = new Lui.Forms.Label();
            this.EntradaModoPantalla = new Lui.Forms.ComboBox();
            this.EntradaBackup = new Lui.Forms.ComboBox();
            this.label27 = new Lui.Forms.Label();
            this.label14 = new Lui.Forms.Label();
            this.EntradaStockDecimales = new Lui.Forms.ComboBox();
            this.Label25 = new Lui.Forms.Label();
            this.Label24 = new Lui.Forms.Label();
            this.EntradaStockDepositoPredet = new Lcc.Entrada.CodigoDetalle();
            this.EntradaStockMultideposito = new Lui.Forms.ComboBox();
            this.Label23 = new Lui.Forms.Label();
            this.EntradaArticulosCodigoPredet = new Lui.Forms.ComboBox();
            this.Label20 = new Lui.Forms.Label();
            this.EntradaPV = new Lui.Forms.TextBox();
            this.Label9 = new Lui.Forms.Label();
            this.EntradaPVND = new Lui.Forms.TextBox();
            this.Label10 = new Lui.Forms.Label();
            this.Label8 = new Lui.Forms.Label();
            this.Label7 = new Lui.Forms.Label();
            this.EntradaPVNC = new Lui.Forms.TextBox();
            this.EntradaPVABC = new Lui.Forms.TextBox();
            this.Label6 = new Lui.Forms.Label();
            this.Label5 = new Lui.Forms.Label();
            this.Label4 = new Lui.Forms.Label();
            this.Label16 = new Lui.Forms.Label();
            this.EntradaClientePredet = new Lcc.Entrada.CodigoDetalle();
            this.Label15 = new Lui.Forms.Label();
            this.EntradaFormaPagoPredet = new Lcc.Entrada.CodigoDetalle();
            this.BotonSiguiente = new Lui.Forms.Button();
            this.FrmArticulos = new Lui.Forms.Frame();
            this.label35 = new Lui.Forms.Label();
            this.EntradaMonedaDecimalesCosto = new Lui.Forms.ComboBox();
            this.EntradaMonedaDecimalesUnitarios = new Lui.Forms.ComboBox();
            this.label34 = new Lui.Forms.Label();
            this.EntradaMonedaDecimalesFinal = new Lui.Forms.ComboBox();
            this.label18 = new Lui.Forms.Label();
            this.EntradaMonedaUnidadMonetariaMinima = new Lui.Forms.TextBox();
            this.label26 = new Lui.Forms.Label();
            this.EntradaStockDepositoPredetSuc = new Lcc.Entrada.CodigoDetalle();
            this.label22 = new Lui.Forms.Label();
            this.FrmComprobantes = new Lui.Forms.Frame();
            this.panel2 = new Lui.Forms.Panel();
            this.EntradaPVRC = new Lui.Forms.TextBox();
            this.label3 = new Lui.Forms.Label();
            this.label11 = new Lui.Forms.Label();
            this.EntradaLimiteCredito = new Lui.Forms.TextBox();
            this.label21 = new Lui.Forms.Label();
            this.EntradaCambiaPrecioComprob = new Lui.Forms.YesNo();
            this.label13 = new Lui.Forms.Label();
            this.EntradaPVR = new Lui.Forms.TextBox();
            this.label12 = new Lui.Forms.Label();
            this.FrmAvanzado = new Lui.Forms.Frame();
            this.buttonPanel1 = new Lui.Forms.ButtonPanel();
            this.LabelTab1 = new Lui.Forms.Label();
            this.LabelTab2 = new Lui.Forms.Label();
            this.LabelTab3 = new Lui.Forms.Label();
            this.LabelTab4 = new Lui.Forms.Label();
            this.LabelTab5 = new Lui.Forms.Label();
            this.FrmCompxSuc = new Lui.Forms.Frame();
            this.panel3 = new Lui.Forms.Panel();
            this.EntradaPVRC2 = new Lui.Forms.TextBox();
            this.label41 = new Lui.Forms.Label();
            this.label42 = new Lui.Forms.Label();
            this.EntradaPVR2 = new Lui.Forms.TextBox();
            this.label45 = new Lui.Forms.Label();
            this.EntradaPV2 = new Lui.Forms.TextBox();
            this.label46 = new Lui.Forms.Label();
            this.EntradaPVND2 = new Lui.Forms.TextBox();
            this.label47 = new Lui.Forms.Label();
            this.label48 = new Lui.Forms.Label();
            this.label49 = new Lui.Forms.Label();
            this.EntradaPVNC2 = new Lui.Forms.TextBox();
            this.EntradaPVABC2 = new Lui.Forms.TextBox();
            this.label50 = new Lui.Forms.Label();
            this.label51 = new Lui.Forms.Label();
            this.label52 = new Lui.Forms.Label();
            this.btnEstructura = new Lui.Forms.Button();
            this.FrmGeneral.SuspendLayout();
            this.panel1.SuspendLayout();
            this.FrmArticulos.SuspendLayout();
            this.FrmComprobantes.SuspendLayout();
            this.panel2.SuspendLayout();
            this.FrmAvanzado.SuspendLayout();
            this.buttonPanel1.SuspendLayout();
            this.FrmCompxSuc.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BotonAceptar
            // 
            this.BotonAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonAceptar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonAceptar.Image = null;
            this.BotonAceptar.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonAceptar.Location = new System.Drawing.Point(538, 12);
            this.BotonAceptar.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.BotonAceptar.MaximumSize = new System.Drawing.Size(160, 64);
            this.BotonAceptar.MinimumSize = new System.Drawing.Size(96, 32);
            this.BotonAceptar.Name = "BotonAceptar";
            this.BotonAceptar.Size = new System.Drawing.Size(108, 40);
            this.BotonAceptar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.BotonAceptar.Subtext = "F9";
            this.BotonAceptar.TabIndex = 1;
            this.BotonAceptar.Text = "Guardar";
            this.BotonAceptar.Click += new System.EventHandler(this.BotonAceptar_Click);
            // 
            // CancelCommandButton
            // 
            this.CancelCommandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelCommandButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.CancelCommandButton.Image = null;
            this.CancelCommandButton.ImagePos = Lui.Forms.ImagePositions.Top;
            this.CancelCommandButton.Location = new System.Drawing.Point(652, 12);
            this.CancelCommandButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.CancelCommandButton.MaximumSize = new System.Drawing.Size(160, 64);
            this.CancelCommandButton.MinimumSize = new System.Drawing.Size(96, 32);
            this.CancelCommandButton.Name = "CancelCommandButton";
            this.CancelCommandButton.Size = new System.Drawing.Size(108, 40);
            this.CancelCommandButton.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.CancelCommandButton.Subtext = "Esc";
            this.CancelCommandButton.TabIndex = 2;
            this.CancelCommandButton.Text = "Cancelar";
            this.CancelCommandButton.Click += new System.EventHandler(this.BotonCancelar_Click);
            // 
            // EntradaEmpresaSituacion
            // 
            this.EntradaEmpresaSituacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaEmpresaSituacion.AutoTab = true;
            this.EntradaEmpresaSituacion.CanCreate = true;
            this.EntradaEmpresaSituacion.Location = new System.Drawing.Point(186, 137);
            this.EntradaEmpresaSituacion.MaxLength = 200;
            this.EntradaEmpresaSituacion.Name = "EntradaEmpresaSituacion";
            this.EntradaEmpresaSituacion.NombreTipo = "Lbl.Impuestos.SituacionTributaria";
            this.EntradaEmpresaSituacion.Required = true;
            this.EntradaEmpresaSituacion.Size = new System.Drawing.Size(287, 24);
            this.EntradaEmpresaSituacion.TabIndex = 12;
            this.EntradaEmpresaSituacion.Text = "0";
            // 
            // Label19
            // 
            this.Label19.Location = new System.Drawing.Point(2, 137);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(184, 24);
            this.Label19.TabIndex = 11;
            this.Label19.Text = "Condición IVA";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaEmpresaClaveTributaria
            // 
            this.EntradaEmpresaClaveTributaria.Location = new System.Drawing.Point(186, 105);
            this.EntradaEmpresaClaveTributaria.MaxLength = 50;
            this.EntradaEmpresaClaveTributaria.Name = "EntradaEmpresaClaveTributaria";
            this.EntradaEmpresaClaveTributaria.Size = new System.Drawing.Size(172, 24);
            this.EntradaEmpresaClaveTributaria.TabIndex = 8;
            // 
            // EtiquetaClaveTributaria
            // 
            this.EtiquetaClaveTributaria.Location = new System.Drawing.Point(2, 105);
            this.EtiquetaClaveTributaria.Name = "EtiquetaClaveTributaria";
            this.EtiquetaClaveTributaria.Size = new System.Drawing.Size(184, 24);
            this.EtiquetaClaveTributaria.TabIndex = 7;
            this.EtiquetaClaveTributaria.Text = "Clave tributaria";
            this.EtiquetaClaveTributaria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaEmpresaNombre
            // 
            this.EntradaEmpresaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaEmpresaNombre.Location = new System.Drawing.Point(186, 41);
            this.EntradaEmpresaNombre.MaxLength = 200;
            this.EntradaEmpresaNombre.Name = "EntradaEmpresaNombre";
            this.EntradaEmpresaNombre.Size = new System.Drawing.Size(368, 24);
            this.EntradaEmpresaNombre.TabIndex = 4;
            // 
            // Label17
            // 
            this.Label17.Location = new System.Drawing.Point(2, 41);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(184, 24);
            this.Label17.TabIndex = 3;
            this.Label17.Text = "Nombre";
            this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmGeneral
            // 
            this.FrmGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrmGeneral.Controls.Add(this.panel1);
            this.FrmGeneral.Location = new System.Drawing.Point(154, 16);
            this.FrmGeneral.Name = "FrmGeneral";
            this.FrmGeneral.Size = new System.Drawing.Size(618, 441);
            this.FrmGeneral.TabIndex = 0;
            this.FrmGeneral.Text = "Datos de la empresa";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.EntradaInicioActividades);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.EntradaIngresosBrutos);
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.label37);
            this.panel1.Controls.Add(this.EntradaLogo);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.EntradaSucursal);
            this.panel1.Controls.Add(this.BotonCambiarPais);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.EntradaEmpresaId);
            this.panel1.Controls.Add(this.EntradaPais);
            this.panel1.Controls.Add(this.Label17);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.EntradaEmpresaNombre);
            this.panel1.Controls.Add(this.EntradaEmpresaRazonSocial);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.EntradaEmpresaClaveTributaria);
            this.panel1.Controls.Add(this.EtiquetaClaveTributaria);
            this.panel1.Controls.Add(this.EntradaProvincia);
            this.panel1.Controls.Add(this.EntradaLocalidad);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.EntradaEmpresaEmail);
            this.panel1.Controls.Add(this.EntradaEmpresaSituacion);
            this.panel1.Controls.Add(this.Label19);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 397);
            this.panel1.TabIndex = 0;
            // 
            // EntradaInicioActividades
            // 
            this.EntradaInicioActividades.DataType = Lui.Forms.DataTypes.Date;
            this.EntradaInicioActividades.Location = new System.Drawing.Point(382, 265);
            this.EntradaInicioActividades.MaxLength = 50;
            this.EntradaInicioActividades.Name = "EntradaInicioActividades";
            this.EntradaInicioActividades.Size = new System.Drawing.Size(167, 24);
            this.EntradaInicioActividades.TabIndex = 22;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(254, 265);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(144, 24);
            this.label39.TabIndex = 21;
            this.label39.Text = "Inicio de actividades";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaIngresosBrutos
            // 
            this.EntradaIngresosBrutos.Location = new System.Drawing.Point(420, 105);
            this.EntradaIngresosBrutos.MaxLength = 50;
            this.EntradaIngresosBrutos.Name = "EntradaIngresosBrutos";
            this.EntradaIngresosBrutos.Size = new System.Drawing.Size(134, 24);
            this.EntradaIngresosBrutos.TabIndex = 10;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(379, 105);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(35, 24);
            this.label38.TabIndex = 9;
            this.label38.Text = "II.BB.";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(3, 365);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(176, 45);
            this.label37.TabIndex = 23;
            this.label37.Text = "Imagen en formato JPEG que se utilizará en comprobantes.";
            this.label37.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
            // 
            // EntradaLogo
            // 
            this.EntradaLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaLogo.Location = new System.Drawing.Point(186, 333);
            this.EntradaLogo.MinimumSize = new System.Drawing.Size(240, 160);
            this.EntradaLogo.Name = "EntradaLogo";
            this.EntradaLogo.Size = new System.Drawing.Size(386, 160);
            this.EntradaLogo.TabIndex = 26;
            this.EntradaLogo.Text = "Logotipo";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(1, 328);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(184, 24);
            this.label29.TabIndex = 25;
            this.label29.Text = "Logotipo";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(2, 297);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(184, 24);
            this.label36.TabIndex = 23;
            this.label36.Text = "Sucursal";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaSucursal
            // 
            this.EntradaSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaSucursal.AutoTab = true;
            this.EntradaSucursal.CanCreate = false;
            this.EntradaSucursal.Location = new System.Drawing.Point(186, 297);
            this.EntradaSucursal.MaxLength = 200;
            this.EntradaSucursal.Name = "EntradaSucursal";
            this.EntradaSucursal.NombreTipo = "Lbl.Entidades.Sucursal";
            this.EntradaSucursal.Required = true;
            this.EntradaSucursal.Size = new System.Drawing.Size(327, 24);
            this.EntradaSucursal.TabIndex = 24;
            this.EntradaSucursal.Text = "0";
            // 
            // BotonCambiarPais
            // 
            this.BotonCambiarPais.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonCambiarPais.Image = null;
            this.BotonCambiarPais.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonCambiarPais.Location = new System.Drawing.Point(474, 1);
            this.BotonCambiarPais.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.BotonCambiarPais.MaximumSize = new System.Drawing.Size(108, 40);
            this.BotonCambiarPais.MinimumSize = new System.Drawing.Size(80, 24);
            this.BotonCambiarPais.Name = "BotonCambiarPais";
            this.BotonCambiarPais.Size = new System.Drawing.Size(80, 24);
            this.BotonCambiarPais.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.BotonCambiarPais.Subtext = "F9";
            this.BotonCambiarPais.TabIndex = 2;
            this.BotonCambiarPais.Text = "Cambiar";
            this.BotonCambiarPais.Visible = false;
            this.BotonCambiarPais.Click += new System.EventHandler(this.BotonCambiarPais_Click);
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(2, 1);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(184, 24);
            this.label33.TabIndex = 0;
            this.label33.Text = "País";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaEmpresaId
            // 
            this.EntradaEmpresaId.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaEmpresaId.Location = new System.Drawing.Point(186, 265);
            this.EntradaEmpresaId.MaxLength = 3;
            this.EntradaEmpresaId.Name = "EntradaEmpresaId";
            this.EntradaEmpresaId.Size = new System.Drawing.Size(48, 24);
            this.EntradaEmpresaId.TabIndex = 20;
            this.EntradaEmpresaId.Text = "0";
            // 
            // EntradaPais
            // 
            this.EntradaPais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaPais.AutoTab = true;
            this.EntradaPais.CanCreate = false;
            this.EntradaPais.Location = new System.Drawing.Point(186, 1);
            this.EntradaPais.MaxLength = 200;
            this.EntradaPais.Name = "EntradaPais";
            this.EntradaPais.NombreTipo = "Lbl.Entidades.Pais";
            this.EntradaPais.Required = true;
            this.EntradaPais.Size = new System.Drawing.Size(311, 24);
            this.EntradaPais.TabIndex = 1;
            this.EntradaPais.Text = "0";
            this.EntradaPais.TextChanged += new System.EventHandler(this.EntradaPais_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "Id de empresa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaEmpresaRazonSocial
            // 
            this.EntradaEmpresaRazonSocial.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaEmpresaRazonSocial.Location = new System.Drawing.Point(186, 73);
            this.EntradaEmpresaRazonSocial.MaxLength = 200;
            this.EntradaEmpresaRazonSocial.Name = "EntradaEmpresaRazonSocial";
            this.EntradaEmpresaRazonSocial.Size = new System.Drawing.Size(368, 24);
            this.EntradaEmpresaRazonSocial.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Razón social";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaProvincia
            // 
            this.EntradaProvincia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaProvincia.AutoTab = true;
            this.EntradaProvincia.CanCreate = true;
            this.EntradaProvincia.Filter = "id_provincia IS NULL";
            this.EntradaProvincia.Location = new System.Drawing.Point(186, 201);
            this.EntradaProvincia.MaxLength = 200;
            this.EntradaProvincia.Name = "EntradaProvincia";
            this.EntradaProvincia.NombreTipo = "Lbl.Entidades.Localidad";
            this.EntradaProvincia.Required = true;
            this.EntradaProvincia.Size = new System.Drawing.Size(363, 24);
            this.EntradaProvincia.TabIndex = 16;
            this.EntradaProvincia.Text = "0";
            this.EntradaProvincia.TextChanged += new System.EventHandler(this.EntradaProvincia_TextChanged);
            // 
            // EntradaLocalidad
            // 
            this.EntradaLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaLocalidad.AutoTab = true;
            this.EntradaLocalidad.CanCreate = true;
            this.EntradaLocalidad.Filter = "id_provincia IS NOT NULL";
            this.EntradaLocalidad.Location = new System.Drawing.Point(186, 233);
            this.EntradaLocalidad.MaxLength = 200;
            this.EntradaLocalidad.Name = "EntradaLocalidad";
            this.EntradaLocalidad.NombreTipo = "Lbl.Entidades.Localidad";
            this.EntradaLocalidad.Required = true;
            this.EntradaLocalidad.Size = new System.Drawing.Size(363, 24);
            this.EntradaLocalidad.TabIndex = 18;
            this.EntradaLocalidad.Text = "0";
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(2, 233);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(184, 24);
            this.label32.TabIndex = 17;
            this.label32.Text = "Localidad o población";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(2, 201);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(184, 24);
            this.label31.TabIndex = 15;
            this.label31.Text = "Provincia o estado";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaEmpresaEmail
            // 
            this.EntradaEmpresaEmail.ForceCase = Lui.Forms.TextCasing.LowerCase;
            this.EntradaEmpresaEmail.Location = new System.Drawing.Point(186, 169);
            this.EntradaEmpresaEmail.MaxLength = 200;
            this.EntradaEmpresaEmail.Name = "EntradaEmpresaEmail";
            this.EntradaEmpresaEmail.Size = new System.Drawing.Size(352, 24);
            this.EntradaEmpresaEmail.TabIndex = 14;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(2, 169);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(184, 24);
            this.label28.TabIndex = 13;
            this.label28.Text = "Correo electrónico";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaActualizaciones
            // 
            this.EntradaActualizaciones.AlwaysExpanded = true;
            this.EntradaActualizaciones.AutoSize = true;
            this.EntradaActualizaciones.Location = new System.Drawing.Point(240, 219);
            this.EntradaActualizaciones.Name = "EntradaActualizaciones";
            this.EntradaActualizaciones.SetData = new string[] {
        "Estables|stable",
        "Preliminares|gama",
        "En prueba|beta"};
            this.EntradaActualizaciones.Size = new System.Drawing.Size(132, 57);
            this.EntradaActualizaciones.TabIndex = 21;
            this.EntradaActualizaciones.TextKey = "stable";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(8, 219);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(232, 24);
            this.label30.TabIndex = 20;
            this.label30.Text = "Recibir actualizaciones";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaModoPantalla
            // 
            this.EntradaModoPantalla.AlwaysExpanded = true;
            this.EntradaModoPantalla.AutoSize = true;
            this.EntradaModoPantalla.Location = new System.Drawing.Point(240, 112);
            this.EntradaModoPantalla.Name = "EntradaModoPantalla";
            this.EntradaModoPantalla.SetData = new string[] {
        "Predeterminado|*",
        "Ventana normal|normal",
        "Ventana maximizada|maximizado",
        "Pantalla completa|completo",
        "Ventanas flotantes|flotante"};
            this.EntradaModoPantalla.Size = new System.Drawing.Size(196, 91);
            this.EntradaModoPantalla.TabIndex = 17;
            this.EntradaModoPantalla.TextKey = "*";
            // 
            // EntradaBackup
            // 
            this.EntradaBackup.AlwaysExpanded = true;
            this.EntradaBackup.AutoSize = true;
            this.EntradaBackup.Location = new System.Drawing.Point(240, 40);
            this.EntradaBackup.Name = "EntradaBackup";
            this.EntradaBackup.SetData = new string[] {
        "Nunca|0",
        "Cuando se solicita|1",
        "Automáticamente|2"};
            this.EntradaBackup.Size = new System.Drawing.Size(196, 57);
            this.EntradaBackup.TabIndex = 0;
            this.EntradaBackup.TextKey = "0";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(8, 112);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(232, 24);
            this.label27.TabIndex = 16;
            this.label27.Text = "Modo de uso de la pantalla";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(232, 24);
            this.label14.TabIndex = 14;
            this.label14.Text = "Realizar copias de seguridad";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaStockDecimales
            // 
            this.EntradaStockDecimales.AlwaysExpanded = false;
            this.EntradaStockDecimales.Location = new System.Drawing.Point(184, 104);
            this.EntradaStockDecimales.Name = "EntradaStockDecimales";
            this.EntradaStockDecimales.SetData = new string[] {
        "Sin decimales|0",
        "Un decimal|1",
        "Dos decimales|2",
        "Tres decimales|3",
        "Cuatro decimales|4"};
            this.EntradaStockDecimales.Size = new System.Drawing.Size(160, 24);
            this.EntradaStockDecimales.TabIndex = 5;
            this.EntradaStockDecimales.TextKey = "0";
            // 
            // Label25
            // 
            this.Label25.Location = new System.Drawing.Point(8, 104);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(176, 24);
            this.Label25.TabIndex = 4;
            this.Label25.Text = "Precisión de existencias";
            this.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label24
            // 
            this.Label24.Location = new System.Drawing.Point(8, 136);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(176, 24);
            this.Label24.TabIndex = 6;
            this.Label24.Text = "Deposito predeterminado";
            this.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaStockDepositoPredet
            // 
            this.EntradaStockDepositoPredet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaStockDepositoPredet.AutoTab = true;
            this.EntradaStockDepositoPredet.CanCreate = true;
            this.EntradaStockDepositoPredet.Location = new System.Drawing.Point(184, 136);
            this.EntradaStockDepositoPredet.MaxLength = 200;
            this.EntradaStockDepositoPredet.Name = "EntradaStockDepositoPredet";
            this.EntradaStockDepositoPredet.NombreTipo = "Lbl.Articulos.Situacion";
            this.EntradaStockDepositoPredet.Required = false;
            this.EntradaStockDepositoPredet.Size = new System.Drawing.Size(414, 24);
            this.EntradaStockDepositoPredet.TabIndex = 7;
            this.EntradaStockDepositoPredet.Text = "0";
            // 
            // EntradaStockMultideposito
            // 
            this.EntradaStockMultideposito.AlwaysExpanded = false;
            this.EntradaStockMultideposito.Location = new System.Drawing.Point(184, 72);
            this.EntradaStockMultideposito.Name = "EntradaStockMultideposito";
            this.EntradaStockMultideposito.SetData = new string[] {
        "Simple|0",
        "Multidepósito|1"};
            this.EntradaStockMultideposito.Size = new System.Drawing.Size(224, 24);
            this.EntradaStockMultideposito.TabIndex = 3;
            this.EntradaStockMultideposito.TextKey = "0";
            // 
            // Label23
            // 
            this.Label23.Location = new System.Drawing.Point(8, 72);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(176, 24);
            this.Label23.TabIndex = 2;
            this.Label23.Text = "Control de existencias";
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaArticulosCodigoPredet
            // 
            this.EntradaArticulosCodigoPredet.AlwaysExpanded = false;
            this.EntradaArticulosCodigoPredet.Location = new System.Drawing.Point(184, 40);
            this.EntradaArticulosCodigoPredet.Name = "EntradaArticulosCodigoPredet";
            this.EntradaArticulosCodigoPredet.SetData = new string[] {
        "Autonumérico incorporado|0",
        "Cód. 1|1",
        "Cód. 2|2",
        "Cód. 3|3",
        "Cód. 4|4"};
            this.EntradaArticulosCodigoPredet.Size = new System.Drawing.Size(224, 24);
            this.EntradaArticulosCodigoPredet.TabIndex = 1;
            this.EntradaArticulosCodigoPredet.TextKey = "0";
            // 
            // Label20
            // 
            this.Label20.Location = new System.Drawing.Point(8, 40);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(176, 24);
            this.Label20.TabIndex = 0;
            this.Label20.Text = "Código predeterminado";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaPV
            // 
            this.EntradaPV.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPV.Location = new System.Drawing.Point(237, 67);
            this.EntradaPV.Name = "EntradaPV";
            this.EntradaPV.Size = new System.Drawing.Size(56, 24);
            this.EntradaPV.TabIndex = 5;
            this.EntradaPV.Text = "0";
            // 
            // Label9
            // 
            this.Label9.Location = new System.Drawing.Point(297, 151);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(284, 24);
            this.Label9.TabIndex = 14;
            this.Label9.Text = "(0 para utilizar el mismo que para facturas)";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label9.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
            // 
            // EntradaPVND
            // 
            this.EntradaPVND.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPVND.Location = new System.Drawing.Point(237, 151);
            this.EntradaPVND.Name = "EntradaPVND";
            this.EntradaPVND.Size = new System.Drawing.Size(56, 24);
            this.EntradaPVND.TabIndex = 13;
            this.EntradaPVND.Text = "0";
            // 
            // Label10
            // 
            this.Label10.Location = new System.Drawing.Point(1, 151);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(236, 24);
            this.Label10.TabIndex = 12;
            this.Label10.Text = "PV para notas de débito A, B y C";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(297, 123);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(284, 24);
            this.Label8.TabIndex = 11;
            this.Label8.Text = "(0 para utilizar el mismo que para facturas)";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label8.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(297, 95);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(284, 24);
            this.Label7.TabIndex = 8;
            this.Label7.Text = "(0 para utilizar el predeterminado)";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label7.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
            // 
            // EntradaPVNC
            // 
            this.EntradaPVNC.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPVNC.Location = new System.Drawing.Point(237, 123);
            this.EntradaPVNC.Name = "EntradaPVNC";
            this.EntradaPVNC.Size = new System.Drawing.Size(56, 24);
            this.EntradaPVNC.TabIndex = 10;
            this.EntradaPVNC.Text = "0";
            // 
            // EntradaPVABC
            // 
            this.EntradaPVABC.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPVABC.Location = new System.Drawing.Point(237, 95);
            this.EntradaPVABC.Name = "EntradaPVABC";
            this.EntradaPVABC.Size = new System.Drawing.Size(56, 24);
            this.EntradaPVABC.TabIndex = 7;
            this.EntradaPVABC.Text = "0";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(1, 123);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(236, 24);
            this.Label6.TabIndex = 9;
            this.Label6.Text = "PV para notas de crédito A, B y C";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(1, 95);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(236, 24);
            this.Label5.TabIndex = 6;
            this.Label5.Text = "PV para facturas A, B y C";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(1, 67);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(236, 24);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "PV predeterminado";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label16
            // 
            this.Label16.Location = new System.Drawing.Point(1, 3);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(209, 24);
            this.Label16.TabIndex = 0;
            this.Label16.Text = "Cliente predeterminado";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaClientePredet
            // 
            this.EntradaClientePredet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaClientePredet.AutoTab = true;
            this.EntradaClientePredet.CanCreate = true;
            this.EntradaClientePredet.Location = new System.Drawing.Point(209, 3);
            this.EntradaClientePredet.MaxLength = 200;
            this.EntradaClientePredet.Name = "EntradaClientePredet";
            this.EntradaClientePredet.NombreTipo = "Lbl.Personas.Persona";
            this.EntradaClientePredet.PlaceholderText = "Ninguno";
            this.EntradaClientePredet.Required = false;
            this.EntradaClientePredet.Size = new System.Drawing.Size(396, 24);
            this.EntradaClientePredet.TabIndex = 1;
            this.EntradaClientePredet.Text = "0";
            // 
            // Label15
            // 
            this.Label15.Location = new System.Drawing.Point(1, 31);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(208, 24);
            this.Label15.TabIndex = 2;
            this.Label15.Text = "Forma de pago predeterminada";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaFormaPagoPredet
            // 
            this.EntradaFormaPagoPredet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaFormaPagoPredet.AutoTab = true;
            this.EntradaFormaPagoPredet.CanCreate = true;
            this.EntradaFormaPagoPredet.Filter = "estado=1";
            this.EntradaFormaPagoPredet.Location = new System.Drawing.Point(209, 31);
            this.EntradaFormaPagoPredet.MaxLength = 200;
            this.EntradaFormaPagoPredet.Name = "EntradaFormaPagoPredet";
            this.EntradaFormaPagoPredet.NombreTipo = "Lbl.Pagos.FormaDePago";
            this.EntradaFormaPagoPredet.PlaceholderText = "Ninguna";
            this.EntradaFormaPagoPredet.Required = false;
            this.EntradaFormaPagoPredet.Size = new System.Drawing.Size(243, 24);
            this.EntradaFormaPagoPredet.TabIndex = 3;
            this.EntradaFormaPagoPredet.Text = "0";
            // 
            // BotonSiguiente
            // 
            this.BotonSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BotonSiguiente.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonSiguiente.Image = null;
            this.BotonSiguiente.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonSiguiente.Location = new System.Drawing.Point(424, 12);
            this.BotonSiguiente.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.BotonSiguiente.MaximumSize = new System.Drawing.Size(160, 64);
            this.BotonSiguiente.MinimumSize = new System.Drawing.Size(96, 32);
            this.BotonSiguiente.Name = "BotonSiguiente";
            this.BotonSiguiente.Size = new System.Drawing.Size(108, 40);
            this.BotonSiguiente.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.BotonSiguiente.Subtext = "F9";
            this.BotonSiguiente.TabIndex = 0;
            this.BotonSiguiente.Text = "Más...";
            this.BotonSiguiente.Click += new System.EventHandler(this.BotonSiguiente_Click);
            // 
            // FrmArticulos
            // 
            this.FrmArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrmArticulos.Controls.Add(this.Label20);
            this.FrmArticulos.Controls.Add(this.EntradaArticulosCodigoPredet);
            this.FrmArticulos.Controls.Add(this.label35);
            this.FrmArticulos.Controls.Add(this.EntradaMonedaDecimalesCosto);
            this.FrmArticulos.Controls.Add(this.EntradaMonedaDecimalesUnitarios);
            this.FrmArticulos.Controls.Add(this.Label25);
            this.FrmArticulos.Controls.Add(this.label34);
            this.FrmArticulos.Controls.Add(this.EntradaMonedaDecimalesFinal);
            this.FrmArticulos.Controls.Add(this.label18);
            this.FrmArticulos.Controls.Add(this.EntradaStockDecimales);
            this.FrmArticulos.Controls.Add(this.EntradaMonedaUnidadMonetariaMinima);
            this.FrmArticulos.Controls.Add(this.label26);
            this.FrmArticulos.Controls.Add(this.EntradaStockDepositoPredetSuc);
            this.FrmArticulos.Controls.Add(this.Label23);
            this.FrmArticulos.Controls.Add(this.Label24);
            this.FrmArticulos.Controls.Add(this.EntradaStockMultideposito);
            this.FrmArticulos.Controls.Add(this.label22);
            this.FrmArticulos.Controls.Add(this.EntradaStockDepositoPredet);
            this.FrmArticulos.Location = new System.Drawing.Point(154, 16);
            this.FrmArticulos.Name = "FrmArticulos";
            this.FrmArticulos.Size = new System.Drawing.Size(618, 441);
            this.FrmArticulos.TabIndex = 0;
            this.FrmArticulos.Text = "Existencias y precios";
            this.FrmArticulos.Visible = false;
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(8, 216);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(176, 24);
            this.label35.TabIndex = 10;
            this.label35.Text = "Precios de costo";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaMonedaDecimalesCosto
            // 
            this.EntradaMonedaDecimalesCosto.AlwaysExpanded = false;
            this.EntradaMonedaDecimalesCosto.Location = new System.Drawing.Point(184, 216);
            this.EntradaMonedaDecimalesCosto.Name = "EntradaMonedaDecimalesCosto";
            this.EntradaMonedaDecimalesCosto.SetData = new string[] {
        "Sin decimales|0",
        "Un decimal|1",
        "Dos decimales|2",
        "Tres decimales|3",
        "Cuatro decimales|4"};
            this.EntradaMonedaDecimalesCosto.Size = new System.Drawing.Size(160, 24);
            this.EntradaMonedaDecimalesCosto.TabIndex = 11;
            this.EntradaMonedaDecimalesCosto.TextKey = "0";
            // 
            // EntradaMonedaDecimalesUnitarios
            // 
            this.EntradaMonedaDecimalesUnitarios.AlwaysExpanded = false;
            this.EntradaMonedaDecimalesUnitarios.Location = new System.Drawing.Point(184, 248);
            this.EntradaMonedaDecimalesUnitarios.Name = "EntradaMonedaDecimalesUnitarios";
            this.EntradaMonedaDecimalesUnitarios.SetData = new string[] {
        "Sin decimales|0",
        "Un decimal|1",
        "Dos decimales|2",
        "Tres decimales|3",
        "Cuatro decimales|4"};
            this.EntradaMonedaDecimalesUnitarios.Size = new System.Drawing.Size(160, 24);
            this.EntradaMonedaDecimalesUnitarios.TabIndex = 13;
            this.EntradaMonedaDecimalesUnitarios.TextKey = "0";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(8, 248);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(176, 24);
            this.label34.TabIndex = 12;
            this.label34.Text = "Precios unitarios";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaMonedaDecimalesFinal
            // 
            this.EntradaMonedaDecimalesFinal.AlwaysExpanded = false;
            this.EntradaMonedaDecimalesFinal.Location = new System.Drawing.Point(184, 280);
            this.EntradaMonedaDecimalesFinal.Name = "EntradaMonedaDecimalesFinal";
            this.EntradaMonedaDecimalesFinal.SetData = new string[] {
        "Sin decimales|0",
        "Un decimal|1",
        "Dos decimales|2",
        "Tres decimales|3",
        "Cuatro decimales|4"};
            this.EntradaMonedaDecimalesFinal.Size = new System.Drawing.Size(160, 24);
            this.EntradaMonedaDecimalesFinal.TabIndex = 15;
            this.EntradaMonedaDecimalesFinal.TextKey = "0";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 280);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(176, 24);
            this.label18.TabIndex = 14;
            this.label18.Text = "Total del comprobante";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaMonedaUnidadMonetariaMinima
            // 
            this.EntradaMonedaUnidadMonetariaMinima.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaMonedaUnidadMonetariaMinima.Location = new System.Drawing.Point(240, 312);
            this.EntradaMonedaUnidadMonetariaMinima.Name = "EntradaMonedaUnidadMonetariaMinima";
            this.EntradaMonedaUnidadMonetariaMinima.Size = new System.Drawing.Size(92, 24);
            this.EntradaMonedaUnidadMonetariaMinima.TabIndex = 17;
            this.EntradaMonedaUnidadMonetariaMinima.Text = "0.00";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 168);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(176, 24);
            this.label26.TabIndex = 8;
            this.label26.Text = "Deposito sucursal";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaStockDepositoPredetSuc
            // 
            this.EntradaStockDepositoPredetSuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaStockDepositoPredetSuc.AutoTab = true;
            this.EntradaStockDepositoPredetSuc.CanCreate = true;
            this.EntradaStockDepositoPredetSuc.Location = new System.Drawing.Point(184, 168);
            this.EntradaStockDepositoPredetSuc.MaxLength = 200;
            this.EntradaStockDepositoPredetSuc.Name = "EntradaStockDepositoPredetSuc";
            this.EntradaStockDepositoPredetSuc.NombreTipo = "Lbl.Articulos.Situacion";
            this.EntradaStockDepositoPredetSuc.Required = false;
            this.EntradaStockDepositoPredetSuc.Size = new System.Drawing.Size(414, 24);
            this.EntradaStockDepositoPredetSuc.TabIndex = 9;
            this.EntradaStockDepositoPredetSuc.Text = "0";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 312);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(236, 24);
            this.label22.TabIndex = 16;
            this.label22.Text = "Denominación monetaria mínima";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmComprobantes
            // 
            this.FrmComprobantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrmComprobantes.Controls.Add(this.panel2);
            this.FrmComprobantes.Location = new System.Drawing.Point(154, 16);
            this.FrmComprobantes.Name = "FrmComprobantes";
            this.FrmComprobantes.Size = new System.Drawing.Size(612, 441);
            this.FrmComprobantes.TabIndex = 0;
            this.FrmComprobantes.Text = "Comprobantes";
            this.FrmComprobantes.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.EntradaClientePredet);
            this.panel2.Controls.Add(this.Label16);
            this.panel2.Controls.Add(this.EntradaPVRC);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.EntradaLimiteCredito);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.EntradaCambiaPrecioComprob);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.EntradaPVR);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.EntradaPV);
            this.panel2.Controls.Add(this.Label9);
            this.panel2.Controls.Add(this.EntradaPVND);
            this.panel2.Controls.Add(this.Label10);
            this.panel2.Controls.Add(this.Label8);
            this.panel2.Controls.Add(this.Label7);
            this.panel2.Controls.Add(this.EntradaPVNC);
            this.panel2.Controls.Add(this.EntradaPVABC);
            this.panel2.Controls.Add(this.Label6);
            this.panel2.Controls.Add(this.Label5);
            this.panel2.Controls.Add(this.Label4);
            this.panel2.Controls.Add(this.EntradaFormaPagoPredet);
            this.panel2.Controls.Add(this.Label15);
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(611, 398);
            this.panel2.TabIndex = 26;
            // 
            // EntradaPVRC
            // 
            this.EntradaPVRC.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPVRC.Location = new System.Drawing.Point(237, 207);
            this.EntradaPVRC.Name = "EntradaPVRC";
            this.EntradaPVRC.Size = new System.Drawing.Size(56, 24);
            this.EntradaPVRC.TabIndex = 19;
            this.EntradaPVRC.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "PV para recibos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(297, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(284, 24);
            this.label11.TabIndex = 17;
            this.label11.Text = "(0 para utilizar el mismo que para facturas)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
            // 
            // EntradaLimiteCredito
            // 
            this.EntradaLimiteCredito.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaLimiteCredito.Location = new System.Drawing.Point(237, 283);
            this.EntradaLimiteCredito.Name = "EntradaLimiteCredito";
            this.EntradaLimiteCredito.Size = new System.Drawing.Size(124, 24);
            this.EntradaLimiteCredito.TabIndex = 23;
            this.EntradaLimiteCredito.Text = "0.00";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(1, 283);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(236, 24);
            this.label21.TabIndex = 22;
            this.label21.Text = "Límite de crédito predeterminado";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaCambiaPrecioComprob
            // 
            this.EntradaCambiaPrecioComprob.Location = new System.Drawing.Point(409, 247);
            this.EntradaCambiaPrecioComprob.Name = "EntradaCambiaPrecioComprob";
            this.EntradaCambiaPrecioComprob.Size = new System.Drawing.Size(76, 24);
            this.EntradaCambiaPrecioComprob.TabIndex = 21;
            this.EntradaCambiaPrecioComprob.Value = true;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(1, 247);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(408, 24);
            this.label13.TabIndex = 20;
            this.label13.Text = "Permite cambiar precio del artículo durante la facturación";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaPVR
            // 
            this.EntradaPVR.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPVR.Location = new System.Drawing.Point(237, 179);
            this.EntradaPVR.Name = "EntradaPVR";
            this.EntradaPVR.Size = new System.Drawing.Size(56, 24);
            this.EntradaPVR.TabIndex = 16;
            this.EntradaPVR.Text = "0";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(1, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(236, 24);
            this.label12.TabIndex = 15;
            this.label12.Text = "PV para remitos";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmAvanzado
            // 
            this.FrmAvanzado.Controls.Add(this.label14);
            this.FrmAvanzado.Controls.Add(this.EntradaBackup);
            this.FrmAvanzado.Controls.Add(this.label27);
            this.FrmAvanzado.Controls.Add(this.EntradaModoPantalla);
            this.FrmAvanzado.Controls.Add(this.EntradaActualizaciones);
            this.FrmAvanzado.Controls.Add(this.label30);
            this.FrmAvanzado.Location = new System.Drawing.Point(154, 16);
            this.FrmAvanzado.Name = "FrmAvanzado";
            this.FrmAvanzado.Size = new System.Drawing.Size(618, 481);
            this.FrmAvanzado.TabIndex = 8;
            this.FrmAvanzado.Text = "Otras";
            this.FrmAvanzado.Visible = false;
            // 
            // buttonPanel1
            // 
            this.buttonPanel1.Controls.Add(this.CancelCommandButton);
            this.buttonPanel1.Controls.Add(this.BotonAceptar);
            this.buttonPanel1.Controls.Add(this.BotonSiguiente);
            this.buttonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonPanel1.Location = new System.Drawing.Point(0, 457);
            this.buttonPanel1.Name = "buttonPanel1";
            this.buttonPanel1.Padding = new System.Windows.Forms.Padding(12);
            this.buttonPanel1.Size = new System.Drawing.Size(784, 64);
            this.buttonPanel1.TabIndex = 100;
            // 
            // LabelTab1
            // 
            this.LabelTab1.Location = new System.Drawing.Point(12, 32);
            this.LabelTab1.Name = "LabelTab1";
            this.LabelTab1.Size = new System.Drawing.Size(122, 24);
            this.LabelTab1.TabIndex = 101;
            this.LabelTab1.Text = "Empresa";
            this.LabelTab1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelTab1.Click += new System.EventHandler(this.LabelTab1_Click);
            // 
            // LabelTab2
            // 
            this.LabelTab2.Location = new System.Drawing.Point(12, 56);
            this.LabelTab2.Name = "LabelTab2";
            this.LabelTab2.Size = new System.Drawing.Size(122, 24);
            this.LabelTab2.TabIndex = 102;
            this.LabelTab2.Text = "Comprobantes";
            this.LabelTab2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelTab2.Click += new System.EventHandler(this.LabelTab2_Click);
            // 
            // LabelTab3
            // 
            this.LabelTab3.Location = new System.Drawing.Point(12, 80);
            this.LabelTab3.Name = "LabelTab3";
            this.LabelTab3.Size = new System.Drawing.Size(122, 24);
            this.LabelTab3.TabIndex = 103;
            this.LabelTab3.Text = "Stock";
            this.LabelTab3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelTab3.Click += new System.EventHandler(this.LabelTab3_Click);
            // 
            // LabelTab4
            // 
            this.LabelTab4.Location = new System.Drawing.Point(12, 104);
            this.LabelTab4.Name = "LabelTab4";
            this.LabelTab4.Size = new System.Drawing.Size(122, 24);
            this.LabelTab4.TabIndex = 105;
            this.LabelTab4.Text = "Otras";
            this.LabelTab4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelTab4.Click += new System.EventHandler(this.LabelTab4_Click);
            // 
            // LabelTab5
            // 
            this.LabelTab5.Location = new System.Drawing.Point(12, 130);
            this.LabelTab5.Name = "LabelTab5";
            this.LabelTab5.Size = new System.Drawing.Size(122, 24);
            this.LabelTab5.TabIndex = 106;
            this.LabelTab5.Text = "Extras";
            this.LabelTab5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelTab5.Click += new System.EventHandler(this.LabelTab5_Click);
            // 
            // FrmCompxSuc
            // 
            this.FrmCompxSuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrmCompxSuc.Controls.Add(this.panel3);
            this.FrmCompxSuc.Location = new System.Drawing.Point(154, 10);
            this.FrmCompxSuc.Name = "FrmCompxSuc";
            this.FrmCompxSuc.Size = new System.Drawing.Size(612, 441);
            this.FrmCompxSuc.TabIndex = 107;
            this.FrmCompxSuc.Text = "Comprobantes por Sucursal y/o Estación";
            this.FrmCompxSuc.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnEstructura);
            this.panel3.Controls.Add(this.EntradaPVRC2);
            this.panel3.Controls.Add(this.label41);
            this.panel3.Controls.Add(this.label42);
            this.panel3.Controls.Add(this.EntradaPVR2);
            this.panel3.Controls.Add(this.label45);
            this.panel3.Controls.Add(this.EntradaPV2);
            this.panel3.Controls.Add(this.label46);
            this.panel3.Controls.Add(this.EntradaPVND2);
            this.panel3.Controls.Add(this.label47);
            this.panel3.Controls.Add(this.label48);
            this.panel3.Controls.Add(this.label49);
            this.panel3.Controls.Add(this.EntradaPVNC2);
            this.panel3.Controls.Add(this.EntradaPVABC2);
            this.panel3.Controls.Add(this.label50);
            this.panel3.Controls.Add(this.label51);
            this.panel3.Controls.Add(this.label52);
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(611, 398);
            this.panel3.TabIndex = 26;
            // 
            // EntradaPVRC2
            // 
            this.EntradaPVRC2.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPVRC2.Location = new System.Drawing.Point(237, 164);
            this.EntradaPVRC2.Name = "EntradaPVRC2";
            this.EntradaPVRC2.Size = new System.Drawing.Size(56, 24);
            this.EntradaPVRC2.TabIndex = 19;
            this.EntradaPVRC2.Text = "0";
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(1, 164);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(236, 24);
            this.label41.TabIndex = 18;
            this.label41.Text = "PV para recibos";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(297, 136);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(284, 24);
            this.label42.TabIndex = 17;
            this.label42.Text = "(0 para utilizar el mismo que para facturas)";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaPVR2
            // 
            this.EntradaPVR2.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPVR2.Location = new System.Drawing.Point(237, 136);
            this.EntradaPVR2.Name = "EntradaPVR2";
            this.EntradaPVR2.Size = new System.Drawing.Size(56, 24);
            this.EntradaPVR2.TabIndex = 16;
            this.EntradaPVR2.Text = "0";
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(1, 136);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(236, 24);
            this.label45.TabIndex = 15;
            this.label45.Text = "PV para remitos";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaPV2
            // 
            this.EntradaPV2.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPV2.Location = new System.Drawing.Point(237, 24);
            this.EntradaPV2.Name = "EntradaPV2";
            this.EntradaPV2.Size = new System.Drawing.Size(56, 24);
            this.EntradaPV2.TabIndex = 5;
            this.EntradaPV2.Text = "0";
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(297, 108);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(284, 24);
            this.label46.TabIndex = 14;
            this.label46.Text = "(0 para utilizar el mismo que para facturas)";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaPVND2
            // 
            this.EntradaPVND2.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPVND2.Location = new System.Drawing.Point(237, 108);
            this.EntradaPVND2.Name = "EntradaPVND2";
            this.EntradaPVND2.Size = new System.Drawing.Size(56, 24);
            this.EntradaPVND2.TabIndex = 13;
            this.EntradaPVND2.Text = "0";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(1, 108);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(236, 24);
            this.label47.TabIndex = 12;
            this.label47.Text = "PV para notas de débito A, B y C";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(297, 80);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(284, 24);
            this.label48.TabIndex = 11;
            this.label48.Text = "(0 para utilizar el mismo que para facturas)";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(297, 52);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(284, 24);
            this.label49.TabIndex = 8;
            this.label49.Text = "(0 para utilizar el predeterminado)";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaPVNC2
            // 
            this.EntradaPVNC2.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPVNC2.Location = new System.Drawing.Point(237, 80);
            this.EntradaPVNC2.Name = "EntradaPVNC2";
            this.EntradaPVNC2.Size = new System.Drawing.Size(56, 24);
            this.EntradaPVNC2.TabIndex = 10;
            this.EntradaPVNC2.Text = "0";
            // 
            // EntradaPVABC2
            // 
            this.EntradaPVABC2.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPVABC2.Location = new System.Drawing.Point(237, 52);
            this.EntradaPVABC2.Name = "EntradaPVABC2";
            this.EntradaPVABC2.Size = new System.Drawing.Size(56, 24);
            this.EntradaPVABC2.TabIndex = 7;
            this.EntradaPVABC2.Text = "0";
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(1, 80);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(236, 24);
            this.label50.TabIndex = 9;
            this.label50.Text = "PV para notas de crédito A, B y C";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(1, 52);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(236, 24);
            this.label51.TabIndex = 6;
            this.label51.Text = "PV para facturas A, B y C";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(1, 24);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(236, 24);
            this.label52.TabIndex = 4;
            this.label52.Text = "PV predeterminado";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEstructura
            // 
            this.btnEstructura.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEstructura.Image = null;
            this.btnEstructura.ImagePos = Lui.Forms.ImagePositions.Top;
            this.btnEstructura.Location = new System.Drawing.Point(409, 341);
            this.btnEstructura.Name = "btnEstructura";
            this.btnEstructura.Size = new System.Drawing.Size(197, 50);
            this.btnEstructura.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.btnEstructura.Subtext = "Tecla";
            this.btnEstructura.TabIndex = 20;
            this.btnEstructura.Text = "Actualizar estructura";
            this.btnEstructura.Click += new System.EventHandler(this.btnEstructura_Click);
            // 
            // Preferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.LabelTab5);
            this.Controls.Add(this.LabelTab4);
            this.Controls.Add(this.LabelTab3);
            this.Controls.Add(this.LabelTab2);
            this.Controls.Add(this.LabelTab1);
            this.Controls.Add(this.buttonPanel1);
            this.Controls.Add(this.FrmCompxSuc);
            this.Controls.Add(this.FrmComprobantes);
            this.Controls.Add(this.FrmArticulos);
            this.Controls.Add(this.FrmAvanzado);
            this.Controls.Add(this.FrmGeneral);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Preferencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferencias";
            this.FrmGeneral.ResumeLayout(false);
            this.FrmGeneral.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.FrmArticulos.ResumeLayout(false);
            this.FrmArticulos.PerformLayout();
            this.FrmComprobantes.ResumeLayout(false);
            this.FrmComprobantes.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.FrmAvanzado.ResumeLayout(false);
            this.FrmAvanzado.PerformLayout();
            this.buttonPanel1.ResumeLayout(false);
            this.FrmCompxSuc.ResumeLayout(false);
            this.FrmCompxSuc.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

                private Lui.Forms.Button BotonAceptar;
                private Lui.Forms.Button CancelCommandButton;
                private Lui.Forms.Label Label16;
                private Lcc.Entrada.CodigoDetalle EntradaClientePredet;
                private Lui.Forms.Label Label15;
                private Lcc.Entrada.CodigoDetalle EntradaFormaPagoPredet;
                private Lui.Forms.Label Label17;
                private Lui.Forms.TextBox EntradaEmpresaNombre;
                private Lui.Forms.Label EtiquetaClaveTributaria;
                private Lui.Forms.Label Label19;
                private Lui.Forms.TextBox EntradaEmpresaClaveTributaria;
                private Lcc.Entrada.CodigoDetalle EntradaEmpresaSituacion;
                private Lui.Forms.Label Label9;
                private Lui.Forms.TextBox EntradaPVND;
                private Lui.Forms.Label Label10;
                private Lui.Forms.Label Label8;
                private Lui.Forms.Label Label7;
                private Lui.Forms.TextBox EntradaPVNC;
                private Lui.Forms.TextBox EntradaPVABC;
                private Lui.Forms.Label Label6;
                private Lui.Forms.Label Label5;
                private Lui.Forms.Label Label4;
                private Lui.Forms.Label Label20;
                private Lui.Forms.TextBox EntradaPV;
                private Lui.Forms.ComboBox EntradaArticulosCodigoPredet;
                private Lui.Forms.ComboBox EntradaStockMultideposito;
                private Lui.Forms.Label Label23;
                private Lui.Forms.Label Label24;
                private Lcc.Entrada.CodigoDetalle EntradaStockDepositoPredet;
                private Lui.Forms.Label Label25;
                private Lui.Forms.ComboBox EntradaStockDecimales;
                private Lui.Forms.Button BotonSiguiente;
                private Lui.Forms.Frame FrmArticulos;
                private Lui.Forms.Frame FrmComprobantes;
                private Lui.Forms.ComboBox EntradaBackup;
                private Lui.Forms.Label label14;
                private Lui.Forms.TextBox EntradaLimiteCredito;
                private Lui.Forms.Label label21;
                private Lui.Forms.TextBox EntradaMonedaUnidadMonetariaMinima;
                private Lui.Forms.Label label22;
                private Lui.Forms.ComboBox EntradaModoPantalla;
                private Lui.Forms.Label label27;
                private Lui.Forms.TextBox EntradaEmpresaEmail;
                private Lui.Forms.Label label28;
                private Lui.Forms.ComboBox EntradaActualizaciones;
                private Lui.Forms.Label label30;
                private Lui.Forms.TextBox EntradaEmpresaRazonSocial;
                private Lui.Forms.Label label1;
                private Lui.Forms.TextBox EntradaPVRC;
                private Lui.Forms.Label label3;
                private Lui.Forms.TextBox EntradaEmpresaId;
                private Lui.Forms.Label label2;
                private Lui.Forms.Frame FrmGeneral;
                private Lui.Forms.Label label26;
                private Lcc.Entrada.CodigoDetalle EntradaStockDepositoPredetSuc;
                private Lui.Forms.Label label11;
                private Lui.Forms.Label label12;
                private Lui.Forms.TextBox EntradaPVR;
                private Lui.Forms.YesNo EntradaCambiaPrecioComprob;
                private Lui.Forms.Label label13;
                private Lcc.Entrada.CodigoDetalle EntradaProvincia;
                private Lui.Forms.Label label31;
                private Lui.Forms.Frame FrmAvanzado;
                private Lcc.Entrada.CodigoDetalle EntradaLocalidad;
                private Lui.Forms.Label label32;
                private Lcc.Entrada.CodigoDetalle EntradaPais;
                private Lui.Forms.Label label33;
                private Lui.Forms.ComboBox EntradaMonedaDecimalesFinal;
                private Lui.Forms.Label label18;
                private Lui.Forms.ComboBox EntradaMonedaDecimalesUnitarios;
                private Lui.Forms.Label label34;
                private Lui.Forms.ComboBox EntradaMonedaDecimalesCosto;
                private Lui.Forms.Label label35;
                private Lui.Forms.ButtonPanel buttonPanel1;
                private Lui.Forms.Button BotonCambiarPais;
                private Lui.Forms.Label label36;
                private Lcc.Entrada.CodigoDetalle EntradaSucursal;
                private Lui.Forms.Label LabelTab1;
                private Lui.Forms.Label LabelTab2;
                private Lui.Forms.Label LabelTab3;
                private Lui.Forms.Label LabelTab4;
                private Lui.Forms.Panel panel1;
                private Lui.Forms.Label label37;
                private Lcc.Entrada.Imagen EntradaLogo;
                private Lui.Forms.Label label29;
                private Lui.Forms.Panel panel2;
                private Lui.Forms.TextBox EntradaInicioActividades;
                private Lui.Forms.Label label39;
                private Lui.Forms.TextBox EntradaIngresosBrutos;
                private Lui.Forms.Label label38;
                private Lui.Forms.Label LabelTab5;
                private Lui.Forms.Frame FrmCompxSuc;
                private Lui.Forms.Panel panel3;
                private Lui.Forms.TextBox EntradaPVRC2;
                private Lui.Forms.Label label41;
                private Lui.Forms.Label label42;
                private Lui.Forms.TextBox EntradaPVR2;
                private Lui.Forms.Label label45;
                private Lui.Forms.TextBox EntradaPV2;
                private Lui.Forms.Label label46;
                private Lui.Forms.TextBox EntradaPVND2;
                private Lui.Forms.Label label47;
                private Lui.Forms.Label label48;
                private Lui.Forms.Label label49;
                private Lui.Forms.TextBox EntradaPVNC2;
                private Lui.Forms.TextBox EntradaPVABC2;
                private Lui.Forms.Label label50;
                private Lui.Forms.Label label51;
                private Lui.Forms.Label label52;
        private Lui.Forms.Button btnEstructura;
    }
}
