namespace BridgeLibrary;

public class ConsoleASCIIRender : IRender
{
    public void Rasterize(int corners, int size)
    {
        switch (corners)
        {
            case 0: // Circle
                var radius = size / 2;
                var angleStep = 1.0 / radius;
                for (var y = -radius; y <= radius; y++)
                {
                    for (var x = -radius; x <= radius; x++)
                    {
                        var distance = Math.Sqrt(x * x + y * y);
                        Console.Write(distance <= radius ? " * " : "   ");
                    }
                    Console.WriteLine();
                }
                break;
            case 3: // Triangle
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size - i - 1; j++)
                        Console.Write("   ");
                    for (var j = 0; j < 2 * i + 1; j++)
                        Console.Write(" * ");
                    Console.WriteLine();
                }
                break;
            case 4: // Square
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                        Console.Write(" * ");
                    Console.WriteLine();
                }
                break;
            default:
                Console.WriteLine("Can't rasterize this shape...");
                break;
        }
    }

    public void Vectorize(int corners, int size)
    {
        switch (corners)
        {
            case 0: // Circle
                var radius = size / 2;
                var consoleBuffer = new string[size, size];
                for (var y = 0; y < size; y++)
                    for (var x = 0; x < size; x++)
                    {
                        var distanceToCenter = Math.Sqrt(Math.Pow(x - radius, 2) + Math.Pow(y - radius, 2));
                        if (Math.Abs(distanceToCenter - radius) < 0.5)
                            consoleBuffer[y, x] = " • ";
                        else
                            consoleBuffer[y, x] = "   ";
                    }
                for (var row = 0; row < size; row++)
                {
                    for (var col = 0; col < size; col++)
                        Console.Write(consoleBuffer[row, col]);
                    Console.WriteLine();
                }
                break;
            case 3: // Triangle
                for (var i = 0; i < size - 1; i++)
                    Console.Write("   ");
                Console.WriteLine(" • ");
                for (var i = 1; i < size - 1; i++)
                {
                    for (var j = 0; j < size - i - 1; j++)
                        Console.Write("   ");
                    Console.Write(" • ");
                    for (var j = 0; j < 2 * i - 1; j++)
                        Console.Write("\u2592\u2592\u2592");
                    Console.WriteLine(" • ");
                }
                for (var i = 0; i < 2 * size - 1; i++)
                    Console.Write(" • ");
                break;
            case 4: // Square
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                        if (i == 0 || i == size - 1 || j == 0 || j == size - 1)
                            Console.Write(" • ");
                        else
                            Console.Write("\u2592\u2592\u2592");
                    Console.WriteLine();
                }
                break;
            default:
                Console.WriteLine("Can't vectorize this shape...");
                break;
        }
    }
}
