using (var client = new HttpClient())
{
    var url = "http://localhost:2306/Job/Wait";
    //var url = "http://localhost:5125/Polling/server-send-event";
    client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
    var request = new HttpRequestMessage(HttpMethod.Get, url);
    using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
    using var body = await response.Content.ReadAsStreamAsync();
    using var reader = new StreamReader(body);
    while (!reader.EndOfStream)
    {
        Console.WriteLine(reader.ReadLine());
    }
}