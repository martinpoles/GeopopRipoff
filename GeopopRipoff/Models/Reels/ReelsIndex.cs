using GeopopRipoff.Models.Home;

namespace GeopopRipoff.Models.Reels
{
    public class ReelsIndex
    {
        //lista di reels
        //primo reels
        public Reels Id_Reels { get; set; }
        public List<ReelsExtraData> List_Reels { get; set; }

        public ReelsIndex()
        {
           List_Reels = new List<ReelsExtraData>();
        }

    }

    public class Reels
    {
        public string Id_Contenuto { get; set; }
        public string Id_Autore { get; set; }
        public string Dt_Pubblicazione { get; set; }
        public string Local_Path { get; set; }

    }

    public class ReelsExtraData
    {
        public string Id_Contenuto { get; set; }
        public string Id_Argomento { get; set; }
        public string Dt_Pubblicazione { get; set; }
        public string Cn_Like { get; set; }
        public string Total_Comments { get; set; }
        public string Path { get; set; }
    }
}
