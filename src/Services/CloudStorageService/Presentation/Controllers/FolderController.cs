namespace CloudStorageService.Presentation.Controllers;


using Application.UseCases;
using Application.DTOs;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



[Route("[controller]")]
public class FolderController : ControllerBase
{
    readonly GetDirectoryContentsHandler getDirectoryContentsHandler;
    readonly AddFileToCurrentDirectoryHandler addFileToCurrentDirectoryHandler;


    public FolderController(GetDirectoryContentsHandler getDirectoryContentsHandler, AddFileToCurrentDirectoryHandler addFileToCurrentDirectoryHandler)
    {
        this.getDirectoryContentsHandler = getDirectoryContentsHandler;
        this.addFileToCurrentDirectoryHandler = addFileToCurrentDirectoryHandler;
    }



    [DisableRequestSizeLimit]
    [HttpPost]
    public async Task<int> AddFolder([FromForm] Guid pathId, [FromForm] List<IFormFile> files, [FromForm] string folderName)
    {
        Console.WriteLine($"\n\n\n\n{files.First().FileName}\n\n\n\n\n");
        var uploadFileDto = files.Select(file =>
                                new UploadFileDto
                                {
                                    FileName = file.FileName,
                                    Content = file.OpenReadStream()
                                }).ToList();

        var response = await addFileToCurrentDirectoryHandler.Handle(pathId, uploadFileDto);

        return response;
    }

    // [HttpGet]
    // public GetDirEnvironment()
    // {

    // }

    [HttpGet]
    public DirectoryContentsDto GetDirEnvironment([FromQuery] Guid pathId)
    {
        try
        {
            return getDirectoryContentsHandler.Handle(pathId);
        }
        catch
        {
            return default!;
        }
    }
}