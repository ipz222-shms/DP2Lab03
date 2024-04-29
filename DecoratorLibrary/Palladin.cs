namespace DecoratorLibrary;

public class Palladin : IHero
{
    public IEnumerable<BaseItem> GetItems() => new List<BaseItem>();

    public void Defend() => Console.WriteLine("Paladin Defends");
}
