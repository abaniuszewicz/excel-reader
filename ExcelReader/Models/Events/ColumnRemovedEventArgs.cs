using System;

namespace ExcelReader.Models.Events
{
    internal class ColumnRemovedEventArgs : EventArgs
    {
        public int Index { get; init; }
        public IColumn Column { get; init; }
    }
}
