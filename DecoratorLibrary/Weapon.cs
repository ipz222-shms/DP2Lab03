namespace DecoratorLibrary;

public class Weapon : BaseItem
{
    public readonly string Name;
    public readonly double Attack;

    public Weapon(IHero hero, string name, double attack) : base(hero)
    {
        Name = name;
        Attack = attack;
    }
    
    public override IEnumerable<BaseItem> GetItems()
        => _hero.GetItems().Append(this);
    
    public override string ToString()
        => $"Weapon {Name} (A:{Attack:F2})";
}
