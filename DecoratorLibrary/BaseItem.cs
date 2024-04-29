namespace DecoratorLibrary;

public abstract class BaseItem(IHero hero) : IHero
{
    protected IHero _hero = hero;

    abstract public IEnumerable<BaseItem> GetItems();
}
