﻿using System.Collections.Generic;

namespace ExcelReader
{
    public interface ISet : IEnumerable<ITable>
    {
        public IEnumerable<ITable> Tables { get; }

        public void AddTable(ITable table);
        public void AddTable(ITable table, int position);

        public void RemoveTable(ITable table);
        public void RemoveTable(int position);
    }
}
