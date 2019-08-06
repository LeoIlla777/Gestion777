namespace Lfc.Comprobantes.Facturas
{
    public partial class Editar
    {
        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.Label2 = new Lui.Forms.Label();
            this.lblImporte = new Lui.Forms.Label();
            this.EntradaFormaPago = new Lcc.Entrada.CodigoDetalle();
            this.Label10 = new Lui.Forms.Label();
            this.EntradaTipo = new Lui.Forms.ComboBox();
            this.Label11 = new Lui.Forms.Label();
            this.EntradaRemito = new Lcc.Entrada.CodigoDetalle();
            this.PanelFormaPago = new Lui.Forms.Panel();
            this.ListaPagos = new Lui.Forms.ListView();
            this.ValoresTipoPagoId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValoresTipoPago = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValoresImporte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValoresObs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PanelComprobanteOriginal = new Lui.Forms.Panel();
            this.EtiquetaComprobanteOriginal = new Lui.Forms.Label();
            this.EntradaComprobanteOriginal = new Lcc.Entrada.CodigoDetalle();
            this.btnAgregarPago = new Lui.Forms.Button();
            this.btnQuitarPago = new Lui.Forms.Button();
            this.EtiquetaValoresImporte = new Lui.Forms.Label();
            this.panelMultiPago = new Lui.Forms.Panel();
            this.EntradaFormaPagoTicket = new Lui.Forms.ComboBox();
            this.btnCerrarPanel = new Lui.Forms.Button();
            this.label12 = new Lui.Forms.Label();
            this.EntradaFecha = new Lui.Forms.TextBox();
            this.lblFecha = new Lui.Forms.Label();
            this.PanelFormaPago.SuspendLayout();
            this.PanelComprobanteOriginal.SuspendLayout();
            this.panelMultiPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(108, 24);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Forma de pago";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblImporte
            // 
            this.lblImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImporte.Location = new System.Drawing.Point(438, 32);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(66, 24);
            this.lblImporte.TabIndex = 0;
            this.lblImporte.Text = "0.00";
            this.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblImporte.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Info;
            this.lblImporte.Visible = false;
            this.lblImporte.Click += new System.EventHandler(this.lblImporte_Click);
            // 
            // EntradaFormaPago
            // 
            this.EntradaFormaPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaFormaPago.AutoTab = true;
            this.EntradaFormaPago.CanCreate = true;
            this.EntradaFormaPago.Filter = "cobros=1 AND estado=1";
            this.EntradaFormaPago.Location = new System.Drawing.Point(112, 0);
            this.EntradaFormaPago.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaFormaPago.MaxLength = 200;
            this.EntradaFormaPago.Name = "EntradaFormaPago";
            this.EntradaFormaPago.NombreTipo = "Lbl.Pagos.FormaDePago";
            this.EntradaFormaPago.Required = true;
            this.EntradaFormaPago.Size = new System.Drawing.Size(126, 24);
            this.EntradaFormaPago.TabIndex = 1;
            this.EntradaFormaPago.Text = "0";
            this.EntradaFormaPago.TextChanged += new System.EventHandler(this.EntradaFormaPago_Leave);
            this.EntradaFormaPago.Leave += new System.EventHandler(this.EntradaFormaPago_Leave);
            // 
            // Label10
            // 
            this.Label10.Location = new System.Drawing.Point(0, 32);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(72, 24);
            this.Label10.TabIndex = 10;
            this.Label10.Text = "Tipo";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaTipo
            // 
            this.EntradaTipo.AlwaysExpanded = false;
            this.EntradaTipo.AutoSize = true;
            this.EntradaTipo.Location = new System.Drawing.Point(72, 32);
            this.EntradaTipo.Name = "EntradaTipo";
            this.EntradaTipo.SetData = new string[] {
        "Factura A|FA"};
            this.EntradaTipo.Size = new System.Drawing.Size(116, 25);
            this.EntradaTipo.TabIndex = 7;
            this.EntradaTipo.TextKey = "FA";
            this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaTipo_TextChanged);
            this.EntradaTipo.Leave += new System.EventHandler(this.EntradaTipo_Leave);
            // 
            // Label11
            // 
            this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label11.Location = new System.Drawing.Point(506, 32);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(56, 24);
            this.Label11.TabIndex = 14;
            this.Label11.Text = "Remito";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaRemito
            // 
            this.EntradaRemito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaRemito.AutoTab = true;
            this.EntradaRemito.CanCreate = false;
            this.EntradaRemito.Filter = "anulada=0 and tipo_fac=\'R\'";
            this.EntradaRemito.Location = new System.Drawing.Point(562, 32);
            this.EntradaRemito.MaxLength = 200;
            this.EntradaRemito.Name = "EntradaRemito";
            this.EntradaRemito.NombreTipo = "Lbl.Comprobantes.Remito";
            this.EntradaRemito.PlaceholderText = "Ninguno";
            this.EntradaRemito.Required = true;
            this.EntradaRemito.Size = new System.Drawing.Size(222, 24);
            this.EntradaRemito.TabIndex = 15;
            this.EntradaRemito.Text = "0";
            this.EntradaRemito.TextChanged += new System.EventHandler(this.EntradaRemito_TextChanged);
            // 
            // PanelFormaPago
            // 
            this.PanelFormaPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelFormaPago.Controls.Add(this.EntradaFormaPago);
            this.PanelFormaPago.Controls.Add(this.Label2);
            this.PanelFormaPago.Location = new System.Drawing.Point(200, 32);
            this.PanelFormaPago.Name = "PanelFormaPago";
            this.PanelFormaPago.Size = new System.Drawing.Size(232, 24);
            this.PanelFormaPago.TabIndex = 12;
            this.PanelFormaPago.VisibleChanged += new System.EventHandler(this.PanelFormaPago_VisibleChanged);
            // 
            // ListaPagos
            // 
            this.ListaPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaPagos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ValoresTipoPagoId,
            this.ValoresTipoPago,
            this.ValoresImporte,
            this.ValoresObs});
            this.ListaPagos.FieldName = null;
            this.ListaPagos.FullRowSelect = true;
            this.ListaPagos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListaPagos.Location = new System.Drawing.Point(3, 33);
            this.ListaPagos.MultiSelect = false;
            this.ListaPagos.Name = "ListaPagos";
            this.ListaPagos.ReadOnly = false;
            this.ListaPagos.Size = new System.Drawing.Size(232, 130);
            this.ListaPagos.TabIndex = 56;
            this.ListaPagos.UseCompatibleStateImageBehavior = false;
            this.ListaPagos.View = System.Windows.Forms.View.Details;
            // 
            // ValoresTipoPagoId
            // 
            this.ValoresTipoPagoId.Text = "TipoPago";
            this.ValoresTipoPagoId.Width = 0;
            // 
            // ValoresTipoPago
            // 
            this.ValoresTipoPago.Text = "Tipo";
            this.ValoresTipoPago.Width = 160;
            // 
            // ValoresImporte
            // 
            this.ValoresImporte.Text = "Importe";
            this.ValoresImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ValoresImporte.Width = 96;
            // 
            // ValoresObs
            // 
            this.ValoresObs.Text = "Obs";
            this.ValoresObs.Width = 500;
            // 
            // PanelComprobanteOriginal
            // 
            this.PanelComprobanteOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelComprobanteOriginal.Controls.Add(this.EtiquetaComprobanteOriginal);
            this.PanelComprobanteOriginal.Controls.Add(this.EntradaComprobanteOriginal);
            this.PanelComprobanteOriginal.Location = new System.Drawing.Point(200, 32);
            this.PanelComprobanteOriginal.Name = "PanelComprobanteOriginal";
            this.PanelComprobanteOriginal.Size = new System.Drawing.Size(232, 24);
            this.PanelComprobanteOriginal.TabIndex = 12;
            this.PanelComprobanteOriginal.Visible = false;
            // 
            // EtiquetaComprobanteOriginal
            // 
            this.EtiquetaComprobanteOriginal.Location = new System.Drawing.Point(3, 2);
            this.EtiquetaComprobanteOriginal.Name = "EtiquetaComprobanteOriginal";
            this.EtiquetaComprobanteOriginal.Size = new System.Drawing.Size(108, 24);
            this.EtiquetaComprobanteOriginal.TabIndex = 0;
            this.EtiquetaComprobanteOriginal.Text = "Factura";
            this.EtiquetaComprobanteOriginal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaComprobanteOriginal
            // 
            this.EntradaComprobanteOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaComprobanteOriginal.AutoTab = true;
            this.EntradaComprobanteOriginal.CanCreate = true;
            this.EntradaComprobanteOriginal.ExtraDetailFields = "tipo_fac,total,fecha";
            this.EntradaComprobanteOriginal.Filter = "tipo_fac IN (\'FA\', \'FB\', \'FC\', \'FE\', \'FM\') AND numero>0";
            this.EntradaComprobanteOriginal.Location = new System.Drawing.Point(109, 0);
            this.EntradaComprobanteOriginal.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaComprobanteOriginal.MaxLength = 200;
            this.EntradaComprobanteOriginal.Name = "EntradaComprobanteOriginal";
            this.EntradaComprobanteOriginal.NombreTipo = "Lbl.Comprobantes.Factura";
            this.EntradaComprobanteOriginal.Required = true;
            this.EntradaComprobanteOriginal.Size = new System.Drawing.Size(120, 24);
            this.EntradaComprobanteOriginal.TabIndex = 1;
            this.EntradaComprobanteOriginal.Text = "0";
            // 
            // btnAgregarPago
            // 
            this.btnAgregarPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarPago.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAgregarPago.Image = null;
            this.btnAgregarPago.ImagePos = Lui.Forms.ImagePositions.Top;
            this.btnAgregarPago.Location = new System.Drawing.Point(12, 174);
            this.btnAgregarPago.Name = "btnAgregarPago";
            this.btnAgregarPago.Size = new System.Drawing.Size(64, 26);
            this.btnAgregarPago.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.btnAgregarPago.Subtext = "Tecla";
            this.btnAgregarPago.TabIndex = 57;
            this.btnAgregarPago.Text = "Agregar";
            this.btnAgregarPago.Click += new System.EventHandler(this.btnAgregarPago_Click);
            // 
            // btnQuitarPago
            // 
            this.btnQuitarPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuitarPago.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuitarPago.Image = null;
            this.btnQuitarPago.ImagePos = Lui.Forms.ImagePositions.Top;
            this.btnQuitarPago.Location = new System.Drawing.Point(82, 174);
            this.btnQuitarPago.Name = "btnQuitarPago";
            this.btnQuitarPago.Size = new System.Drawing.Size(64, 26);
            this.btnQuitarPago.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.btnQuitarPago.Subtext = "Tecla";
            this.btnQuitarPago.TabIndex = 58;
            this.btnQuitarPago.Text = "Quitar";
            this.btnQuitarPago.Click += new System.EventHandler(this.btnQuitarPago_Click);
            // 
            // EtiquetaValoresImporte
            // 
            this.EtiquetaValoresImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EtiquetaValoresImporte.Location = new System.Drawing.Point(151, 165);
            this.EtiquetaValoresImporte.Name = "EtiquetaValoresImporte";
            this.EtiquetaValoresImporte.Size = new System.Drawing.Size(84, 35);
            this.EtiquetaValoresImporte.TabIndex = 59;
            this.EtiquetaValoresImporte.Text = "$ 0.00";
            this.EtiquetaValoresImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EtiquetaValoresImporte.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
            // 
            // panelMultiPago
            // 
            this.panelMultiPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMultiPago.BackColor = System.Drawing.Color.Wheat;
            this.panelMultiPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMultiPago.Controls.Add(this.btnCerrarPanel);
            this.panelMultiPago.Controls.Add(this.label12);
            this.panelMultiPago.Controls.Add(this.btnQuitarPago);
            this.panelMultiPago.Controls.Add(this.btnAgregarPago);
            this.panelMultiPago.Controls.Add(this.EtiquetaValoresImporte);
            this.panelMultiPago.Controls.Add(this.ListaPagos);
            this.panelMultiPago.Location = new System.Drawing.Point(194, 32);
            this.panelMultiPago.Name = "panelMultiPago";
            this.panelMultiPago.Size = new System.Drawing.Size(240, 211);
            this.panelMultiPago.TabIndex = 59;
            this.panelMultiPago.Visible = false;
            // 
            // EntradaFormaPagoTicket
            // 
            this.EntradaFormaPagoTicket.AlwaysExpanded = false;
            this.EntradaFormaPagoTicket.AutoSize = true;
            this.EntradaFormaPagoTicket.Location = new System.Drawing.Point(196, 32);
            this.EntradaFormaPagoTicket.Name = "EntradaFormaPagoTicket";
            this.EntradaFormaPagoTicket.SetData = new string[] {
        "No controla pago|0",
        "Efectivo|1",
        "Cuenta corriente|3"};
            this.EntradaFormaPagoTicket.Size = new System.Drawing.Size(176, 25);
            this.EntradaFormaPagoTicket.TabIndex = 1;
            this.EntradaFormaPagoTicket.TextKey = "0";
            this.EntradaFormaPagoTicket.Visible = false;
            // 
            // btnCerrarPanel
            // 
            this.btnCerrarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnCerrarPanel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCerrarPanel.Image = null;
            this.btnCerrarPanel.ImagePos = Lui.Forms.ImagePositions.Top;
            this.btnCerrarPanel.Location = new System.Drawing.Point(201, 2);
            this.btnCerrarPanel.Name = "btnCerrarPanel";
            this.btnCerrarPanel.Size = new System.Drawing.Size(32, 26);
            this.btnCerrarPanel.SubLabelPos = Lui.Forms.SubLabelPositions.None;
            this.btnCerrarPanel.Subtext = "";
            this.btnCerrarPanel.TabIndex = 61;
            this.btnCerrarPanel.Text = "X";
            this.btnCerrarPanel.Click += new System.EventHandler(this.btnCerrarPanel_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label12.Location = new System.Drawing.Point(3, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 25);
            this.label12.TabIndex = 60;
            this.label12.Text = "Seleccione Forma de Pago";
            this.label12.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Info;
            // 
            // EntradaFecha
            // 
            this.EntradaFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaFecha.DataType = Lui.Forms.DataTypes.Date;
            this.EntradaFecha.Location = new System.Drawing.Point(837, 35);
            this.EntradaFecha.Name = "EntradaFecha";
            this.EntradaFecha.Size = new System.Drawing.Size(120, 24);
            this.EntradaFecha.TabIndex = 60;
            this.EntradaFecha.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(790, 36);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 20);
            this.lblFecha.TabIndex = 61;
            this.lblFecha.Text = "Fecha";
            this.lblFecha.Visible = false;
            // 
            // Editar
            // 
            this.Controls.Add(this.EntradaFormaPagoTicket);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.EntradaFecha);
            this.Controls.Add(this.panelMultiPago);
            this.Controls.Add(this.EntradaTipo);
            this.Controls.Add(this.EntradaRemito);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.PanelFormaPago);
            this.Controls.Add(this.lblImporte);
            this.MinimumSize = new System.Drawing.Size(600, 320);
            this.Name = "Editar";
            this.Controls.SetChildIndex(this.lblImporte, 0);
            this.Controls.SetChildIndex(this.PanelFormaPago, 0);
            this.Controls.SetChildIndex(this.Label10, 0);
            this.Controls.SetChildIndex(this.Label11, 0);
            this.Controls.SetChildIndex(this.EntradaRemito, 0);
            this.Controls.SetChildIndex(this.EntradaTipo, 0);
            this.Controls.SetChildIndex(this.panelMultiPago, 0);
            this.Controls.SetChildIndex(this.EntradaFecha, 0);
            this.Controls.SetChildIndex(this.lblFecha, 0);
            this.Controls.SetChildIndex(this.EntradaFormaPagoTicket, 0);
            this.PanelFormaPago.ResumeLayout(false);
            this.PanelComprobanteOriginal.ResumeLayout(false);
            this.panelMultiPago.ResumeLayout(false);
            this.panelMultiPago.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Lui.Forms.Label Label2;
        internal Lui.Forms.Label lblImporte;
        internal Lui.Forms.Label Label10;
        public Lui.Forms.ComboBox EntradaTipo;
        internal Lui.Forms.Label Label11;
        public Lcc.Entrada.CodigoDetalle EntradaFormaPago;
        public Lcc.Entrada.CodigoDetalle EntradaRemito;
        internal Lui.Forms.Panel PanelFormaPago;
        internal Lui.Forms.Panel PanelComprobanteOriginal;
        internal Lui.Forms.Label EtiquetaComprobanteOriginal;
        public Lcc.Entrada.CodigoDetalle EntradaComprobanteOriginal;
        private Lui.Forms.ListView ListaPagos;
        private Lui.Forms.Button btnAgregarPago;
        private System.Windows.Forms.ColumnHeader ValoresTipoPagoId;
        private System.Windows.Forms.ColumnHeader ValoresTipoPago;
        private System.Windows.Forms.ColumnHeader ValoresImporte;
        private System.Windows.Forms.ColumnHeader ValoresObs;
        private Lui.Forms.Button btnQuitarPago;
        private Lui.Forms.Label EtiquetaValoresImporte;
        private Lui.Forms.Panel panelMultiPago;
        private Lui.Forms.Button btnCerrarPanel;
        private Lui.Forms.Label label12;
        private Lui.Forms.TextBox EntradaFecha;
        private Lui.Forms.Label lblFecha;
        internal Lui.Forms.ComboBox EntradaFormaPagoTicket;
    }
}
