using System;

namespace ExcelReader.Models.Events
{
    internal class ColumnAddedEventArgs : EventArgs
    {
        public int Index { get; init; }
        public IColumn Column { get; init; }
    }
}
