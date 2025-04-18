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



    public DirectoryContentsDto Handle(Guid? pathId = null)
    {

        var files = fileEnvironmentManager.GetFiles(ref pathId);


        return new DirectoryContentsDto { CurrentPathId = (Guid)pathId!, Files = files.ToList() };
    }
}
