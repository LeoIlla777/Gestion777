namespace Lfc.Pagos.Planes
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
            this.EntradaComision = new Lui.Forms.TextBox();
            this.EntradaInteres = new Lui.Forms.TextBox();
            this.label1 = new Lui.Forms.Label();
            this.Label4 = new Lui.Forms.Label();
            this.EntradaTarjeta = new Lcc.Entrada.CodigoDetalle();
            this.label10 = new Lui.Forms.Label();
            this.EntradaNombre = new Lui.Forms.TextBox();
            this.Label5 = new Lui.Forms.Label();
            this.EntradaCuotas = new Lui.Forms.TextBox();
            this.label2 = new Lui.Forms.Label();
            this.SuspendLayout();
            // 
            // EntradaComision
            // 
            this.EntradaComision.DataType = Lui.Forms.DataTypes.Float;
            this.EntradaComision.Location = new System.Drawing.Point(154, 133);
            this.EntradaComision.Name = "EntradaComision";
            this.EntradaComision.Size = new System.Drawing.Size(108, 24);
            this.EntradaComision.TabIndex = 4;
            this.EntradaComision.Text = "0.0000";
            // 
            // EntradaInteres
            // 
            this.EntradaInteres.DataType = Lui.Forms.DataTypes.Float;
            this.EntradaInteres.Location = new System.Drawing.Point(154, 103);
            this.EntradaInteres.Name = "EntradaInteres";
            this.EntradaInteres.Size = new System.Drawing.Size(108, 24);
            this.EntradaInteres.TabIndex = 3;
            this.EntradaInteres.Text = "0.0000";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "Comisión";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(13, 103);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(133, 24);
            this.Label4.TabIndex = 28;
            this.Label4.Text = "Interes";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EntradaTarjeta
            // 
            this.EntradaTarjeta.AutoTab = true;
            this.EntradaTarjeta.CanCreate = true;
            this.EntradaTarjeta.FieldName = "";
            this.EntradaTarjeta.Filter = "tipo=4";
            this.EntradaTarjeta.Location = new System.Drawing.Point(154, 42);
            this.EntradaTarjeta.MaxLength = 200;
            this.EntradaTarjeta.Name = "EntradaTarjeta";
            this.EntradaTarjeta.NombreTipo = "Lbl.Pagos.FormaDePago";
            this.EntradaTarjeta.PlaceholderText = "Sin especificar";
            this.EntradaTarjeta.Required = true;
            this.EntradaTarjeta.Size = new System.Drawing.Size(312, 24);
            this.EntradaTarjeta.TabIndex = 1;
            this.EntradaTarjeta.Text = "0";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(10, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 24);
            this.label10.TabIndex = 34;
            this.label10.Text = "Tarjeta";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EntradaNombre
            // 
            this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
            this.EntradaNombre.Location = new System.Drawing.Point(154, 12);
            this.EntradaNombre.MaxLength = 200;
            this.EntradaNombre.Name = "EntradaNombre";
            this.EntradaNombre.Size = new System.Drawing.Size(312, 24);
            this.EntradaNombre.TabIndex = 0;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(10, 12);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(136, 24);
            this.Label5.TabIndex = 32;
            this.Label5.Text = "Nombre";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EntradaCuotas
            // 
            this.EntradaCuotas.DataType = Lui.Forms.DataTypes.Integer;
            this.EntradaCuotas.Location = new System.Drawing.Point(154, 72);
            this.EntradaCuotas.Name = "EntradaCuotas";
            this.EntradaCuotas.Size = new System.Drawing.Size(108, 24);
            this.EntradaCuotas.TabIndex = 2;
            this.EntradaCuotas.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 36;
            this.label2.Text = "Cuotas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Editar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EntradaCuotas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EntradaTarjeta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.EntradaNombre);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.EntradaComision);
            this.Controls.Add(this.EntradaInteres);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label4);
            this.Name = "Editar";
            this.Size = new System.Drawing.Size(593, 190);
            this.Text = "Editar";
            this.ResumeLayout(false);

        }

        #endregion

        internal Lui.Forms.TextBox EntradaComision;
        internal Lui.Forms.TextBox EntradaInteres;
        internal Lui.Forms.Label label1;
        internal Lui.Forms.Label Label4;
        private Lcc.Entrada.CodigoDetalle EntradaTarjeta;
        internal Lui.Forms.Label label10;
        internal Lui.Forms.TextBox EntradaNombre;
        internal Lui.Forms.Label Label5;
        internal Lui.Forms.TextBox EntradaCuotas;
        internal Lui.Forms.Label label2;
    }
}