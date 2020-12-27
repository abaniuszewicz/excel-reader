using System.Xml.Serialization;

namespace ExcelReader.Deserialization.WorkbookModels
{
    public class WorkbookSheet
    {
        [XmlAttribute("name")]
        public string Name { get; init; }
        [XmlAttribute("sheetId")]
        public int SheetId { get; init; }
        [XmlAttribute(AttributeName = "id", Namespace = "http://schemas.openxmlformats.org/officeDocument/2006/relationships")]
        public string RId { get; init; }
    }
}
