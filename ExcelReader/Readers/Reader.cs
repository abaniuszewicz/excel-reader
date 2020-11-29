using ExcelReader.Sets;
using ExcelReader.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace ExcelReader.Readers
{
    public sealed class Reader : IReader
    {
        public ISet Read(FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file), "File cannot be null");
            if (!file.Exists)
                throw new ArgumentException($"File {file.FullName} does not exist", nameof(file));

            _extractionDirectory = GetExtractionDirectory();

            try
            {
                Unzipper.Unzip(file, _extractionDirectory);

                XmlDocument workbook = GetWorkbook();
                XmlDocument style = GetStyles();
                XmlDocument sharedStrings = GetSharedStrings();
                IEnumerable<XmlDocument> sheets = GetSheets();

                return new Set(workbook, style, sharedStrings, sheets);
            }
            finally
            {
                _extractionDirectory.Delete(recursive: true);
            }

            return null;
        }

        private DirectoryInfo GetExtractionDirectory()
        {
            DirectoryInfo directory;
            do
            {
                string path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                directory = new DirectoryInfo(path);
            }
            while (directory.Exists); // loop until we get unique path
            return directory;
        }

        private XmlDocument GetWorkbook()
        {
            DirectoryInfo woorkbookDirectory = new DirectoryInfo(Path.Combine(_extractionDirectory.FullName, "xl"));
            XmlDocument xml = new XmlDocument();
            xml.Load(woorkbookDirectory.GetFiles("woorkbook.xml").First().FullName);
            return xml;
        }

        private IEnumerable<XmlDocument> GetSheets()
        {
            DirectoryInfo sheetDirectory = new DirectoryInfo(Path.Combine(_extractionDirectory.FullName, "xl", "worksheets"));
            foreach (FileInfo sheet in sheetDirectory.GetFiles("*.xml"))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(sheet.FullName);
                yield return xml;
            }

        }

        private XmlDocument GetStyles()
        {
            DirectoryInfo styleDirectory = new DirectoryInfo(Path.Combine(_extractionDirectory.FullName, "xl"));
            XmlDocument xml = new XmlDocument();
            xml.Load(styleDirectory.GetFiles("styles.xml").First().FullName);
            return xml;
        }

        private XmlDocument GetSharedStrings()
        {
            DirectoryInfo sharedStringsDirectory = new DirectoryInfo(Path.Combine(_extractionDirectory.FullName, "xl"));
            XmlDocument xml = new XmlDocument();
            xml.Load(sharedStringsDirectory.GetFiles("sharedStrings.xml").First().FullName);
            return xml;
        }

        private DirectoryInfo _extractionDirectory;
    }
}
