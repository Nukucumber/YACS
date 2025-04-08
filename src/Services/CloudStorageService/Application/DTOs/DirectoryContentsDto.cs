namespace CloudStorageService.Application.DTOs;


using Domain.Entities;


public class DirectoryContentsDto(string path, List<FileEntity> files)
{
    string Path { get; } = path;
    List<FileEntity> Files { get; } = files;
}