using System;
using System.Xml.Serialization;

namespace ExcelReader.Deserialization.StylesModels.FontModels
{
    [Serializable]
    public class FontSize
    {
        [XmlAttribute("val")]
        public int Size { get; init; }
    }
}
