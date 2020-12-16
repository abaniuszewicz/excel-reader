using ExcelReader.Deserialization;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;

namespace ExcelReader.Tests.Deserialization
{
    [TestFixture]
    internal class DeserializerTests
    {
        [SetUp]
        public void Setup()
        {
            _deserializer = new Deserializer<object>();
        }

        [Test]
        public void Deserialize_WhenPasssedNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _deserializer.Deserialize(null));
        }

        [Test]
        public void Deserialize_WhenPassedNotExistingFile_ThrowsArgumentException()
        {
            FileInfo nonExistingFile = new FileInfo("c://this_surely_does_not/exists.xlsx");

            Assert.Throws<ArgumentException>(() => _deserializer.Deserialize(nonExistingFile));
        }

        private Deserializer<object> _deserializer;
    }
}
