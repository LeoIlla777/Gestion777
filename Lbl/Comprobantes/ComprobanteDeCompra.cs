using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Comprobante de Compra")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob", TablaImagenes = "comprob_imagenes")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Automatico)]

    [Entity(TableName = "comprob", IdFieldName = "id_comprob")]
        public class ComprobanteDeCompra : ComprobanteConArticulos, Lbl.IElementoConImagen
        {
                //Requiere permisos de comprobantes con articulos 
                //Heredar constructor
                public ComprobanteDeCompra(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public ComprobanteDeCompra(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
			: base(dataBase, row) { }

                public ComprobanteDeCompra(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["FA"];
                        this.Compra = true;
                        this.Fecha = DateTime.Now;
                        this.FormaDePago = new Pagos.FormaDePago(this.Connection, Pagos.TiposFormasDePago.CuentaCorriente);
                }

                public override Tipo Tipo
                {
                        get
                        {
                                return base.Tipo;
                        }
                        set
                        {
                                base.Tipo = value;

                                if (this.Compra == false && this.Tipo.EsFacturaNCoND && this.FormaDePago == null)
                                        this.FormaDePago = new Lbl.Pagos.FormaDePago(this.Connection, Lbl.Pagos.TiposFormasDePago.CuentaCorriente);

                                //if (this.Tipo.Nomenclatura == "PD" || this.Tipo.Nomenclatura == "NP")
                                //        this.Estado = 50;
                        }
                }

                new public ComprobanteDeCompra Convertir(Tipo tipo)
                {
                        if (tipo.NombreTipoLbl == "Lbl.Comprobantes.Remito")
                            tipo.NombreTipoLbl = "Lbl.Comprobantes.RemitoCompra";

                        if (tipo.NombreTipoLbl == "Lbl.Comprobantes.Factura")
                            tipo.NombreTipoLbl = "Lbl.Comprobantes.ComprobanteDeCompra";

                        Lbl.Comprobantes.ComprobanteConArticulos Res = base.Convertir(tipo);
                        Res.Compra = true;
                        Res.Fecha = DateTime.Now;
                        if (tipo.NombreTipoLbl == "Lbl.Comprobantes.RemitoCompra")
                            tipo.NombreTipoLbl = "Lbl.Comprobantes.Remito";
                        return (ComprobanteDeCompra)Res;
                }
        }
}
