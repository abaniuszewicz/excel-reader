using ExcelReader.Sets;
using ExcelReader.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace ExcelReader.Readers
{
    public sealed class Reader : IReader
    {
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

            DirectoryInfo extractionDirectory = GetExtractionDirectory();
            try
            {
                _logger.LogDebug("Extracting {0} to {1}...", file.Name, extractionDirectory.FullName);
                Unzipper.Unzip(file, extractionDirectory);
                _logger.LogDebug("Extraction complete");
            }
            finally
            {
                extractionDirectory.Delete(true);
            }
            throw new NotImplementedException();
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
    }
}
