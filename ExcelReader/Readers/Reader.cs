using ExcelReader.Sets;
using ExcelReader.Utilities;
using System;
using System.IO;

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

            DirectoryInfo extractionDirectory = GetExtractionDirectory();
            try
            {
                Unzipper.Unzip(file, extractionDirectory);
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
