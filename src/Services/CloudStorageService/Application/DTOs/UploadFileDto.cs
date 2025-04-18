namespace CloudStorageService.Application.DTOs;



public class UploadFileDto
{
    public required string FileName { get; set; }
    public required Stream Content { get; set; }
}