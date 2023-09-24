class Program
{
    static void Main(string[] args)
    {
        string path = "numbers.txt";
        ReadTextFileExample reader = new ReadTextFileExample();

        Console.Clear();
        reader.ReadTextFile(path);
    }
}