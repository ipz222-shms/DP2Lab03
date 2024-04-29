namespace DecoratorLibrary;

public class Artifact : BaseItem
{
    public readonly string Name;
    public readonly double Magic;

    public Artifact(IHero hero, string name, double magic) : base(hero)
    {
        Name = name;
        Magic = magic;
    }

    public override IEnumerable<BaseItem> GetItems()
        => _hero.GetItems().Append(this);
    
    public override string ToString()
        => $"Artifact {Name} (M:{Magic:F2})";
}
