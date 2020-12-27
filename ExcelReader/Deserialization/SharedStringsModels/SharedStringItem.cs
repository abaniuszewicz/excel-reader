using System.Xml.Serialization;

namespace ExcelReader.Deserialization.SharedStringsModels
{
    public class SharedStringItem
    {
        /* Two cases here:
         * (1) either simple <si><t>Cell text</t></si> elements which holds simple text
         * (2) complex constructs, e.g. when cell has multiple colors applied on character level we're dealing with compound object
         * More: https://docs.microsoft.com/en-us/office/open-xml/working-with-the-shared-string-table */
        [XmlElement("t")]
        public string Text { get; init; } // TODO: handle (2)
    }
}
