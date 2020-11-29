using System;
using System.IO;
using System.IO.Compression;

namespace ExcelReader.Utilities
{
    internal static class Unzipper
    {
        internal static void Unzip(FileInfo file, DirectoryInfo extractTo)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file), "File cannot be null");
            if (!file.Exists)
                throw new ArgumentException($"File {file.FullName} does not exist", nameof(file));
            if (extractTo == null)
                throw new ArgumentNullException(nameof(extractTo), "Extraction directory cannot be null");

            ZipFile.ExtractToDirectory(file.FullName, extractTo.FullName);
        }
    }
}
