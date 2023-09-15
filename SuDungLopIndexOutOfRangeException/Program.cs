class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        try
        {
            List<char> chars = new List<char>();

            chars.InsertRange(0, new Char[] { 'a', 'b', 'c', 'd', 'e', 'f' });

            int value = chars[6];
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
        }
    }
}