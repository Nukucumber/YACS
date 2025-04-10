namespace CloudStorageService.Presentation.Controllers;


using Application.UseCases;
using Application.DTOs;

using Microsoft.AspNetCore.Mvc;


[Route("[controller]")]
public class FileController : ControllerBase
{
    readonly GetDirectoryContentsHandler getDirectoryContentsHandler;

    public FileController(GetDirectoryContentsHandler getDirectoryContentsHandler)
    {
        this.getDirectoryContentsHandler = getDirectoryContentsHandler;
    }

    [HttpGet]
    public DirectoryContentsDto TestRun()
    {
        try
        {
            return getDirectoryContentsHandler.Handle();
        }
        catch
        {
            return default!;
        }
    }
}