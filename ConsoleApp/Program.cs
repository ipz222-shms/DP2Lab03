using AdapterLibrary;
using BridgeLibrary;
using CompositeLibrary;
using ConsoleApp;
using DecoratorLibrary;
using ProxyLibrary;

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
            List<Shape> shapes =
            [
                new Circle(new ConsoleTextRender(), 1),
                new Circle(new ConsoleASCIIRender(), 7),
                new Triangle(new ConsoleASCIIRender(), 4),
                new Square(new ConsoleASCIIRender(), 8)
            ];

            foreach (var shape in shapes)
            {
                shape.Rasterize();
                shape.Vectorize();
            }
            
            break;
        case Scenario.Proxy:
            Console.WriteLine("Regular SmartTextReader:");
            ISmartText str = new SmartTextReader();
            var result = str.ReadFile("../../../ProxyReadFile.txt");
            Console.WriteLine($"Lines in result: {result.Count()}");
            
            Console.WriteLine("\nSmartTextChecker > SmartTextReader:");
            str = new SmartTextChecker(str);
            result = str.ReadFile("../../../ProxyReadFile.txt");
            Console.WriteLine($"Lines in result: {result.Count()}");

            Console.WriteLine("\nSmartTextReaderLocker (success) > SmartTextChecker > SmartTextReader:");
            ISmartText strWhiteList = new SmartTextReaderLocker(str, @"^\.\.\/\.\.\/\.\.\/.*\.txt$", true);
            result = strWhiteList.ReadFile("../../../ProxyReadFile.txt");
            Console.WriteLine($"Lines in result: {result.Count()}");
            
            Console.WriteLine("\nSmartTextReaderLocker (fail) > SmartTextChecker > SmartTextReader:");
            str = new SmartTextReaderLocker(str, @"^\.\.\/\.\.\/\.\.\/.*$");
            result = str.ReadFile("../../../ProxyReadFile.txt");
            Console.WriteLine($"Lines in result: {result.Count()}");
            
            break;
        case Scenario.Composite:
            LightElementNode html = new("html");
            
            LightElementNode head = new("head");
            html.AppendChild(head);
            LightElementNode title = new("title");
            head.AppendChild(title);
            title.AppendChild(new LightTextNode("Hello World!"));

            LightElementNode body = new("body");
            html.AppendChild(body);

            LightElementNode h1 = new("h1")
            {
                Display = "inline-block"
            };
            body.AppendChild(h1);
            h1.AppendChild(new LightTextNode("Hello World!"));
            
            body.AppendChild(new LightElementNode("br")
            {
                IsSingle = true
            });

            LightElementNode table = new("table");
            body.AppendChild(table);
            LightElementNode tbody = new("tbody")
            {
                Display = "table-row-group"
            };
            table.AppendChild(tbody);
            for (var r = 1; r <= 3; r++)
            {
                LightElementNode tr = new("tr")
                {
                    Display = "table-row"
                };
                for (var c = 1; c <= 4; c++)
                {
                    LightElementNode td = new("td")
                    {
                        Display = "table-cell"
                    };
                    td.AppendChild(new LightTextNode($"{r + c}"));
                    tr.AppendChild(td);
                }
                tbody.AppendChild(tr);
            }
            
            table.AddClass("numbers-table");
            
            Console.WriteLine(html.OuterHTML());
            
            break;
        case Scenario.Flyweight:
            
            break;
        default:
            throw new NotImplementedException();
    }
    
    Console.Write("\n\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
