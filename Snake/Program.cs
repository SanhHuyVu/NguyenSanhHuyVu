class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        bool isGameOver = false;
        int height = 8;
        int width = 20;
        int score = 0;

        int[] foodCurrentPos = new int[2];
        int[] currentPos = new int[2];

        currentPos[0] = width / 2;
        currentPos[1] = height / 2;

        DrawBorders(width, height);

        respawnFood();

        DrawSnakeHead();

        Console.SetCursorPosition(0, 9);
        Console.WriteLine("Press escape to exit");
        Console.Write("Score: " + score);

        do
        {
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    Console.Clear();
                    currentPos[0] -= 1;

                    Update();
                    break;
                case ConsoleKey.RightArrow:
                    Console.Clear();
                    currentPos[0] += 1;

                    Update();
                    break;
                case ConsoleKey.UpArrow:
                    Console.Clear();
                    currentPos[1] -= 1;

                    Update();
                    break;
                case ConsoleKey.DownArrow:
                    Console.Clear();
                    currentPos[1] += 1;

                    Update();
                    break;
                case ConsoleKey.Escape:
                    return;
            }
        } while (!isGameOver);

        void Update()
        {
            CheckGameOver();
            DrawBorders(width, height);

            CheckFoodEaten();
            DrawFood();
            DrawSnakeHead();

            Console.SetCursorPosition(0, 9);
            if (isGameOver)
            {
                Console.WriteLine("GameOver");
            }
            else
            {
                Console.WriteLine("Press escape to exit");
            }
            Console.Write("Score: " + score);
        }

        void CheckFoodEaten()
        {
            if (foodCurrentPos.SequenceEqual(currentPos))
            {
                score++;

                DrawBorders(width, height);

                respawnFood();

                DrawSnakeHead();
            }
        }

        void respawnFood()
        {

            do
            {
                Random rnd = new Random();
                foodCurrentPos[0] = rnd.Next(1, width - 1);
                foodCurrentPos[1] = rnd.Next(1, height);
            } while (foodCurrentPos.SequenceEqual(currentPos));

            DrawFood();
        }

        void DrawFood()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(foodCurrentPos[0], foodCurrentPos[1]);
            Console.WriteLine("*");
            Console.ResetColor();
        }

        void CheckGameOver()
        {
            if (currentPos[0] <= 0 || currentPos[0] >= width - 1)
            {
                isGameOver = true;
            }
            if (currentPos[1] <= 0 || currentPos[1] >= height)
            {
                isGameOver = true;
            }
            if (isGameOver)
            {
                return;
            }
        }

        void DrawSnakeHead()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(currentPos[0], currentPos[1]);
            Console.WriteLine("o");
            Console.ResetColor();
        }

        void DrawBorders(int width, int height)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            // top border
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('#');
            }

            // left border
            for (int i = 1; i < height + 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('#');
            }

            // right border
            for (int i = 1; i < height + 1; i++)
            {
                Console.SetCursorPosition(width - 1, i);
                Console.Write("#");
            }

            // bottom border
            for (int i = 1; i < width; i++)
            {
                Console.SetCursorPosition(i, height);
                Console.Write("#");
            }

            Console.ResetColor();
        }
    }
}