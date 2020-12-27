using System.IO;

namespace ExcelReader.Readers
{
    public interface IReader
    {
        public ISet Read(FileInfo file);
    }
}
