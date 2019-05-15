using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lbl.Articulos
{
    public class CodBar
    {
        public string Impresora { get; set; }
        public bool Nombre { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Cantidad { get; set; }
        public int Hoja { get; set; }
        public int TipoCodBar { get; set; }

        public List<string> Fields()
        {
            List<string> field = new List<string>();
            field.Add("CodBar.Impresora");
            field.Add("CodBar.Nombre");
            field.Add("CodBar.Width");
            field.Add("CodBar.Height");
            field.Add("CodBar.Cantidad");
            field.Add("CodBar.Hoja");
            field.Add("CodBar.TipoCodBar");
            return field;
        }
    }
}
