namespace CloudStorageService.Domain.Entities;



public class FileSystemItem
{
    protected Metadata _data;
    protected FileSystemItemAction _action;

    public FileSystemItem(FileSystemItemFactory factory)
    {
        _data = factory.GetMetadata();
        _action = factory.GetAction(_data);
    }


    public string GetData()
    {
        return _action.Get();
    }
}



public abstract class Metadata
{
    public string Path { get; protected set; } = string.Empty;
    public string Name { get; protected set; } = string.Empty;
}


public abstract class FileSystemItemAction
{
    protected Metadata _data;
    protected FileSystemItemAction(Metadata data)
    {
        _data = data;
    }
    public abstract string Get();
}


public abstract class FileSystemItemFactory
{
    public abstract Metadata GetMetadata();
    public abstract FileSystemItemAction GetAction(Metadata data);
}