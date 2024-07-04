using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GeopopRipoff.Models
{
    public class Argomenti
    {
        [Key]
        public string Oid { get; set; }
        public string Id_Argomento { get; set; }
        public string Ds_Argomento { get; set; }

    }
    public class Articoli
    {
        [Key]
        public int Oid { get; set; }
        public string Id_Articolo { get; set; }
        public int Oid_Autore { get; set; }
        public string Ds_Path { get; set; }
        public DateTime Dt_Pubblicazione { get; set; }
    }

    public class Autori
    {
        [Key]
        public int Oid { get; set; }
        public string Id_Autore { get; set; }
        public DateTime Dt_Nascita { get; set; }
        
    }
    public class Argomenti_Articoli
    {
        [Key]
        public int Oid { get; set; }
        public int Oid_Argomento { get; set; }
        public int Oid_Articolo { get; set; }
    }

    public class Articoli_Autori
    {
        [Key]
        public int Oid { get; set; }
        public int Oid_Articoli { get; set; }
        public int Oid_Autori { get; set; }
    }
    public class ArgumentsPageModel
    {
        public string Id_Argomento { get; set; }
        public List<Articoli> List_Articoli { get; set; }
    }

}