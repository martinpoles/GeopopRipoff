namespace GeopopRipoff.Models
{
    public class Argument
    {
        public string Oid { get; set; }
        public string Id_Argomento { get; set; }

    }
    public class ArgumentsPageModel
    {
        public string Oid { get; set; }
        public string Id_Argomento { get; set; }
        public List<Articles> List_Articoli { get; set; }

    }
    public class Articles
    {
        public string Oid { get; set; }
        public string Id_Articolo { get; set; }

        public string Oid_Autore { get; set; }
    }
}
