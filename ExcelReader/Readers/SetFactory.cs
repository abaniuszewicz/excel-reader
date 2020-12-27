using ExcelReader.Deserialization.SharedStringsModels;
using ExcelReader.Deserialization.SheetModels;
using ExcelReader.Deserialization.StylesModels;
using ExcelReader.Deserialization.WorkbookModels;
using ExcelReader.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ExcelReader.Readers
{
    internal class SetFactory
    {
        private readonly ILogger _logger;
        private readonly Workbook _workbook;
        private readonly IEnumerable<Sheet> _sheets;
        private readonly Styles _styles;
        private readonly SharedStringTable _sharedStrings;

        public SetFactory(ILogger logger, Workbook workbook, IEnumerable<Sheet> sheets, Styles styles, SharedStringTable sharedStrings)
        {
            _logger = logger;
            _workbook = workbook ?? throw new ArgumentNullException(nameof(workbook));
            _sheets = sheets ?? throw new ArgumentNullException(nameof(sheets));
            _styles = styles ?? throw new ArgumentNullException(nameof(styles));
            _sharedStrings = sharedStrings ?? throw new ArgumentNullException(nameof(sharedStrings));
        }

        public ISet Create()
        {
            Set set = new Set();

            // TODO: this approach is very naive - we should not assume that tables are ordered. Consider using workboom.xml.rels to link appropriate sheets.
            foreach (Sheet sheet in _sheets)
            {
                ITable table = new TableFactory(_logger, sheet, _styles, _sharedStrings).Create();
                set.AddTable(table);
            }

            return set;
        }
    }
}
