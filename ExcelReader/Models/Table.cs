using System.Collections.Generic;
using System.Xml;

namespace ExcelReader.Models
{
    internal class Table : ITable
    {
        private readonly XmlDocument _sheet;
        private readonly XmlDocument _styles;

        public string Name { get; set; }
        public IEnumerable<IRow> Rows { get; }
        public IEnumerable<IColumn> Columns { get; }

        public Table(string name, XmlDocument sheet, XmlDocument styles)
        {
            Name = name;
            _sheet = sheet;
            _styles = styles;
        }

        public void AddColumn(IColumn column)
        {
        }

        public void AddColumn(IColumn column, int position)
        {
        }

        public void AddRow(IRow row)
        {
        }

        public void AddRow(IRow row, int position)
        {
        }

        public void RemoveColumn(IColumn column)
        {
        }

        public void RemoveColumn(int position)
        {
        }

        public void RemoveRow(IRow row)
        {
        }

        public void RemoveRow(int position)
        {
        }
    }
}
