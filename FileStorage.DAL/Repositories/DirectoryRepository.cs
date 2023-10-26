using System.IO;
using FileStorage.DAL.Interfaces;

namespace FileStorage.DAL.Repositories
{
    public class DirectoryRepository : IDirectoryRepository
    {
        public FileInfo[] GetInformationAboutAllFilesInDirectory(DirectoryInfo directory)
        {
            return directory.GetFiles();
        }

        public DirectoryInfo GetDirectoryInfo(string pathToDirectory)
        {
            return new DirectoryInfo(pathToDirectory);
        }
    }
}
