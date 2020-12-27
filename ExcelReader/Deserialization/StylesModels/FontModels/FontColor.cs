using System;
using System.Xml.Serialization;

namespace ExcelReader.Deserialization.StylesModels.FontModels
{
    [Serializable]
    public class FontColor
    {
        [XmlAttribute("rgb")]
        public string Rgb { get; init; }
    }
}
