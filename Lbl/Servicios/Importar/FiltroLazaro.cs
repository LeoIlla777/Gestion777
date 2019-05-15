using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Servicios.Importar
{
        public class FiltroGestion : Filtro
        {
                public FiltroGestion(Lfx.Data.IConnection dataBase, Opciones opciones)
                        : base(dataBase, opciones)
                {
                        this.Nombre = "Filtro de importación de Gestión";
                }
        }
}
