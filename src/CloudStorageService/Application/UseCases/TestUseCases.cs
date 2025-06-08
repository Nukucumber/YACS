namespace CloudStorageService.Application.UseCases;

using Domain.Entities;
using Builders;

public class TestUseCases
{
    private IFileSystemItemTypeDefinitor _definitor;


    public TestUseCases(IFileSystemItemTypeDefinitor definitor)
    {
        _definitor = definitor;
    }


    public FileSystemItem Handle(string? param = null)
    {
        var fileBuilder = new FileSystemItemBuilder(_definitor);

        var file = fileBuilder.Build(param);

        return file;
    }
}