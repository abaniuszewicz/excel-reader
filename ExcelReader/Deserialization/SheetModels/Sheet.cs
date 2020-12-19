using System;
using System.Xml.Serialization;

namespace ExcelReader.Deserialization.SheetModels
{
    [Serializable, XmlRoot(ElementName = "worksheet", Namespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main")]
    public class Sheet
    {
        [XmlArray("sheetData")]
        [XmlArrayItem("row")]
        public Row[] Rows { get; set; }
    }
}
