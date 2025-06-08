namespace CloudStorageService.Application.Builders;

using CloudStorageService.Domain.Entities;



public interface IFileSystemItemTypeDefinitor
{
    public FileSystemItemFactory Definit(string? param = null);
}
