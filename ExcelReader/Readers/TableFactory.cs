using ExcelReader.Deserialization.SharedStringsModels;
using ExcelReader.Deserialization.SheetModels;
using ExcelReader.Deserialization.StylesModels;
using Microsoft.Extensions.Logging;
using System;

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
            throw new NotImplementedException();
        }
    }
}
