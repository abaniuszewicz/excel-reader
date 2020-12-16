using System.Xml.Serialization;

namespace ExcelReader.Deserialization.WorkbookModels
{
    public class WorkbookSheet
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("sheetId")]
        public int SheetId { get; set; }
        [XmlAttribute(AttributeName = "id", Namespace = "http://schemas.openxmlformats.org/officeDocument/2006/relationships")]
        public string RId { get; set; }
    }
}
