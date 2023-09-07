public class StopWatch
{
    //.ToString("h:mm:ss tt")
    private DateTime startTime = DateTime.Now;
    private DateTime endTime;
    private int[] array;

    public StopWatch()
    {
        array = Enumerable.Range(1, 100000).ToArray();
        Random random = new Random();
        array = array.OrderBy(x => new Random().Next()).ToArray();
    }

    public void Start()
    {
        startTime = DateTime.Now;
    }
    public void Stop()
    {
        endTime = DateTime.Now;
    }
    public void GetElapsedTime()
    {
        TimeSpan timePassed = endTime - startTime;
        Console.WriteLine("Elapsed Time: "+timePassed.TotalMilliseconds+" miliseconds");
    }
    public void SelectionSort()
    {
        int n = array.Length;

        Console.WriteLine("Selection sort an array of "+array.Length+" numbers");
        Start();
        Console.WriteLine("start at: "+startTime.ToString("h:mm:ss:ff"));
        Console.WriteLine("Sorting...");

        int temp, smallest;
        for (int i = 0; i < n - 1; i++)
        {
            smallest = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[smallest])
                {
                    smallest = j;
                }
            }
            temp = array[smallest];
            array[smallest] = array[i];
            array[i] = temp;
        }

        Console.Clear();
        Console.WriteLine("Selection sort an array of "+array.Length+" numbers");
        Console.WriteLine("start at: "+startTime.ToString("h:mm:ss:ff"));
        Stop();
        Console.WriteLine("end at: "+endTime.ToString("h:mm:ss:ff"));
    }
}