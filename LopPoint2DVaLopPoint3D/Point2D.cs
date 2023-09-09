public class Point2D
{
    float x = 0.0f;
    float y = 0.0f;

    public Point2D()
    {

    }

    public Point2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float GetX()
    {
        return x;
    }

    public float GetY()
    {
        return y;
    }

    public void SetX(float x)
    {
        this.x = x;
    }

    public void SetY(float y)
    {
        this.y = y;
    }

    public void SetXY(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float[] GetXY()
    {
        float[] xy = {x, y};
        return xy;
    }

    public override string ToString()
    {
        return $"2d point with x = {x} and y = {y}";
    }
}