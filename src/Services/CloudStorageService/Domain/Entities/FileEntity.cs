namespace CloudStorageService.Domain.Entities;



public class FileEntity
{
    public string fullName { get; } = string.Empty;
    public long size { get; } = default;
    public FileType type { get; } = FileType.File;
    public Guid guid { get; } = Guid.Empty;


    public FileEntity(string fullName, long size, FileType type, Guid guid)
    {
        this.fullName = fullName;
        this.size = size;
        this.type = type;
        this.guid = guid;
    }
}
