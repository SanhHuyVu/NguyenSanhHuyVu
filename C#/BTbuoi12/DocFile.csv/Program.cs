class Program
{
    static void Main(string[] args)
    {
        string path = "nations.csv";

        StreamReader reader = new StreamReader(path);

        string line = "";

        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            string[] temp = line.Replace("\"", "").Split(",");
            Console.WriteLine(temp[5]);
        }

        reader.Close();
        reader.Dispose();
    }
}