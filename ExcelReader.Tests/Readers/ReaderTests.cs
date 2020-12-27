using ExcelReader.Readers;
using NUnit.Framework;
using System;
using System.IO;

namespace ExcelReader.Tests.Readers
{
    [TestFixture]
    internal class ReaderTests
    {
        [SetUp]
        public void Setup()
        {
            _reader = new Reader();
        }

        [Test]
        public void Read_WhenPassedNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _reader.Read(null));
        }

        [Test]
        public void Read_WhenPassedNotExistingFile_ThrowsArgumentException()
        {
            FileInfo nonExistingFile = new FileInfo("c://this_surely_does_not/exists.xlsx");
            Assert.Throws<ArgumentException>(() => _reader.Read(nonExistingFile));
        }

        private IReader _reader;
    }
}
