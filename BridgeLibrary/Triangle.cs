namespace BridgeLibrary;

public class Triangle : Shape
{
    public Triangle(IRender render, int size) : base(render)
    {
        Corners = 3;
        Size = size;
    }

    public override string ToString() => "Triangle";
}
