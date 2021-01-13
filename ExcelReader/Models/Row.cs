using System.Collections;
using System.Collections.Generic;

namespace ExcelReader.Models
{
    internal class Row : IRow
    {
        private readonly List<ICell> _cells = new List<ICell>();

        public IEnumerable<ICell> Cells => _cells;

        internal void Add(ICell cell)
        {
            Add(cell, _cells.Count);
        }

        internal void Add(ICell cell, int position)
        {
            _cells.Insert(position, cell);
        }

        public IEnumerator<ICell> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
