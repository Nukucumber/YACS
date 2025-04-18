namespace CloudStorageService.Application.DTOs;


using Domain.Entities;


public class DirectoryContentsDto
{
    public Guid CurrentPathId { get; set; }
    public List<FileEntity> Files { get; set; } = [];
}