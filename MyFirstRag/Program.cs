using MyFirstRag;
using MyFirstRag.Extractors;
using MyFirstRag.Models;

const string pdfPath = @"c:\temp\coffee_machine.pdf";

try
{
    // 1. Load and extract text from PDF
    Console.Write("Loading PDF... ");
    var extractedText = PdfExtractor.ExtractTextFromPdf(pdfPath);
    Console.WriteLine($"Extracted {extractedText.Length:N0} characters from PDF\n");

    // 2. Split text into chunks
    Console.WriteLine("Creating text chunks...");
    var chunks = ChunksUtil.SplitIntoChunks(extractedText, chunkSize: 1000, overlap: 200);
    Console.WriteLine($"Created {chunks.Count} chunks\n");

    // 3. Create embeddings for chunks
    var embedding = DependencyInjectionFactory.GetService<EmbeddingService>();
    Console.WriteLine("Creating embeddings...");
    var vectorStore = await embedding.CreateVectorStore(chunks);
    Console.WriteLine($"Created {vectorStore.Count} embeddings\n");

    // 4. Ask questions and get answers
    Console.WriteLine("Ready to answer questions!\n");
    await Example1BasicRAG(vectorStore);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

static async Task Example1BasicRAG(List<VectorChunk> vectors)
{
    Console.WriteLine("=== Example 1: Basic RAG Query ===");
    Console.WriteLine("Ask a question:\n");
    var question = Console.ReadLine() ?? throw new ArgumentNullException();

    var service = DependencyInjectionFactory.GetService<ChatService>();
    var response = await service.AskQuestionWithRAGAsync(question, vectors, topK: 3);

    Console.WriteLine($"\nQuestion: {response.Question}");
    Console.WriteLine($"\nAnswer:\n{response.Answer}");
    Console.WriteLine($"\nUsed {response.RelevantChunks.Count} context chunks");
    Console.WriteLine(new string('=', 80));
}