public class ReadTextFileExample
{
    public void ReadTextFile(string filePath)
    {
        try
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists) throw new FileNotFoundException(); ;

            StreamReader reader = new StreamReader(filePath);

            string line = "";
            int sum = 0;

            while ((line = reader.ReadLine()) != null)
            {
                Console.Write(line + " ");
                sum += int.Parse(line);
            }

            reader.Close();

            Console.WriteLine();
            Console.WriteLine(sum);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}