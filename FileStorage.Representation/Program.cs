using System;
using Autofac;
using FileStorage.BLL;
using FileStorage.BLL.Interfaces;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace FileStorage.Representation
{
    public class Program
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

        private static void Main()
        {
            var builder = new ContainerBuilder();
            builder
                .RegisterModule<ContainerConfig>()
                .RegisterModule<DIConfigurationModule>();
            Log.Error("Start");
            var container = builder.Build();
            var service = container.Resolve<IParserService>();
            while (true)
            {
                try
                {
                    Console.WriteLine("Input some command");
                    var command = Console.ReadLine();
                    service.ParseUserInput(command);
                }
                catch (ArgumentOutOfRangeException arg)
                {
                    Log.Error("You input wrong command!Try again!" + arg.Message);
                }
            }
        }
    }
}
