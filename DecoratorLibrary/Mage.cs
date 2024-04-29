namespace DecoratorLibrary;

public class Mage : IHero
{
    public IEnumerable<BaseItem> GetItems() => new List<BaseItem>();

    public void CastSpell(string spell) => Console.WriteLine($"Mage casts {spell}");
}
