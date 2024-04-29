namespace BridgeLibrary;

public abstract class Shape
{
    protected readonly IRender _render;

    public Shape(IRender render) => _render = render;
    
    public int Corners { get; protected set; }
    public int Size { get; protected set; }

    public virtual void Rasterize()
    {
        Console.WriteLine($"\nRendering {this} as Raster image.");
        _render.Rasterize(Corners, Size);
    }

    public virtual void Vectorize()
    {
        Console.WriteLine($"\nRendering {this} as Vector image.");
        _render.Vectorize(Corners, Size);
    }
}
