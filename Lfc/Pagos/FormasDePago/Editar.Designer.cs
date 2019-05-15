namespace Lfc.Pagos.FormasDePago
{
    partial class Editar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EntradaNombre = new Lui.Forms.TextBox();
            this.Label5 = new Lui.Forms.Label();
            this.EntradaCaja = new Lcc.Entrada.CodigoDetalle();
            this.label10 = new Lui.Forms.Label();
            this.EntradaTipo = new Lui.Forms.ComboBox();
            this.label8 = new Lui.Forms.Label();
            this.Label4 = new Lui.Forms.Label();
            this.label1 = new Lui.Forms.Label();
            this.EntradaPagos = new Lui.Forms.ComboBox();
            this.Label7 = new Lui.Forms.Label();
            this.EntradaCobros = new Lui.Forms.ComboBox();
            this.label2 = new Lui.Forms.Label();
            this.EntradaRecargo = new Lui.Forms.TextBox();
            this.EntradaRetenciones = new Lui.Forms.TextBox();
            this.EntradaConceptoIngreso = new Lcc.Entrada.CodigoDetalle();
            this.label35 = new Lui.Forms.Label();
            this.EntradaConceptoEgreso = new Lcc.Entrada.CodigoDetalle();
            this.label3 = new Lui.Forms.Label();
            this.SuspendLayout();
            // 
            // EntradaNombre
            // 
            this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaNombre.Location = new System.Drawing.Point(146, 3);
            this.EntradaNombre.MaxLength = 200;
            this.EntradaNombre.Name = "EntradaNombre";
            this.EntradaNombre.Size = new System.Drawing.Size(312, 24);
            this.EntradaNombre.TabIndex = 0;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(2, 3);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(136, 24);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "Nombre";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EntradaCaja
            // 
            this.EntradaCaja.AutoTab = true;
            this.EntradaCaja.CanCreate = true;
            this.EntradaCaja.Location = new System.Drawing.Point(146, 33);
            this.EntradaCaja.MaxLength = 200;
            this.EntradaCaja.Name = "EntradaCaja";
            this.EntradaCaja.NombreTipo = "Lbl.Cajas.Caja";
            this.EntradaCaja.PlaceholderText = "Sin especificar";
            this.EntradaCaja.Required = true;
            this.EntradaCaja.Size = new System.Drawing.Size(312, 24);
            this.EntradaCaja.TabIndex = 1;
            this.EntradaCaja.Text = "0";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(2, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 24);
            this.label10.TabIndex = 14;
            this.label10.Text = "Caja";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EntradaTipo
            // 
            this.EntradaTipo.AlwaysExpanded = true;
            this.EntradaTipo.AutoSize = true;
            this.EntradaTipo.Location = new System.Drawing.Point(146, 63);
            this.EntradaTipo.Name = "EntradaTipo";
            this.EntradaTipo.SetData = new string[] {
        "Efectivo|1",
        "Cheque (propio)|2",
        "Cuenta corriente|3",
        "Tarjeta|4",
        "Caja|6",
        "Otro|7",
        "Cheque (terceros)|8"};
            this.EntradaTipo.Size = new System.Drawing.Size(210, 91);
            this.EntradaTipo.TabIndex = 2;
            this.EntradaTipo.TextKey = "1";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(2, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "Tipo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(5, 160);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(133, 24);
            this.Label4.TabIndex = 18;
            this.Label4.Text = "Desc./Recargo";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Retenciones";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EntradaPagos
            // 
            this.EntradaPagos.AlwaysExpanded = true;
            this.EntradaPagos.AutoSize = true;
            this.EntradaPagos.Location = new System.Drawing.Point(146, 220);
            this.EntradaPagos.Name = "EntradaPagos";
            this.EntradaPagos.SetData = new string[] {
        "Sí|1",
        "No|0"};
            this.EntradaPagos.Size = new System.Drawing.Size(108, 40);
            this.EntradaPagos.TabIndex = 5;
            this.EntradaPagos.TextKey = "0";
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(6, 220);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(140, 24);
            this.Label7.TabIndex = 22;
            this.Label7.Text = "Puede Hace Pagos";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EntradaCobros
            // 
            this.EntradaCobros.AlwaysExpanded = true;
            this.EntradaCobros.AutoSize = true;
            this.EntradaCobros.Location = new System.Drawing.Point(146, 266);
            this.EntradaCobros.Name = "EntradaCobros";
            this.EntradaCobros.SetData = new string[] {
        "Sí|1",
        "No|0"};
            this.EntradaCobros.Size = new System.Drawing.Size(108, 40);
            this.EntradaCobros.TabIndex = 6;
            this.EntradaCobros.TextKey = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Puede Hacer Cobros";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EntradaRecargo
            // 
            this.EntradaRecargo.DataType = Lui.Forms.DataTypes.Float;
            this.EntradaRecargo.Location = new System.Drawing.Point(146, 160);
            this.EntradaRecargo.Name = "EntradaRecargo";
            this.EntradaRecargo.Size = new System.Drawing.Size(108, 24);
            this.EntradaRecargo.TabIndex = 3;
            this.EntradaRecargo.Text = "0.0000";
            // 
            // EntradaRetenciones
            // 
            this.EntradaRetenciones.DataType = Lui.Forms.DataTypes.Float;
            this.EntradaRetenciones.Location = new System.Drawing.Point(146, 190);
            this.EntradaRetenciones.Name = "EntradaRetenciones";
            this.EntradaRetenciones.Size = new System.Drawing.Size(108, 24);
            this.EntradaRetenciones.TabIndex = 4;
            this.EntradaRetenciones.Text = "0.0000";
            // 
            // EntradaConceptoIngreso
            // 
            this.EntradaConceptoIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaConceptoIngreso.AutoTab = true;
            this.EntradaConceptoIngreso.CanCreate = true;
            this.EntradaConceptoIngreso.Location = new System.Drawing.Point(146, 312);
            this.EntradaConceptoIngreso.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaConceptoIngreso.MaxLength = 200;
            this.EntradaConceptoIngreso.Name = "EntradaConceptoIngreso";
            this.EntradaConceptoIngreso.NombreTipo = "Lbl.Cajas.Concepto";
            this.EntradaConceptoIngreso.PlaceholderText = "Sin especificar";
            this.EntradaConceptoIngreso.Required = true;
            this.EntradaConceptoIngreso.Size = new System.Drawing.Size(312, 24);
            this.EntradaConceptoIngreso.TabIndex = 25;
            this.EntradaConceptoIngreso.Text = "0";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(5, 312);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(133, 24);
            this.label35.TabIndex = 26;
            this.label35.Text = "Concepto Ingreso";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntradaConceptoEgreso
            // 
            this.EntradaConceptoEgreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntradaConceptoEgreso.AutoTab = true;
            this.EntradaConceptoEgreso.CanCreate = true;
            this.EntradaConceptoEgreso.Location = new System.Drawing.Point(146, 342);
            this.EntradaConceptoEgreso.MaximumSize = new System.Drawing.Size(480, 32);
            this.EntradaConceptoEgreso.MaxLength = 200;
            this.EntradaConceptoEgreso.Name = "EntradaConceptoEgreso";
            this.EntradaConceptoEgreso.NombreTipo = "Lbl.Cajas.Concepto";
            this.EntradaConceptoEgreso.PlaceholderText = "Sin especificar";
            this.EntradaConceptoEgreso.Required = true;
            this.EntradaConceptoEgreso.Size = new System.Drawing.Size(312, 24);
            this.EntradaConceptoEgreso.TabIndex = 27;
            this.EntradaConceptoEgreso.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "Concepto Egreso";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Editar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EntradaConceptoEgreso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EntradaConceptoIngreso);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.EntradaRetenciones);
            this.Controls.Add(this.EntradaRecargo);
            this.Controls.Add(this.EntradaCobros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EntradaPagos);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.EntradaTipo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.EntradaCaja);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.EntradaNombre);
            this.Controls.Add(this.Label5);
            this.Name = "Editar";
            this.Size = new System.Drawing.Size(555, 395);
            this.Text = "Editar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        internal Lui.Forms.TextBox EntradaNombre;
        internal Lui.Forms.Label Label5;
        private Lcc.Entrada.CodigoDetalle EntradaCaja;
        internal Lui.Forms.Label label10;
        internal Lui.Forms.ComboBox EntradaTipo;
        internal Lui.Forms.Label label8;
        internal Lui.Forms.Label Label4;
        internal Lui.Forms.Label label1;
        internal Lui.Forms.ComboBox EntradaPagos;
        internal Lui.Forms.Label Label7;
        internal Lui.Forms.ComboBox EntradaCobros;
        internal Lui.Forms.Label label2;
        internal Lui.Forms.TextBox EntradaRecargo;
        internal Lui.Forms.TextBox EntradaRetenciones;
        internal Lcc.Entrada.CodigoDetalle EntradaConceptoIngreso;
        internal Lui.Forms.Label label35;
        internal Lcc.Entrada.CodigoDetalle EntradaConceptoEgreso;
        internal Lui.Forms.Label label3;
    }
}