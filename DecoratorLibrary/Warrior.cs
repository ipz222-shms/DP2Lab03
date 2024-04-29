namespace DecoratorLibrary;

public class Warrior : IHero
{
    public IEnumerable<BaseItem> GetItems() => new List<BaseItem>();

    public void Attack() => Console.WriteLine("Warrior Attacks");
}
