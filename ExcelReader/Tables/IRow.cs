using ExcelReader.Cells;
using System.Collections.Generic;

namespace ExcelReader.Tables
{
    public interface IRow : IEnumerable<ICell>
    {
        public IEnumerable<ICell> Cells { get; }
    }
}
