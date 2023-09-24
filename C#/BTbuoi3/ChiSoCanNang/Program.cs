using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;

class Program
{
    static void Main(string[] args)
    {
        double weight;
        double height;

        Console.WriteLine("Enter weight: ");
        weight = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter height(meter): ");
        height = float.Parse(Console.ReadLine());

        double bmi = weight / Math.Pow(height, 2);
        Math.Round(bmi, 1);
        switch (bmi)
        {
            case var v when (v < 18.5):
            Console.WriteLine("you are under weight! with bmi: "+v);
            break;
            case var v when (v < 25):
            Console.WriteLine("you are normal! with bmi: "+v);
            break;
            case var v when (v < 30):
            Console.WriteLine("you are overweight! with bmi: "+v);
            break;
            case var v when (30 <= v):
            Console.WriteLine("you are obese! with bmi: "+v);
            break;
        }
    }
}