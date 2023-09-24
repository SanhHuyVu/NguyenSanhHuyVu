using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            // Shape Test
            Console.WriteLine();
            Console.WriteLine("----Shape----");
            Shape shape = new Shape();
            Console.WriteLine(shape);
            shape.HowToColor();

            Console.WriteLine();
            shape = new Shape("red", false);
            Console.WriteLine(shape);
            shape.HowToColor();

            // Circle Test
            Console.WriteLine();
            Console.WriteLine("----Circle----");
            Circle circle = new Circle();
            Console.WriteLine(circle);
            circle.HowToColor();

            Console.WriteLine();
            circle = new Circle(3.5);
            Console.WriteLine(circle);
            circle.HowToColor();

            Console.WriteLine();
            circle = new Circle(3.5, "indigo", false);
            Console.WriteLine(circle);
            circle.HowToColor();

            // Square Test
            Console.WriteLine();
            Console.WriteLine("----Square----");
            Square square = new Square();
            Console.WriteLine(square);
            square.HowToColor();

            Console.WriteLine();
            square = new Square(2.3);
            Console.WriteLine(square);
            square.HowToColor();

            Console.WriteLine();
            square = new Square(5.8, "yellow", true);
            Console.WriteLine(square);
            square.HowToColor();

            Console.WriteLine();
            square = new Square(5.8, "yellow", false);
            Console.WriteLine(square);
            square.HowToColor();
        }
    }
}
