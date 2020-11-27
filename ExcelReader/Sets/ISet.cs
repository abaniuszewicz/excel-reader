using ExcelReader.Tables;
using System.Collections.Generic;

namespace ExcelReader.Sets
{
    public interface ISet : IEnumerable<ITable>
    {
        public string Name { get; }
        public IEnumerable<ITable> Tables { get; }

        public void AddTable(ITable table);
        public void AddTable(ITable table, int position);

        public void RemoveTable(ITable table);
        public void RemoveTable(int position);
    }
}
