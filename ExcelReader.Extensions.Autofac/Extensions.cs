using Autofac;
using ExcelReader.Readers;

namespace ExcelReader.Extensions.Autofac
{
    public static class Extensions
    {
        public static ContainerBuilder RegisterExcelReaderWithDefaults(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Reader>().As<IReader>().InstancePerLifetimeScope();
            return containerBuilder;
        }

        public static CustomImplementationConfigurator RegisterCustomExcelReader(this ContainerBuilder containerBuilder)
            => new CustomImplementationConfigurator(containerBuilder);
    }
}