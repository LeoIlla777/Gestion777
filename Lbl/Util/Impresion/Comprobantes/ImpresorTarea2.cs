using System.Data;
using System.Drawing;

namespace Lazaro.Base.Util.Impresion.Comprobantes
{
        public class ImpresorTarea2 : ImpresorElemento
    {
                public ImpresorTarea2(Lbl.ElementoDeDatos elemento, IDbTransaction transaction)
                        : base(elemento, transaction) { }

                public Lbl.Tareas.Tarea Tarea
                {
                        get
                        {
                                return this.Elemento as Lbl.Tareas.Tarea;
                        }
                }

        public override string ObtenerValorCampo(string nombreCampo, string formato)
        {
            string Res = null;
            switch (nombreCampo.ToUpperInvariant())
            {
                case "CLIENTE":
                case "CLIENTE.NOMBRE":
                    return this.Tarea.Cliente.ToString();

                case "LOCALIDAD":
                case "LOCALIDAD.NOMBRE":
                case "CLIENTE.LOCALIDAD":
                case "CLIENTE.LOCALIDAD.NOMBRE":
                    if (this.Tarea.Cliente.Localidad == null)
                        return "";
                    else
                        return this.Tarea.Cliente.Localidad.ToString();

                case "DOMICILIO":
                case "CLIENTE.DOMICILIO":
                    if (this.Tarea.Cliente.Domicilio != null && this.Tarea.Cliente.Domicilio.Length > 0)
                        return this.Tarea.Cliente.Domicilio;
                    else
                        return this.Tarea.Cliente.DomicilioLaboral;

                case "CLIENTE.DOCUMENTO":
                    if (this.Tarea.Cliente.ClaveTributaria != null)
                        return this.Tarea.Cliente.ClaveTributaria.ToString();
                    else
                        return this.Tarea.Cliente.NumeroDocumento;
                case "CUIT":
                case "CLIENTE.CUIT":
                    if (this.Tarea.Cliente.ClaveTributaria != null)
                        return this.Tarea.Cliente.ClaveTributaria.ToString();
                    else
                        return "";
                case "CLIENTE.ID":
                    return this.Tarea.Cliente.Id.ToString();

                case "VENDEDOR":
                case "VENDEDOR.NOMBRE":
                    return this.Tarea.Encargado.ToString();
                case "TOTAL":
                case "TAREA.TOTAL":
                    decimal totalTarea = this.Tarea.ImporteAsociado - ((this.Tarea.DescuentoArticulos * this.Tarea.ImporteAsociado) / 100);
                    return Lfx.Types.Formatting.FormatCurrencyForPrint(totalTarea, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                case "ARTICULOS.CODIGOS":
                case "ART�CULOS.C�DIGOS":
                case "CODIGOS":
                case "C�DIGOS":
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        // FIXME: que imprima el c�digo seleccionado por el usuario, no siempre el autonum�rico
                        string CodigoImprimir;
                        if (this.Tarea.Articulos[i].Articulo == null)
                            CodigoImprimir = "";
                        else
                            CodigoImprimir = this.Tarea.Articulos[i].Articulo.Id.ToString();
                        if (Res == null)
                            Res = CodigoImprimir;
                        else
                            Res += System.Environment.NewLine + CodigoImprimir;
                    }
                    return Res;

                case "ARTICULOS.CANTIDADES":
                case "ART�CULOS.CANTIDADES":
                case "CANTIDADES":
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        if (Res == null)
                        {
                            Res = "";
                        }
                        Res += Lfx.Types.Formatting.FormatNumberForPrint(this.Tarea.Articulos[i].Cantidad, Lbl.Sys.Config.Articulos.Decimales) + System.Environment.NewLine;
                    }
                    return Res;

                case "ARTICULOS.IVA":
                case "ART�CULOS.IVA":
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        if (Res == null)
                        {
                            Res = "";
                        }
                        Res += this.Tarea.Articulos[i].ObtenerAlicuota().Porcentaje.ToString("0.0") + "%" + System.Environment.NewLine;
                    }
                    return Res;

                case "ARTICULOS.IVADISCRIMINADO":
                case "ART�CULOS.IVADISCRIMINADO":
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        if (Res == null)
                        {
                            Res = "";
                        }
                        Res += Lfx.Types.Formatting.FormatCurrencyForPrint(this.Tarea.Articulos[i].ImporteUnitarioIvaDiscriminado, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal) + System.Environment.NewLine;
                    }
                    return Res;

