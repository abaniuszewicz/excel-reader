using System.Collections.Generic;

namespace ExcelReader
{
    public interface IColumn : IEnumerable<ICell>
    {
        public IEnumerable<ICell> Cells { get; }
    }
}
