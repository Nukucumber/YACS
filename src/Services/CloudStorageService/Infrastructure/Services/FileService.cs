namespace CloudStorageService.Infrastructure.Services;


using Domain.Entities;
using Application.Interfaces;
using Application.DTOs;
using Options;

using Microsoft.Extensions.Options;

public static class FileService
{
    public partial class FileEnvironmentManager : IUploadMultipleExtension
    {
        readonly IOptions<FileStorageOption> options;
        readonly Dictionary<Guid, string> relativePathDictionary;

        public FileEnvironmentManager(IOptions<FileStorageOption> options)
        {
            this.options = options;
            relativePathDictionary = new Dictionary<Guid, Dictionary<string, Guid>>{
                {Guid.Parse("b0d4ce5d-2757-4699-948c-cfa72ba94f86"), "wafawf/1"},
                {Guid.Parse("7febf16f-651b-43b0-a5e3-0da8da49e90d"), "fff"},
                {Guid.Parse("00000000-0000-0000-0000-000000000000"), ""}
            };
        }



        public async Task<int> UploadFilesAsync(Guid? relativePathId, List<UploadFileDto> files, CancellationToken cancellationToken = default)
        {
            var fullPath = GetFullPath(options.Value.RootUploadPath, ref relativePathId);
            Console.WriteLine($"\n\n\n{Path.Combine(fullPath)}\n\n\n");

            try
            {
                foreach (var file in files)
                {
                    using (var stream = new FileStream(Path.Combine(fullPath, file.FileName), FileMode.Create))
                    {
                        Console.WriteLine($"\n\n\n{Path.Combine(fullPath, file.FileName)}\n\n\n");
                        await file.Content.CopyToAsync(stream);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n{fullPath}\n\n{ex.Message}\n\n{ex.StackTrace}\n\n\n");
                return -1;
            }
            return 0;
        }


        public IEnumerable<FileEntity> DeleteFile(Guid? relativePathId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<FileEntity> GetFiles(ref Guid? relativePathId)
        {
            var fullPath = GetFullPath(options.Value.RootUploadPath, ref relativePathId);

            var directoryInfo = EnumerateFileSystemInfos(fullPath);
            var res = from file in directoryInfo
                      select new FileEntity(
                        file.Name,
                        file is DirectoryInfo ? 0 : ((FileInfo)file).Length,
                        file is DirectoryInfo ? FileType.Folder : FileType.File);

            return res;
        }

        public IEnumerable<FileEntity> RenameFile(Guid? relativePathId, string newFileName)
        {
            throw new NotImplementedException();
        }



        private string GetFullPath(string rootPath, ref Guid? relativePathId, string? fileName = "")
        {
            var normalizedRootPath = PathNormalizing(rootPath);
            
            relativePathId ??= Guid.Empty;

            var relativePath = relativePathDictionary[(Guid)relativePathId];

            var fullPath = Path.Combine(normalizedRootPath, relativePath);

            return fullPath;
        }

        private string PathNormalizing(string path)
        {
            var normalizedPath = string.Join('/',
                    from dir in path.Replace("\\", "/").Split("/")
                    where !string.IsNullOrEmpty(dir.TrimStart())
                    select dir);

            return normalizedPath;
        }

        private IEnumerable<FileSystemInfo> EnumerateFileSystemInfos(
            string path,
            string searchPattern = "*",
            SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            foreach (var entry in Directory.EnumerateFileSystemEntries(path, searchPattern, searchOption))
            {
                FileSystemInfo fsInfo;

                try
                {
                    var attributes = File.GetAttributes(entry);
                    if (attributes.HasFlag(FileAttributes.Directory))
                    {
                        fsInfo = new DirectoryInfo(entry);
                    }
                    else
                    {
                        fsInfo = new FileInfo(entry);
                    }
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    continue;
                }

                yield return fsInfo;
            }
        }
    }

}