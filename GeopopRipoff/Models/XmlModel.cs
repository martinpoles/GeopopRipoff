using GeopopRipoff.Models.Home;
using System.Xml.Serialization;

namespace GeopopRipoff.Models
{
    public class XmlModel
    {
    }
    
    [XmlRoot("article")]
    public class ArticleXml
    {

        public List<Argomento> Argomenti { get; set; }
        public Autore Autore { get; set; }
        public DateTime DtPubblicazione { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("header")]
        public string Header { get; set; }

        [XmlArray("chapters")]
        [XmlArrayItem("chapter")]
        public List<Chapters> Chapters { get; set; }
        public string LocalPath { get; set; }
        public ArticleXml()
        {
            Chapters = new List<Chapters>();
            Argomenti = new List<Argomento>();
            Autore = new Autore();
        }
    }

    public class Chapters
    {
        [XmlElement("subtitle")]
        public string Subtitle { get; set; }

        [XmlElement("content")]
        public string Content { get; set; }

        public string SubImgPath { get; set; }

        public Chapters(string subtitle, string content, string subImgPath = null)
        {
            Subtitle = subtitle;
            Content = content;
            SubImgPath = subImgPath;
        }
    }
}
