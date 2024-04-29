namespace ProxyLibrary;

public interface ISmartText
{
    public IEnumerable<IEnumerable<char>> ReadFile(string filename);
}
