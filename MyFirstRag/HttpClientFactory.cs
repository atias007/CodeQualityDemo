namespace MyFirstRag;

internal class HttpClientFactory
{
    private static HttpClientHandler GetHandler() => new()
    {
        CheckCertificateRevocationList = false
    };

    public static HttpClient GetGetHttpClient() => new(GetHandler());
}