namespace GeopopRipoff.Models.Home
{
    public class HomeIndex
    {
        public List<Argomento> Argomenti { get; set; }
        public List<Content> Storie { get; set; }
        public List<Content> ShowCase { get; set; }
        public List<Content> Reels { get; set; }

        public HomeIndex()
        {
            Argomenti = new List<Argomento>();
            Storie = new List<Content>();
            ShowCase = new List<Content>();
            Reels = new List<Content>();
        }
    }

    public class Content
    {
        public string Id_Contenuto { get; set; }
        public string Id_Argomento {  get; set; }
        public string Path { get; set; }
    }

    public class IdContenutoArgomento
    {
        public string id_argomento { get; set; }
        public string id_contenuto { get; set; }
    }
}
