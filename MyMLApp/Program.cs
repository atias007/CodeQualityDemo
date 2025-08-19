// See https://aka.ms/new-console-template for more information
using MyMLApp;

Console.WriteLine("Hello, World!");

//Load sample data
var sampleData = new SentimentModel.ModelInput()
{
    Col0 = @"Crust feel like shit.",
};

//Load model and predict output
var result = SentimentModel.Predict(sampleData);

Console.WriteLine(result);