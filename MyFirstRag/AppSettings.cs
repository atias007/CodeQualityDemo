namespace MyFirstRag;

internal class AppSettings
{
    public readonly string ChatModel = "gpt-4o-mini";
    public readonly string EmbeddingModel = "text-embedding-ada-002";
    public string ApiKey => Environment.GetEnvironmentVariable("OPEN_AI_API_KEY") ?? throw new InvalidDataException("api key is null");
}