using System.Text;

namespace FlyweightLibrary;

public class LightElementNode(FlyweightNode node) : ILightNode
{
    private readonly List<string> _classes = [];
    private readonly List<ILightNode> _children = [];
    public FlyweightNode Type { get; } = node;
    public IEnumerable<string> Classes => new List<string>(_classes);
    public IEnumerable<ILightNode> Children => new List<ILightNode>(_children);
    public int ChildrenCount => _children.Count;

    public void AppendChild(ILightNode child)
    {
        if (Type.IsSingle)
            throw new ArgumentException("Single nodes can't contain any children!");
        _children.Add(child);
    }

    public void RemoveChild(ILightNode child)
        => _children.Remove(child);

    public void AddClass(string css)
    {
        if (!_classes.Contains(css))
            _classes.Add(css);
    }

    public void RemoveClass(string css)
        => _classes.Remove(css);
    
    public string InnerHTML()
    {
        StringBuilder sb = new();
        foreach (var childNode in _children)
            sb.Append($"\n{childNode.Render()}");
        return sb.ToString();
    }

    public string OuterHTML() => Render();

    public string Render()
    {
        StringBuilder sb = new($"<{Type.Tag}");
        
        if (Type.Display != null)
            sb.Append($" style=\"display:{Type.Display};\"");
        
        if (_classes.Count != 0)
            sb.Append($" class=\"{string.Join(' ', _classes)}\"");
        
        if (!Type.IsSingle)
        {
            if (_children.Count != 0)
            {
                sb.Append('>');
                sb.Append(InnerHTML());
                sb.Append($"\n</{Type.Tag}>");
            }
            else
                sb.Append($"</{Type.Tag}>");
        }
        else
            sb.Append(" />");

        return sb.ToString();
    }
}
