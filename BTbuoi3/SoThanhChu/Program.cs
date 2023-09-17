class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        int number;
        string letters = "";


        do
        {
            if (!string.IsNullOrWhiteSpace(letters))
            {
                Console.WriteLine(letters);
            }
            Console.WriteLine("number to letters: ");
            Console.WriteLine("type 'stop' to stop program");
            Console.WriteLine("Enter your number: ");

            var input = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(input, out number))
            {
                if (input == "stop")
                {
                    Console.WriteLine("program stopped!");
                    return;
                }
            }

            if (number == 0)
            {
                letters = number + " is Zero";
            }
            else if (0 <= number && number <= 10)
            {
                letters = number + " is " + GetOnes(number);
            }
            else if (10 < number && number < 100)
            {
                letters = number + " is " + TwoDigitNumbers(number);
            }
            else if (100 <= number && number < 999)
            {
                letters = number + " is " + ThreeDegitNumber(number);
            }
            else
            {
                letters = "Out Of Ability";
            }

        } while (true);

        string TwoDigitNumbers(int number)
        {
            if (10 <= number && number < 20)
            {
                switch (number)
                {
                    case 10:
                        return "ten";
                    case 11:
                        return "eleven";
                    case 12:
                        return "twelve";
                    case 13:
                        return "thirteen";
                    case 14:
                        return "fourteen";
                    case 15:
                        return "fifteen";
                    case 16:
                        return "sixteen";
                    case 17:
                        return "sixteen";
                    case 18:
                        return "eighteen";
                    case 19:
                        return "nineteen";
                }
            }
            else if (20 <= number && number < 100)
            {
                int tens = number / 10;
                int ones = number % 10;
                return GetTens(tens) + "" + GetOnes(ones);
            }
            return "";
        }

        string ThreeDegitNumber(int number)
        {
            int ones = number % 10;
            int tens = (number % 100) / 10;
            int hundreds = number / 100;

            if (tens == 1)
            {
                return GetOnes(hundreds) + " hundred and " + TwoDigitNumbers(number % 100);
            }
            else if (tens == 0 && ones == 0)
            {
                return GetOnes(hundreds) + " hundred ";
            }
            else
            {
                return GetOnes(hundreds) + " hundred and " + GetTens(tens) + " " + GetOnes(ones);
            }
        }

        string GetOnes(int number)
        {
            switch (number)
            {
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 10:
                    return "Ten";
                default:
                    return "";
            }
        }

        string GetTens(int number)
        {
            switch (number)
            {
                case 2:
                    return "twenty";
                case 3:
                    return "thirty";
                case 4:
                    return "forty";
                case 5:
                    return "fifty";
                case 6:
                    return "sixty";
                case 7:
                    return "seventy";
                case 8:
                    return "eighty";
                case 9:
                    return "ninety";
                default:
                    return "";
            }
        }
    }
}