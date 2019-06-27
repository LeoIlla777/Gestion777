using System;
using System.Collections.Generic;

namespace Lfc.Comprobantes.Facturas
{
        public class Inicio : Lfc.Comprobantes.Inicio
        {
                public Inicio()
                        : base()
                {
                        NombrePagina = "FacturaVenta";  //Lbl.Comprobantes.NotaDeCredito
                        int limitOpciones = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingInt("Paginar", NombrePagina, 999999);
                        this.Limit = limitOpciones;
                        this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.Factura);
                        this.HabilitarBorrar = true;
                }

                public Inicio(string comando)
                        : this()
                {
                        NombrePagina = "FacturaVenta";  //Lbl.Comprobantes.NotaDeCredito
                        int limitOpciones = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingInt("Paginar", NombrePagina, 999999);
                        this.Limit = limitOpciones;
                        try {
                                this.Definicion.ElementoTipo = Lbl.Instanciador.InferirTipo(comando);        
                        } catch {
                                this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.Factura);
                        }
                        this.Letra = comando;
                        
                        this.HabilitarBorrar = true;
                }


                public override Lfx.Types.OperationResult SolicitudEliminacion(Lbl.ListaIds codigos)
                {
                        Lfx.Workspace.Master.RunTime.Execute("INSTANCIAR Lfc.Comprobantes.Facturas.Anular " + codigos[0].ToString() + "®0");
                        return new Lfx.Types.SuccessOperationResult();
                }
        }
}
