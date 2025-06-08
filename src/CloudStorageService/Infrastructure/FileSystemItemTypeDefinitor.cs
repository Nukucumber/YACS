namespace CloudStorageService.Infrastructure;

using Application.Builders;
using Domain.Entities;



public class FileSystemItemTypeDefinitor : IFileSystemItemTypeDefinitor
{
    public FileSystemItemFactory Definit(string? param = null)
    {
        switch (param)
        {
            case "d":
                return new FolderFactory();
            case "f":
                return new FileFactory();
            default:
                throw new Exception("File system item's type is not definited");
        }
    }
}