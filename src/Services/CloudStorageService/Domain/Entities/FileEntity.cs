namespace CloudStorageService.Domain.Entities;



public class FileEntity(string name, long size, FileType type)
{
    public string Name { get; } = name;
    public long Size { get; } = size;

    public FileType Type { get; } = type;
}

public enum FileType
{
    File,
    Folder
}
