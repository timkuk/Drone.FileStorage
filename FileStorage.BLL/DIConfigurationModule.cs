using Autofac;
using FileStorage.DAL.Interfaces;
using FileStorage.DAL.Repositories;

namespace FileStorage.BLL
{
    public class DiConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DirectoryRepository>().As<IDirectoryRepository>();
            builder.RegisterType<CustomFileRepository>().As<ICustomFileRepository>();
        }
    }
}