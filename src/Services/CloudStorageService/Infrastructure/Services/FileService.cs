namespace CloudStorageService.Infrastructure.Services;


using CloudStorageService.Domain.Entities;
using CloudStorageService.Domain.Interfaces;


public static class FileService
{

    public class FileEnvironmentManager : IFileEnvironmentManager
    {
        public string GetCurrentDirectory()
        {
            return Environment.CurrentDirectory;
        }

        public IEnumerable<FileEntity> GetFiles(string directoryPath)
        {
            var directoryInfo = FileSystemHelper.EnumerateFileSystemInfos(directoryPath);
            var res = from file in directoryInfo select new FileEntity(file.Name, file is DirectoryInfo ? 0 : ((FileInfo)file).Length, file is DirectoryInfo ? FileType.Folder : FileType.File);
            return res;
        }
    }



    private class FileSystemHelper
    {
        public static IEnumerable<FileSystemInfo> EnumerateFileSystemInfos(
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