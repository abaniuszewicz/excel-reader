using System.Collections.Generic;

namespace ExcelReader
{
    public interface ITable
    {
        public string Name { get; set; }
        public IEnumerable<IRow> Rows { get; }
        public IEnumerable<IColumn> Columns { get; }

        public void AddRow(IRow row);
        public void AddRow(IRow row, int index);

        public void RemoveRow(IRow row);
        public void RemoveRow(int index);

        public void AddColumn(IColumn column);
        public void AddColumn(IColumn column, int index);

        public void RemoveColumn(IColumn column);
        public void RemoveColumn(int index);
    }
}