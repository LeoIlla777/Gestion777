namespace Lazaro.Pres.Spreadsheet
{
    public class HeaderLeo
    {
        public string title { get; set; }
        public int columnas { get; set; }
        public bool merge { get; set; }
        public int size { get; set; }
        public bool bold { get; set; }
        public ListaAlign alig { get; set; }
    }

    public enum ListaAlign
    {
        center,
        centercontinuous,
        distributed,
        fill,
        general,
        justify,
        left,
        right
    }
}

