namespace Lfc.Comprobantes.Compra
{
    partial class Editar
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.EntradaTipo = new Lui.Forms.ComboBox();
            this.EntradaFormaPago = new Lui.Forms.ComboBox();
            this.EntradaFecha = new Lui.Forms.TextBox();
            this.EntradaPV = new Lui.Forms.TextBox();
            this.EntradaHaciaSituacion = new Lcc.Entrada.CodigoDetalle();
            this.EntradaNumero = new Lui.Forms.TextBox();
            this.EntradaProductos = new Lcc.Entrada.Articulos.MatrizDetalleCompra();
            this.EntradaProveedor = new Lcc.Entrada.CodigoDetalle();
            this.label7 = new Lui.Forms.Label();
            this.EtiquetaHaciaSituacion = new Lui.Forms.Label();
            this.Label2 = new Lui.Forms.Label();
            this.Label3 = new Lui.Forms.Label();
            this.EntradaEstado = new Lui.Forms.ComboBox();
            this.BotonObs = new Lui.Forms.Button();
            this.BotonConvertir = new Lui.Forms.Button();
            this.EntradaOtrosGastos = new Lui.Forms.TextBox();
            this.EntradaCancelado = new Lui.Forms.TextBox();
            this.EntradaGastosEnvio = new Lui.Forms.TextBox();
            this.EntradaTotal = new Lui.Forms.TextBox();
            this.EntradaObs = new System.Windows.Forms.TextBox();
            this.label9 = new Lui.Forms.Label();
            this.label6 = new Lui.Forms.Label();
            this.EtiquetaEstado = new Lui.Forms.Label();
            this.label1 = new Lui.Forms.Label();
            this.lblTotal = new Lui.Forms.Label();
            this.Contenedor = new Lui.Forms.Panel();
            this.label4 = new Lui.Forms.Label();
            this.EntradaSubTotal = new Lui.Forms.TextBox();
            this.lblDolar = new Lui.Forms.Label();
            this.EntradaPercepcionIIBB = new Lui.Forms.TextBox();
            this.EntradaLocalidad = new Lcc.Entrada.CodigoDetalle();
            this.lblLugar = new Lui.Forms.Label();
            this.EntradaPercepcionIVA = new Lui.Forms.TextBox();
            this.lblPerIva = new Lui.Forms.Label();
            this.lblPerIIBB = new Lui.Forms.Label();
            this.gbMoneda = new System.Windows.Forms.GroupBox();
            this.EntradaMoneda = new Lcc.Entrada.CodigoDetalle();
            this.EntradaCotiza = new Lui.Forms.TextBox();
            this.label25 = new Lui.Forms.Label();
            this.EntradaAfecta = new Lui.Forms.ComboBox();
            this.lblAfecta = new Lui.Forms.Label();
            this.lblRemito = new Lui.Forms.Label();
            this.EntradaRemito = new Lcc.Entrada.CodigoDetalle();
            this.EntradaDescuento = new Lui.Forms.TextBox();
            this.EtiquetaDescuento = new Lui.Forms.Label();
            this.Contenedor.SuspendLayout();
            this.gbMoneda.SuspendLayout();
            this.SuspendLayout();
            // 
            // EntradaTipo
            // 
            this.EntradaTipo.AlwaysExpanded = false;
            this.EntradaTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaTipo.AutoSize = true;
            this.EntradaTipo.Location = new System.Drawing.Point(627, 0);
            this.EntradaTipo.Name = "EntradaTipo";
            this.EntradaTipo.SetData = new string[] {
        "Factura A|FA"};
            this.EntradaTipo.Size = new System.Drawing.Size(132, 25);
            this.EntradaTipo.TabIndex = 2;
            this.EntradaTipo.TextKey = "FA";
            this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaTipoPvNumero_TextChanged);
            // 
            // EntradaFormaPago
            // 
            this.EntradaFormaPago.AlwaysExpanded = false;
            this.EntradaFormaPago.AutoSize = true;
            this.EntradaFormaPago.Location = new System.Drawing.Point(188, 28);
            this.EntradaFormaPago.Name = "EntradaFormaPago";
            this.EntradaFormaPago.SetData = new string[] {
        "No controla pago|0",
        "Efectivo|1",
        "Cuenta corriente|3"};
            this.EntradaFormaPago.Size = new System.Drawing.Size(176, 25);
            this.EntradaFormaPago.TabIndex = 6;
            this.EntradaFormaPago.TextKey = "0";
            // 
            // EntradaFecha
            // 
            this.EntradaFecha.DataType = Lui.Forms.DataTypes.Date;
            this.EntradaFecha.Location = new System.Drawing.Point(80, 28);
            this.EntradaFecha.Name = "EntradaFecha";
            this.EntradaFecha.Size = new System.Drawing.Size(100, 24);
            this.EntradaFecha.TabIndex = 5;
            // 
            // EntradaPV
            // 
            this.EntradaPV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaPV.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaPV.Location = new System.Drawing.Point(795, 0);
            this.EntradaPV.Name = "EntradaPV";
            this.EntradaPV.Size = new System.Drawing.Size(56, 24);
            this.EntradaPV.TabIndex = 3;
            this.EntradaPV.Text = "0";
            this.EntradaPV.TextChanged += new System.EventHandler(this.EntradaTipoPvNumero_TextChanged);
            // 
            // EntradaHaciaSituacion
            // 
            this.EntradaHaciaSituacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaHaciaSituacion.AutoTab = true;
            this.EntradaHaciaSituacion.CanCreate = false;
            this.EntradaHaciaSituacion.Filter = "deposito>0";
            this.EntradaHaciaSituacion.Location = new System.Drawing.Point(444, 28);
            this.EntradaHaciaSituacion.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaHaciaSituacion.MaxLength = 200;
            this.EntradaHaciaSituacion.Name = "EntradaHaciaSituacion";
            this.EntradaHaciaSituacion.NombreTipo = "Lbl.Articulos.Situacion";
            this.EntradaHaciaSituacion.Required = true;
            this.EntradaHaciaSituacion.Size = new System.Drawing.Size(480, 24);
            this.EntradaHaciaSituacion.TabIndex = 8;
            this.EntradaHaciaSituacion.Text = "0";
            // 
            // EntradaNumero
            // 
            this.EntradaNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaNumero.Location = new System.Drawing.Point(855, 0);
            this.EntradaNumero.Name = "EntradaNumero";
            this.EntradaNumero.Size = new System.Drawing.Size(100, 24);
            this.EntradaNumero.TabIndex = 4;
            this.EntradaNumero.TextChanged += new System.EventHandler(this.EntradaTipoPvNumero_TextChanged);
            this.EntradaNumero.Leave += new System.EventHandler(this.EntradaNumero_Leave);
            // 
            // EntradaProductos
            // 
            this.EntradaProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaProductos.AplicaIva = true;
            this.EntradaProductos.AutoScroll = true;
            this.EntradaProductos.AutoScrollMargin = new System.Drawing.Size(4, 4);
            this.EntradaProductos.BloquearAtriculo = false;
            this.EntradaProductos.BloquearCantidad = false;
            this.EntradaProductos.BloquearDescuento = false;
            this.EntradaProductos.BloquearPrecio = false;
            this.EntradaProductos.CargarPersona = "";
            this.EntradaProductos.DiscriminarIva = false;
            this.EntradaProductos.FreeTextCode = "*";
            this.EntradaProductos.Location = new System.Drawing.Point(0, 115);
            this.EntradaProductos.MostrarExistencias = false;
            this.EntradaProductos.Name = "EntradaProductos";
            this.EntradaProductos.PedirSeguimiento = true;
            this.EntradaProductos.Precio = Lcc.Entrada.Articulos.Precios.Costo;
            this.EntradaProductos.Size = new System.Drawing.Size(957, 279);
            this.EntradaProductos.TabIndex = 12;
            this.EntradaProductos.TotalChanged += new System.EventHandler(this.RecalcularTotal);
            this.EntradaProductos.ObtenerDatosSeguimiento += new System.EventHandler(this.EntradaProductos_ObtenerDatosSeguimiento);
            this.EntradaProductos.TextChanged += new System.EventHandler(this.RecalcularTotal);
            // 
            // EntradaProveedor
            // 
            this.EntradaProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaProveedor.AutoTab = true;
            this.EntradaProveedor.CanCreate = true;
            this.EntradaProveedor.Filter = "estado=1";
            this.EntradaProveedor.Location = new System.Drawing.Point(80, 0);
            this.EntradaProveedor.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaProveedor.MaxLength = 200;
            this.EntradaProveedor.Name = "EntradaProveedor";
            this.EntradaProveedor.NombreTipo = "Lbl.Personas.Proveedor";
            this.EntradaProveedor.Required = true;
            this.EntradaProveedor.Size = new System.Drawing.Size(480, 24);
            this.EntradaProveedor.TabIndex = 0;
            this.EntradaProveedor.Text = "0";
            this.EntradaProveedor.TextChanged += new System.EventHandler(this.EntradaProveedor_TextChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 24);
            this.label7.TabIndex = 20;
            this.label7.Text = "Fecha";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EtiquetaHaciaSituacion
            // 
            this.EtiquetaHaciaSituacion.Location = new System.Drawing.Point(372, 28);
            this.EtiquetaHaciaSituacion.Name = "EtiquetaHaciaSituacion";
            this.EtiquetaHaciaSituacion.Size = new System.Drawing.Size(68, 24);
            this.EtiquetaHaciaSituacion.TabIndex = 7;
            this.EtiquetaHaciaSituacion.Text = "Destino";
            this.EtiquetaHaciaSituacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.Location = new System.Drawing.Point(763, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(28, 24);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Nº";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(0, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(80, 24);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Proveedor";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaEstado
            // 
            this.EntradaEstado.AlwaysExpanded = false;
            this.EntradaEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EntradaEstado.Location = new System.Drawing.Point(286, 403);
            this.EntradaEstado.Name = "EntradaEstado";
            this.EntradaEstado.SetData = new string[] {
        "N/A|0"};
            this.EntradaEstado.Size = new System.Drawing.Size(164, 24);
            this.EntradaEstado.TabIndex = 15;
            this.EntradaEstado.TextKey = "0";
            // 
            // BotonObs
            // 
            this.BotonObs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BotonObs.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonObs.Image = null;
            this.BotonObs.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonObs.Location = new System.Drawing.Point(116, 458);
            this.BotonObs.Name = "BotonObs";
            this.BotonObs.Size = new System.Drawing.Size(108, 32);
            this.BotonObs.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
            this.BotonObs.Subtext = "F7";
            this.BotonObs.TabIndex = 62;
            this.BotonObs.Text = "Observac.";
            this.BotonObs.Click += new System.EventHandler(this.BotonObs_Click);
            // 
            // BotonConvertir
            // 
            this.BotonConvertir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BotonConvertir.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BotonConvertir.Image = null;
            this.BotonConvertir.ImagePos = Lui.Forms.ImagePositions.Top;
            this.BotonConvertir.Location = new System.Drawing.Point(0, 458);
            this.BotonConvertir.Name = "BotonConvertir";
            this.BotonConvertir.Size = new System.Drawing.Size(108, 32);
            this.BotonConvertir.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
            this.BotonConvertir.Subtext = "F4";
            this.BotonConvertir.TabIndex = 60;
            this.BotonConvertir.Text = "Convertir";
            this.BotonConvertir.Click += new System.EventHandler(this.BotonConvertir_Click);
            // 
            // EntradaOtrosGastos
            // 
            this.EntradaOtrosGastos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EntradaOtrosGastos.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaOtrosGastos.Location = new System.Drawing.Point(116, 430);
            this.EntradaOtrosGastos.Name = "EntradaOtrosGastos";
            this.EntradaOtrosGastos.Prefijo = "$";
            this.EntradaOtrosGastos.Size = new System.Drawing.Size(104, 24);
            this.EntradaOtrosGastos.TabIndex = 14;
            this.EntradaOtrosGastos.Text = "0.00";
            this.EntradaOtrosGastos.TextChanged += new System.EventHandler(this.RecalcularTotal);
            // 
            // EntradaCancelado
            // 
            this.EntradaCancelado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaCancelado.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaCancelado.Location = new System.Drawing.Point(831, 462);
            this.EntradaCancelado.Name = "EntradaCancelado";
            this.EntradaCancelado.Prefijo = "$";
            this.EntradaCancelado.Size = new System.Drawing.Size(124, 28);
            this.EntradaCancelado.TabIndex = 59;
            this.EntradaCancelado.TabStop = false;
            this.EntradaCancelado.Text = "0.00";
            this.EntradaCancelado.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
            // 
            // EntradaGastosEnvio
            // 
            this.EntradaGastosEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EntradaGastosEnvio.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaGastosEnvio.Location = new System.Drawing.Point(116, 402);
            this.EntradaGastosEnvio.Name = "EntradaGastosEnvio";
            this.EntradaGastosEnvio.Prefijo = "$";
            this.EntradaGastosEnvio.Size = new System.Drawing.Size(104, 24);
            this.EntradaGastosEnvio.TabIndex = 13;
            this.EntradaGastosEnvio.Text = "0.00";
            this.EntradaGastosEnvio.TextChanged += new System.EventHandler(this.RecalcularTotal);
            // 
            // EntradaTotal
            // 
            this.EntradaTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaTotal.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaTotal.Location = new System.Drawing.Point(831, 430);
            this.EntradaTotal.Name = "EntradaTotal";
            this.EntradaTotal.Prefijo = "$";
            this.EntradaTotal.Size = new System.Drawing.Size(124, 28);
            this.EntradaTotal.TabIndex = 57;
            this.EntradaTotal.TabStop = false;
            this.EntradaTotal.Text = "0.00";
            this.EntradaTotal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
            // 
            // EntradaObs
            // 
            this.EntradaObs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EntradaObs.Location = new System.Drawing.Point(224, 430);
            this.EntradaObs.Name = "EntradaObs";
            this.EntradaObs.Size = new System.Drawing.Size(32, 25);
            this.EntradaObs.TabIndex = 61;
            this.EntradaObs.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(0, 430);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 24);
            this.label9.TabIndex = 52;
            this.label9.Text = "Otros Gastos";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(727, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 28);
            this.label6.TabIndex = 58;
            this.label6.Text = "Cancelado";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
            // 
            // EtiquetaEstado
            // 
            this.EtiquetaEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EtiquetaEstado.Location = new System.Drawing.Point(226, 402);
            this.EtiquetaEstado.Name = "EtiquetaEstado";
            this.EtiquetaEstado.Size = new System.Drawing.Size(60, 24);
            this.EtiquetaEstado.TabIndex = 54;
            this.EtiquetaEstado.Text = "Estado";
            this.EtiquetaEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(0, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 50;
            this.label1.Text = "Gastos de Envío";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Location = new System.Drawing.Point(727, 430);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(104, 28);
            this.lblTotal.TabIndex = 56;
            this.lblTotal.Text = "Total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
            // 
            // Contenedor
            // 
            this.Contenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Contenedor.Controls.Add(this.label4);
            this.Contenedor.Controls.Add(this.EntradaSubTotal);
            this.Contenedor.Controls.Add(this.lblDolar);
            this.Contenedor.Controls.Add(this.EntradaPercepcionIIBB);
            this.Contenedor.Controls.Add(this.EntradaLocalidad);
            this.Contenedor.Controls.Add(this.lblLugar);
            this.Contenedor.Controls.Add(this.EntradaPercepcionIVA);
            this.Contenedor.Controls.Add(this.lblPerIva);
            this.Contenedor.Controls.Add(this.lblPerIIBB);
            this.Contenedor.Controls.Add(this.label1);
            this.Contenedor.Controls.Add(this.EtiquetaEstado);
            this.Contenedor.Controls.Add(this.label9);
            this.Contenedor.Controls.Add(this.label6);
            this.Contenedor.Controls.Add(this.lblTotal);
            this.Contenedor.Controls.Add(this.gbMoneda);
            this.Contenedor.Controls.Add(this.EntradaAfecta);
            this.Contenedor.Controls.Add(this.lblAfecta);
            this.Contenedor.Controls.Add(this.lblRemito);
            this.Contenedor.Controls.Add(this.EntradaRemito);
            this.Contenedor.Controls.Add(this.EntradaDescuento);
            this.Contenedor.Controls.Add(this.EtiquetaDescuento);
            this.Contenedor.Controls.Add(this.EntradaEstado);
            this.Contenedor.Controls.Add(this.EntradaFormaPago);
            this.Contenedor.Controls.Add(this.EntradaTipo);
            this.Contenedor.Controls.Add(this.EntradaObs);
            this.Contenedor.Controls.Add(this.BotonObs);
            this.Contenedor.Controls.Add(this.Label3);
            this.Contenedor.Controls.Add(this.BotonConvertir);
            this.Contenedor.Controls.Add(this.Label2);
            this.Contenedor.Controls.Add(this.EntradaOtrosGastos);
            this.Contenedor.Controls.Add(this.EtiquetaHaciaSituacion);
            this.Contenedor.Controls.Add(this.EntradaCancelado);
            this.Contenedor.Controls.Add(this.label7);
            this.Contenedor.Controls.Add(this.EntradaGastosEnvio);
            this.Contenedor.Controls.Add(this.EntradaProveedor);
            this.Contenedor.Controls.Add(this.EntradaTotal);
            this.Contenedor.Controls.Add(this.EntradaProductos);
            this.Contenedor.Controls.Add(this.EntradaNumero);
            this.Contenedor.Controls.Add(this.EntradaHaciaSituacion);
            this.Contenedor.Controls.Add(this.EntradaPV);
            this.Contenedor.Controls.Add(this.EntradaFecha);
            this.Contenedor.Location = new System.Drawing.Point(0, 0);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(955, 490);
            this.Contenedor.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(747, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 76;
            this.label4.Text = "SubTotal";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // EntradaSubTotal
            // 
            this.EntradaSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaSubTotal.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaSubTotal.Enabled = false;
            this.EntradaSubTotal.Location = new System.Drawing.Point(831, 398);
            this.EntradaSubTotal.Name = "EntradaSubTotal";
            this.EntradaSubTotal.Prefijo = "$";
            this.EntradaSubTotal.Size = new System.Drawing.Size(124, 28);
            this.EntradaSubTotal.TabIndex = 77;
            this.EntradaSubTotal.TabStop = false;
            this.EntradaSubTotal.Text = "0.00";
            this.EntradaSubTotal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
            // 
            // lblDolar
            // 
            this.lblDolar.Location = new System.Drawing.Point(774, 59);
            this.lblDolar.Name = "lblDolar";
            this.lblDolar.Size = new System.Drawing.Size(155, 30);
            this.lblDolar.TabIndex = 70;
            this.lblDolar.Text = "<---- El precio de costo es cotizado por otra moneda\r\n";
            this.lblDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDolar.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
            this.lblDolar.Visible = false;
            // 
            // EntradaPercepcionIIBB
            // 
            this.EntradaPercepcionIIBB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EntradaPercepcionIIBB.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaPercepcionIIBB.Location = new System.Drawing.Point(341, 431);
            this.EntradaPercepcionIIBB.MaxLength = 14;
            this.EntradaPercepcionIIBB.Name = "EntradaPercepcionIIBB";
            this.EntradaPercepcionIIBB.PlaceholderText = "";
            this.EntradaPercepcionIIBB.Prefijo = "$";
            this.EntradaPercepcionIIBB.Size = new System.Drawing.Size(89, 24);
            this.EntradaPercepcionIIBB.TabIndex = 18;
            this.EntradaPercepcionIIBB.Text = "0.00";
            this.EntradaPercepcionIIBB.Visible = false;
            this.EntradaPercepcionIIBB.TextChanged += new System.EventHandler(this.RecalcularTotal);
            // 
            // EntradaLocalidad
            // 
            this.EntradaLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EntradaLocalidad.AutoTab = true;
            this.EntradaLocalidad.CanCreate = false;
            this.EntradaLocalidad.Filter = "id_provincia is null AND id_pais=1";
            this.EntradaLocalidad.Location = new System.Drawing.Point(496, 434);
            this.EntradaLocalidad.MaxLength = 0;
            this.EntradaLocalidad.Name = "EntradaLocalidad";
            this.EntradaLocalidad.NombreTipo = "Lbl.Entidades.Localidad";
            this.EntradaLocalidad.PlaceholderText = "Lugar de Percepción IIBB";
            this.EntradaLocalidad.Required = true;
            this.EntradaLocalidad.Size = new System.Drawing.Size(245, 21);
            this.EntradaLocalidad.TabIndex = 19;
            this.EntradaLocalidad.Text = "0";
            this.EntradaLocalidad.Visible = false;
            // 
            // lblLugar
            // 
            this.lblLugar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLugar.Location = new System.Drawing.Point(436, 431);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(51, 24);
            this.lblLugar.TabIndex = 75;
            this.lblLugar.Text = "Lugar";
            this.lblLugar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLugar.Visible = false;
            // 
            // EntradaPercepcionIVA
            // 
            this.EntradaPercepcionIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EntradaPercepcionIVA.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaPercepcionIVA.Location = new System.Drawing.Point(665, 403);
            this.EntradaPercepcionIVA.Name = "EntradaPercepcionIVA";
            this.EntradaPercepcionIVA.Prefijo = "$";
            this.EntradaPercepcionIVA.Size = new System.Drawing.Size(76, 24);
            this.EntradaPercepcionIVA.TabIndex = 17;
            this.EntradaPercepcionIVA.Text = "0.00";
            this.EntradaPercepcionIVA.Visible = false;
            this.EntradaPercepcionIVA.TextChanged += new System.EventHandler(this.RecalcularTotal);
            // 
            // lblPerIva
            // 
            this.lblPerIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPerIva.Location = new System.Drawing.Point(605, 403);
            this.lblPerIva.Name = "lblPerIva";
            this.lblPerIva.Size = new System.Drawing.Size(60, 24);
            this.lblPerIva.TabIndex = 73;
            this.lblPerIva.Text = "Perc.IVA";
            this.lblPerIva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPerIva.Visible = false;
            // 
            // lblPerIIBB
            // 
            this.lblPerIIBB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPerIIBB.Location = new System.Drawing.Point(278, 430);
            this.lblPerIIBB.Name = "lblPerIIBB";
            this.lblPerIIBB.Size = new System.Drawing.Size(60, 24);
            this.lblPerIIBB.TabIndex = 71;
            this.lblPerIIBB.Text = "Perc.IIBB";
            this.lblPerIIBB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPerIIBB.Visible = false;
            // 
            // gbMoneda
            // 
            this.gbMoneda.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMoneda.Controls.Add(this.EntradaMoneda);
            this.gbMoneda.Controls.Add(this.EntradaCotiza);
            this.gbMoneda.Controls.Add(this.label25);
            this.gbMoneda.Location = new System.Drawing.Point(420, 59);
            this.gbMoneda.Name = "gbMoneda";
            this.gbMoneda.Size = new System.Drawing.Size(348, 50);
            this.gbMoneda.TabIndex = 11;
            this.gbMoneda.TabStop = false;
            this.gbMoneda.Text = "Cotización de los artículos en otra moneda";
            this.gbMoneda.Visible = false;
            // 
            // EntradaMoneda
            // 
            this.EntradaMoneda.AutoTab = true;
            this.EntradaMoneda.CanCreate = true;
            this.EntradaMoneda.ExtraDetailFields = "Cotizacion";
            this.EntradaMoneda.Location = new System.Drawing.Point(70, 20);
            this.EntradaMoneda.MaxLength = 0;
            this.EntradaMoneda.Name = "EntradaMoneda";
            this.EntradaMoneda.NombreTipo = "Lbl.Entidades.Moneda";
            this.EntradaMoneda.PlaceholderText = "Sin especificar";
            this.EntradaMoneda.Required = true;
            this.EntradaMoneda.Size = new System.Drawing.Size(169, 21);
            this.EntradaMoneda.TabIndex = 0;
            this.EntradaMoneda.Text = "0";
            this.EntradaMoneda.TextChanged += new System.EventHandler(this.EntradaMoneda_TextChanged);
            // 
            // EntradaCotiza
            // 
            this.EntradaCotiza.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaCotiza.Location = new System.Drawing.Point(245, 17);
            this.EntradaCotiza.MaxLength = 14;
            this.EntradaCotiza.Name = "EntradaCotiza";
            this.EntradaCotiza.PlaceholderText = "Precio de costo o de compra.";
            this.EntradaCotiza.Prefijo = "$";
            this.EntradaCotiza.Size = new System.Drawing.Size(89, 24);
            this.EntradaCotiza.TabIndex = 1;
            this.EntradaCotiza.Text = "0.00";
            this.EntradaCotiza.TextChanged += new System.EventHandler(this.RecalcularTotal);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(10, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 24);
            this.label25.TabIndex = 2;
            this.label25.Text = "Moneda";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EntradaAfecta
            // 
            this.EntradaAfecta.AlwaysExpanded = false;
            this.EntradaAfecta.AutoSize = true;
            this.EntradaAfecta.Location = new System.Drawing.Point(289, 58);
            this.EntradaAfecta.Name = "EntradaAfecta";
            this.EntradaAfecta.SetData = new string[] {
        "Precio Costo|1",
        "Precio Costo y Venta|2",
        "No Afecta|0"};
            this.EntradaAfecta.Size = new System.Drawing.Size(125, 23);
            this.EntradaAfecta.TabIndex = 10;
            this.EntradaAfecta.TextKey = "0";
            this.EntradaAfecta.Visible = false;
            // 
            // lblAfecta
            // 
            this.lblAfecta.Location = new System.Drawing.Point(242, 55);
            this.lblAfecta.Name = "lblAfecta";
            this.lblAfecta.Size = new System.Drawing.Size(44, 24);
            this.lblAfecta.TabIndex = 67;
            this.lblAfecta.Text = "Afecta";
            this.lblAfecta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAfecta.Visible = false;
            // 
            // lblRemito
            // 
            this.lblRemito.Location = new System.Drawing.Point(2, 55);
            this.lblRemito.Name = "lblRemito";
            this.lblRemito.Size = new System.Drawing.Size(68, 24);
            this.lblRemito.TabIndex = 66;
            this.lblRemito.Text = "Remito";
            this.lblRemito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRemito.Visible = false;
            // 
            // EntradaRemito
            // 
            this.EntradaRemito.AutoTab = true;
            this.EntradaRemito.CanCreate = false;
            this.EntradaRemito.Filter = "anulada=0 and tipo_fac=\'R\'";
            this.EntradaRemito.Location = new System.Drawing.Point(80, 59);
            this.EntradaRemito.MaxLength = 200;
            this.EntradaRemito.Name = "EntradaRemito";
            this.EntradaRemito.NombreTipo = "Lbl.Comprobantes.Remito";
            this.EntradaRemito.PlaceholderText = "Ninguno";
            this.EntradaRemito.Required = true;
            this.EntradaRemito.Size = new System.Drawing.Size(156, 21);
            this.EntradaRemito.TabIndex = 9;
            this.EntradaRemito.Text = "0";
            this.EntradaRemito.Visible = false;
            // 
            // EntradaDescuento
            // 
            this.EntradaDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EntradaDescuento.DataType = Lui.Forms.DataTypes.Float;
            this.EntradaDescuento.Location = new System.Drawing.Point(516, 403);
            this.EntradaDescuento.Name = "EntradaDescuento";
            this.EntradaDescuento.Size = new System.Drawing.Size(76, 24);
            this.EntradaDescuento.Sufijo = "%";
            this.EntradaDescuento.TabIndex = 16;
            this.EntradaDescuento.Text = "0.0000";
            this.EntradaDescuento.Visible = false;
            this.EntradaDescuento.TextChanged += new System.EventHandler(this.RecalcularTotal);
            // 
            // EtiquetaDescuento
            // 
            this.EtiquetaDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EtiquetaDescuento.Location = new System.Drawing.Point(456, 403);
            this.EtiquetaDescuento.Name = "EtiquetaDescuento";
            this.EtiquetaDescuento.Size = new System.Drawing.Size(60, 24);
            this.EtiquetaDescuento.TabIndex = 63;
            this.EtiquetaDescuento.Text = "Descto.";
            this.EtiquetaDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EtiquetaDescuento.Visible = false;
            // 
            // Editar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.Contenedor);
            this.Name = "Editar";
            this.Size = new System.Drawing.Size(955, 490);
            this.Contenedor.ResumeLayout(false);
            this.Contenedor.PerformLayout();
            this.gbMoneda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Lui.Forms.ComboBox EntradaTipo;
        internal Lui.Forms.ComboBox EntradaFormaPago;
        internal Lui.Forms.TextBox EntradaFecha;
        internal Lui.Forms.TextBox EntradaPV;
        internal Lcc.Entrada.CodigoDetalle EntradaHaciaSituacion;
        internal Lui.Forms.TextBox EntradaNumero;
        internal Lcc.Entrada.Articulos.MatrizDetalleCompra EntradaProductos;
        internal Lcc.Entrada.CodigoDetalle EntradaProveedor;
        internal Lui.Forms.Label label7;
        internal Lui.Forms.Label EtiquetaHaciaSituacion;
        internal Lui.Forms.Label Label2;
        internal Lui.Forms.Label Label3;
        internal Lui.Forms.ComboBox EntradaEstado;
        internal Lui.Forms.Button BotonObs;
        internal Lui.Forms.Button BotonConvertir;
        internal Lui.Forms.TextBox EntradaOtrosGastos;
        internal Lui.Forms.TextBox EntradaCancelado;
        internal Lui.Forms.TextBox EntradaGastosEnvio;
        internal Lui.Forms.TextBox EntradaTotal;
        internal System.Windows.Forms.TextBox EntradaObs;
        internal Lui.Forms.Label label9;
        internal Lui.Forms.Label label6;
        internal Lui.Forms.Label EtiquetaEstado;
        internal Lui.Forms.Label label1;
        internal Lui.Forms.Label lblTotal;
        private Lui.Forms.Panel Contenedor;
        internal Lui.Forms.TextBox EntradaDescuento;
        internal Lui.Forms.Label EtiquetaDescuento;
        private Lcc.Entrada.CodigoDetalle EntradaRemito;
        internal Lui.Forms.Label lblRemito;
        internal Lui.Forms.ComboBox EntradaAfecta;
        internal Lui.Forms.Label lblAfecta;
        private System.Windows.Forms.GroupBox gbMoneda;
        internal Lcc.Entrada.CodigoDetalle EntradaMoneda;
        internal Lui.Forms.TextBox EntradaCotiza;
        internal Lui.Forms.Label label25;
        internal Lui.Forms.Label lblDolar;
        internal Lui.Forms.Label lblPerIIBB;
        internal Lui.Forms.TextBox EntradaPercepcionIVA;
        internal Lui.Forms.Label lblPerIva;
        internal Lcc.Entrada.CodigoDetalle EntradaLocalidad;
        internal Lui.Forms.Label lblLugar;
        internal Lui.Forms.TextBox EntradaPercepcionIIBB;
        internal Lui.Forms.Label label4;
        internal Lui.Forms.TextBox EntradaSubTotal;
    }
}
