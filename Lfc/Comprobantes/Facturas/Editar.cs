using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace Lfc.Comprobantes.Facturas
{
    public partial class Editar : Lfc.Comprobantes.Editar
    {
        private bool m_PuedeEditarPago = false, m_MostrarEditarCobro = true;
        public Control ControlDestino = null;
        private decimal totPago = 0;
        private CuponTarjeta m_CuponTarj = null;
        //private List<CuponTarjeta> m_MultiCuponTarj = null;
        private List<Lbl.Comprobantes.Cobro> m_Cobros = new List<Lbl.Comprobantes.Cobro>();
        private string m_NuevoNumero = "", m_nombreClienteFree = "";

        public Editar()
        {
            ElementoTipo = typeof(Lbl.Comprobantes.ComprobanteConArticulos);

            EntradaCliente.FreeTextCode = "*";

            InitializeComponent();

            this.EntradaCliente.TextChanged += new System.EventHandler(this.EntradaCliente_TextChanged);

            EntradaProductos.Top = EntradaTipo.Bottom + 8;
            EntradaProductos.Height = EntradaSubTotal.Top - 8 - EntradaProductos.Top;
        }

        public Editar(string tipo)
                : this()
        {
            switch (tipo)
            {
                case "F":
                    TipoPredet = "FB";
                    break;
                case "NC":
                    TipoPredet = "NCB";
                    break;
                case "ND":
                    TipoPredet = "NDB";
                    break;
                default:
                    TipoPredet = tipo;
                    break;
            }
        }


        public override Lfx.Types.OperationResult ValidarControl(bool deImprimir)
        {
            Lfx.Types.OperationResult Res = base.ValidarControl();

            if (Res.Success == true)
            {
                if (EntradaRemito.ValueInt > 0)
                {
                    int RemitoId = EntradaRemito.ValueInt;
                    if (RemitoId == 0)
                    {
                        Res.Success = false;
                        Res.Message += "El número de remito no es válido." + Environment.NewLine;
                    }
                }//Controlar esto!!!

                if (lblFecha.Visible)
                {
                    DateTime fecAct = new DateTime();
                    if (!DateTime.TryParse(EntradaFecha.Text, out fecAct))
                    {
                        Res.Success = false;
                        Res.Message = "Debe ingresar una fecha válida." + Environment.NewLine;
                    }
                    else
                    {
                        using (EditarNumeroComprobante NuevoNumero = new EditarNumeroComprobante())
                        {
                            object nomObj = this.Elemento.Registro["nombre"];
                            object pvObj = this.Elemento.Registro["pv"];
                            int pvInt = pvObj != null ? int.Parse(pvObj.ToString()) : 0;
                            NuevoNumero.OldNumber = nomObj == null ? pvInt.ToString("0000") + "-00000000" : nomObj.ToString();
                            if (NuevoNumero.ShowDialog() == DialogResult.OK)
                            {
                                m_NuevoNumero = NuevoNumero.NewNumber;
                            }
                            else
                            {
                                Res.Success = false;
                            }
                        }
                    }
                }
                if (EntradaFormaPagoTicket.Visible)
                    EntradaFormaPago.ValueInt = EntradaFormaPagoTicket.ValueInt;

                Lbl.Pagos.FormaDePago FormaPago = EntradaFormaPago.Elemento as Lbl.Pagos.FormaDePago;
                Lbl.Comprobantes.Tipo Tipo = new Lbl.Comprobantes.Tipo(this.Connection, EntradaTipo.TextKey);
                if (FormaPago == null && Tipo.EsFacturaOTicket)
                {
                    Res.Success = false;
                    Res.Message += "Por favor seleccione la forma de pago." + Environment.NewLine;
                }

                if (FormaPago != null && FormaPago.Tipo == Lbl.Pagos.TiposFormasDePago.MultiPago)
                {
                    if (decimal.Parse(lblImporte.Text) != EntradaTotal.ValueDecimal)
                    {
                        Res.Success = false;
                        Res.Message += @"El importe de pago no coincide." + Environment.NewLine;
                    }
                }

                if (m_MostrarEditarCobro && FormaPago != null && FormaPago.Tipo == Lbl.Pagos.TiposFormasDePago.Tarjeta)
                {
                    Lbl.Comprobantes.ComprobanteConArticulos CompTar = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                    CuponTarjeta tarj = new CuponTarjeta();
                    if (m_CuponTarj != null)
                    {
                        tarj = m_CuponTarj;
                    }
                    else if (CompTar.Obs != null && CompTar.Obs.ToString().Trim().Length > 0)
                    {
                        string[] spliTar = CompTar.Obs.Split('®');
                        if (spliTar.Length == 4)
                        {
                            tarj.Cupon = spliTar[0];
                            tarj.IdPlan = int.Parse(spliTar[1]);
                            tarj.Cuotas = int.Parse(spliTar[2]);
                            tarj.Obs = spliTar[3];
                        }
                        else
                        {
                            tarj = null;
                        }
                    }
                    using (Comprobantes.Recibos.EditarCobro FormularioEditarPago = new Comprobantes.Recibos.EditarCobro())
                    {
                        FormularioEditarPago.Cobro.FromCobro(new Lbl.Comprobantes.Cobro(this.Connection, FormaPago));
                        FormularioEditarPago.Cobro.FormaDePagoEditable = false;
                        if (EntradaInteres.ValueDecimal > 0)
                            FormularioEditarPago.Cobro.Importe = EntradaTotal.ValueDecimal / (1 + (EntradaInteres.ValueDecimal / 100));
                        else
                            FormularioEditarPago.Cobro.Importe = EntradaTotal.ValueDecimal;
                        FormularioEditarPago.Cobro.importeOriginal = FormularioEditarPago.Cobro.Importe;
                        if (tarj != null)
                        {
                            FormularioEditarPago.Cobro.EntradaCupon.Text = tarj.Cupon;
                            FormularioEditarPago.Cobro.EntradaPlan.ValueInt = tarj.IdPlan;
                            FormularioEditarPago.Cobro.EntradaCuotas.ValueInt = tarj.Cuotas;
                            FormularioEditarPago.Cobro.EntradaObs.Text = tarj.Obs;
                            FormularioEditarPago.Cobro.EntradaInteres.ValueDecimal = EntradaInteres.ValueDecimal;
                            FormularioEditarPago.Cobro.TotalInteres = EntradaInteres.ValueDecimal;
                            FormularioEditarPago.Cobro.SumarInteres();
                        }
                        FormularioEditarPago.Cobro.ImporteVisible = true;
                        FormularioEditarPago.Cobro.ImporteEditable = false;
                        FormularioEditarPago.Cobro.SumaInteresEnTotal = true;
                        FormularioEditarPago.Cobro.ControlCupon = false;
                        if (FormularioEditarPago.ShowDialog() == DialogResult.OK)
                        {
                            EntradaInteres.ValueDecimal = FormularioEditarPago.Cobro.TotalInteres;
                            CuponTarjeta newTarj = new CuponTarjeta();
                            newTarj.Cuotas = FormularioEditarPago.Cobro.EntradaCuotas.ValueInt;
                            newTarj.Cupon = FormularioEditarPago.Cobro.EntradaCupon.Text;
                            newTarj.IdPlan = FormularioEditarPago.Cobro.EntradaPlan.Elemento.Id;
                            newTarj.Obs = FormularioEditarPago.Cobro.EntradaObs.Text;
                            m_CuponTarj = newTarj;
                            //Imprimé directo.
                            m_MostrarEditarCobro = false;
                        }
                        else
                        {
                            Res.Success = false;
                            m_CuponTarj = null;
                        }
                    }
                }

                if (EntradaCliente.ValueInt == 0 && EntradaCliente.IsFreeText)
                {
                    m_nombreClienteFree = EntradaCliente.TextDetail;
                    EntradaCliente.Elemento = new Lbl.Personas.Persona(this.Connection, 998);
                }

                if ((EntradaCliente.ValueInt == 999 || EntradaCliente.ValueInt == 998) && FormaPago != null && FormaPago.Tipo == Lbl.Pagos.TiposFormasDePago.CuentaCorriente)
                {
                    Res.Success = false;
                    Res.Message += @"El cliente ""Consumidor final"" no puede tener una cuenta corriente. Deber facturar a nombre de un cliente identificado para poder usar la cuenta corriente." + Environment.NewLine;
                }

                // En Argentina, obligo a ingresar la CUIT
                Lbl.Personas.Persona Cliente = EntradaCliente.Elemento as Lbl.Personas.Persona;
                if (Cliente == null)
                {
                    Res.Success = false;
                    Res.Message += "Por favor seleccione un cliente." + Environment.NewLine;
                }
                else if (Lbl.Sys.Config.Pais.Id == 1 && Cliente.SituacionTributaria != null && (Cliente.SituacionTributaria.Id == 2 || Cliente.SituacionTributaria.Id == 3))
                {
                    if (Cliente.ClaveTributaria == null || Cliente.ClaveTributaria.EsValido() == false)
                    {
                        Res.Success = false;
                        Res.Message += "El cliente debe tener una clave tributaria válida." + Environment.NewLine;
                    }
                }
            }
            return Res;
        }

        public override void ActualizarControl()
        {
            Lbl.Comprobantes.ComprobanteConArticulos Res = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
            totPago = 0;
            if (Res.Tipo != null)
            {
                if (Res.Tipo.EsFactura || this.Tipo.EsTicket)
                {
                    List<Lbl.Comprobantes.Tipo> TiposFac = new List<Lbl.Comprobantes.Tipo>();
                    foreach (Lbl.Comprobantes.Tipo Tp in Lbl.Comprobantes.Tipo.TodosPorLetra.Values)
                    {
                        if (Tp.EsFacturaOTicket)
                            TiposFac.Add(Tp);
                    }
                    string[] NombresYTipos = new string[TiposFac.Count];
                    int i = 0;
                    foreach (Lbl.Comprobantes.Tipo Tp in TiposFac)
                    {
                        NombresYTipos[i++] = Tp.Nombre + "|" + Tp.Nomenclatura;
                    }
                    EntradaTipo.SetData = NombresYTipos;
                    EntradaFormaPago.Elemento = Res.FormaDePago;
                    PanelFormaPago.Visible = true;
                    PanelComprobanteOriginal.Visible = false;
                    m_NuevoNumero = Res.Nombre;
                    if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(Res.PV))
                    {
                        Lbl.Comprobantes.PuntoDeVenta puntosVentas = Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[Res.PV];
                        if (puntosVentas.Enumerar == 1 || (puntosVentas.Enumerar == 0 && !Res.Tipo.NumerarAlImprimir && !Res.Tipo.NumerarAlGuardar))
                        {
                            lblFecha.Visible = EntradaFecha.Visible = true;
                            EntradaFecha.Text = Res.Fecha.ToShortDateString();
                        }
                    }
                }
                else if (Res.Tipo.EsNotaCredito || this.Tipo.EsNotaDebito)
                {
                    List<Lbl.Comprobantes.Tipo> TiposFac = new List<Lbl.Comprobantes.Tipo>();
                    foreach (Lbl.Comprobantes.Tipo Tp in Lbl.Comprobantes.Tipo.TodosPorLetra.Values)
                    {
                        if (Tp.EsNotaCredito || Tp.EsNotaDebito)
                            TiposFac.Add(Tp);
                    }
                    string[] NombresYTipos = new string[TiposFac.Count];
                    int i = 0;
                    foreach (Lbl.Comprobantes.Tipo Tp in TiposFac)
                    {
                        NombresYTipos[i++] = Tp.Nombre + "|" + Tp.Nomenclatura;
                    }
                    EntradaTipo.SetData = NombresYTipos;
                    EntradaFormaPago.ValueInt = 3;
                    EntradaComprobanteOriginal.Elemento = Res.ComprobanteOriginal;

                    if (Res.ComprobanteOriginal != null && Res.ComprobanteOriginal.Cliente != null)
                    {
                        EntradaComprobanteOriginal.Filter = "tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM') AND numero>0 AND id_cliente=" + Res.ComprobanteOriginal.Cliente.Id.ToString();
                    }

                    PanelFormaPago.Visible = false;
                    PanelComprobanteOriginal.Visible = true;
                }
                else if (Res.Tipo.EsTicketX)
                {
                    string[] NombresYTipos = new string[1];
                    NombresYTipos[0] = "Ticket X|TX";
                    EntradaFormaPagoTicket.Visible = true;

                    EntradaTipo.SetData = NombresYTipos;
                    EntradaFormaPago.Elemento = Res.FormaDePago;
                    EntradaFormaPagoTicket.ValueInt = Res.FormaDePago != null ? Res.FormaDePago.Id : 0;
                    PanelFormaPago.Visible = true;
                    PanelComprobanteOriginal.Visible = false;
                    m_NuevoNumero = Res.Nombre;
                    if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(Res.PV))
                    {
                        Lbl.Comprobantes.PuntoDeVenta puntosVentas = Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[Res.PV];
                        if (puntosVentas.Enumerar == 1 || (puntosVentas.Enumerar == 0 && !Res.Tipo.NumerarAlImprimir && !Res.Tipo.NumerarAlGuardar))
                        {
                            lblFecha.Visible = EntradaFecha.Visible = true;
                            EntradaFecha.Text = Res.Fecha.ToShortDateString();
                        }
                    }
                    //EntradaFormaPago.Elemento = new Lbl.Pagos.FormaDePago(Res.Connection, 3);//CtaCte
                }
                EntradaTipo.TextKey = Res.Tipo.Nomenclatura;
                this.DiscriminarIva = Res.Tipo.DiscriminaIva;
            }

            if (Res.FormaDePago != null && Res.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.MultiPago)
                m_Cobros = Res.MultiCobros;
            ListaPagos.Items.Clear();
            foreach (Lbl.Comprobantes.Cobro cb in m_Cobros)
                MostrarFormaCobro(cb);
            try
            {
                if (Res.Cliente != null)
                {
                    this.AplicaIva = Res.Cliente.ObtenerSituacionIva() != Lbl.Impuestos.SituacionIva.Exento;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Res.IdRemito == 0)
                EntradaRemito.Text = "";
            else
                EntradaRemito.Text = Lbl.Comprobantes.Comprobante.NumeroCompleto(Res.Connection, Res.IdRemito);
            PuedeEditarPago = EsCancelable();

            base.ActualizarControl();

        }

        public override void ActualizarElemento()
        {
            Lbl.Comprobantes.ComprobanteConArticulos Res = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
            //Agrego campos propios de esta instancia
            if (EntradaFormaPagoTicket.Visible)
                EntradaFormaPago.ValueInt = EntradaFormaPagoTicket.ValueInt;

            if (EntradaFormaPago.ValueInt > 0)
                Res.FormaDePago = new Lbl.Pagos.FormaDePago(Res.Connection, EntradaFormaPago.ValueInt);
            else
                Res.FormaDePago = null;

            if (PanelComprobanteOriginal.Visible)
            {
                Res.ComprobanteOriginal = EntradaComprobanteOriginal.Elemento as Lbl.Comprobantes.ComprobanteFacturable;
            }

            Lbl.Entidades.Sucursal sucursal = new Lbl.Entidades.Sucursal(this.Connection, EntradaPV.ValueInt);
            if (sucursal != null && sucursal.SituacionOrigen != null)
            {
                Lbl.Articulos.Situacion situacion = new Lbl.Articulos.Situacion(this.Connection, sucursal.SituacionOrigen.Id);
                Res.SituacionOrigen = situacion;
            }

            if (Res.SituacionDestino == null && Res.Tipo.Nomenclatura == "TX")
                Res.SituacionDestino = new Lbl.Articulos.Situacion(this.Connection, 999);

            if (m_CuponTarj != null)
                Res.Obs = m_CuponTarj.ToString();

            Res.MultiCobros = m_Cobros;
            if (lblFecha.Visible)
            {
                Res.Fecha = DateTime.Parse(EntradaFecha.Text);
                Res.Nombre = m_NuevoNumero;
                string[] spitNewNumber = m_NuevoNumero.Split('-');
                if (spitNewNumber.Length > 1)
                {
                    Res.PV = int.Parse(spitNewNumber[0]);
                    EntradaPV.ValueInt = Res.PV;
                    Res.Numero = int.Parse(spitNewNumber[1]);
                }
                Res.Impreso = true;
            }
            if (EntradaRemito.ValueInt > 0)
            {
                Res.IdRemito = EntradaRemito.ValueInt;
            }
            else
            {
                Res.IdRemito = 0;
            }

            if (EntradaCliente.ValueInt == 998)
            {
                if (Res.ClienteFree == null)
                    Res.ClienteFree = new Lbl.Comprobantes.ClienteFree(this.Connection);
                Res.ClienteFree.Nombre = m_nombreClienteFree;
            }

            base.ActualizarElemento();
        }


        public override Lfx.Types.OperationResult BeforePrint()
        {
            Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
            //if (Comprob.Impreso)
            //{
            //    GuardarCobrador(Comprob);
            //    return new Lfx.Types.FailureOperationResult("Comprobante se encuentra impreso.");
            //}

            if (Comprob.Articulos.Count >= 1 && (Comprob.Articulos[0].Cantidad < 0 || Comprob.Articulos[0].ImporteUnitario < 0))
                return new Lfx.Types.FailureOperationResult("El primer ítem de la factura no puede ser negativo. Utilice los ítem negativos en último lugar.");

            Comprob.Cliente.Cargar();

            if (Comprob.FormaDePago == null && Comprob.Tipo.Nomenclatura != "TX")
                return new Lfx.Types.FailureOperationResult("Por favor seleccione la forma de pago.");

            if (Comprob.Cliente == null)
                return new Lfx.Types.FailureOperationResult("Por favor seleccione un cliente.");

            if (Comprob.Tipo == null)
                return new Lfx.Types.FailureOperationResult("Por favor seleccione el tipo de comprobante.");

            if (Lbl.Sys.Config.Pais.Id == 1)
            {
                // Verificaciones especiales para Argentina
                if (Comprob.Tipo.EsFacturaNCoND && Comprob.Cliente.SituacionTributaria != null && Comprob.Tipo.Letra != Comprob.Cliente.LetraPredeterminada())
                {
                    Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog(@"La situación tributaria del cliente y el tipo de comprobante no se corresponden.
Un cliente " + Comprob.Cliente.SituacionTributaria.ToString() + @" debería llevar un comprobante tipo " + Comprob.Cliente.LetraPredeterminada() + @". No debería continuar con la impresión. 
¿Desea continuar de todos modos?", "Tipo de comprobante incorrecto");
                    Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                    if (Pregunta.ShowDialog() == DialogResult.Cancel)
                        return new Lfx.Types.FailureOperationResult("Corrija la situación tributaria del cliente o el tipo de comprobante.");
                }

                if (Comprob.Tipo.Letra.ToUpperInvariant() == "A")
                {
                    if (Comprob.Cliente.ClaveTributaria == null || Comprob.Cliente.ClaveTributaria.EsValido() == false)
                        return new Lfx.Types.FailureOperationResult("El cliente no tiene una CUIT válida. Por favor edite el cliente y escriba una CUIT válida.");
                }
                else if (Comprob.Tipo.Letra == "B")
                {
                    //Si es factura B de más de $ 5000, debe llevar el Nº de DNI
                    if (Comprob.Total >= 5000 && Comprob.Cliente.NumeroDocumento.Length < 5 &&
                            (Comprob.Cliente.ClaveTributaria == null || Comprob.Cliente.ClaveTributaria.EsValido() == false))
                        return new Lfx.Types.FailureOperationResult("Para Facturas B de $ 5.000 o más debe proporcionar el número de DNI/CUIT del cliente.");
                    //Si es factura B de más de $ 5000, debe llevar domicilio
                    if (Comprob.Total >= 5000 && Comprob.Cliente.Domicilio.Length < 1)
                        return new Lfx.Types.FailureOperationResult("Para Facturas B de $ 5.000 o más debe proporcionar el domicilio del cliente.");
                }
            }

            if (EntradaProductos.MostrarExistencias && this.Tipo.MueveExistencias < 0 && Comprob.HayExistencias() == false)
            {
                Lui.Forms.YesNoDialog OPregunta = new Lui.Forms.YesNoDialog("Las existencias actuales no son suficientes para cubrir la operación que intenta realizar.\n¿Desea continuar de todos modos?", "No hay existencias suficientes");
                OPregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                if (OPregunta.ShowDialog() == DialogResult.Cancel)
                    return new Lfx.Types.FailureOperationResult("No se imprimir el comprobante por falta de existencias.");
            }

            if (Comprob.Cliente.Id != 999 && (Comprob.Tipo.EsFactura || Comprob.Tipo.EsNotaDebito))
            {
                decimal SaldoCtaCte = Comprob.Cliente.CuentaCorriente.ObtenerSaldo(false);

                if (Comprob.FormaDePago != null && Comprob.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.CuentaCorriente)
                {
                    decimal LimiteCredito = Comprob.Cliente.LimiteCredito;

                    if (LimiteCredito == 0)
                        LimiteCredito = Lfx.Types.Parsing.ParseCurrency(Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Cuentas.LimiteCreditoPredet", "0"));

                    if (LimiteCredito != 0 && (Comprob.Total + SaldoCtaCte) > LimiteCredito)
                        return new Lfx.Types.FailureOperationResult("El valor de la factura y/o el saldo en cuenta corriente supera el límite de crédito de este cliente.");
                }
                else
                {
                    if (SaldoCtaCte < 0)
                    {
                        using (SaldoEnCuentaCorriente FormularioError = new SaldoEnCuentaCorriente())
                        {
                            switch (FormularioError.ShowDialog())
                            {
                                case DialogResult.Yes:
                                    //Corregir el problema
                                    this.EntradaFormaPago.ValueInt = 3;
                                    this.Save();
                                    Comprob.FormaDePago.Tipo = Lbl.Pagos.TiposFormasDePago.CuentaCorriente;
                                    break;
                                case DialogResult.No:
                                    //Continuar. No corregir el problema.
                                    break;
                                default:
                                    //Cancelar y volver a la edición.
                                    return new Lfx.Types.CancelOperationResult();
                            }
                        }
                    }
                }
            }

            if (Comprob.FormaDePago != null && Comprob.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.MultiPago)
            {
                if (EntradaTotal.ValueDecimal > decimal.Parse(lblImporte.Text))
                    return new Lfx.Types.FailureOperationResult("El pago debe ser igual a la factura.");
            }

            if (Comprob.PV < 1)
                return new Lfx.Types.FailureOperationResult("Por favor escriba un punto de venta válido.");

            if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(Comprob.PV) == false)
            {
                // No existe el PV... vacío la caché antes intentar de nuevo y dar un error
                Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.Clear();
                if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(Comprob.PV) == false)
                    return new Lfx.Types.FailureOperationResult("El punto de venta no existe. Si desea definir un nuevo punto de venta, utilice el menú Sistema -> Parametros -> Comprobantes -> Tablas -> Puntos de venta.");
            }

            //Verifica si el punto de venta es por talonario
            Lbl.Comprobantes.PuntoDeVenta Pv = Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[Comprob.PV];
            if (Pv.Tipo == Lbl.Comprobantes.TipoPv.Talonario)
            {
                Lbl.Impresion.Impresora Impresora = Comprob.ObtenerImpresora();

                if (Pv.CargaManual && (Impresora == null || Impresora.CargaPapel == Lbl.Impresion.CargasPapel.Automatica))
                {
                    Lui.Printing.ManualFeedDialog FormularioCargaManual = new Lui.Printing.ManualFeedDialog();
                    FormularioCargaManual.DocumentName = Comprob.Tipo.ToString() + " " + Comprob.PV.ToString("0000") + "-" + Lbl.Comprobantes.Numerador.ProximoNumero(Comprob).ToString("00000000");
                    // Muestro el nombre de la impresora
                    if (Impresora != null)
                    {
                        FormularioCargaManual.PrinterName = Impresora.Nombre;
                    }
                    else
                    {
                        System.Drawing.Printing.PrinterSettings objPrint = new System.Drawing.Printing.PrinterSettings();
                        FormularioCargaManual.PrinterName = objPrint.PrinterName;
                    }
                    if (FormularioCargaManual.ShowDialog() == DialogResult.Cancel)
                        return new Lfx.Types.CancelOperationResult();
                }
            }

            if (Comprob.Tipo.MueveExistencias != 0)
            {
                Lfx.Types.OperationResult Res = Comprob.VerificarSeries();
                if (Res.Success == false)
                    return Res;
            }


            if (Comprob.FormaDePago != null && Comprob.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.Tarjeta)
            {
                Lbl.Comprobantes.ComprobanteConArticulos CompTar = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                CuponTarjeta tarj = new CuponTarjeta();// CompTar.Obs;
                if (m_CuponTarj != null && !m_MostrarEditarCobro)
                {
                    this.Save();
                }
                else if (CompTar.Obs != null && CompTar.Obs.ToString().Trim().Length > 0)
                {
                    string[] spliTar = CompTar.Obs.Split('®');
                    if (spliTar.Length == 4)
                    {
                        tarj.Cupon = spliTar[0];
                        tarj.IdPlan = int.Parse(spliTar[1]);
                        tarj.Cuotas = int.Parse(spliTar[2]);
                        tarj.Obs = spliTar[3];
                    }
                    else
                    {
                        tarj = null;
                    }

                    using (Comprobantes.Recibos.EditarCobro FormularioEditarPago = new Comprobantes.Recibos.EditarCobro())
                    {
                        FormularioEditarPago.Cobro.FromCobro(new Lbl.Comprobantes.Cobro(this.Connection, Comprob.FormaDePago));
                        FormularioEditarPago.Cobro.FormaDePagoEditable = false;
                        if (EntradaInteres.ValueDecimal > 0)
                            FormularioEditarPago.Cobro.Importe = EntradaTotal.ValueDecimal / (1 + (EntradaInteres.ValueDecimal / 100));
                        else
                            FormularioEditarPago.Cobro.Importe = EntradaTotal.ValueDecimal;
                        FormularioEditarPago.Cobro.importeOriginal = FormularioEditarPago.Cobro.Importe;
                        if (tarj != null)
                        {
                            FormularioEditarPago.Cobro.EntradaCupon.Text = tarj.Cupon;
                            FormularioEditarPago.Cobro.EntradaPlan.ValueInt = tarj.IdPlan;
                            FormularioEditarPago.Cobro.EntradaCuotas.ValueInt = tarj.Cuotas;
                            FormularioEditarPago.Cobro.EntradaObs.Text = tarj.Obs;
                            FormularioEditarPago.Cobro.EntradaInteres.ValueDecimal = EntradaInteres.ValueDecimal;
                            FormularioEditarPago.Cobro.TotalInteres = EntradaInteres.ValueDecimal;
                            FormularioEditarPago.Cobro.SumarInteres();
                        }
                        FormularioEditarPago.Cobro.ImporteVisible = true;
                        FormularioEditarPago.Cobro.ImporteEditable = false;
                        FormularioEditarPago.Cobro.SumaInteresEnTotal = true;
                        FormularioEditarPago.Cobro.ControlCupon = false;//Con parametro, para definir si se controla el N° de cupon.
                        if (FormularioEditarPago.ShowDialog() == DialogResult.OK)
                        {
                            EntradaInteres.ValueDecimal = FormularioEditarPago.Cobro.TotalInteres;
                            Lbl.Comprobantes.ComprobanteConArticulos FacLeo = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                            CuponTarjeta newTarj = new CuponTarjeta();
                            newTarj.Cuotas = FormularioEditarPago.Cobro.EntradaCuotas.ValueInt;
                            newTarj.Cupon = FormularioEditarPago.Cobro.EntradaCupon.Text;
                            newTarj.IdPlan = FormularioEditarPago.Cobro.EntradaPlan.Elemento.Id;
                            newTarj.Obs = FormularioEditarPago.Cobro.EntradaObs.Text;
                            m_CuponTarj = newTarj;
                            m_MostrarEditarCobro = false;
                            this.Save();
                        }
                        else
                        {
                            m_MostrarEditarCobro = true;
                            m_CuponTarj = null;
                            return new Lfx.Types.CancelOperationResult();
                        }
                    }
                }
            }
            return base.BeforePrint();
        }

        public override void AfterPrint()
        {
            PuedeEditarPago = this.EsCancelable();

            Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

            if (Comprob.Impreso)
            {
                if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(Comprob.PV))
                {
                    var Pv = Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[Comprob.PV];
                    if (Pv.Tipo == Lbl.Comprobantes.TipoPv.ElectronicoAfip)
                    {
                        // Es un punto de venta electrónico... abro el PDF generado
                        var Carpeta = System.IO.Path.Combine(Lbl.Sys.Config.CarpetaEmpresa, "Comprobantes", "PV" + Comprob.PV.ToString());
                        System.Diagnostics.Process.Start(System.IO.Path.Combine(Carpeta, Comprob.ToString() + ".pdf"));
                    }
                }
                if (Comprob.FormaDePago != null)
                {
                    switch (Comprob.FormaDePago.Tipo)
                    {
                        case Lbl.Pagos.TiposFormasDePago.Efectivo:
                            //El pago lo asentó la rutina de impresión
                            //Yo sólo muestro la ventanita de calcular el cambio
                            Comprobantes.PagoVuelto FormularioVuelto = new Comprobantes.PagoVuelto();
                            FormularioVuelto.Total = Lfx.Types.Parsing.ParseCurrency(EntradaTotal.Text);
                            FormularioVuelto.ShowDialog();
                            break;
                        case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                        case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                        case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                        case Lbl.Pagos.TiposFormasDePago.OtroValor:
                        case Lbl.Pagos.TiposFormasDePago.Caja:
                        case Lbl.Pagos.TiposFormasDePago.MultiPago:
                            if (this.EsCancelable())
                                EditarPago();
                            break;
                    }
                }
                GuardarCobrador(Comprob);
            }
        }


        private void GuardarCobrador(Lbl.Comprobantes.ComprobanteConArticulos Comprob)
        {
            int CobrID = (new Lbl.Personas.Persona(this.Connection, Lbl.Sys.Config.Actual.UsuarioConectado.Id)).Id;
            using (IDbTransaction Trans = Comprob.Connection.BeginTransaction())
            {
                //Guardo el cobrador.
                qGen.IStatement Comando = new qGen.Update("comprob", new qGen.Where("id_comprob=" + Comprob.Id + " AND id_cobrador is NULL"));
                Comando.ColumnValues.AddWithValue("id_cobrador", CobrID);
                Comando.ColumnValues.AddWithValue("fecha_cobrador", new qGen.SqlExpression("NOW()"));
                Comprob.Connection.ExecuteNonQuery(Comando);
                Trans.Commit();
            }
        }

        private void EntradaCliente_TextChanged(object sender, System.EventArgs e)
        {
            EntradaProductos.CargarPersona = this.EntradaCliente.ValueInt.ToString();
        }


        private void EntradaTipo_TextChanged(object sender, System.EventArgs e)
        {
            this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra[EntradaTipo.TextKey];
            this.DiscriminarIva = this.Tipo.DiscriminaIva;
        }


        private Lfx.Types.OperationResult EditarPago()
        {
            Lbl.Comprobantes.ComprobanteConArticulos Factura = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

            if (Factura.ImporteCancelado >= Factura.Total)
                return new Lfx.Types.FailureOperationResult("Este comprobante ya fue cancelado en su totalidad.");

            if (Factura.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.Efectivo)
            {
                using (IDbTransaction Trans = Factura.Connection.BeginTransaction())
                {
                    Factura.AsentarPago(false);
                    Factura.MoverExistencias(false);
                    Trans.Commit();
                }
                this.PuedeEditarPago = false;
            }
            else if (Factura.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.CuentaCorriente)
            {
                CrearReciboParaEstaFactura();
            }
            else if (Factura.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.MultiPago)
            {
                MultiCobroGenerarPagos(Factura);
            }
            else
            {
                //Cuando ya se cargo previamente el cupon o los pagos, entonces solamente grabo y no vuelvo a mostrar.
                if (Factura.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.Tarjeta && m_CuponTarj != null)
                {
                    using (IDbTransaction TransTarj = Factura.Connection.BeginTransaction())
                    {
                        Lbl.Pagos.Cupon MiOtroCupon = new Lbl.Pagos.Cupon(Factura.Connection);
                        MiOtroCupon.Numero = m_CuponTarj.Cupon;
                        MiOtroCupon.FormaDePago = Factura.FormaDePago;

                        if (m_CuponTarj.IdPlan > 0)
                            MiOtroCupon.Plan = new Lbl.Pagos.Plan(Factura.Connection, m_CuponTarj.IdPlan);
                        else
                            MiOtroCupon.Plan = null;

                        MiOtroCupon.Obs = m_CuponTarj.Obs;

                        MiOtroCupon.Concepto = Lbl.Cajas.Concepto.IngresosPorFacturacion;
                        MiOtroCupon.ConceptoTexto = "Cobro s/" + Factura.ToString();

                        if (EntradaVendedor.ValueInt > 0)
                            MiOtroCupon.Vendedor = new Lbl.Personas.Persona(Factura.Connection, EntradaVendedor.ValueInt);

                        MiOtroCupon.Factura = Factura;
                        MiOtroCupon.Importe = Factura.ImporteImpago;
                        MiOtroCupon.Guardar();

                        Factura.CancelarImporte(Factura.Total, null);
                        TransTarj.Commit();
                    }
                    PuedeEditarPago = false;
                }
                else
                {
                    using (Comprobantes.Recibos.EditarCobro FormularioEditarPago = new Comprobantes.Recibos.EditarCobro())
                    {
                        FormularioEditarPago.Cobro.FromCobro(new Lbl.Comprobantes.Cobro(this.Connection, Factura.FormaDePago));
                        FormularioEditarPago.Cobro.FormaDePagoEditable = true;
                        FormularioEditarPago.Cobro.Importe = Factura.Total;
                        FormularioEditarPago.Cobro.ImporteVisible = true;
                        FormularioEditarPago.Cobro.ImporteEditable = false;
                        if (FormularioEditarPago.ShowDialog() == DialogResult.OK)
                        {
                            Lbl.Comprobantes.Cobro MiCobro = FormularioEditarPago.Cobro.ToCobro(Factura.Connection);
                            if (MiCobro.FormaDePago.Id != Factura.FormaDePago.Id)
                            {
                                // Tengo que actualizar la forma de pago
                                using (IDbTransaction Trans = Factura.Connection.BeginTransaction())
                                {
                                    Factura.FormaDePago = MiCobro.FormaDePago;
                                    EntradaFormaPago.Elemento = MiCobro;
                                    Factura.Connection.FieldInt("UPDATE comprob SET id_formapago=" + MiCobro.FormaDePago.Id.ToString() + " WHERE id_comprob=" + Factura.Id.ToString());
                                    if (MiCobro.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.CuentaCorriente)
                                    {
                                        // Si la nueva forma de pago es cta. cte., asiento el saldo
                                        // Y uso saldo a favor, si lo hay
                                        decimal Saldo = Factura.Cliente.CuentaCorriente.ObtenerSaldo(true);
                                        Factura.Cliente.CuentaCorriente.AsentarMovimiento(true,
                                                Lbl.Cajas.Concepto.IngresosPorFacturacion,
                                                "Saldo a Cta. Cte. s/" + Factura.ToString(),
                                                Factura.ImporteImpago,
                                                null,
                                                Factura,
                                                null,
                                                null);
                                        if (Saldo < 0)
                                        {
                                            Saldo = Math.Abs(Saldo);
                                            if (Saldo > Factura.Total)
                                                Factura.CancelarImporte(Factura.Total, null);
                                            else
                                                Factura.CancelarImporte(Saldo, null);
                                        }
                                    }
                                    Trans.Commit();
                                }
                            }
                            switch (Factura.FormaDePago.Tipo)
                            {
                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                    using (IDbTransaction TransEfe = Factura.Connection.BeginTransaction())
                                    {
                                        Lbl.Cajas.Caja CajaDiaria = new Lbl.Cajas.Caja(Factura.Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria);
                                        CajaDiaria.Movimiento(true, Lbl.Cajas.Concepto.IngresosPorFacturacion, Factura.ToString(), Factura.Cliente, Factura.ImporteImpago, Factura.Obs, Factura, null, null);
                                        Factura.CancelarImporte(Factura.Total, null);
                                        TransEfe.Commit();
                                    }
                                    break;
                                case Lbl.Pagos.TiposFormasDePago.MultiPago:
                                    MultiCobroGenerarPagos(Factura);
                                    break;
                                case Lbl.Pagos.TiposFormasDePago.CuentaCorriente:
                                    CrearReciboParaEstaFactura();
                                    break;
                                case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                    using (IDbTransaction TransCheTer = Factura.Connection.BeginTransaction())
                                    {
                                        Lbl.Bancos.Cheque Cheque = MiCobro.Cheque;
                                        Cheque.Concepto = Lbl.Cajas.Concepto.IngresosPorFacturacion;
                                        Cheque.ConceptoTexto = "Cobro s/" + this.Elemento.ToString();
                                        Cheque.Factura = Factura;
                                        Cheque.Guardar();
                                        Factura.CancelarImporte(Factura.Total, null);
                                        TransCheTer.Commit();
                                    }
                                    PuedeEditarPago = false;
                                    break;
                                case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                    using (IDbTransaction TransTarj = Factura.Connection.BeginTransaction())
                                    {
                                        Lbl.Pagos.Cupon CuponCredito = MiCobro.Cupon;
                                        CuponCredito.Concepto = Lbl.Cajas.Concepto.IngresosPorFacturacion;
                                        CuponCredito.ConceptoTexto = "Cobro s/" + Factura.ToString();

                                        if (EntradaVendedor.ValueInt > 0)
                                            CuponCredito.Vendedor = new Lbl.Personas.Persona(Factura.Connection, EntradaVendedor.ValueInt);

                                        CuponCredito.Factura = Factura;
                                        CuponCredito.Importe = Factura.ImporteImpago;
                                        CuponCredito.Guardar();

                                        Factura.CancelarImporte(Factura.Total, null);
                                        TransTarj.Commit();
                                    }
                                    PuedeEditarPago = false;
                                    break;
                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                    using (IDbTransaction TransCaja = Factura.Connection.BeginTransaction())
                                    {
                                        Lbl.Cajas.Caja CajaDeposito = MiCobro.CajaDestino;
                                        CajaDeposito.Movimiento(true, Lbl.Cajas.Concepto.IngresosPorFacturacion, "Cobro s/" + Factura.ToString(), Factura.Cliente, MiCobro.Importe, MiCobro.Obs, Factura, null, null);
                                        Factura.CancelarImporte(Factura.Total, null);
                                        TransCaja.Commit();
                                    }
                                    PuedeEditarPago = false;
                                    break;
                                default:
                                    throw new NotImplementedException("No se reconoce la forma de pago " + Factura.FormaDePago.Tipo.ToString());
                            }

                        }
                        else
                        {
                            return new Lfx.Types.SuccessOperationResult();
                        }
                    }
                }
                this.PuedeEditarPago = false;
            }

            return new Lfx.Types.SuccessOperationResult();
        }


        private void MultiCobroGenerarPagos(Lbl.Comprobantes.ComprobanteConArticulos comp)
        {
            //(MODIFICAR)
        }

        private void CrearReciboParaEstaFactura()
        {
            Lbl.Comprobantes.ComprobanteConArticulos Factura = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
            Lbl.Comprobantes.ReciboDeCobro Recibo = new Lbl.Comprobantes.ReciboDeCobro(Lfx.Workspace.Master.GetNewConnection("Nuevo recibo para " + Factura.ToString()) as Lfx.Data.Connection);
            Recibo.Crear();
            Recibo.Facturas.AddWithValue(Factura, Factura.ImporteImpago);
            Recibo.Cliente = Factura.Cliente;

            Recibo.Concepto = Lbl.Cajas.Concepto.IngresosPorFacturacion;
            Recibo.ConceptoTexto = "Cancelación de " + Factura.ToString();

            Lfc.FormularioEdicion NuevoRecibo = Lfc.Instanciador.InstanciarFormularioEdicion(Recibo);
            NuevoRecibo.MdiParent = this.ParentForm.MdiParent;
            NuevoRecibo.Show();
        }


        internal bool EsCancelable()
        {
            Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
            if (Comprob == null || Comprob.ImporteImpago == 0)
            {
                return false;
            }
            else
            {
                return (Comprob.Impreso && Comprob.Anulado == false && Comprob.Existe && Comprob.FormaDePago != null);
            }
        }

        internal bool EsEditable()
        {
            Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
            if (Comprob == null)
            {
                return true;
            }
            else if (Comprob.ImporteImpago == 0)
            {
                return false;
            }
            else
            {
                return (!Comprob.Impreso && Comprob.Anulado == false && Comprob.Existe && Comprob.FormaDePago != null);
            }
        }


        private void EntradaRemito_TextChanged(object sender, System.EventArgs e)
        {
            int RemitoId = EntradaRemito.ValueInt;
            if (RemitoId > 0)
            {
                Lfx.Data.Row Remito = this.Connection.FirstRowFromSelect("SELECT * FROM comprob WHERE tipo_fac='R' AND id_comprob=" + RemitoId.ToString() + " AND impresa>0 AND anulada=0");
                if (Remito == null)
                    EntradaProductos.MostrarExistencias = true;
                else
                {
                    EntradaProductos.MostrarExistencias = false;
                    Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("¿Desea agregar los artículos del remito a la factura?", "Remito a Facturar");
                    if (Pregunta.ShowDialog() == DialogResult.OK)
                    {
                        Lbl.Comprobantes.ComprobanteConArticulos cRemito = new Lbl.Comprobantes.ComprobanteConArticulos(this.Connection, RemitoId);
                        if (cRemito != null)
                            EntradaProductos.CargarArticulos(cRemito.Articulos);
                    }
                }
            }
            else
            {
                EntradaProductos.MostrarExistencias = true;
            }
        }


        private void EntradaFormaPago_Leave(object sender, System.EventArgs e)
        {
            if (EntradaFormaPago.ValueInt == 99)
                EntradaFormaPago.ValueInt = 3;
            if (EntradaFormaPago.ValueInt == 5)
                EntradaFormaPago.ValueInt = 4;
            if (EntradaFormaPago.ValueInt == 9)
            {
                lblImporte.Visible = panelMultiPago.Visible = true;
                btnAgregarPago.Enabled = btnQuitarPago.Enabled = EsEditable();
                btnAgregarPago.Focus();
            }
            else
            {
                lblImporte.Visible = false;
                lblImporte.Text = "0.00";
                totPago = 0;
                ListaPagos.Items.Clear();
            }
        }


        [EditorBrowsable(EditorBrowsableState.Never), System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Lbl.Comprobantes.Tipo Tipo {
            get {
                return base.Tipo;
            }
            set {
                base.Tipo = value;
                PanelFormaPago.Visible = value.EsFactura || value.EsTicket || value.EsNotaCredito;
                if (value.EsNotaCredito && !PanelFormaPago.Visible)
                    PanelFormaPago.Visible = true;
                PanelComprobanteOriginal.Visible = value.EsNotaCredito;
                if (EntradaTipo.TextKey != value.Nomenclatura)
                    EntradaTipo.TextKey = value.Nomenclatura;
            }
        }


        private bool PuedeEditarPago {
            get {
                return m_PuedeEditarPago;
            }
            set {
                m_PuedeEditarPago = value;
                FireFormActionsChanged();
            }
        }

        public override Lazaro.Pres.Forms.FormActionCollection GetFormActions()
        {
            Lazaro.Pres.Forms.FormActionCollection Res = base.GetFormActions();
            if (this.PuedeEditarPago)
                Res.Add(new Lazaro.Pres.Forms.FormAction("Pago", "F2", "pago", 10, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
            return Res;
        }


        public override Lfx.Types.OperationResult PerformFormAction(string name)
        {
            switch (name)
            {
                case "pago":
                    EditarPago();
                    //Cargo la forma de pago por botón.
                    int CobrID = (new Lbl.Personas.Persona(this.Connection, Lbl.Sys.Config.Actual.UsuarioConectado.Id)).Id;
                    using (IDbTransaction Trans = this.Connection.BeginTransaction())
                    {
                        //Guardo el cobrador.
                        qGen.IStatement Comando = new qGen.Update("comprob", new qGen.Where("id_comprob", this.Elemento.Id));
                        Comando.ColumnValues.AddWithValue("id_cobrador", CobrID);
                        Comando.ColumnValues.AddWithValue("fecha_cobrador", new qGen.SqlExpression("NOW()"));
                        this.Connection.ExecuteNonQuery(Comando);
                        Trans.Commit();
                    }
                    return new Lfx.Types.SuccessOperationResult();
                default:
                    return base.PerformFormAction(name);
            }
        }

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            Comprobantes.Recibos.EditarCobro FormularioEditarCobro = new Comprobantes.Recibos.EditarCobro();
            FormularioEditarCobro.Connection = this.Connection;
            FormularioEditarCobro.Cobro.FromCobro(new Lbl.Comprobantes.Cobro(this.Connection, Lbl.Pagos.TiposFormasDePago.Efectivo));
            FormularioEditarCobro.Cobro.ObsVisible = false;

            if (FormularioEditarCobro.ShowDialog() == DialogResult.OK)
            {
                Lbl.Comprobantes.Cobro Cb = FormularioEditarCobro.Cobro.ToCobro(this.Connection);
                if (Cb.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.Tarjeta)
                {
                    //Agregar recargo a la factura.(MODIFICAR)
                }
                m_Cobros.Add(Cb);
                MostrarFormaCobro(Cb);
            }
        }

        protected void MostrarFormaCobro(Lbl.Comprobantes.Cobro Cb)
        {
            ListaPagos.BeginUpdate();
            ListViewItem itm = ListaPagos.Items.Add(Cb.FormaDePago.GetHashCode().ToString());
            switch (Cb.FormaDePago.Tipo)
            {
                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                    itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Cb.FormaDePago.ToString()));
                    itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Lfx.Types.Formatting.FormatCurrency(Cb.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                    break;
                case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                    itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Cb.FormaDePago.ToString()));
                    itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Lfx.Types.Formatting.FormatCurrency(Cb.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                    itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, "Cupón Nº " + Cb.Cupon.Numero + " de " + Cb.Cupon.FormaDePago.ToString()));
                    break;
                case Lbl.Pagos.TiposFormasDePago.Caja:
                    itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Cb.FormaDePago.ToString()));
                    itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Lfx.Types.Formatting.FormatCurrency(Cb.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                    itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, "Depósito en " + Cb.CajaDestino.ToString()));
                    break;
                default:
                    itm.SubItems.Add(Cb.FormaDePago.ToString());
                    itm.SubItems.Add(Lfx.Types.Formatting.FormatCurrency(Cb.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                    itm.SubItems.Add(Cb.ToString());
                    break;
            }
            totPago += Cb.Importe;
            lblImporte.Text = EtiquetaValoresImporte.Text = Lfx.Types.Formatting.FormatCurrency(totPago, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
            ListaPagos.EndUpdate();
        }

        private void btnCerrarPanel_Click(object sender, EventArgs e)
        {
            panelMultiPago.Visible = false;
            EntradaRemito.Focus();
        }

        private void btnQuitarPago_Click(object sender, EventArgs e)
        {
            //Sacar recargo si es con tarjeta.(MODIFICAR)
            if (ListaPagos.SelectedItems.Count == 0 && ListaPagos.Items.Count > 0)
                ListaPagos.Items[ListaPagos.Items.Count - 1].Selected = true;

            if (ListaPagos.SelectedItems.Count == 0)
            {
                Lui.Forms.MessageBox.Show("Debe seleccionar un valor para quitar.", "Error");
            }
            else
            {
                ListViewItem itm = ListaPagos.SelectedItems[0];
                decimal totImp = decimal.Parse(itm.SubItems[2].Text);
                totPago -= totImp;
                lblImporte.Text = EtiquetaValoresImporte.Text = Lfx.Types.Formatting.FormatCurrency(totPago, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                itm.Remove();
                Lbl.Comprobantes.Cobro deCobro = m_Cobros.Find(x => x.FormaDePago.GetHashCode().ToString() == itm.SubItems[0].Text);
                m_Cobros.Remove(deCobro);
                if (ListaPagos.Items.Count == 1)
                    ListaPagos.Items[0].Selected = true;
            }
        }

        private void PanelFormaPago_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void EntradaTipo_Leave(object sender, EventArgs e)
        {
            Label2.Visible = true;
        }

        private void lblImporte_Click(object sender, EventArgs e)
        {
            panelMultiPago.Visible = !panelMultiPago.Visible;
        }
    }

    public class CuponTarjeta
    {
        public string Cupon { get; set; }
        public int IdPlan { get; set; }
        public int Cuotas { get; set; }
        public string Obs { get; set; }

        public override string ToString()
        {
            string ResCup = this.Cupon.ToString();
            ResCup += "®" + this.IdPlan.ToString() + "®" + this.Cuotas.ToString() + "®" + this.Obs;
            return ResCup;
        }
    }
}