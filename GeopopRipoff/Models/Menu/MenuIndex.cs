namespace GeopopRipoff.Models.Menu
{
    public class MenuIndex
    {
        public List<Argomento> Argomenti { get; set; }
        public Utente Utente { get; set; }

        public MenuIndex()
        {
            Argomenti = new List<Argomento>();
            Utente = new Utente();
        }
    }
}
