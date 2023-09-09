public class Point3D : Point2D
{
    float z = 0.0f;

    public Point3D()
    {

    }

    public Point3D(float x, float y, float z) : base(x, y)
    {
        this.z = z;
    }

    public float GetZ()
    {
        return z;
    }

    public void SetZ(float z)
    {
        this.z = z;
    }

    public void SetXYZ(float x, float y, float z)
    {
        SetXY(x, y);
        this.z = z;
    }

    public float[] GetXYZ()
    {
        float[] xyz = { GetX(), GetY(), z };
        return xyz;
    }

    public override string ToString()
    {
        return $"3d point with x = {GetX()}, y = {GetY()}, z = {z} and is a sub class of a "+base.ToString();
    }
}