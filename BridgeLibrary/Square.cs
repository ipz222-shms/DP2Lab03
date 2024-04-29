namespace BridgeLibrary;

public class Square : Shape
{
    public Square(IRender render, int size) : base(render)
    {
        Corners = 4;
        Size = size;
    }

    public override string ToString() => "Square";
}
