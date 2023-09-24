
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Linear Equation Resolver");
        Console.WriteLine("Given a equation as 'a * x + b = 0', please enter constants:");
        Console.Write("Enter a:");
        float a = float.Parse(Console.ReadLine());
        Console.Write("Enter b:");
        float b = float.Parse(Console.ReadLine());

        if (a != 0)
        {
            Console.WriteLine("The solution is: x=-b/a= " + (-b / a));
        }
        if (a == 0)
        {
            if (b == 0)
            {
                Console.WriteLine("The solution is all x!");
            }
            else
            {
                Console.WriteLine("No solution!");
            }
        }
    }
}