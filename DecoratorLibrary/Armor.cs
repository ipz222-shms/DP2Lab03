namespace DecoratorLibrary;

public class Armor : BaseItem
{
    public readonly string Name;
    public readonly double Defense;

    public Armor(IHero hero, string name, double defense) : base(hero)
    {
        Name = name;
        Defense = defense;
    }
    
    public override IEnumerable<BaseItem> GetItems()
        => _hero.GetItems().Append(this);
    
    public override string ToString()
        => $"Armor {Name} (D:{Defense:F2})";
}
