namespace ExcelReader
{
    public interface ICell
    {
        public string Value { get; set; }
        public int RowIndex { get; }
        public int ColumnIndex { get; }
    }
}
