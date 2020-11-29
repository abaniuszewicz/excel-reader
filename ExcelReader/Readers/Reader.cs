using ExcelReader.Sets;
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

            throw new NotImplementedException();
        }
    }
}
