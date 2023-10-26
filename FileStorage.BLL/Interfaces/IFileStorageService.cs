using System.IO;

namespace FileStorage.BLL.Interfaces
{
    public interface IFileStorageService
    {
        void RemoveFile(FileInfo fileInfo);
    }
}
