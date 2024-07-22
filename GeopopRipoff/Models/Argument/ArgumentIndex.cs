namespace GeopopRipoff.Models.Argument
{
    public class ArgumentIndex
    {
        public string PathHeader { get; set; }
        public string Descrizione { get; set; }
        public string Id_Argomento { get; set; }
        public List<Argomento> Argomenti { get; set; }
        public List<ContenutoArgumentArticle> Contenuti { get; set; }

        public ArgumentIndex()
        {
            Contenuti = new List<ContenutoArgumentArticle>();
        }
    }

    public class ContenutoArgumentArticle
    {

        public string ImgPath { get; set; }
        public string Title { get; set; }
    }

    public class TrashBag
    {
        public string id_argomento { get; set; }
        public int counter { get; set; }
    }

    public class DbDataArticle 
    {
        public string id_contenuto { get; set; }
        public string id_autore { get; set; }
        public DateTime dt_pubblicazione { get; set; }
    }


}
