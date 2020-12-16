using System;
using System.Xml.Serialization;

namespace ExcelReader.Deserialization.WorkbookModels
{
    [Serializable, XmlRoot(ElementName = "workbook", Namespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main")]
    public class Workbook
    {
        [XmlArray("sheets")]
        [XmlArrayItem("sheet")]
        public WorkbookSheet[] Sheets { get; set; }
    }
}
