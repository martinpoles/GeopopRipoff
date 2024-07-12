using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Xml.Serialization;

namespace GeopopRipoff.Models
{
    public class DbTable
    {
    }

    public class Contenuto
    {
        [Key]
        public int Oid { get; set; }
        public string Id_Contenuto { get; set; }
        public DateTime Dt_Pubblicazione { get; set; }
        public string Ds_Contenuto { get; set; }
    }

    public class Argomento
    {
        [Key]
        public int Oid { get; set; }
        public string Id_Argomento { get; set; }
        public string Ds_Argomento { get; set; }
    }

    public class Autore
    {
        [Key]
        public int Oid { get; set; }
        public string Id_Autore { get; set; }
        public DateTime Dt_Nascita { get; set; }
    }

    public class Formato
    {
        [Key]
        public int Oid { get; set; }
        public string Id_Formato { get; set; }
    }

    public class ContenutoAutore
    {
        [Key]
        public int Oid { get; set; }
        public int Oid_Contenuto { get; set; }
        public int Oid_Autore { get; set; }

        [ForeignKey("OidContenuto")]
        public Contenuto Contenuto { get; set; }

        [ForeignKey("OidAutore")]
        public Autore Autore { get; set; }
    }

    public class ContenutoFormato
    {
        [Key]
        public int Oid { get; set; }
        public int Oid_Contenuto { get; set; }
        public int Oid_Formato { get; set; }

        [ForeignKey("OidContenuto")]
        public Contenuto Contenuto { get; set; }

        [ForeignKey("OidFormato")]
        public Formato Formato { get; set; }
    }

    public class ContenutoArgomento
    {
        [Key]
        public int Oid { get; set; }
        public int Oid_Contenuto { get; set; }
        public int Oid_Argomento { get; set; }

        [ForeignKey("OidContenuto")]
        public Contenuto Contenuto { get; set; }

        [ForeignKey("OidArgomento")]
        public Argomento Argomento { get; set; }
    }


    public class Utente
    {
        [Key]
        public int Oid { get; set; }
        public string Id_Username { get; set; }
        public string Id_Nome { get; set; }
        public string Id_Cognome { get; set; }
        public string Id_Email { get; set; }
    }

}