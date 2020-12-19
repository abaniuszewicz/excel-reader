using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
