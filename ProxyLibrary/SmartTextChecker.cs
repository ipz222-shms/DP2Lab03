namespace ProxyLibrary;

public class SmartTextChecker(ISmartText service) : ISmartText
{
    private readonly ISmartText _originalSmartText = service;

    public IEnumerable<IEnumerable<char>> ReadFile(string filename)
    {
        Console.WriteLine($"Reading file '{filename}' ...");
        var result = _originalSmartText.ReadFile(filename);
        var lines = result.Count();
        var chars = result.Select(l => l.Count()).Sum();
        Console.WriteLine("Success!");
        Console.WriteLine($"Total amount of Lines: {lines}");
        Console.WriteLine($"Total amount of Characters: {chars}");
        return result;
    }
}
