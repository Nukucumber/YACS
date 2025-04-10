namespace CloudStorageService.Application.DTOs;


using Domain.Entities;


public class DirectoryContentsDto
{
    public string path { get; } = string.Empty;
    public List<FileEntity> files { get; } = [];


    public DirectoryContentsDto(string path, List<FileEntity> files)
    {
        this.path = path;
        this.files = files;
    }
}