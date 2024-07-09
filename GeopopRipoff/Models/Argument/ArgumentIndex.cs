namespace GeopopRipoff.Models.Argument
{
    public class ArgumentIndex
    {
        public string PathHeader { get; set; }
        public string Descrizione { get; set; }
        public string Id_Argomento { get; set; }
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

}
