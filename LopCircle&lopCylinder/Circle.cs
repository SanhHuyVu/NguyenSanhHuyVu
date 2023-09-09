public class Circle
{
    double radius = 1.0;
    string color = "no color";

    public Circle()
    {

    }

    public Circle(double radius, string color)
    {
        this.radius = radius;
        this.color = color;
    }

    public override string ToString()
    {
        return $"a circle with radius = {radius}, area = {GetArea()}, perimeter = {GetPerimeter()} and color = {color}";
    }

    public double GetRadius()
    {
        return radius;
    }

    public void SetRadius(double radius)
    {
        this.radius = radius;
    }

    public string GetColor()
    {
        return color;
    }

    public void SetColor(string color)
    {
        this.color = color;
    }

    public double GetArea()
    {
        return radius * radius * Math.PI;
    }

    public double GetPerimeter()
    {
        return 2 * radius * Math.PI;
    }
}