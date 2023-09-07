﻿class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        do
        {
            Console.WriteLine("enter 'stop' to exit");
            Console.WriteLine("0: Ractangle");
            Console.WriteLine("1: Cat");
            Console.WriteLine("2: Student");
            Console.WriteLine("3: Fan");
            Console.WriteLine("4: StopWatch");
            Console.Write("Enter: ");

            var input = Console.ReadLine();
            int option;

            if (!int.TryParse(input, out option))
            {
                if (input == "stop")
                {
                    return;
                }
            }

            Console.Clear();
            Run(option);
        } while (true);

        void Run(int option)
        {
            switch (option)
            {
                case 0:
                    RunRectangle();
                    break;
                case 1:
                    RunCat();
                    break;
                case 2:
                    RunStudent();
                    break;
                case 3:
                    RunFan();
                    break;
                case 4:
                    StopWatch stopWatch = new StopWatch();

                    stopWatch.SelectionSort();
                    stopWatch.GetElapsedTime();

                    break;
            }
        }

        void RunRectangle()
        {
            do
            {
                double width, height;
                Console.WriteLine("Enter 'back' to return");
                Console.WriteLine("new Rectangle");

                Console.Write("enter width:");
                var widthInput = Console.ReadLine();
                if (!double.TryParse(widthInput, out width))
                {
                    Console.Clear();
                    if (widthInput == "back") return;
                    continue;
                }

                Console.Write("enter height:");
                var heightInput = Console.ReadLine();
                if (!double.TryParse(heightInput, out height))
                {
                    Console.Clear();
                    if (heightInput == "back") return;
                    continue;
                }

                Console.Clear();
                Rectangle rec = new Rectangle(width, height);
                rec.Display();
            } while (true);
        }

        void RunCat()
        {
            do
            {
                Console.WriteLine("Enter 'back' to return");
                Console.WriteLine("new cat");

                Console.Write("enter name for cat:");
                string name = Console.ReadLine();
                if (name == "back")
                {
                    Console.Clear();
                    return;
                }

                Console.Write("enter weight:");
                string weight = Console.ReadLine();
                if (weight == "back")
                {
                    Console.Clear();
                    return;
                }

                Console.Write("enter height:");
                string height = Console.ReadLine();
                if (height == "back")
                {
                    Console.Clear();
                    return;
                }


                Console.Clear();
                Cat cat = new Cat(weight, height, name);
                cat.PrintInfo();
            } while (true);
        }

        void RunStudent()
        {
            do
            {
                int rollno;
                Console.WriteLine("Enter 'back' to return");
                Console.WriteLine("new student");

                Console.Write("enter rollno:");
                var rollnoInput = Console.ReadLine();
                if (!int.TryParse(rollnoInput, out rollno))
                {
                    Console.Clear();
                    if (rollnoInput == "back") return;
                    continue;
                }

                Console.Write("enter name for student:");
                string name = Console.ReadLine();
                if (name == "back")
                {
                    Console.Clear();
                    return;
                }

                Console.Clear();
                Student.Change();

                Student student = new Student(rollno, name);
                student.Display();
            } while (true);
        }

        void RunFan()
        {
            do
            {
                int speed;
                bool on;
                double radius;

                Console.WriteLine("Enter 'back' to return");
                Console.WriteLine("new Fan");

                Console.Write("enter speed(1/2/3):");
                var speedInput = Console.ReadLine();
                if (!int.TryParse(speedInput, out speed))
                {
                    Console.Clear();
                    if (speedInput == "back") return;
                    continue;
                }
                else if (speed < 1 || 3 < speed)
                {
                    Console.Clear();
                    continue;
                }

                Console.Write("turn fan on(yes/no):");
                var onInput = Console.ReadLine();
                switch (onInput)
                {
                    case "yes":
                        on = true;
                        break;
                    case "no":
                        on = false;
                        break;
                    case "back":
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        continue;
                }

                Console.Write("enter radius:");
                var radiusInput = Console.ReadLine();
                if (!double.TryParse(radiusInput, out radius))
                {
                    Console.Clear();
                    if (radiusInput == "back") return;
                    continue;
                }

                Console.Write("enter color:");
                string color = Console.ReadLine();
                if (color == "back")
                {
                    Console.Clear();
                    return;
                }

                Console.Clear();
                Fan fan = new Fan();
                fan.SetSpeed(speed);
                fan.SetOn(on);
                fan.SetRadius(radius);
                fan.SetColor(color);

                fan.ToString();
            } while (true);
        }
    }
}