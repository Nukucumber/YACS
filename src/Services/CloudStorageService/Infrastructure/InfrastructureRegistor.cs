namespace CloudStorageService.Infrastructure;


using Microsoft.Extensions.DependencyInjection;

using CloudStorageService.Application.UseCases;
using CloudStorageService.Domain.Interfaces;
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
}