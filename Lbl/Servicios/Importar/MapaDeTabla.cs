using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Servicios.Importar
{
        /// <summary>
        /// Especifica cómo se "mapea" una tabla externa a una tabla de Gestión.
        /// </summary>
        public class MapaDeTabla
        {
                public string Nombre { get; set; }
                public string TablaExterna { get; set; }
                public string TablaGestion { get; set; }
                public string ColumnaIdExterna { get; set; }
                public string ColumnaIdGestion { get; set; }
                public MapaDeColumnas MapaDeColumnas { get; set; }
                public Type TipoElemento { get; set; }
                public string Where { get; set; }
                public bool ActualizaRegistros { get; set; }
                public int Limite { get; set; }
                public int Saltear { get; set; }
                public bool AutoSaltear { get; set; }

                public MapaDeTabla(string nombre, string tablaExterna, string tablaGestion)
                {
                        this.MapaDeColumnas = new MapaDeColumnas();
                        this.ColumnaIdGestion = "import_id";
                        this.Nombre = nombre;
                        this.ActualizaRegistros = true;
                        this.TablaExterna = tablaExterna;
                        this.TablaGestion = tablaGestion;
                        this.AutoSaltear = true;
                }

                public MapaDeTabla(string nombre, string tablaExterna, string tablaGestion, string columnaIdExterna)
                        : this(nombre, tablaExterna, tablaGestion)
                {
                        this.ColumnaIdExterna = columnaIdExterna;
                }

                public override string ToString()
                {
                        return this.Nombre;
                }
        }
}
