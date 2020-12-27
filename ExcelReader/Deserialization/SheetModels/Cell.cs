using System;
using System.Xml.Serialization;

namespace ExcelReader.Deserialization.SheetModels
{
    [Serializable]
    public class Cell
    {
        [XmlAttribute("r")]
        public string Position { get; init; }
        [XmlAttribute("t")]
        public string DataType { get; init; }
        [XmlElement("v")]
        public string Value { get; init; }
    }
}
