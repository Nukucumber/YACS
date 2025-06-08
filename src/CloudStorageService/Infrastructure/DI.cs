namespace CloudStorageService.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

using Application.Builders;
using Application.UseCases;



public static class DI
{
    public static IServiceCollection Inject(this IServiceCollection services)
    {
        services.AddScoped<IFileSystemItemTypeDefinitor, FileSystemItemTypeDefinitor>().AddScoped<TestUseCases>();

        return services;
    }
}