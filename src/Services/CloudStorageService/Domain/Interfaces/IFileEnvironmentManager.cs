namespace CloudStorageService.Domain.Interfaces;


using Entities;



public interface IFileEnvironmentManager
{
    IEnumerable<FileEntity> GetFiles(ref Guid? relativePathId);
    IEnumerable<FileEntity> DeleteFile(Guid? relativePathId);
    IEnumerable<FileEntity> RenameFile(Guid? relativePathId, string newFileName);
}


