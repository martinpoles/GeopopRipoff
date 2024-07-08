namespace GeopopRipoff.Models
{
    public class Temp
    {
    }

    public class HomeIndex
    {
        public List<Argomenti> Id_argomenti { get; set; }

        public List<Storie> Stories { get; set; }
    }

    public class Storie 
    {
        public string Id_Storie { get; set; }
        public string Relative_Path { get; set; }
    }

    public class TempTemp
    {
        public string id_argomento { get; set; }
        public string id_articolo { get; set; }
    }
}
