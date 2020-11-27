using ExcelReader.Cells;
using System.Collections.Generic;

namespace ExcelReader.Tables
{
    public interface IColumn : IEnumerable<ICell>
    {
        public IEnumerable<ICell> Cells { get; }
    }
}
