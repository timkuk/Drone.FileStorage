using System;
using System.Linq;
using FileStorage.BLL.Interfaces;
using System.Collections.Generic;
using FileStorage.DAL.Interfaces;

namespace FileStorage.BLL.Services
{
    public class CommandsProcessorService : ICommandsProcessorService
    {
        private readonly IDirectoryRepository _directoryRepository;

        private readonly IFileStorageService _fileStorage;

        private readonly IParamsService _paramsService;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);


        public CommandsProcessorService(
            IDirectoryRepository directoryRepository,
            IFileStorageService fileStorage,
            IParamsService paramsService)
        {
            _directoryRepository = directoryRepository;
            _fileStorage = fileStorage;
            _paramsService = paramsService;
        }


        public void ProcessCommands(List<string> splitCommands)
        {
            var command = splitCommands[0];
            switch (command)
            {
                case "clean.exe":
                    splitCommands.RemoveRange(0, 1);
                    var commandsMap = new Dictionary<string, string>();

                    for (var i = 0; i < splitCommands.Count - 1; i += 2)
                    {
                        commandsMap[splitCommands[i]] = splitCommands[i + 1];
                    }

                    var directory = commandsMap.SingleOrDefault(k => k is { Key: "d", Value: not null });

                    var pathToDirectory = directory.Value;
                    var directoryInfo = _directoryRepository.GetDirectoryInfo(pathToDirectory);
                    if (!directoryInfo.Exists)
                    {
                        Console.WriteLine($"Path to directory {pathToDirectory} not found\"");
                        Log.Info("Directory not found");
                        Environment.Exit(-2);
                    }

                    var filesByConditions = _paramsService.GetFilesWithConditions(commandsMap, directoryInfo);

                    foreach (var file in filesByConditions)
                    {
                        Console.WriteLine($"File {file.Name} has been removed . Size {file.Length}");
                        _fileStorage.RemoveFile(file);
                        Log.Info($"Files {file.Name} has been removed");
                    }
                    break;

                default:
                    Log.Error("Input not exists command!Try again");
                    break;
            }
        }
    }
}
