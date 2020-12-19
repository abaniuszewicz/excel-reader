using Autofac;
using ExcelReader.Readers;

namespace ExcelReader.Extensions.Autofac
{
    public class CustomImplementationConfigurator
    {
        private readonly ContainerBuilder _containerBuilder;

        public CustomImplementationConfigurator(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        public CustomImplementationConfigurator UseReader<TReader>() where TReader : class, IReader
        {
            _containerBuilder.RegisterType<TReader>()
                .As<IReader>()
                .InstancePerLifetimeScope();

            return this;
        }

        public ContainerBuilder Configure()
        {
            _containerBuilder.RegisterType<Reader>().As<IReader>().InstancePerLifetimeScope().IfNotRegistered(typeof(IReader));
            return _containerBuilder;
        }
    }
}
