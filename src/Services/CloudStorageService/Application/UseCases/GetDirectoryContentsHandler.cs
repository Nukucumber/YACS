namespace CloudStorageService.Application.UseCases;


using Domain.Interfaces;
using DTOs;



public class GetDirectoryContentsHandler
{
    private readonly IFileEnvironmentManager fileEnvironmentManager;


    public GetDirectoryContentsHandler(IFileEnvironmentManager fileEnvironmentManager)
    {
        this.fileEnvironmentManager = fileEnvironmentManager;                                                                                                    
    }



    public DirectoryContentsDto Handle(string currentPath = "")
    {

        var path = fileEnvironmentManager.GetCurrentDirectory(currentPath);
        var files = fileEnvironmentManager.GetFiles(path);
        
        return new DirectoryContentsDto
        (
            path!,
            files.ToList()
        );
    }
}
