using Autofac;
using ExcelReader.Demo.CustomImplementations;
using ExcelReader.Extensions.Autofac;
using ExcelReader.Readers;
using System.Data;
using System.IO;

namespace ExcelReader.Demo
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            FileInfo file = new FileInfo("SampleFiles/MultipleSheets.xlsx");

            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterCustomExcelReader()
                .UseReader<CustomReader>()
                .Configure();
            IContainer container = containerBuilder.Build();

            IReader reader = container.Resolve<IReader>();
            reader.Read(file);
        }
    }
}
