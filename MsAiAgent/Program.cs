using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using MsAiAgent;
using OpenAI;
using System.Net.Mime;
using System.Threading;

string key = Environment.GetEnvironmentVariable("OPEN_AI_API_KEY") ?? throw new InvalidDataException("api key is null");
string model = "gpt-4o";

//await PromptDemo(key, model);
//await ChatDemo(key, model);
//await ImageDemo(key, model);
//await ThreadDemo(key, model);
await ToolsDemo(key, model);

static async Task PromptDemo(string key, string model)
{
    AIAgent agent = new OpenAIClient(key)
        .GetChatClient(model)
        .CreateAIAgent("you are proffesional joke teller");

    var response = await agent.RunAsync("Tell me joke about pirate");
    Console.WriteLine(response);
}

static async Task ChatDemo(string key, string model)
{
    var systemMessage = new ChatMessage(ChatRole.System,
        """
        If the user ask you to tell a joke, refuse to do so, explain that you are not a clown.
        Offer the user as intresting fact about astronomy instead.
        """);

    var userMessage = new ChatMessage(ChatRole.User, "Tell me joke about pirate");
    var messages = new List<ChatMessage> { systemMessage, userMessage };

    AIAgent agent = new OpenAIClient(key)
        .GetChatClient(model)
        .CreateAIAgent("you are proffesional joke teller");

    var responseStream = agent.RunStreamingAsync(messages);
    await foreach (var item in responseStream)
    {
        Console.Write(item);
    }
}

static async Task ImageDemo(string key, string model)
{
    AIAgent agent = new OpenAIClient(key)
        .GetChatClient(model)
        .CreateAIAgent("you are helpful agent that can analyze images");

    var message = new ChatMessage(ChatRole.User,
        [
            new TextContent("What do you see in this picture?"),
            new UriContent("https://www.dogster.com/wp-content/uploads/2024/04/german-shepherd-dog-standing-at-the-park_Bildagentur-Zoonar-GmbH_Shutterstock.jpg", MediaTypeNames.Image.Jpeg)
        ]);

    Console.WriteLine(await agent.RunAsync(message));
}

static async Task ThreadDemo(string key, string model)
{
    AIAgent agent = new OpenAIClient(key)
       .GetChatClient(model)
       .CreateAIAgent("you are proffesional joke teller");

    var thread1 = agent.GetNewThread();
    Console.WriteLine(await agent.RunAsync("Tell me a joke about c# developer", thread1));
    Console.WriteLine("----------------");
    Console.WriteLine(await agent.RunAsync("now add some emojis to the joke and tell it in the voice of robot", thread1));
}

static async Task ToolsDemo(string key, string model)
{
    var tool = AIFunctionFactory.Create(Tools.GetWeather);

    AIAgent agent = new OpenAIClient(key)
       .GetChatClient(model)
       .CreateAIAgent("you are helful assistant", tools: [tool]);

    Console.WriteLine(await agent.RunAsync("What is the weather like in Tel-Aviv"));
}