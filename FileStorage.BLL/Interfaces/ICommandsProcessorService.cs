using System.Collections.Generic;

namespace FileStorage.BLL.Interfaces
{
    public interface ICommandsProcessorService
    {
        void ProcessCommands(List<string> commands);
    }
}
