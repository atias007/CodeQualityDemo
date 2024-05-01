using DemoGrpcService;
using Grpc.Net.Client;
using System.Diagnostics.Contracts;

using var channel = GrpcChannel.ForAddress("http://localhost:5091");
var client = new Greeter.GreeterClient(channel);

var reply = client.Add(new AddRequest { A = 10, B = 20 });
Console.WriteLine(reply.Result);

var reply2 = client.SayHello(new HelloRequest { FirstName = "Eli", LastName = "Cohen" });
Console.WriteLine(reply2.Message);

Console.ReadLine();