                case "ART�CULOS.IMPORTESCONIVA":
                case "ARTICULOS.IMPORTESCONIVA":
                    Res = "";
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        if (Res == null)
                        {
                            Res = "";
                        }
                        Res += Lfx.Types.Formatting.FormatCurrencyForPrint(this.Tarea.Articulos[i].ImporteAImprimir, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal) + System.Environment.NewLine;
                    }
                    return Res;

                case "ART�CULOS.UNITARIOSCONIVA":
                case "ARTICULOS.UNITARIOSCONIVA":
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        if (Res == null)
                        {
                            Res = "";
                        }
                        Res += Lfx.Types.Formatting.FormatCurrencyForPrint(this.Tarea.Articulos[i].ImporteUnitarioConIvaFinal, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal) + System.Environment.NewLine;
                    }
                    return Res;

                case "ART�CULOS.IMPORTESCONIVA1":
                case "ART�CULOS.IMPORTESCONIVA2":
                case "ART�CULOS.IMPORTESCONIVA3":
                case "ART�CULOS.IMPORTESCONIVA4":
                case "ART�CULOS.IMPORTESCONIVA5":
                case "ART�CULOS.IMPORTESCONIVA6":
                case "ART�CULOS.IMPORTESCONIVA7":
                case "ART�CULOS.IMPORTESCONIVA8":
                case "ART�CULOS.IMPORTESCONIVA9":
                case "ARTICULOS.IMPORTESCONIVA1":
                case "ARTICULOS.IMPORTESCONIVA2":
                case "ARTICULOS.IMPORTESCONIVA3":
                case "ARTICULOS.IMPORTESCONIVA4":
                case "ARTICULOS.IMPORTESCONIVA5":
                case "ARTICULOS.IMPORTESCONIVA6":
                case "ARTICULOS.IMPORTESCONIVA7":
                case "ARTICULOS.IMPORTESCONIVA8":
                case "ARTICULOS.IMPORTESCONIVA9":
                    int NumeroIvaArt = Lfx.Types.Parsing.ParseInt(nombreCampo.Substring(nombreCampo.Length - 1));
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        if (Res == null)
                            Res = Lfx.Types.Formatting.FormatCurrencyForPrint(this.Tarea.Articulos[i].ImporteConIvaFinalAlicuota(NumeroIvaArt), Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                        else
                            Res += System.Environment.NewLine + Lfx.Types.Formatting.FormatCurrencyForPrint(this.Tarea.Articulos[i].ImporteConIvaFinalAlicuota(NumeroIvaArt), Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                    }
                    return Res;


                case "ARTICULOS.DETALLES":
                case "ART�CULOS.DETALLES":
                case "DETALLES":
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        string NombreArticulo;
                        if (this.Tarea.Articulos[i].Articulo == null)
                            NombreArticulo = this.Tarea.Articulos[i].Nombre;
                        else
                            NombreArticulo = this.Tarea.Articulos[i].Articulo.ToString();
                        if (Res == null)
                            Res = NombreArticulo;
                        else
                            Res += System.Environment.NewLine + NombreArticulo;
                    }
                    if (this.Tarea.DescuentoArticulos != 0)
                        Res += System.Environment.NewLine + "Descuento: " + Lfx.Types.Formatting.FormatNumberForPrint(this.Tarea.DescuentoArticulos, 2) + "%";
                    return Res;

                case "ARTICULOS.UNITARIOSORIGINALES":
                case "ART�CULOS.UNITARIOSORIGINALES":
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        Lbl.Comprobantes.DetalleArticulo Det = this.Tarea.Articulos[i];
                        string Linea = Lfx.Types.Formatting.FormatCurrencyForPrint(Det.ImporteUnitario, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                        if (Res == null)
                            Res = Linea;
                        else
                            Res += System.Environment.NewLine + Linea;
                    }
                    return Res;

                case "ARTICULOS.UNITARIOS":
                case "ART�CULOS.UNITARIOS":
                case "ART�CULOS.UNITARIOSFINALES":
                case "PRECIOS":
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        Lbl.Comprobantes.DetalleArticulo Det = this.Tarea.Articulos[i];
                        string Linea;
                        Linea = Lfx.Types.Formatting.FormatCurrencyForPrint(Det.ImporteUnitarioConIvaFinal, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                        if (Res == null)
                            Res = Linea;
                        else
                            Res += System.Environment.NewLine + Linea;
                    }
                    return Res;

                case "ARTICULOS.DESCUENTOS":
                case "ART�CULOS.DESCUENTOS":
                case "DESCUENTOS":
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        Lbl.Comprobantes.DetalleArticulo Det = this.Tarea.Articulos[i];
                        string Linea;
                        if (Det.Descuento == 0)
                            Linea = "--";
                        else
                            Linea = Lfx.Types.Formatting.FormatNumberForPrint(Det.Descuento, 2) + "%";
                        if (Res == null)
                            Res = Linea;
                        else
                            Res += System.Environment.NewLine + Linea;
                    }
                    return Res;

                case "ARTICULOS.IMPORTES":
                case "ART�CULOS.IMPORTES":
                case "IMPORTES":
                    Res = null;
                    for (int i = 0; i < this.Tarea.Articulos.Count; i++)
                    {
                        Lbl.Comprobantes.DetalleArticulo Det = this.Tarea.Articulos[i];
                        string Linea = Lfx.Types.Formatting.FormatCurrencyForPrint(Det.ImporteAImprimir, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                        if (Res == null)
                        {
                            Res = "";
                        }
                        Res += Linea + System.Environment.NewLine;
                    }
                    return Res;
                case "SONPESOS":
                case "TAREA.SONPESOS":
                    decimal totalTareaenPesos = this.Tarea.ImporteAsociado - ((this.Tarea.DescuentoArticulos * this.Tarea.ImporteAsociado) / 100);
                    return Lfx.Types.Formatting.SpellNumber(totalTareaenPesos);
                default:
                    return base.ObtenerValorCampo(nombreCampo, formato);
            }
        }
    }
}