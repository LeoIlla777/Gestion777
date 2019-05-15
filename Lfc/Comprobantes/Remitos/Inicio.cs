using System;
using System.Collections.Generic;

namespace Lfc.Comprobantes.Remitos
{
        public class Inicio : Lfc.Comprobantes.Inicio
        {
                public Inicio()
                        : base()
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.Remito);
                }

                public Inicio(string comand)
                        : base(comand)
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.Remito);
                        this.HabilitarBorrar = true;
                }


                public override Lfx.Types.OperationResult SolicitudEliminacion(Lbl.ListaIds codigos)
                {
                    using (Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog(@"Una vez anulados, los comprobantes deberán ser archivados en todas sus copias y no podrán ser rehabilitados ni reutilizados.", @"¿Está seguro de que desea anular?"))
                    {
                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                        if (Pregunta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            int IdRemito = codigos[0];
                            System.Data.IDbTransaction Trans = this.Connection.BeginTransaction(System.Data.IsolationLevel.Serializable);
                            System.Data.DataTable Tabla = this.Connection.Select("select id_comprob from comprob where id_remito=" + IdRemito + " and anulada=0;");
                            if (Tabla == null || Tabla.Rows.Count == 0)
                            {
                                Lbl.Comprobantes.ComprobanteConArticulos Rem = new Lbl.Comprobantes.ComprobanteConArticulos(Connection, IdRemito);
                                if (Rem.Anulado == false)
                                {
                                    Rem.Anular(false);
                                    Trans.Commit();
                                }
                            }
                            else
                            {
                                Lui.Forms.MessageBox.Show("No se puede anular si se encuentra relacionada con una factura", "¡Error!");
                            }
                    
                        }
                    }
                    return new Lfx.Types.SuccessOperationResult();
                }
        }
}
