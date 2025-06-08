namespace CloudStorageService.Application.Builders;

using CloudStorageService.Domain.Entities;



class FileSystemItemBuilder
{
    private IFileSystemItemTypeDefinitor? _typeDefinitor;

    public FileSystemItemBuilder(IFileSystemItemTypeDefinitor typeDefinitor)
    {
        _typeDefinitor = typeDefinitor;
    }


    public FileSystemItem Build(string? param = null)
    {
        if (_typeDefinitor == null)
            throw new Exception("Definitor is not definited");


        var fileSystemItemType = _typeDefinitor.Definit(param);

        if (fileSystemItemType == null)
            throw new Exception("File system item's type is not definited");

        return new FileSystemItem(fileSystemItemType);
    }
}