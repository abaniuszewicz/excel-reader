using Autofac;
using ExcelReader.Demo.CustomImplementations;
using ExcelReader.Extensions.Autofac;
using ExcelReader.Readers;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System.Data;
using System.IO;

using MicrosoftLogging = Microsoft.Extensions.Logging;

namespace ExcelReader.Demo
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            FileInfo file = new FileInfo("SampleFiles/MultipleSheets.xlsx");

            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterExcelReaderWithDefaults()
                .RegisterInstance(ConfigureLogger()).As<MicrosoftLogging.ILogger>().SingleInstance();
            IContainer container = containerBuilder.Build();

            IReader reader = container.Resolve<IReader>();
            reader.Read(file);
        }

        private static MicrosoftLogging.ILogger ConfigureLogger()
        {
            Serilog.ILogger logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss:fff} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .MinimumLevel.Debug()
                .CreateLogger();

            LoggerFactory factory = new LoggerFactory();
            factory.AddSerilog(logger);
            return factory.CreateLogger<MicrosoftLogging.ILogger>();
        }
    }
}
