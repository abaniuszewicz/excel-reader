using ExcelReader.Deserialization.SheetModels;
using System;
using System.Collections.Generic;

namespace ExcelReader.Utilities
{
    internal static class Extensions
    {
        public static (int RowIndex, int ColumnIndex) GetZeroBasedPosition(this Cell cell)
        {
            int startOfRowIndexDefinition = cell.Position.IndexOf(char.IsDigit);

            string columnIndexDefinition = cell.Position[..startOfRowIndexDefinition];
            string rowIndexDefinition = cell.Position[startOfRowIndexDefinition..];

            int rowIndex = int.Parse(rowIndexDefinition) - 1;
            int columnIndex = Utils.ExcelColumnNumberStringToZeroBasedIndex(columnIndexDefinition);
            return (rowIndex, columnIndex);
        }

        public static int IndexOf(this string text, Predicate<char> predicate)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (predicate(text[i]))
                    return i;
            }

            return -1;
        }

        public static IRow ToRow(this IEnumerable<ICell> cells)
        {
            Models.Row row = new Models.Row();
            foreach (ICell cell in cells)
                row.Add(cell);

            return row;
        }
    }
}
