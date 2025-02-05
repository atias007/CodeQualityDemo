using System.Collections.Concurrent;

namespace MiscDemo
{
    internal class ProducerConsumer
    {
        private readonly BlockingCollection<string> requestQueue = new();

        public async Task Run()
        {
            var produceTask = Produce();
            var consumeTask = Consume();

            await Task.WhenAll(produceTask, consumeTask);
        }

        public async Task Produce()
        {
            string[] requests = { "GET /home", "POST /login", "GET /profile", "GET /dashboard" };
            foreach (var request in requests)
            {
                requestQueue.Add(request);
                Console.WriteLine($"Request added to queue: {request}");
                await Task.Delay(2000);  // Simulate time delay between requests
            }

            requestQueue.CompleteAdding();  // Mark the queue as complete
        }

        public async Task Consume()
        {
            foreach (var request in requestQueue.GetConsumingEnumerable())
            {
                Console.WriteLine($"Processing request: {request}");
                await Task.Delay(300);  // Simulate processing time per request (e.g., database query)
            }
        }
    }
}