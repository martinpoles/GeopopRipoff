using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Serialization;

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


    public class WrapperArgumentsPageModel
    {
        public List<ArgumentsPageModel> ArgumentsPageModel { get; set; }
        public string Descrizione { get; set; }
        public string PathHeader { get; set; }
    }

    public class ArgumentsPageModel
    {

        public string ImgPath { get; set; }
        public string Title { get; set; }
    }


    public class TempClass
    {
        public string id_articolo { get; set; }
        public string ds_argomento { get; set; }
    }

    [XmlRoot("article")]
    public class ArticleXml
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("header")]
        public string Header { get; set; }

        [XmlArray("chapters")]
        [XmlArrayItem("chapter")]
        public List<Chapters> Chapters { get; set; }
        public string LocalPath { get; set; }
    }

    public class Chapters
    {
        [XmlElement("subtitle")]
        public string Subtitle { get; set; }

        [XmlElement("chapter")]
        public string Chapter { get; set; }

        public string SubImgPath { get; set; }

        public Chapters(string subtitle, string chapter, string subImgPath = null)
        {
            Subtitle = subtitle;
            Chapter = chapter;
            SubImgPath = subImgPath;
        }
    }
}