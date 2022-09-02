using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace Lingvo.API.Configurations;

public static class CompressionConfig
{
    public static IServiceCollection AddCompressionConfig(this IServiceCollection services)
    {
        services.AddResponseCompression(options =>
        {
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
        });

        services.Configure<BrotliCompressionProviderOptions>(options =>
            options.Level = CompressionLevel.Fastest
        );

        services.Configure<GzipCompressionProviderOptions>(options =>
            options.Level = CompressionLevel.Fastest
        );

        return services;
    }
}
