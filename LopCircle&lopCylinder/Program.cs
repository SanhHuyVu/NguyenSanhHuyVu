class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Cylinder cylinder = new Cylinder();
        Console.WriteLine(cylinder.ToString());
        Console.WriteLine();

        cylinder.SetColor("dark-red");
        cylinder.SetHeight(3.4);
        cylinder.SetRadius(0.75);
        Console.WriteLine(cylinder.ToString());
    }
}