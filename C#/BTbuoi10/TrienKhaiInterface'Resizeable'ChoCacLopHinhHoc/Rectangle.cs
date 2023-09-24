public class Rectangle : Shape, IResizeable
{
    double width = 1.0;
    double length = 1.0;

    public Rectangle()
    {

    }

    public Rectangle(double width, double length)
    {
        this.width = width;
        this.length = length;
    }

    public Rectangle(double width, double length, string color, bool filled) : base(color, filled)
    {
        this.width = width;
        this.length = length;
    }

    public virtual void SetWidth(double width)
    {
        this.width = width;
    }

    public virtual void SetLength(double length)
    {
        this.length = length;
    }

    public double GetWidth()
    {
        return width;
    }

    public double GetLength()
    {
        return length;
    }

    public double GetArea()
    {
        return width * length;
    }

    public double GetPerimeter()
    {
        return (width + length) * 2;
    }

    public override void ToString()
    {
        Console.Write($"A Rectangle with width = {width} and length = {length}, which is a subclass of ");
        base.ToString();
    }

    public void Resize(double percent)
    {
        percent = Math.Clamp(percent, 1, double.MaxValue);
        width *= percent / 100;
        length *= percent / 100;
    }
}