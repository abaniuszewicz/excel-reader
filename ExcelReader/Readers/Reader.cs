using ExcelReader.Deserialization;
using ExcelReader.Deserialization.SharedStringsModels;
using ExcelReader.Deserialization.SheetModels;
using ExcelReader.Deserialization.StylesModels;
using ExcelReader.Deserialization.WorkbookModels;
using ExcelReader.Sets;
using ExcelReader.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExcelReader.Readers
{
    public sealed class Reader : IReader
    {
        private DirectoryInfo _extractionDirectory;
        private readonly ILogger _logger;

        public Reader(ILogger logger)
        {
            _logger = logger;
        }

        public ISet Read(FileInfo file)
        {
            if (file is null)
            {
                _logger.LogError("File {0} is null", file.Name);
                throw new ArgumentNullException(nameof(file), "File cannot be null");
            }
            if (!file.Exists)
            {
                _logger.LogError("File {0} does not exist", file.Name);
                throw new ArgumentException($"File {file.FullName} does not exist", nameof(file));
            }

            _extractionDirectory = Utils.GetUniqueTempDirectory();

            try
            {
                _logger.LogDebug("Extracting {0} to {1}...", file.Name, _extractionDirectory.FullName);
                Unzipper.Unzip(file, _extractionDirectory);
                _logger.LogDebug("Extraction complete");
                Workbook workbook = GetWorkbook();
                SharedStringTable sharedStringTable = GetSharedStringTable();
                IEnumerable<Sheet> sheets = GetSheets();
                Styles styles = GetStyles();
                throw new NotImplementedException();
            }
            finally
            {
                _extractionDirectory.Delete(recursive: true);
            }
        }

        private Workbook GetWorkbook()
        {
            DirectoryInfo workbookDirectory = new DirectoryInfo(Path.Combine(_extractionDirectory.FullName, "xl"));
            FileInfo workbookFile = workbookDirectory.GetFiles("workbook.xml").First();
            return new Deserializer<Workbook>().Deserialize(workbookFile);
        }

        private Styles GetStyles()
        {
            DirectoryInfo stylesDirectory = new DirectoryInfo(Path.Combine(_extractionDirectory.FullName, "xl"));
            FileInfo stylesFile = stylesDirectory.GetFiles("styles.xml").First();
            return new Deserializer<Styles>().Deserialize(stylesFile);
        }

        private SharedStringTable GetSharedStringTable()
        {
            DirectoryInfo sharedStringsDirectory = new DirectoryInfo(Path.Combine(_extractionDirectory.FullName, "xl"));
            FileInfo sharedStringsFile = sharedStringsDirectory.GetFiles("sharedStrings.xml").First();
            return new Deserializer<SharedStringTable>().Deserialize(sharedStringsFile);
        }

        private IEnumerable<Sheet> GetSheets()
        {
            DirectoryInfo sheetDirectory = new DirectoryInfo(Path.Combine(_extractionDirectory.FullName, "xl", "worksheets"));
            foreach (FileInfo sheetFile in sheetDirectory.GetFiles("*.xml"))
                yield return new Deserializer<Sheet>().Deserialize(sheetFile);
        }
    }
}
