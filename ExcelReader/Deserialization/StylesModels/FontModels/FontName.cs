using System;
using System.Xml.Serialization;

namespace ExcelReader.Deserialization.StylesModels.FontModels
{
    [Serializable]
    public class FontName
    {
        [XmlAttribute("val")]
        public string Name { get; init; }
    }
}
