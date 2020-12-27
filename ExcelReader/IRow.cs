using System.Collections.Generic;

namespace ExcelReader
{
    public interface IRow : IEnumerable<ICell>
    {
        public IEnumerable<ICell> Cells { get; }
    }
}
