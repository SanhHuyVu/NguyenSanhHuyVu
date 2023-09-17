class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        do
        {
            Console.WriteLine("Enter 'stop' to exit program");
            Console.WriteLine("0: copy file using FileInfo");
            Console.WriteLine("1: copy file using Stream");
            Console.Write("Enter option: ");

            var OpInput = Console.ReadLine();

            if (!int.TryParse(OpInput, out int option))
            {
                if (OpInput == "stop") return;
                continue;
            }

            switch (option)
            {
                case 0:
                    FileInfo source, destination;
                    Console.Clear();

                    try
                    {
                        Console.Write("Enter source file: ");
                        source = new FileInfo(Console.ReadLine());
                        Console.Write("Enter destination file: ");
                        destination = new FileInfo(Console.ReadLine());

                        Console.Clear();

                        CopyFileUsingFileInfo(source, destination);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Cannot Copy");
                        Console.Error.WriteLine(e.Message);
                    }
                    break;
                case 1:
                    FileInfo source2, destination2;
                    Console.Clear();

                    try
                    {
                        Console.Write("Enter source file: ");
                        source2 = new FileInfo(Console.ReadLine());
                        Console.Write("Enter destination file: ");
                        destination2 = new FileInfo(Console.ReadLine());

                        Console.Clear();

                        copyFileUsingStream(source2, destination2);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Cannot Copy");
                        Console.Error.WriteLine(e.Message);
                    }
                    break;
            }

        } while (true);
    }

    static void CopyFileUsingFileInfo(FileInfo source, FileInfo destination, bool overWrite = true)
    {
        Console.WriteLine("Copying file with FileInfo...");
        source.CopyTo(destination.FullName, overWrite);
        Console.WriteLine($"File copied FROM {source.FullName} TO {destination.FullName}");
    }
    static void copyFileUsingStream(FileInfo source, FileInfo destination)
    {
        Console.WriteLine("Copying file with Stream...");
        StreamReader reader = null;
        StreamWriter writer = null;

        try
        {
            reader = new StreamReader(source.FullName);
            writer = new StreamWriter(destination.FullName);
            char[] buffer = new char[1024];
            int length;
            while ((length = reader.Read(buffer)) > 0)
            {
                writer.Write(buffer, 0, length);
            }
        }
        finally
        {
            reader.Close();
            reader.Dispose();
            writer.Close();
            writer.Dispose();
            Console.WriteLine($"File copied FROM {source.FullName} TO {destination.FullName}");
        }
    }
}