namespace CloudStorageService.Application.UseCases;

using Interfaces;
using DTOs;

public class AddFileToCurrentDirectoryHandler
{
    private readonly IUploadMultipleExtension fileEnvironmentManager;


    public AddFileToCurrentDirectoryHandler(IUploadMultipleExtension fileEnvironmentManager)
    {
        this.fileEnvironmentManager = fileEnvironmentManager;
    }



    public async Task<int> Handle(Guid? pathId, List<UploadFileDto> uploadFiles)
    {
        var result = await fileEnvironmentManager.UploadFilesAsync(pathId, uploadFiles);

        return result;
    }
}
