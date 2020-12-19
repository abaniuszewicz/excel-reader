using System.Xml.Serialization;

namespace ExcelReader.Deserialization.SheetModels
{
    public class Row
    {
        [XmlAttribute("r")]
        public int Index { get; init; }
        [XmlElement("c")]
        public Cell[] Cells { get; init; }
    }
}
