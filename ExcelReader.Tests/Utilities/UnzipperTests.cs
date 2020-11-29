using ExcelReader.Utilities;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;

namespace ExcelReader.Tests.Utilities
{
    [TestFixture]
    public class UnzipperTests
    {
        [SetUp]
        public void Setup()
        {
            _fileThatExists = new FileInfo(Assembly.GetExecutingAssembly().Location);
            _directoryThatExists = _fileThatExists.Directory;
        }

        [Test]
        public void Unzip_WhenPasssedNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Unzipper.Unzip(null, _directoryThatExists));
            Assert.Throws<ArgumentNullException>(() => Unzipper.Unzip(_fileThatExists, null));
            Assert.Throws<ArgumentNullException>(() => Unzipper.Unzip(null, null));
        }

        [Test]
        public void Unzip_WhenPassedNotExistingFile_ThrowsArgumentException()
        {
            FileInfo nonExistingFile = new FileInfo("c://this_surely_does_not/exists.xlsx");

            Assert.Throws<ArgumentException>(() => Unzipper.Unzip(nonExistingFile, _directoryThatExists));
        }

        private FileInfo _fileThatExists;
        private DirectoryInfo _directoryThatExists;
    }
}
