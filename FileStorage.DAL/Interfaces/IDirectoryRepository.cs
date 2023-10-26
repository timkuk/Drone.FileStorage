using System.IO;

namespace FileStorage.DAL.Interfaces
{
    public interface IDirectoryRepository
    {
        FileInfo[] GetInformationAboutAllFilesInDirectory(DirectoryInfo directoryFiles);

        DirectoryInfo GetDirectoryInfo(string pathToDirectory);
    }
}
