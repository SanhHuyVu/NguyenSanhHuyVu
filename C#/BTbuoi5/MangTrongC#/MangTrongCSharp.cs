class MangTrongCSharp
{
    static void Main(string[] args)
    {
        do
        {
            int col;
            int row;
            int[,] _2dArray;
            Console.WriteLine("Enter 'stop' to exit");

            Console.Write("Enter the row of 2d Array: ");
            var rowInput = Console.ReadLine();
            if (!int.TryParse(rowInput, out row))
            {
                if (rowInput == "stop")
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid");
                    continue;
                }
            }

            Console.Write("Enter the column of 2d Array: ");
            var colInput = Console.ReadLine();
            if (!int.TryParse(colInput, out col))
            {
                if (colInput == "stop")
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid");
                    continue;
                }
            }

            _2dArray = new int[row, col];

            for (int r = 0; r < _2dArray.GetLength(0); r++)
            {
                for (int c = 0; c < _2dArray.GetLength(1); c++)
                {
                    int value;
                    Console.Write($"Enter value at [{r}][{c}]: ");
                    var valueInput = Console.ReadLine();
                    if (!int.TryParse(valueInput, out value))
                    {
                        Console.WriteLine("Invalid value");
                        c--;
                        continue;
                    }

                    _2dArray[r, c] = value;
                }
            }

            Print2DArray(_2dArray);

            Console.WriteLine("The highest value of the 2d array is: " + GetHighestValue(_2dArray));

            // Console.WriteLine("Sum of main diagonal Line: " + SumOfMainDiagonalLine(_2dArray));
            SumOfMainDiagonalLine(_2dArray);
        } while (true);

        void Print2DArray(int[,] _2dArray)
        {
            Console.Clear();
            Console.WriteLine("wd array:");
            int diagonalLineLength = (_2dArray.GetLength(0) < _2dArray.GetLength(1)) ? _2dArray.GetLength(0) : _2dArray.GetLength(1);
            for (int i = 0; i < _2dArray.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < _2dArray.GetLength(1); j++)
                {
                    // high light the main line red
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(_2dArray[i, j] + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                        continue;
                    }
                    Console.Write(_2dArray[i, j] + "\t|");
                }
                Console.WriteLine();
            }
        }

        // 1.Tìm phần tử lớn nhất của mảng hai chiều
        int GetHighestValue(int[,] _2dArray)
        {
            int highestValue = int.MinValue;
            for (int i = 0; i < _2dArray.GetLength(0); i++)
            {
                for (int j = 0; j < _2dArray.GetLength(1); j++)
                {
                    if (_2dArray[i, j] > highestValue)
                    {
                        highestValue = _2dArray[i, j];
                    }
                }
            }

            return highestValue;
        }

        // 2.Tính tổng các giá trị trên đường chéo chính mảng hai chiều vuông
        void SumOfMainDiagonalLine(int[,] _2dArray)
        {
            int diagonalLineLength = (_2dArray.GetLength(0) < _2dArray.GetLength(1)) ? _2dArray.GetLength(0) : _2dArray.GetLength(1);

            int sumOfMainDiagonalLine = 0;

            for (int i = 0; i < diagonalLineLength; i++)
            {
                sumOfMainDiagonalLine += _2dArray[i, i];
            }

            // return sumOfMainDiagonalLine;
            Console.WriteLine("sum Of Main Diagonal Line: " + sumOfMainDiagonalLine);

        }
    }
}
