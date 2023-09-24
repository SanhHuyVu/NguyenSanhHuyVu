public class Tile
{
    public enum TILETYPE { N, X, O }
    public int x { get; set; } = 0;
    public int y { get; set; } = 0;

    public TILETYPE tileType { get; set; } = TILETYPE.N;

    public Tile()
    {

    }

    public Tile(int posX, int posY)
    {
        this.x = posX;
        this.y = posY;
    }
}