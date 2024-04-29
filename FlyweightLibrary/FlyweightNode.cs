namespace FlyweightLibrary;

public class FlyweightNode(string tag, bool isSingle, string? display)
{
    public string Tag { get; private set; } = tag;
    public bool IsSingle { get; private set; } = isSingle;
    public string? Display { get; private set; } = display;
}
