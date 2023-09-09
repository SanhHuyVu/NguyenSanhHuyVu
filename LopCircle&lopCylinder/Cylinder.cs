public class Cylinder : Circle
{
    double height = 1.0;

    public Cylinder()
    {

    }

    public Cylinder(double height)
    {
        this.height = height;
    }

    public Cylinder(double height, double radius, string color) : base(radius, color)
    {
        this.height = height;
    }

    public double GetHeight()
    {
        return height;
    }

    public void SetHeight(double height)
    {
        this.height = height;
    }

    public double GetVolume(){
        return height * GetArea();
    }

    public override string ToString()
    {

        return $"a cylinder with height = {height} and volume = {GetVolume()} and is a subclass of "+base.ToString();
    }
}