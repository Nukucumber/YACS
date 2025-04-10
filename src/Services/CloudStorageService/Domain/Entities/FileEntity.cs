namespace CloudStorageService.Domain.Entities;



public class FileEntity
{
    public string name { get; } = string.Empty;
    public long size { get; } = default;
    public FileType type { get; } = FileType.File;


    public FileEntity(string name, long size, FileType type)
    {
        this.name = name;
        this.size = size;
        this.type = type;
    }
}

public enum FileType
{
    File,
    Folder
}
