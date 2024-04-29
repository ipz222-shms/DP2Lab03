using System.Text.RegularExpressions;

namespace ProxyLibrary;

/// <param name="whiteList">true - regex works as whitelist only, false - as blacklist</param>
public class SmartTextReaderLocker(ISmartText service, string regex, bool whiteList = false) : ISmartText
{
    private readonly ISmartText _originalSmartText = service;
    private readonly Regex _regex = new(regex);
    
    public IEnumerable<IEnumerable<char>> ReadFile(string filename)
    {
        var match = _regex.IsMatch(filename);
        if ((!match && whiteList) || (match && !whiteList))
        {
            Console.WriteLine("Access denied!");
            return Enumerable.Empty<IEnumerable<char>>();
        }
        return service.ReadFile(filename);
    }
}
