using Microsoft.Extensions.AI;
using OpenAI;
using System.Text;
using ChatMessage = Microsoft.Extensions.AI.ChatMessage;

const string openAiApiKey = "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";

var chatAgent = new OpenAIClient(openAiApiKey).GetChatClient("gpt-4.1").AsIChatClient();
////var chatAgentOptions = new ChatOptions
////{
////};

// Start the conversation with context for the AI model
List<ChatMessage> chatHistory =
    [
        new ChatMessage(ChatRole.System, """
            You are a friendly hiking enthusiast who helps people discover fun hikes in their area.
            You introduce yourself when first saying hello.
            When helping people out, you always ask them for this information
            to inform the hiking recommendation you provide:

            1. The location where they would like to hike
            2. What hiking intensity they are looking for

            You will then provide three suggestions for nearby hikes that vary in length
            after you get that information. You will also share an interesting fact about
            the local nature on the hikes when making a recommendation. At the end of your
            response, ask if there is anything else you can help with.
        """)
    ];

// Loop to get user input and stream AI response
while (true)
{
    // Get user prompt and add to chat history
    Console.WriteLine(">> Your prompt:");
    string? userPrompt = Console.ReadLine();
    chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

    // Stream the AI response and add to chat history
    Console.WriteLine("-- AI Response:");
    var response = new StringBuilder();
    await foreach (ChatResponseUpdate item in
        chatAgent.GetStreamingResponseAsync(chatHistory))
    {
        Console.Write(item.Text);
        response.Append(item.Text);
    }

    chatHistory.Add(new ChatMessage(ChatRole.Assistant, response.ToString()));
    Console.WriteLine();
}