using System.IO;
using System.Collections.Generic;

namespace FileStorage.BLL.Interfaces
{
    public interface IParamsService
    {
        FileInfo[] GetFilesWithConditions(Dictionary<string, string> commandsMap, DirectoryInfo directoryInfo);
    }
}
