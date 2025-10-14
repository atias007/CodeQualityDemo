using Microsoft.Extensions.DependencyInjection;

namespace MyFirstRag;

internal static class DependencyInjectionFactory
{
    private static IServiceProvider _serviceProvider;

    static DependencyInjectionFactory()
    {
        var services = new ServiceCollection();
        services
            .AddHttpClient("my-rag")
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler { CheckCertificateRevocationList = false };
            })
            .AddStandardResilienceHandler();

        services.AddSingleton<AppSettings>();
        services.AddSingleton<EmbeddingService>();
        services.AddSingleton<ChatService>();
        _serviceProvider = services.BuildServiceProvider();
    }

    public static T GetService<T>() where T : notnull
    {
        return _serviceProvider.GetRequiredService<T>();
    }
}