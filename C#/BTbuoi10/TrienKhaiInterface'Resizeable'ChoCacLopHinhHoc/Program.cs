class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // circle
        Console.WriteLine("----Circle----");
        Circle circle = new Circle(5);
        double cirResizeInt = 50;

        Console.WriteLine("before resize");
        circle.ToString();

        Console.WriteLine();
        Console.WriteLine($"after resize(resize to {cirResizeInt}% of the original)");

        circle.Resize(cirResizeInt);
        circle.ToString();

        // rectangle
        Console.WriteLine();
        Console.WriteLine("----Rectangle----");
        Rectangle rectangle = new Rectangle(6, 10);
        double recResizeInt = 72;

        Console.WriteLine("before resize");
        rectangle.ToString();

        Console.WriteLine();
        Console.WriteLine($"after resize(resize to {recResizeInt}% of the original)");

        rectangle.Resize(recResizeInt);
        rectangle.ToString();

        // square
        Console.WriteLine();
        Console.WriteLine("----Square----");
        Square square = new Square(7);
        double squareResizeInt = 50;

        Console.WriteLine("before resize");
        square.ToString();

        Console.WriteLine();
        Console.WriteLine($"after resize(resize to {squareResizeInt}% of the original)");

        square.Resize(squareResizeInt);
        square.ToString();
    }
}