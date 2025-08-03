// Import packages
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Polly;
using Polly.Retry;
using SemanticKernel;

var services = new ServiceCollection();
services
    .AddTransient<SupplierPlugin>()
    .AddDbContext<NorthwindContext>(option => option.UseSqlServer("Password=CustomsDev123!;Persist Security Info=True;User ID=sa;Initial Catalog=Northwind;Data Source=localhost;Encrypt=false"), ServiceLifetime.Transient);

var plugin = services.BuildServiceProvider().GetRequiredService<SupplierPlugin>();

#region OpenAI Configuration

var apiKey = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY") ?? throw new ArgumentNullException(); ;
const string modelId = "gpt-4.1";

#endregion OpenAI Configuration

#region Ollama Configuration

// const string modelId = "llama3.2";
// const string endpoint = "http://localhost:11434";

#endregion Ollama Configuration

AsyncRetryPolicy _retry = Policy
    .Handle<Exception>()
    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(1));

var handler = new HttpClientHandler
{
    CheckCertificateRevocationList = false
};
using var httpClient = new HttpClient(handler);

// Create a kernel with Azure OpenAI chat completion
// OPENAI:
var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId, apiKey, httpClient: httpClient);
// OLLAMA: var builder = Kernel.CreateBuilder().AddOllamaChatCompletion(modelId, new Uri(endpoint));

// Add enterprise components
// builder.Services.AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));

// Build the kernel
Kernel kernel = builder.Build();
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

// Add a plugin (the LightsPlugin class is defined below)
kernel.Plugins.AddFromObject(plugin, "Suppliers");

// Enable planning
var openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
};

// Create a history store the conversation
var history = new ChatHistory();

// Initiate a back-and-forth chat
string? userInput;
do
{
    // Collect user input
    Console.Write("User > ");
    userInput = Console.ReadLine();

    // Add user input
    history.AddUserMessage(userInput);

    // Get the response from the AI
    var result = await _retry.ExecuteAsync(() => chatCompletionService.GetChatMessageContentAsync(
        history,
        executionSettings: openAIPromptExecutionSettings,
        kernel: kernel));

    // Print the results
    Console.WriteLine("Assistant > " + result);

    // Add the message from the agent to the chat history
    history.AddMessage(result.Role, result.Content ?? string.Empty);
} while (userInput is not null);