using AdapterLibrary;
using ConsoleApp;
using DecoratorLibrary;

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

            LoggerFile loggerFile = new(logger, "../../../log.txt");
            loggerFile.Log("Log example.");
            loggerFile.Error("Error example.");
            loggerFile.Warn("Warn example.");
            
            break;
        case Scenario.Decorator:
            IHero mage = new Mage();
            mage = new Weapon(mage, "Broom", 1);
            mage = new Armor(mage, "Robe", 1);
            mage = new Artifact(mage, "Daedric", 25);
            Console.WriteLine($"Mage's Items: {string.Join(", ", mage.GetItems())}");

            IHero warrior = new Warrior();
            warrior = new Weapon(warrior, "Sword", 12);
            warrior = new Weapon(warrior, "Shield", 4);
            warrior = new Armor(warrior, "Light", 10);
            Console.WriteLine($"Warrior's Items: {string.Join(", ", warrior.GetItems())}");

            IHero palladin = new Palladin();
            palladin = new Armor(palladin, "Heavy", 30);
            palladin = new Weapon(palladin, "Two handed sword", 20);
            palladin = new Artifact(palladin, "Deffense Stone", 7);
            Console.WriteLine($"Palladin's Items: {string.Join(", ", palladin.GetItems())}");
            
            break;
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
