using System;

namespace ExcelReader.Models.Events
{
    internal class RowRemovedEventArgs : EventArgs
    {
        public int Index { get; init; }
        public IRow Row { get; init; }
    }
}
