using ExcelReader.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.Models
{
    internal class Table : ITable
    {
        private readonly List<IRow> _rows = new List<IRow>();
        private readonly List<IColumn> _columns = new List<IColumn>();

        public event EventHandler<RowAddedEventArgs> RowAdded;
        public event EventHandler<RowRemovedEventArgs> RowRemoved;
        public event EventHandler<ColumnAddedEventArgs> ColumnAdded;
        public event EventHandler<ColumnRemovedEventArgs> ColumnRemoved;

        public string Name { get; set; }

        public IEnumerable<IRow> Rows => _rows;

        public IEnumerable<IColumn> Columns => _columns;

        public void AddColumn(IColumn column)
        {
            AddColumn(column, _columns.Count);
        }

        public void AddColumn(IColumn column, int index)
        {
            if (_columns.IndexOf(column) > 0)
                throw new ArgumentException("This column already belongs to this table.", nameof(column));

            _columns.Insert(index, column);
            ColumnAdded?.Invoke(this, new ColumnAddedEventArgs { Column = column, Index = index });
        }

        public void AddRow(IRow row)
        {
            AddRow(row, _rows.Count);
        }

        public void AddRow(IRow row, int index)
        {
            if (_rows.IndexOf(row) > 0)
                throw new ArgumentException("This row already belongs to this table.", nameof(row));

            _rows.Insert(index, row);
            RowAdded?.Invoke(this, new RowAddedEventArgs { Row = row, Index = index });
        }

        public void RemoveColumn(IColumn column)
        {
            int index = _columns.IndexOf(column);
            RemoveColumn(column, index);
        }

        public void RemoveColumn(int index)
        {
            IColumn column = _columns.ElementAtOrDefault(index);
            RemoveColumn(column, index);
        }

        private void RemoveColumn(IColumn column, int index)
        {
            if (column == default || index < 0)
                throw new ArgumentOutOfRangeException(nameof(column), "This column does not belong to this table");

            _columns.Remove(column);
            ColumnRemoved?.Invoke(this, new ColumnRemovedEventArgs { Column = column, Index = index });
        }

        public void RemoveRow(IRow row)
        {
            int index = _rows.IndexOf(row);
            RemoveRow(row, index);
        }

        public void RemoveRow(int index)
        {
            IColumn column = _columns.ElementAtOrDefault(index);
            RemoveColumn(column, index);
        }

        private void RemoveRow(IRow row, int index)
        {
            if (row == default || index < 0)
                throw new ArgumentOutOfRangeException(nameof(row), "This row does not belong to this table");

            _rows.Remove(row);
            RowRemoved?.Invoke(this, new RowRemovedEventArgs { Row = row, Index = index });
        }
    }
}
