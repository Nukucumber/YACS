namespace CloudStorageService.Application.Interfaces;


using Domain.Interfaces;
using DTOs;



public interface IUploadMultipleExtension : IFileEnvironmentManager
{
    //IReadOnlyList<UploadResult> with succsess saved files instead int as result
    Task<int> UploadFilesAsync(Guid? relativePathId, List<UploadFileDto> files, CancellationToken cancellationToken = default);
}