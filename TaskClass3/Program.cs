// See https://aka.ms/new-console-template for more information
using TaskClass3;

var task1 = new Mission1().Start();
var task2 = new Mission2().Start();
await Task.WhenAll(task1, task2);
Console.WriteLine("Press any key finish");
Console.ReadKey();