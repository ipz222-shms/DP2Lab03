namespace BridgeLibrary;

public interface IRender
{
    public void Rasterize(int corners, int size);
    public void Vectorize(int corners, int size);
}
