using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Articulos
{
    public partial class CambioMasivoPrecios : Lui.Forms.ChildDialogForm
    {
        public CambioMasivoPrecios()
        {
            if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Articulos.Articulo), Lbl.Sys.Permisos.Operaciones.EditarAvanzado) == false)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
                return;
            }

            InitializeComponent();
        }


        public ListView ListadoArticulos {
            get {
                return this.Listado;
            }
        }


        public override Lfx.Types.OperationResult Ok()
        {

            using (var Trans = this.Connection.BeginTransaction())
            {
                foreach (ListViewItem Itm in this.Listado.Items)
                {
                    int ArtId = Lfx.Types.Parsing.ParseInt(Itm.Tag.ToString());

                    decimal Costo = Lfx.Types.Parsing.ParseCurrency(Itm.SubItems[1].Text);
                    decimal Pvp = Lfx.Types.Parsing.ParseCurrency(Itm.SubItems[3].Text);
                    decimal Iva = Lfx.Types.Parsing.ParseCurrency(Itm.SubItems[5].Text);
                    decimal margen = Lfx.Types.Parsing.ParseCurrency(Itm.SubItems[6].Text);

                    decimal NuevoCosto = 0m;
                    decimal NuevoPvp = 0m;
                    decimal Aumento = EntradaCantidad.ValueDecimal;

                    switch (EntradaUnidad.TextKey)
                    {
                        case "pct":
                            if (EntradaMovimiento.TextKey == "+")
                            {
                                NuevoCosto = Costo * (1m + Aumento / 100m);
                                NuevoPvp = Pvp * (1m + Aumento / 100m);
                            }
                            else
                            {
                                NuevoCosto = Costo * (1m - Aumento / 100m);
                                NuevoPvp = Pvp * (1m - Aumento / 100m);
                            }
                            break;
                        case "pesos":
                            if (EntradaMovimiento.TextKey == "+")
                            {
                                NuevoCosto = Costo + Aumento;
                                NuevoPvp = Pvp + Aumento;
                            }
                            else
                            {
                                NuevoCosto = Costo - Aumento;
                                NuevoPvp = Pvp - Aumento;
                            }
                            break;
                        case "psmg":
                            if (EntradaMovimiento.TextKey == "+")
                            {
                                NuevoCosto = Costo + Aumento;
                                NuevoPvp = NuevoCosto * (margen == 0 ? 1 : margen);
                            }
                            else
                            {
                                NuevoCosto = Costo - Aumento;
                                NuevoPvp = NuevoCosto * (margen == 0 ? 1 : margen);
                            }
                            break;
                    }

                    qGen.Update ActualizarPrecio = new qGen.Update("articulos");
                    if (EntradaPrecio.TextKey == "costo" || EntradaPrecio.TextKey == "ambos")
                    {
                        ActualizarPrecio.ColumnValues.AddWithValue("costo", NuevoCosto);
                    }
                    if (EntradaPrecio.TextKey == "pvp" || EntradaPrecio.TextKey == "ambos")
                    {
                        if (Iva != 0)
                            NuevoPvp /= Iva;
                        ActualizarPrecio.ColumnValues.AddWithValue("pvp", NuevoPvp);
                    }
                    ActualizarPrecio.WhereClause = new qGen.Where();
                    ActualizarPrecio.WhereClause.AddWithValue("id_articulo", ArtId);

                    this.Connection.ExecuteNonQuery(ActualizarPrecio);

                    qGen.Insert AgregarAlHistorialDePrecios = new qGen.Insert("articulos_precios");
                    AgregarAlHistorialDePrecios.ColumnValues.AddWithValue("id_articulo", ArtId);
                    AgregarAlHistorialDePrecios.ColumnValues.AddWithValue("costo", NuevoCosto);
                    AgregarAlHistorialDePrecios.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                    AgregarAlHistorialDePrecios.ColumnValues.AddWithValue("id_margen", null);
                    AgregarAlHistorialDePrecios.ColumnValues.AddWithValue("pvp", NuevoPvp);
                    AgregarAlHistorialDePrecios.ColumnValues.AddWithValue("id_persona", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                    this.Connection.ExecuteNonQuery(AgregarAlHistorialDePrecios);

                }
                Trans.Commit();
            }

            return new Lfx.Types.SuccessOperationResult();
        }

        private void EntradaUnidad_TextChanged(object sender, EventArgs e)
        {
            if (EntradaUnidad.TextKey == "pct")
            {
                EntradaCantidad.DataType = Lui.Forms.DataTypes.Float;
                EntradaCantidad.Sufijo = "%";
                EntradaCantidad.Prefijo = "";
            }
            else
            {
                EntradaCantidad.DataType = Lui.Forms.DataTypes.Currency;
                EntradaCantidad.Sufijo = "";
                EntradaCantidad.Prefijo = "$";
            }

            this.Recalcular();
        }

        private void EntradaPrecio_TextChanged(object sender, EventArgs e)
        {
            this.Recalcular();
        }

        private void EntradaMovimiento_TextChanged(object sender, EventArgs e)
        {
            this.Recalcular();
        }

        private void EntradaCantidad_TextChanged(object sender, EventArgs e)
        {
            this.Recalcular();
        }

        protected void Recalcular()
        {
            foreach (ListViewItem Itm in this.Listado.Items)
            {
                Itm.UseItemStyleForSubItems = false;
                decimal Costo = Lfx.Types.Parsing.ParseCurrency(Itm.SubItems[1].Text);
                decimal Pvp = Lfx.Types.Parsing.ParseCurrency(Itm.SubItems[3].Text);

                decimal NuevoCosto = 0m;
                decimal NuevoPvp = 0m;
                decimal Aumento = EntradaCantidad.ValueDecimal;

                switch (EntradaUnidad.TextKey)
                {
                    case "pct":
                        if (EntradaMovimiento.TextKey == "+")
                        {
                            NuevoCosto = Costo * (1m + Aumento / 100m);
                            NuevoPvp = Pvp * (1m + Aumento / 100m);
                        }
                        else
                        {
                            NuevoCosto = Costo * (1m - Aumento / 100m);
                            NuevoPvp = Pvp * (1m - Aumento / 100m);
                        }
                        break;
                    case "pesos":
                        if (EntradaMovimiento.TextKey == "+")
                        {
                            NuevoCosto = Costo + Aumento;
                            NuevoPvp = Pvp + Aumento;
                        }
                        else
                        {
                            NuevoCosto = Costo - Aumento;
                            NuevoPvp = Pvp - Aumento;
                        }
                        break;
                    case "psmg":
                        int ArtId = Lfx.Types.Parsing.ParseInt(Itm.Tag.ToString());
                        Lbl.Articulos.Articulo GetArt = new Lbl.Articulos.Articulo(this.Connection, ArtId);

                        decimal Margen = 0;
                        if (GetArt != null && GetArt.Margen != null)
                        {
                            Margen = Math.Round(GetArt.Margen.Porcentaje, Lbl.Sys.Config.Moneda.DecimalesFinal);
                            if (Margen != 0)
                                Margen = 1 + Margen / 100;
                        }

                        if (EntradaMovimiento.TextKey == "+")
                        {
                            NuevoCosto = Costo + Aumento;
                            if (Margen == 0)
                                Margen = 1 + ((Pvp - Costo) / (Costo == 0 ? 1 : Costo));
                            NuevoPvp = NuevoCosto * Margen;
                        }
                        else
                        {
                            NuevoCosto = Costo - Aumento;
                            if (Margen == 0)
                                Margen = 1 + ((Pvp - Costo) / (Costo == 0 ? 1 : Costo));
                            NuevoPvp = NuevoCosto * (Margen == 0 ? 1 : Margen);
                        }
                        Itm.SubItems[6].Text = Margen.ToString();
                        break;
                }

                if (EntradaPrecio.TextKey == "costo")
                {
                    Itm.SubItems[4].Text = Itm.SubItems[3].Text;
                    Itm.SubItems[2].Text = Lfx.Types.Formatting.FormatCurrency(NuevoCosto);
                    Itm.SubItems[2].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    Itm.SubItems[4].BackColor = System.Drawing.SystemColors.Window;
                }
                else if (EntradaPrecio.TextKey == "pvp")
                {
                    Itm.SubItems[2].Text = Itm.SubItems[1].Text;
                    Itm.SubItems[4].Text = Lfx.Types.Formatting.FormatCurrency(NuevoPvp);
                    Itm.SubItems[2].BackColor = System.Drawing.SystemColors.Window;
                    Itm.SubItems[4].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                else
                {
                    Itm.SubItems[2].Text = Lfx.Types.Formatting.FormatCurrency(NuevoCosto);
                    Itm.SubItems[4].Text = Lfx.Types.Formatting.FormatCurrency(NuevoPvp);
                    Itm.SubItems[2].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    Itm.SubItems[4].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
            }
        }

        private void CambioMasivoPrecios_Activated(object sender, EventArgs e)
        {
            this.Recalcular();
        }
    }
}