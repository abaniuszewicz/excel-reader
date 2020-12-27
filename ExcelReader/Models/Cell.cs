namespace ExcelReader.Models
{
    internal class Cell : ICell
    {
        public string Value { get; set; }

        public int RowIndex { get; set; }

        public int ColumnIndex { get; set; }
    }
}
