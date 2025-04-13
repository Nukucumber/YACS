namespace CloudStorageService.Infrastructure;


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using CloudStorageService.Application.UseCases;
using CloudStorageService.Domain.Interfaces;
using Options;
using Services;

public static class InfrastructureRegistor
{
    public static IServiceCollection ServicesRegistration(this IServiceCollection serviceCollection)
    {
        serviceCollection
        .AddScoped<IFileEnvironmentManager, FileService.FileEnvironmentManager>()
        .AddScoped<GetDirectoryContentsHandler>();

        return serviceCollection;
    }

    public static IServiceCollection InfraOptionsRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<FileStorageOption>(configuration.GetSection(nameof(FileStorageOption)));
        return serviceCollection;
    }
}