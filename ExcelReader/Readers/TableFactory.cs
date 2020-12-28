using ExcelReader.Deserialization.SharedStringsModels;
using ExcelReader.Deserialization.SheetModels;
using ExcelReader.Deserialization.StylesModels;
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
            throw new NotImplementedException();
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
                    throw new NotImplementedException();
                }

                matrix.Add(matrixRow);
            }

            return matrix;
        }
    }
}
