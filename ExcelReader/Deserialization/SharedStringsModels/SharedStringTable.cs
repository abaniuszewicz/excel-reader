using System;
using System.Xml.Serialization;

namespace ExcelReader.Deserialization.SharedStringsModels
{
    [Serializable, XmlRoot(ElementName = "sst", Namespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main")]
    public class SharedStringTable
    {
        [XmlAttribute("count")]
        public int Count { get; init; }
        [XmlAttribute("uniqueCount")]
        public int UniqueCount { get; init; }
        [XmlElement("si")]
        public SharedStringItem[] SharedStringItems { get; init; }
    }
}
