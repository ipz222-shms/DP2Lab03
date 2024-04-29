namespace BridgeLibrary;

public class Circle : Shape
{
    public Circle(IRender render, int size) : base(render)
    {
        Corners = 0;
        Size = size;
    }

    public override string ToString() => "Circle";
}
