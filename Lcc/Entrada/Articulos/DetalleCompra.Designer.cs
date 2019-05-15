using Lui.Forms;

namespace Lcc.Entrada.Articulos
{
    public partial class DetalleCompra
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.LabelSerials = new Lui.Forms.Label();
            this.LabelSerialsCruz = new Lui.Forms.Label();
            this.EntradaDescuento = new Lui.Forms.TextBox();
            this.EntradaImporte = new Lui.Forms.TextBox();
            this.EntradaUnitario = new Lui.Forms.TextBox();
            this.EntradaNoGravado = new Lui.Forms.TextBox();
            this.EntradaCantidad = new Lui.Forms.TextBox();
            this.EntradaArticulo = new Lcc.Entrada.CodigoDetalle();
            this.EntradaIva = new Lui.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelSerials
            // 
            this.LabelSerials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelSerials.AutoEllipsis = true;
            this.LabelSerials.Location = new System.Drawing.Point(16, 26);
            this.LabelSerials.Name = "LabelSerials";
            this.LabelSerials.Size = new System.Drawing.Size(1041, 16);
            this.LabelSerials.TabIndex = 6;
            this.LabelSerials.Text = "Seguimiento:";
            this.LabelSerials.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
            this.LabelSerials.UseMnemonic = false;
            this.LabelSerials.Visible = false;
            this.LabelSerials.VisibleChanged += new System.EventHandler(this.RecalcularAltura);
            // 
            // LabelSerialsCruz
            // 
            this.LabelSerialsCruz.Location = new System.Drawing.Point(4, 18);
            this.LabelSerialsCruz.Name = "LabelSerialsCruz";
            this.LabelSerialsCruz.Size = new System.Drawing.Size(14, 20);
            this.LabelSerialsCruz.TabIndex = 7;
            this.LabelSerialsCruz.Text = "L";
            this.LabelSerialsCruz.Visible = false;
            // 
            // EntradaDescuento
            // 
            this.EntradaDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaDescuento.DataType = Lui.Forms.DataTypes.Float;
            this.EntradaDescuento.DecimalPlaces = 2;
            this.EntradaDescuento.Location = new System.Drawing.Point(881, 0);
            this.EntradaDescuento.Name = "EntradaDescuento";
            this.EntradaDescuento.PlaceholderText = "Escriba el descuento para este ítem";
            this.EntradaDescuento.Size = new System.Drawing.Size(75, 24);
            this.EntradaDescuento.Sufijo = "%";
            this.EntradaDescuento.TabIndex = 4;
            this.EntradaDescuento.TabStop = false;
            this.EntradaDescuento.Text = "0.00";
            this.EntradaDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaDescuento_KeyDown);
            this.EntradaDescuento.TextChanged += new System.EventHandler(this.EntradaUnitarioIvaDescuentoCantidad_TextChanged);
            // 
            // EntradaImporte
            // 
            this.EntradaImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaImporte.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaImporte.Location = new System.Drawing.Point(957, 0);
            this.EntradaImporte.MaxLength = 14;
            this.EntradaImporte.Name = "EntradaImporte";
            this.EntradaImporte.Prefijo = "$";
            this.EntradaImporte.ReadOnly = true;
            this.EntradaImporte.Size = new System.Drawing.Size(100, 24);
            this.EntradaImporte.TabIndex = 5;
            this.EntradaImporte.TabStop = false;
            this.EntradaImporte.Text = "0.00";
            // 
            // EntradaUnitario
            // 
            this.EntradaUnitario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaUnitario.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaUnitario.Location = new System.Drawing.Point(503, 0);
            this.EntradaUnitario.MaxLength = 14;
            this.EntradaUnitario.Name = "EntradaUnitario";
            this.EntradaUnitario.PlaceholderText = "Escriba el precio unitario.";
            this.EntradaUnitario.Prefijo = "$";
            this.EntradaUnitario.Size = new System.Drawing.Size(95, 24);
            this.EntradaUnitario.TabIndex = 1;
            this.EntradaUnitario.TabStop = false;
            this.EntradaUnitario.Text = "0.00";
            this.EntradaUnitario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaUnitario_KeyDown);
            this.EntradaUnitario.TextChanged += new System.EventHandler(this.EntradaUnitarioIvaDescuentoCantidad_TextChanged);
            // 
            // EntradaNoGravado
            // 
            this.EntradaNoGravado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaNoGravado.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaNoGravado.Location = new System.Drawing.Point(600, 0);
            this.EntradaNoGravado.MaxLength = 14;
            this.EntradaNoGravado.Name = "EntradaNoGravado";
            this.EntradaNoGravado.PlaceholderText = "Escriba el precio unitario no gravado.";
            this.EntradaNoGravado.Prefijo = "$";
            this.EntradaNoGravado.Size = new System.Drawing.Size(95, 24);
            this.EntradaNoGravado.TabIndex = 2;
            this.EntradaNoGravado.TabStop = false;
            this.EntradaNoGravado.Text = "0.00";
            this.EntradaNoGravado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaNoGravado_KeyDown);
            this.EntradaNoGravado.TextChanged += new System.EventHandler(this.EntradaUnitarioIvaDescuentoCantidad_TextChanged);
            // 
            // EntradaCantidad
            // 
            this.EntradaCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaCantidad.DataType = Lui.Forms.DataTypes.Stock;
            this.EntradaCantidad.Location = new System.Drawing.Point(793, 0);
            this.EntradaCantidad.MaxLength = 10;
            this.EntradaCantidad.Name = "EntradaCantidad";
            this.EntradaCantidad.PlaceholderText = "Escriba la cantidad.";
            this.EntradaCantidad.Size = new System.Drawing.Size(87, 24);
            this.EntradaCantidad.TabIndex = 3;
            this.EntradaCantidad.Text = "0";
            this.EntradaCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EntradaCantidad_KeyPress);
            this.EntradaCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaCantidad_KeyDown);
            this.EntradaCantidad.TextChanged += new System.EventHandler(this.EntradaUnitarioIvaDescuentoCantidad_TextChanged);
            this.EntradaCantidad.Click += new System.EventHandler(this.EntradaCantidad_Click);
            // 
            // EntradaArticulo
            // 
            this.EntradaArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaArticulo.AutoTab = true;
            this.EntradaArticulo.CanCreate = true;
            this.EntradaArticulo.ExtraDetailFields = "pvp,codigo1,codigo2,stock_actual";
            this.EntradaArticulo.Filter = "estado=1";
            this.EntradaArticulo.FreeTextCode = "*";
            this.EntradaArticulo.Location = new System.Drawing.Point(0, 0);
            this.EntradaArticulo.MaxLength = 200;
            this.EntradaArticulo.Name = "EntradaArticulo";
            this.EntradaArticulo.NameExtraDetailFields = "Pvp, Código 1, Código 2, Stock";
            this.EntradaArticulo.NombreTipo = "Lbl.Articulos.Articulo";
            this.EntradaArticulo.PlaceholderText = "";
            this.EntradaArticulo.Required = true;
            this.EntradaArticulo.Size = new System.Drawing.Size(497, 24);
            this.EntradaArticulo.TabIndex = 0;
            this.EntradaArticulo.Text = "0";
            this.EntradaArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaArticulo_KeyDown);
            this.EntradaArticulo.TextChanged += new System.EventHandler(this.EntradaArticulo_TextChanged);
            // 
            // EntradaIva
            // 
            this.EntradaIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaIva.DataType = Lui.Forms.DataTypes.Currency;
            this.EntradaIva.Location = new System.Drawing.Point(697, 0);
            this.EntradaIva.MaxLength = 14;
            this.EntradaIva.Name = "EntradaIva";
            this.EntradaIva.PlaceholderText = "Importe de IVA";
            this.EntradaIva.Prefijo = "$";
            this.EntradaIva.ReadOnly = true;
            this.EntradaIva.Size = new System.Drawing.Size(95, 24);
            this.EntradaIva.TabIndex = 8;
            this.EntradaIva.TabStop = false;
            this.EntradaIva.Text = "0.00";
            this.EntradaIva.TextChanged += new System.EventHandler(this.EntradaUnitarioIvaDescuentoCantidad_TextChanged);
            // 
            // DetalleCompra
            // 
            this.Controls.Add(this.EntradaIva);
            this.Controls.Add(this.EntradaDescuento);
            this.Controls.Add(this.EntradaImporte);
            this.Controls.Add(this.EntradaUnitario);
            this.Controls.Add(this.EntradaNoGravado);
            this.Controls.Add(this.EntradaCantidad);
            this.Controls.Add(this.EntradaArticulo);
            this.Controls.Add(this.LabelSerialsCruz);
            this.Controls.Add(this.LabelSerials);
            this.Name = "DetalleCompra";
            this.Size = new System.Drawing.Size(1057, 44);
            this.ResumeLayout(false);

        }
        #endregion

        internal CodigoDetalle EntradaArticulo;
        internal TextBox EntradaCantidad;
        internal TextBox EntradaUnitario;
        internal TextBox EntradaNoGravado;
        internal TextBox EntradaImporte;
        internal TextBox EntradaDescuento;
        internal Lui.Forms.Label LabelSerials;
        internal Lui.Forms.Label LabelSerialsCruz;
        internal TextBox EntradaIva;
    }
}
