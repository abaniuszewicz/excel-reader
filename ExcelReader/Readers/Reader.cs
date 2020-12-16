using ExcelReader.Deserialization;
using ExcelReader.Deserialization.SharedStringsModels;
using ExcelReader.Deserialization.SheetModels;
using ExcelReader.Deserialization.StylesModels;
using ExcelReader.Deserialization.WorkbookModels;
using ExcelReader.Sets;
using ExcelReader.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExcelReader.Readers
{
    public sealed class Reader : IReader
    {
        private DirectoryInfo _extractionDirectory;

        public ISet Read(FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file), "File cannot be null");
            if (!file.Exists)
                throw new ArgumentException($"File {file.FullName} does not exist", nameof(file));

            _extractionDirectory = Utils.GetUniqueTempDirectory();

            try
            {
                Unzipper.Unzip(file, _extractionDirectory);
                Workbook workbook = GetWorkbook();
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
            throw new NotImplementedException();
        }

        private SharedStrings GetSharedStrings()
        {
            DirectoryInfo sharedStringsDirectory = new DirectoryInfo(Path.Combine(_extractionDirectory.FullName, "xl"));
            FileInfo sharedStringsFile = sharedStringsDirectory.GetFiles("sharedStrings.xml").First();
            throw new NotImplementedException();
        }

        private IEnumerable<Sheet> GetSheets()
        {
            DirectoryInfo sheetDirectory = new DirectoryInfo(Path.Combine(_extractionDirectory.FullName, "xl", "worksheets"));
            foreach (FileInfo sheetFile in sheetDirectory.GetFiles("*.xml"))
            {
            }
            throw new NotImplementedException();
        }
    }
}
