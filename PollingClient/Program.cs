using (var client = new HttpClient())
{
    client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
    var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5125/Polling/server-send-event");
    using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
    using var body = await response.Content.ReadAsStreamAsync();
    using var reader = new StreamReader(body);
    while (!reader.EndOfStream)
    {
        Console.WriteLine(reader.ReadLine());
    }
}