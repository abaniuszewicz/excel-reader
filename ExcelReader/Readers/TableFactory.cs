using ExcelReader.Deserialization.SharedStringsModels;
using ExcelReader.Deserialization.SheetModels;
using ExcelReader.Deserialization.StylesModels;
using ExcelReader.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ExcelReader.Readers
{
    internal class TableFactory
    {
        private readonly ILogger _logger;
        private readonly Sheet _sheet;
        private readonly Styles _styles;
        private readonly SharedStringTable _sharedStrings;

        public TableFactory(ILogger logger, Sheet sheet, Styles styles, SharedStringTable sharedStrings)
        {
            _logger = logger;
            _sheet = sheet;
            _styles = styles;
            _sharedStrings = sharedStrings;
        }

        public ITable Create()
        {
            ITable table = new Models.Table();
            List<List<ICell>> matrix = Get2DCellMatrix();
            foreach (List<ICell> matrixRow in matrix)
            {
                IRow row = matrixRow.ToRow();
                table.AddRow(row);
            }

            return table;
        }

        private List<List<ICell>> Get2DCellMatrix()
        {
            List<List<ICell>> matrix = new List<List<ICell>>();

            foreach (Row row in _sheet.Rows)
            {
                List<ICell> matrixRow = new List<ICell>();
                foreach (Cell cell in row.Cells)
                {
                    (int rowIndex, int columnIndex) = cell.GetZeroBasedPosition();
                    ICell matrixCell = new Models.Cell()
                    {
                        RowIndex = rowIndex,
                        ColumnIndex = columnIndex,
                        Value = cell.Value,
                    };

                    matrixRow.Add(matrixCell);
                }

                matrix.Add(matrixRow);
            }

            return matrix;
        }
    }
}
