namespace FlyweightLibrary;

public class NodesFlyweightFactory
{
    public readonly List<FlyweightNode> _nodeTypes = [];

    public FlyweightNode GetFlyweight(string tag, bool isSingle = false, string? display = null)
    {
        var type = _nodeTypes.Find(t => t.Tag == tag && 
                                        t.IsSingle == isSingle && t.Display == display);

        if (type == null)
        {
            type = new FlyweightNode(tag, isSingle, display);
            _nodeTypes.Add(type);
        }
        
        return type;
    }
}
