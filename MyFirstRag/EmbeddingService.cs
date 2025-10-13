using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Embeddings;

namespace MyFirstRag;

internal class EmbeddingService(string apiKey, string embeddingModel = "text-embedding-ada-002")
{
    // Create embeddings and store them with original text
    public async Task<List<VectorChunk>> CreateVectorStore(List<string> chunks)
    {
        using var httpClient = HttpClientFactory.GetGetHttpClient();

        var kernelBuilder = Kernel.CreateBuilder();
        kernelBuilder.AddOpenAITextEmbeddingGeneration(
            modelId: embeddingModel,
            apiKey: apiKey,
            httpClient: httpClient);

        var kernel = kernelBuilder.Build();
        var embeddingService = kernel.GetRequiredService<ITextEmbeddingGenerationService>();
        var embeddings = await embeddingService.GenerateEmbeddingsAsync(chunks, kernel);
        var vectorStore = chunks.Zip(embeddings).Select((z, i) => new VectorChunk { Embedding = z.Second.ToArray(), Text = z.First, Index = i }).ToList();
        return vectorStore;
    }

    public async Task<VectorChunk> CreateVectorStore(string value)
    {
        var result = await CreateVectorStore([value]);
        return result.First();
    }
}