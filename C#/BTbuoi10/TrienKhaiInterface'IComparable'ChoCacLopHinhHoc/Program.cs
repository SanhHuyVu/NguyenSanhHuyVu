class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        ComperableCircle[] circles = new ComperableCircle[3];

        circles[0] = new ComperableCircle(3.6);
        circles[1] = new ComperableCircle();
        circles[2] = new ComperableCircle(3.5, "indigo", false);

        Console.WriteLine();
        Console.WriteLine("Pre-sorted:");
        foreach (ComperableCircle circle in circles)
        {
            circle.ToString();
        }

        Array.Sort(circles);

        Console.WriteLine();
        Console.WriteLine("After-sorted:");
        foreach (ComperableCircle circle in circles)
        {
            circle.ToString();
        }
    }
}