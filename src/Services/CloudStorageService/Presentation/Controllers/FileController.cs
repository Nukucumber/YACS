namespace CloudStorageService.Presentation.Controllers;


using Application.UseCases;
using Application.DTOs;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



[Route("[controller]")]
public class FileController : ControllerBase
{
    readonly AddFileToCurrentDirectoryHandler addFileToCurrentDirectoryHandler;


    public FileController(AddFileToCurrentDirectoryHandler addFileToCurrentDirectoryHandler)
    {
        this.addFileToCurrentDirectoryHandler = addFileToCurrentDirectoryHandler;
    }



    [DisableRequestSizeLimit]
    [HttpPost]
    public async Task<int> AddFile([FromForm] Guid pathId, [FromForm] List<IFormFile> files, [FromForm] string folderName)
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
}