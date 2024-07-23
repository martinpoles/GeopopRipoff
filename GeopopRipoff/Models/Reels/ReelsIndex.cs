using GeopopRipoff.Models.Home;

namespace GeopopRipoff.Models.Reels
{
    public class ReelsIndex
    {
        //lista di reels
        //primo reels
        public Reels Id_Reels { get; set; }
        public List<Content> List_Reels { get; set; }

        public ReelsIndex()
        {
           List_Reels = new List<Content>();
        }

    }

    public class Reels
    {
        public string Id_Contenuto { get; set; }
        public string Id_Autore { get; set; }
        public string Dt_Pubblicazione { get; set; }
        public string Local_Path { get; set; }

    }
}
