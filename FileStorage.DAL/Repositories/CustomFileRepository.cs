using System.IO;
using FileStorage.DAL.Interfaces;

namespace FileStorage.DAL.Repositories
{
    public class CustomFileRepository : ICustomFileRepository
    {
        public void RemoveFile(FileInfo file)
        {
            file.Delete();
        }
    }
}
