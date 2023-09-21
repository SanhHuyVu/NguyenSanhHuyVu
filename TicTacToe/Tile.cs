public class Tile
{
    public enum OccupiedBy { N, X, O }
    public int x { get; set; } = 0;
    public int y { get; set; } = 0;

    public OccupiedBy occupiedBy { get; set; } = OccupiedBy.N;

    public Tile()
    {

    }

    public Tile(int posX, int posY)
    {
        this.x = posX;
        this.y = posY;
    }
}