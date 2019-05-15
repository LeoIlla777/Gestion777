using System.Data;
using System.Drawing;

namespace Lazaro.Base.Util.Impresion.Caja
{
        public class ImpresorMovimiento : ImpresorElemento
    {
                public ImpresorMovimiento(Lbl.ElementoDeDatos elemento, IDbTransaction transaction)
                        : base(elemento, transaction) { }

                public Lbl.Cajas.Movimiento Movimiento {
                        get
                        {
                                return this.Elemento as Lbl.Cajas.Movimiento;
                        }
                }

        public override string ObtenerValorCampo(string nombreCampo, string formato)
        {
            switch (nombreCampo.ToUpperInvariant())
            {
                case "EMPRESA":
                case "EMPRESA.NOMBRE":
                    return Lbl.Sys.Config.Empresa.Nombre;
                case "EMPRESA.DOMICILIO":
                    return Lfx.Workspace.Master.CurrentConfig.Empresa.Domicilio;
                case "NUMERO":
                    return this.Movimiento.Id.ToString();
                case "CLIENTE":
                case "CLIENTE.NOMBRE":
                    return this.Movimiento.Cliente.ToString();
                case "PERSONA":
                case "VENDEDOR":
                case "PERSONA.NOMBRE":
                    return this.Movimiento.Persona.ToString();
                case "OBSERVACION":
                case "OBS":
                    return this.Movimiento.Obs;
                case "CONCEPTO":
                    return this.Movimiento.Concepto.ToString();
                case "CONCEPTOTEXTO":
                    return this.Movimiento.ConceptoTexto;
                case "VALORES":
                    string valores = "Efectivo    : $" + Lfx.Types.Formatting.FormatCurrencyForPrint(System.Math.Abs(Movimiento.Importe), Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                    valores +=       "\nTarjetas  : $" + Lfx.Types.Formatting.FormatCurrencyForPrint(this.Connection.FieldDecimal("SELECT SUM(Importe) FROM tarjetas_cupones WHERE  id_movimiento=" + this.Movimiento.Id.ToString() + " AND estado<>1"), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                    valores +=       "\nCheques   : $" + Lfx.Types.Formatting.FormatCurrencyForPrint(this.Connection.FieldDecimal("SELECT SUM(Importe) FROM bancos_cheques WHERE  id_movimiento=" + this.Movimiento.Id.ToString() + " AND estado<>90"), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                    valores +=       "\nCtaCte    : $" + Lfx.Types.Formatting.FormatCurrencyForPrint(this.Connection.FieldDecimal("SELECT SUM(Importe) FROM ctacte WHERE  id_movimiento=" + this.Movimiento.Id.ToString()), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                    return valores;
                case "TOTAL":
                    decimal total = System.Math.Abs(Movimiento.Importe);
                    total += this.Connection.FieldDecimal("SELECT SUM(Importe) FROM tarjetas_cupones WHERE  id_movimiento=" + this.Movimiento.Id.ToString() + " AND estado<>1");
                    total += this.Connection.FieldDecimal("SELECT SUM(Importe) FROM bancos_cheques WHERE  id_movimiento=" + this.Movimiento.Id.ToString() + " AND estado<>90");
                    total += this.Connection.FieldDecimal("SELECT SUM(Importe) FROM ctacte WHERE  id_movimiento=" + this.Movimiento.Id.ToString());
                    return Lfx.Types.Formatting.FormatCurrencyForPrint(total, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                case "IMPORTE":
                    return Lfx.Types.Formatting.FormatCurrencyForPrint(Movimiento.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                case "CHEQUE":
                case "CHEQUES":
                    decimal cheque = System.Math.Round(this.Connection.FieldDecimal("SELECT SUM(Importe) FROM bancos_cheques WHERE  id_movimiento=" + this.Movimiento.Id.ToString() + " AND estado<>90"), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                    return Lfx.Types.Formatting.FormatCurrencyForPrint(cheque, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                case "TARJETAS":
                case "CUPONES":
                    decimal Transporte = System.Math.Round(this.Connection.FieldDecimal("SELECT SUM(Importe) FROM tarjetas_cupones WHERE  id_movimiento=" + this.Movimiento.Id.ToString() + " AND estado<>1"), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                    return Lfx.Types.Formatting.FormatCurrencyForPrint(Transporte, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                case "CUENTACORRIENTE":
                case "CTACTE":
                    decimal ctacte = System.Math.Round(this.Connection.FieldDecimal("SELECT SUM(Importe) FROM ctacte WHERE  id_movimiento=" + this.Movimiento.Id.ToString()), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                    return Lfx.Types.Formatting.FormatCurrencyForPrint(ctacte, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                default:
                    return base.ObtenerValorCampo(nombreCampo, formato);
            }
        }
    }
}