using ExcelReader.Deserialization.StylesModels.FontModels;
using System;
using System.Xml.Serialization;

namespace ExcelReader.Deserialization.StylesModels
{
    [Serializable, XmlRoot(ElementName = "styleSheet", Namespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main")]
    public class Styles
    {
        [XmlArray("fonts")]
        [XmlArrayItem("font")]
        public Font[] Fonts { get; init; }
        // TODO: handle borders and fills
    }
}
