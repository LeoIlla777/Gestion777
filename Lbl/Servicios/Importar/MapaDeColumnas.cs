using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Servicios.Importar
{
        public enum ConversionDeColumna
        {
                Ninguna,
                ConvertirAMayusculasYMinusculas,
                ConvertirAMinusculas,
                InterpretarNombreYApellido,
                InterpretarSql
        }

        /// <summary>
        /// Especifica cómo se "mapea" una columna de una tabla externa a una columna de una tabla de Gestión.
        /// </summary>
        public class MapaDeColumna
        {
                public string ColumnaExterna, ColumnaGestion;
                public object ValorPredeterminado = null;
                public ConversionDeColumna Conversion = ConversionDeColumna.Ninguna;
                public object ParametroConversion = null;
                public System.Collections.Generic.Dictionary<string, object> Reemplazos = new Dictionary<string, object>();

                public MapaDeColumna(string columnaExterna, string columnaGestion)
                {
                        this.ColumnaExterna = columnaExterna;
                        this.ColumnaGestion = columnaGestion;
                }

                public MapaDeColumna(string columnaExterna, string columnaGestion, object valorPredeterminado)
                        : this(columnaExterna, columnaGestion)
                {
                        this.ValorPredeterminado = valorPredeterminado;
                }

                public MapaDeColumna(string columnaExterna, string columnaGestion, ConversionDeColumna conversion)
                        : this(columnaExterna, columnaGestion)
                {
                        this.Conversion = conversion;
                }
        }

        /// <summary>
        /// Contiene una lista de columnas a mapear en una tabla.
        /// </summary>
        public class MapaDeColumnas : System.Collections.Generic.List<MapaDeColumna>
        {
                public void AddWithValues(string columnaExterna, string columnaInterna)
                {
                        this.Add(new MapaDeColumna(columnaExterna, columnaInterna));
                }

                public void AddWithValues(string columnaExterna, string columnaInterna, object valorPredeterminado)
                {
                        this.Add(new MapaDeColumna(columnaExterna, columnaInterna, valorPredeterminado));
                }

                public void AddWithValues(string columnaExterna, string columnaInterna, ConversionDeColumna conversion)
                {
                        this.Add(new MapaDeColumna(columnaExterna, columnaInterna, conversion));
                }

                public MapaDeColumna this[string nombreColumnaExterna]
                {
                        get
                        {
                                foreach (MapaDeColumna Col in this) {
                                        if (Col.ColumnaExterna == nombreColumnaExterna)
                                                return Col;
                                }
                                return null;
                        }
                }
        }
}
