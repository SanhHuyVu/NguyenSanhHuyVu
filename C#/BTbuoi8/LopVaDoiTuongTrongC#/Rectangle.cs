public class Rectangle
{
    double width;
    double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public double GetArea()
    {
        return width * height;
    }

    public double GetPerimeter()
    {
        return 2 * (width + height);
    }

    public void Display()
    {
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Area: " + GetArea());
        Console.WriteLine("Perimeter: " + GetPerimeter());
    }
}