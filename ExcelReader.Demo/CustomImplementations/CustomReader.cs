using ExcelReader.Readers;
using System.IO;

namespace ExcelReader.Demo.CustomImplementations
{
    internal sealed class CustomReader : IReader
    {
        public ISet Read(FileInfo file)
        {
            return null;
        }
    }
}
