using System.Xml.Serialization;

namespace GeopopRipoff.Utility
{
    public class PolicyReader
    {
    }


    [XmlRoot("body")]
    public class Document
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("header")]
        public string Header { get; set; }

        [XmlArray("sections")]
        [XmlArrayItem("section")]
        public List<Section> Sections { get; set; }
    }

    public class Section
    {
        [XmlElement("subtitle")]
        public string Subtitle { get; set; }

        [XmlElement("content")]
        public string Content { get; set; }
        public Section(string subtitle,  string content)
        {
            Subtitle = subtitle;
            Content = content;
        }
    }
}
