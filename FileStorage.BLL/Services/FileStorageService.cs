using System.IO;
using FileStorage.BLL.Interfaces;
using FileStorage.DAL.Interfaces;

namespace FileStorage.BLL.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly ICustomFileRepository _repository;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);


        public FileStorageService(ICustomFileRepository repository)
        {
            _repository = repository;
        }


        public void RemoveFile(FileInfo fileInfo)
        {
            var isFileExists = fileInfo.Exists;

            if (isFileExists == false)
            {
                Log.Info($"Can't remove {fileInfo.Name}");
                return;
            }

            _repository.RemoveFile(fileInfo);
        }
    }
}
