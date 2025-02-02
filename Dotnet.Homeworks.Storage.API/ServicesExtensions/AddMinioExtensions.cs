using Minio;
using MinioConfig = Dotnet.Homeworks.Storage.API.Configuration.MinioConfig;

namespace Dotnet.Homeworks.Storage.API.ServicesExtensions;

public static class AddMinioExtensions
{
    public static IServiceCollection AddMinioClient(this IServiceCollection services,
        MinioConfig minioConfiguration)
    {
        var client = new MinioClient()
            .WithCredentials(minioConfiguration.Username, minioConfiguration.Password)
            .WithEndpoint(minioConfiguration.Endpoint, minioConfiguration.Port)
            .WithSSL(minioConfiguration.WithSsl)
            .Build();
        
        services.AddSingleton<IMinioClient, MinioClient>(_ => client);

        return services;
    }
}