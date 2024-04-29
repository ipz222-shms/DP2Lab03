namespace BridgeLibrary;

public class ConsoleTextRender : IRender
{
    public void Rasterize(int corners, int size)
    {
        Console.WriteLine("Rasterized.");
    }

    public void Vectorize(int corners, int size)
    {
        Console.WriteLine("Vectorized.");
    }
}
