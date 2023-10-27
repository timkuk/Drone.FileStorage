using Autofac;
using FileStorage.BLL.Services;
using FileStorage.BLL.Interfaces;

namespace FileStorage.Representation
{
    public class ContainerConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ParserService>().As<IParserService>();
            builder.RegisterType<ParamsService>().As<IParamsService>();
            builder.RegisterType<FileStorageService>().As<IFileStorageService>();
            builder.RegisterType<CommandsProcessorService>().As<ICommandsProcessorService>();
        }
    }
}
