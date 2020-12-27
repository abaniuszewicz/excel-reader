using System.IO;

namespace ExcelReader.Utilities
{
    internal static class Utils
    {
        internal static DirectoryInfo GetUniqueTempDirectory()
        {
            while (true)
            {
                string path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                DirectoryInfo directory = new DirectoryInfo(path);

                // loop until we find unique, new path
                if (!directory.Exists) 
                    return directory;
            }
        }
    }
}
