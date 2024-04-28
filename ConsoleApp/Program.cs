using AdapterLibrary;
using ConsoleApp;

while (true)
{
    var i = 0;
    Console.WriteLine("Select scenario:");
    foreach (var scenario in Enum.GetValues<Scenario>())
        Console.WriteLine($"\t{++i}: {scenario}");

    Console.Write("\nEnter number: ");
    var input = Console.ReadLine();
    int selectedScenario;
    if (int.TryParse(input, out var iValue))
        selectedScenario = --iValue;
    else
    {
        Console.Clear();
        Console.WriteLine("Invalid input!\n");
        continue;
    }

    Console.Clear();
    if (!Enum.IsDefined(typeof(Scenario), selectedScenario))
    {
        Console.WriteLine("Unknown scenario!\n");
        continue;
    }
    
    Console.WriteLine($"Run '{(Scenario)selectedScenario}' scenario:\n\n");

    switch ((Scenario)selectedScenario)
    {
        case Scenario.Adapter:
            Logger logger = new();
            logger.Log("Log example.");
            logger.Error("Error example.");
            logger.Warn("Warn example.");

            LoggerFile loggerFile = new(logger);
            loggerFile.Log("Log example.");
            loggerFile.Error("Error example.");
            loggerFile.Warn("Warn example.");
            
            break;
        case Scenario.Decorator:
        case Scenario.Bridge:
        case Scenario.Proxy:
        case Scenario.Composite:
        case Scenario.Flyweight:
        default:
            throw new NotImplementedException();
    }
    
    Console.Write("\n\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
