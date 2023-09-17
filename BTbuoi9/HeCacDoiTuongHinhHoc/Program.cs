public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Square square = new Square();

        square.SetColor("red");
        square.SetSide(5);
        Console.WriteLine("area: "+square.GetArea());
        Console.WriteLine("Perimeter: "+square.GetPerimeter());
        square.ToString();
        Console.WriteLine(square);
    }
}