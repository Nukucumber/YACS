// Application/UseCases/GetDirectoryContents/GetDirectoryContentsHandler.cs
namespace CloudStorageService.Application.UseCases;


using Domain.Interfaces;
using DTOs;

public class GetDirectoryContentsHandler
{
    private readonly IFileEnvironmentManager _fileEnvironmentManager;

    public GetDirectoryContentsHandler(IFileEnvironmentManager fileEnvironmentManager)
    {
        _fileEnvironmentManager = fileEnvironmentManager;                                                                                                    
    }

    public DirectoryContentsDto Handle()
    {
        var path = _fileEnvironmentManager.GetCurrentDirectory();
        var files = _fileEnvironmentManager.GetFiles(path);
        
        return new DirectoryContentsDto
        (
            path!,
            files.ToList()
        );
    }
}
