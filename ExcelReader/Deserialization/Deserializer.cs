using System;
using System.IO;
using System.Xml.Serialization;

namespace ExcelReader.Deserialization
{
    internal class Deserializer<T>
    {
        internal T Deserialize(FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file), "File cannot be null");
            if (!file.Exists)
                throw new ArgumentException($"File {file.FullName} does not exist", nameof(file));

            using FileStream stream = file.OpenRead();
            return (T)_serializer.Deserialize(stream);
        }

        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(T));
    }
}
