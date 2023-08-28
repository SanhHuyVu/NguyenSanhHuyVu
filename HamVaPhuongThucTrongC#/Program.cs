class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        do
        {
            int option;

            Console.WriteLine("Choose funtion to run:");
            Console.WriteLine("0: Tempurature Convert");
            Console.WriteLine("1: Find min value of an array");
            Console.WriteLine("2: Delete index from array");
            Console.WriteLine("3: Count number of appeareance of character in string");
            Console.WriteLine("Enter 'stop' to stop");

            var input = Console.ReadLine();

            if (!int.TryParse(input, out option))
            {
                if (input == "stop")
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("-Invalid-");
                    continue;
                }
            }

            RunFunction(option);

        } while (true);

        void RunFunction(int function)
        {
            switch (function)
            {
                case 0:
                    Console.Clear();
                    ConvertTemperature();
                    break;
                case 1:
                    Console.Clear();
                    MinValueOfArray();
                    break;
                case 2:
                    Console.Clear();
                    DeleteFromArray();
                    break;
                case 3:
                    Console.Clear();
                    NumOfAppearanceInString();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("-Invalid-");
                    break;
            }
        }

        void ConvertTemperature()
        {
            int isCToF;
            float tempurature = 10f;

            do
            {
                Console.WriteLine("Enter 'back' to back");
                Console.WriteLine("-Tempurature Convert-");
                Console.WriteLine("0: convert C to F");
                Console.WriteLine("1: convert F to C");

                var input = Console.ReadLine();

                if (!int.TryParse(input, out isCToF))
                {
                    if (input == "back")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-Invalid-");
                        continue;
                    }
                }
                else if (isCToF == 0 || isCToF == 1)
                {
                    Console.Clear();
                    Console.Write("Enter tempurature:");
                    var temInput = Console.ReadLine();

                    if (!float.TryParse(temInput, out tempurature))
                    {
                        continue;
                    }

                    switch (isCToF)
                    {
                        case 0:
                            Console.WriteLine(tempurature + "C is " + (tempurature * 1.8 + 32) + "F");
                            continue;
                        case 1:
                            Console.WriteLine(tempurature + "F is " + ((tempurature - 32) / 1.8) + "C");
                            continue;
                        default:
                            Console.WriteLine("-Invalid-");
                            continue;
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("-Invalid-");
                    continue;
                }

            } while (true);
        }

        void MinValueOfArray()
        {
            do
            {
                // create array
                Console.WriteLine("Enter 'back' to back");
                Console.WriteLine("Find min value of array");
                Console.Write("Enter lenght of array: ");

                var input = Console.ReadLine();
                if (!int.TryParse(input, out var value))
                {
                    if (input == "back")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-Invalid-");
                        continue;
                    }
                }
                else if (value < 1)
                {
                    Console.Clear();
                    Console.WriteLine("-Invalid-");
                    continue;
                }

                int[] intArray = new int[value];

                // inout indexes
                for (int i = 0; i < intArray.Length; i++)
                {
                    Console.Write("enter value at index [" + i + "]");
                    var indexInput = Console.ReadLine();
                    if (!int.TryParse(indexInput, out var indexValue))
                    {
                        if (indexInput == "stop")
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            i--;
                            continue;
                        }
                    }
                    intArray[i] = indexValue;
                }

                // find min
                int minValue = int.MaxValue;
                for (int i = 0; i < intArray.Length; i++)
                {
                    if (intArray[i] < minValue)
                    {
                        minValue = intArray[i];
                    }
                }

                Console.Clear();
                Console.WriteLine("Array is:");
                for (int i = 0; i < intArray.Length; i++)
                {
                    Console.Write(intArray[i] + " ");
                }
                Console.WriteLine("");
                Console.WriteLine("min value is: " + minValue);

                continue;
            } while (true);
        }

        void DeleteFromArray()
        {
            do
            {
                // create array
                Console.WriteLine("Enter 'back' to back");
                Console.WriteLine("Delete index from array");
                Console.Write("Enter lenght of array: ");

                var input = Console.ReadLine();
                if (!int.TryParse(input, out var value))
                {
                    if (input == "back")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-Invalid-");
                        continue;
                    }
                }
                else if (value < 1)
                {
                    Console.Clear();
                    Console.WriteLine("-Invalid-");
                    continue;
                }

                // input array indexes
                int[] intArray = new int[value];

                for (int i = 0; i < intArray.Length; i++)
                {
                    Console.Write("enter value at index [" + i + "]");
                    var indexInput = Console.ReadLine();
                    if (!int.TryParse(indexInput, out var indexValue))
                    {
                        if (indexInput == "back")
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            i--;
                            continue;
                        }
                    }
                    intArray[i] = indexValue;
                }

                // input index to remove
                Console.Write("Enter index to remove: ");
                var indexToRemoveInput = Console.ReadLine();
                if (!int.TryParse(indexToRemoveInput, out var indexToRemove))
                {
                    if (indexToRemoveInput == "back")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-Invalid-");
                        continue;
                    }
                }

                Console.Clear();
                Console.WriteLine("Before: ");
                for (int i = 0; i < intArray.Length; i++)
                {
                    Console.Write(intArray[i] + " ");
                }

                // deleting index
                bool found = false;
                for (int i = 0; i < intArray.Length; i++)
                {
                    if (intArray[i] == indexToRemove)
                    {
                        found = true;
                    }
                }

                Console.WriteLine();
                if (found == false)
                {
                    Console.Clear();
                    Console.WriteLine("-index with value " + indexToRemove + " was not found-");
                    continue;
                }

                int[] newIntArray = new int[intArray.Length - 1];

                for (int i = 0; i < intArray.Length - 1; i++)
                {
                    if (intArray[i] != indexToRemove)
                    {
                        newIntArray[i] = intArray[i];
                    }
                }

                Console.WriteLine("After: ");
                for (int i = 0; i < newIntArray.Length; i++)
                {
                    Console.Write(newIntArray[i] + " ");
                }
                Console.WriteLine();
            } while (true);
        }

        void NumOfAppearanceInString()
        {
            do
            {
                // input string
                Console.WriteLine("Enter 'back' to back");
                Console.WriteLine("Count the number of appearance of character in string");
                Console.Write("Enter string: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                if (input == "back")
                {
                    Console.Clear();
                    return;
                }

                // input character
                Console.Write("Enter character to count: ");
                string characterInput = Console.ReadLine();

                if (!char.TryParse(characterInput, out char character))
                {
                    if (characterInput == "back")
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("-Invalid-");
                        continue;
                    }
                }

                // counting
                Console.Clear();
                int count = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == char.Parse(characterInput))
                    {
                        count++;
                    }
                }
                Console.WriteLine($"'{characterInput}' appeared {count} times in '{input}'");

            } while (true);
        }
    }
}
