class Program
{
    // static void Main(string[] args)
    // {
    //     int arrayLenght;
    //     Console.Clear();

    //     do
    //     {
    //         Console.WriteLine("Type stop to exit");
    //         Console.Write("Enter the length of array: ");
    //         var input = Console.ReadLine();
    //         if (!int.TryParse(input, out arrayLenght))
    //         {
    //             if (input == "stop")
    //             {
    //                 return;
    //             }
    //         }
    //         else
    //         {
    //             int[] arrayInt = new int[arrayLenght];
    //             for (int i = 0; i < arrayInt.Length; i++)
    //             {
    //                 Console.Write($"Enter value at index {i}:");
    //                 var valueInput = Console.ReadLine();
    //                 if (!int.TryParse(valueInput, out arrayInt[i]))
    //                 {
    //                     Console.WriteLine("Invalid");
    //                     i--;
    //                     continue;
    //                 }
    //             }

    //             Console.Clear();
    //             Console.WriteLine("The array is: ");
    //             for (int i = 0; i < arrayInt.Length; i++)
    //             {
    //                 Console.Write(arrayInt[i] + " ");
    //             }
    //             Console.WriteLine("");

    //             Console.WriteLine("The highest value is: " + GetHighestValue(arrayInt));
    //             Console.WriteLine("The highest odd value is: " + GetHighestOddValue(arrayInt));
    //         }
    //     } while (true);

    //     int GetHighestValue(int[] arrayInt)
    //     {
    //         int highestValue = int.MinValue;
    //         for (int i = 0; i < arrayInt.Length; i++)
    //         {
    //             if (arrayInt[i] > highestValue)
    //             {
    //                 highestValue = arrayInt[i];
    //             }
    //         }
    //         return highestValue;
    //     }

    //     int GetHighestOddValue(int[] arrayInt)
    //     {
    //         int highestValue = int.MinValue;
    //         for (int i = 0; i < arrayInt.Length; i++)
    //         {
    //             if (arrayInt[i] % 2 == 1 && arrayInt[i] > highestValue)
    //             {
    //                 highestValue = arrayInt[i];
    //             }
    //         }
    //         return highestValue;
    //     }
    // }
}