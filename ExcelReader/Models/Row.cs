using System.Collections;
using System.Collections.Generic;

namespace ExcelReader.Models
{
    internal class Row : IRow
    {
        private readonly List<ICell> _cells = new List<ICell>();

        public IEnumerable<ICell> Cells => _cells;

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
