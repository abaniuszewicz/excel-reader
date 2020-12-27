using System.Collections;
using System.Collections.Generic;

namespace ExcelReader.Models
{
    internal class Set : ISet
    {
        private readonly List<ITable> _tables = new List<ITable>();

        public IEnumerable<ITable> Tables => _tables;

        public void AddTable(ITable table)
        {
            _tables.Add(table);
        }

        public void AddTable(ITable table, int index)
        {
            _tables.Insert(index, table);
        }

        public void RemoveTable(ITable table)
        {
            _tables.Remove(table);
        }

        public void RemoveTable(int index)
        {
            _tables.RemoveAt(index);
        }

        public IEnumerator<ITable> GetEnumerator()
        {
            return Tables.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
