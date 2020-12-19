using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
