namespace CloudStorageService.Infrastructure;

using CloudStorageService.Domain.Entities;



public class FolderMetadata : Metadata
{
}


public class FolderAction : FileSystemItemAction
{
    public FolderAction(Metadata data) : base (data)
    {
        _data = data;
    }

    public override string Get()
    {
        return "folder";
    }
}


public class FolderFactory : FileSystemItemFactory
{

    public override Metadata GetMetadata()
    {
        return new FolderMetadata();
    }

    public override FileSystemItemAction GetAction(Metadata data)
    {
        return new FolderAction(data);
    }
}





public class FileMetadata : Metadata
{
}


public class FileAction : FileSystemItemAction
{
    public FileAction(Metadata data) : base (data)
    {
        _data = data;
    }

    public override string Get()
    {
        return "file";
    }
}


public class FileFactory : FileSystemItemFactory
{

    public override Metadata GetMetadata()
    {
        return new FileMetadata();
    }

    public override FileSystemItemAction GetAction(Metadata data)
    {
        return new FileAction(data);
    }
}