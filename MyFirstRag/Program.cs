using MyFirstRag;

const string pdfPath = @"c:\temp\coffee_machine.pdf";

string OPENAI_API_KEY = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY") ?? throw new ArgumentNullException();

try
{
    // 1. Load and extract text from PDF
    Console.Write("Loading PDF... ");
    string extractedText = PdfExtractor.ExtractTextFromPdf(pdfPath);
    Console.WriteLine($"Extracted {extractedText.Length:N0} characters from PDF\n");

    // 2. Split text into chunks
    Console.WriteLine("Creating text chunks...");
    var chunks = ChunksUtil.SplitIntoChunks(extractedText, chunkSize: 1000, overlap: 200);
    Console.WriteLine($"Created {chunks.Count} chunks\n");

    // 3. Create embeddings for chunks
    var embedding = new EmbeddingService(OPENAI_API_KEY);
    Console.WriteLine("Creating embeddings...");
    var vectorStore = await embedding.CreateVectorStore(chunks);
    Console.WriteLine($"Created {vectorStore.Count} embeddings\n");

    // 4. Ask questions and get answers
    Console.WriteLine("Ready to answer questions!\n");
    await Example1BasicRAG(vectorStore, OPENAI_API_KEY, embedding);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

static async Task Example1BasicRAG(List<VectorChunk> chunks, string apiKey, EmbeddingService embeddingService)
{
    Console.WriteLine("=== Example 1: Basic RAG Query ===");
    Console.WriteLine("Ask a question:\n");
    var question = Console.ReadLine() ?? throw new ArgumentNullException();

    var service = new ChatService(apiKey, embeddingService);
    var response = await service.AskQuestionWithRAGAsync(question, chunks, topK: 3);

    Console.WriteLine($"\nQuestion: {response.Question}");
    Console.WriteLine($"\nAnswer:\n{response.Answer}");
    Console.WriteLine($"\nUsed {response.RelevantChunks.Count} context chunks");
    Console.WriteLine(new string('=', 80));
}