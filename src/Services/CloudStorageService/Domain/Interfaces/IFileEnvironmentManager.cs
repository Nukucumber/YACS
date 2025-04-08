namespace CloudStorageService.Domain.Interfaces;


using Entities;



public interface IFileEnvironmentManager
{
    string GetCurrentDirectory();
    IEnumerable<FileEntity> GetFiles(string directoryPath);
}