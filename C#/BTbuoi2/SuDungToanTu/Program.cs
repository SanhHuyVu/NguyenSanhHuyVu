public class Program
{
    static void Main(string[] args)
    {
        float w;
        float h;

        Console.Write("Enter width: ");
        w = float.Parse(Console.ReadLine());

        Console.Write("Enter height: ");
        h = float.Parse(Console.ReadLine());

        float area  = w*h;

        Console.WriteLine(area);
    }
}