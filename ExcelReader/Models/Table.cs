using System.Collections.Generic;

namespace ExcelReader.Models
{
    internal class Table : ITable
    {
        private readonly List<IRow> _rows = new List<IRow>();
        private readonly List<IColumn> _columns = new List<IColumn>();

        public string Name { get; set; }

        public IEnumerable<IRow> Rows => _rows;

        public IEnumerable<IColumn> Columns => _columns;

        public void AddColumn(IColumn column)
        {
            _columns.Add(column);
        }

        public void AddColumn(IColumn column, int index)
        {
            _columns.Insert(index, column);
        }

        public void AddRow(IRow row)
        {
            _rows.Add(row);
        }

        public void AddRow(IRow row, int index)
        {
            _rows.Insert(index, row);
        }

        public void RemoveColumn(IColumn column)
        {
            _columns.Remove(column);
        }

        public void RemoveColumn(int index)
        {
            _columns.RemoveAt(index);
        }

        public void RemoveRow(IRow row)
        {
            _rows.Remove(row);
        }

        public void RemoveRow(int index)
        {
            _rows.RemoveAt(index);
        }
    }
}
