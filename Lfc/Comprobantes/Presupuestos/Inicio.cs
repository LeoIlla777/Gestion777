using System;
using System.Collections.Generic;

namespace Lfc.Comprobantes.Presupuestos
{
        public class Inicio : Lfc.Comprobantes.Inicio
        {
                public Inicio()
                        : base()
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.Presupuesto);
                        this.Definicion.Paging = true;
                }

                public Inicio(string comand)
                        : base(comand)
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.Presupuesto);
                }
        }
}
