using ExcelReader.Readers;
using System.Data;
using System.IO;

namespace ExcelReader.Demo
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            FileInfo file = new FileInfo("SampleFiles/SingleSheet.xlsx");
            IReader reader = new Reader();
            reader.Read(file);
        }
    }
}
