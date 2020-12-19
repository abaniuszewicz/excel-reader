using System;
using System.Xml;
using System.Xml.Serialization;

namespace ExcelReader.Deserialization.StylesModels.FontModels
{
    [Serializable]
    public class Font
    {
        [XmlElement("sz")]
        public FontSize Size { get; init; }
        [XmlElement("color")]
        public FontColor Color { get; init; }
        [XmlElement("name")]
        public FontName Name { get; init; }
        [XmlElement("b")]
        public Bold Bold { get; init; }
        [XmlElement("i")]
        public Italic Italic { get; init; }
        [XmlElement("u")]
        public Underline Underline { get; init; }
    }
}
