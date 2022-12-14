// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using TGC.AdventOfCode2022.Abstractions;
using TGC.AdventOfCode2022.Runner.Runners;

Console.WriteLine("Please enter advent to run (1-24)");

var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<IRunner, Runner01>();
serviceCollection.AddScoped<IRunner, Runner02>();
serviceCollection.AddScoped<IRunner, Runner03>();
serviceCollection.AddScoped<IRunner, Runner04>();
serviceCollection.AddScoped<IRunner, Runner05>();
serviceCollection.AddScoped<IRunner, Runner06>();


var serviceProvider = serviceCollection.BuildServiceProvider();

var input = Console.ReadLine();
var number = InputParsing(input);

var runners = serviceProvider.GetServices<IRunner>();

var runner = runners.First(r => r.Accept(number));

Task.Run(async () => {
    await runner.RunAsync();
}).Wait();


//TODO: fix to be circular
int InputParsing(string? input)
{
    if (InputValidation(input))
    {
        return int.Parse(input);
    }

    throw new Exception("Input is incorrect!");
}

bool InputValidation(string? input)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        return false;
    }
    return true;
}