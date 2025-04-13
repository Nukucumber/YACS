namespace CloudStorageService.Domain.Interfaces;


using Entities;



public interface IFileEnvironmentManager
{
    string GetCurrentDirectory(string currentPath = "");
    IEnumerable<FileEntity> GetFiles(string directoryPath);
    IEnumerable<FileEntity> AddFile(string fullFilePath);
    IEnumerable<FileEntity> DeleteFile(string fullFilePath);
    IEnumerable<FileEntity> RenameFile(string fullFilePath, string newFileName);
}