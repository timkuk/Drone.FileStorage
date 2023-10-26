using System.IO;

namespace FileStorage.DAL.Interfaces
{
    public interface ICustomFileRepository
    {
        void RemoveFile(FileInfo file);
    }
}
