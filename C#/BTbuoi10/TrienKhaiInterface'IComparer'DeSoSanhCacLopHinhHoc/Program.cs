class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Circle[] circles = new Circle[3];
        circles[0] = new Circle(3.6);
        circles[1] = new Circle();
        circles[2] = new Circle(3.5, "indigo", false);

        Console.WriteLine();
        Console.WriteLine("Pre-sorted:");
        foreach (Circle circle in circles)
        {
            circle.ToString();
        }

        IComparer<Circle> comparer = new CircleComparer();

        Array.Sort(circles, comparer);

        Console.WriteLine();
        Console.WriteLine("Post-sorted:");
        foreach (Circle circle in circles)
        {
            circle.ToString();
        }
    }
}