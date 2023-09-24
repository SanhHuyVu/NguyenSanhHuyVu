class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        int option;
        do
        {
            Console.WriteLine("Choose shape to draw:");
            Console.WriteLine("0: Rectangle");
            Console.WriteLine("1: top-left triangle");
            Console.WriteLine("2: botton-left triangle");
            Console.WriteLine("3: botton-right triangle");
            Console.WriteLine("4: top-right triangle");
            Console.WriteLine("5: isosceles triangle");
            Console.WriteLine("Type 'stop' to exit");
            Console.Write("Enter: ");

            var input = Console.ReadLine();
            if (!int.TryParse(input, out option))
            {
                if (input == "stop")
                {
                    Console.Clear();
                    return;
                }
            }
            Draw(option);

        } while (true);


        void Draw(int input)
        {
            switch (input)
            {
                case 0:
                    DrawRectangle();
                    break;
                case 1:
                    DrawTriangle(1);
                    break;
                case 2:
                    DrawTriangle(2);
                    break;
                case 3:
                    DrawTriangle(3);
                    break;
                case 4:
                    DrawTriangle(4);
                    break;
                case 5:
                    DrawIsoscelesTriangle();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid!");
                    break;
            }
        }

        void DrawRectangle()
        {
            Console.Clear();
            Console.WriteLine("Rectangle");
            int width;
            int height;
            Console.Write("Enter Width:");
            width = int.Parse(Console.ReadLine());
            Console.Write("Enter height:");
            height = int.Parse(Console.ReadLine());

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    if (w == width - 1)
                    {
                        Console.WriteLine("#");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
            }
        }

        void DrawTriangle(int type)
        {
            Console.Clear();
            switch (type)
            {
                case 1:
                    Console.WriteLine("top-left triangle");
                    break;
                case 2:
                    Console.WriteLine("botton-left triangle");
                    break;
                case 3:
                    Console.WriteLine("botton-right triangle");
                    break;
                case 4:
                    Console.WriteLine("top-right triangle");
                    break;
            }

            Console.Write("Enter height: ");
            int height = int.Parse(Console.ReadLine());

            switch (type)
            {
                case 1:
                    for (int h = 0; h < height; h++)
                    {
                        for (int w = 0; w < height - h; w++)
                        {
                            if (w == height - h - 1)
                            {
                                Console.WriteLine("#");
                            }
                            else
                            {
                                Console.Write("#");
                            }
                        }
                    }
                    break;
                case 2:
                    for (int h = 0; h < height; h++)
                    {
                        for (int w = 0; w < h + 1; w++)
                        {
                            if (w == h)
                            {
                                Console.WriteLine("#");
                            }
                            else
                            {
                                Console.Write("#");
                            }
                        }
                    }
                    break;
                case 3:
                    for (int h = 0; h < height; h++)
                    {
                        for (int w = 0; w < height; w++)
                        {
                            if (w == height - 1)
                            {
                                Console.WriteLine("#");
                            }
                            else if (w < height - h - 1)
                            {
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write("#");
                            }
                        }
                    }
                    break;
                case 4:
                    for (int h = 0; h < height; h++)
                    {
                        for (int w = 0; w < height; w++)
                        {
                            if (w == height - 1)
                            {
                                Console.WriteLine("#");
                            }
                            else if (w < h)
                            {
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write("#");
                            }
                        }
                    }
                    break;
            }
        }

        void DrawIsoscelesTriangle()
        {
            Console.Clear();
            Console.WriteLine("isosceles triangle");
            Console.Write("Enter height: ");
            int height = int.Parse(Console.ReadLine());

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < height * 2; w++)
                {
                    if (w == height * 2 - 1)
                    {
                        Console.WriteLine("");
                    }
                    else if (w < height - h - 1 || w > height + h - 1)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
            }
        }
    }
}