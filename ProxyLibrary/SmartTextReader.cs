namespace ProxyLibrary;

public class SmartTextReader : ISmartText
{
    public IEnumerable<IEnumerable<char>> ReadFile(string filename)
        => File.ReadAllLines(filename).Select(l => l.ToArray());
}
