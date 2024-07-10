namespace GeopopRipoff.Models.Menu
{
    public class MenuIndex
    {
        public List<Argomento> Argomenti { get; set; }
        public UserProfile UserProfile { get; set; }

        public MenuIndex()
        {
            Argomenti = new List<Argomento>();
        }

    }

    public class UserProfile
    {
        public string FacebookId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
