using System;
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

        internal static int ExcelColumnNumberStringToZeroBasedIndex(string colAdress)
        {
            int[] digits = new int[colAdress.Length];
            for (int i = 0; i < colAdress.Length; ++i)
            {
                digits[i] = Convert.ToInt32(colAdress[i]) - 64;
            }

            int mul = 1; 
            int res = 0;
            for (int pos = digits.Length - 1; pos >= 0; --pos)
            {
                res += digits[pos] * mul;
                mul *= 26;
            }

            return res - 1;
        }
    }
}
