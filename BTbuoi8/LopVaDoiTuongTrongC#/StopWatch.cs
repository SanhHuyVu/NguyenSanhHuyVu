public class StopWatch
{
    //.ToString("h:mm:ss:ff tt")
    private DateTime startTime = DateTime.Now;
    private DateTime endTime;

    public StopWatch(int num)
    {
        
    }

    public DateTime GetStartTime(){
        return startTime;
    }

    public DateTime GetEndTime(){
        return endTime;
    }

    public void Start()
    {
        startTime = DateTime.Now;
    }
    public void Stop()
    {
        endTime = DateTime.Now;
    }
    public TimeSpan GetElapsedTime()
    {
        TimeSpan timePassed = endTime - startTime;
        return timePassed;
    }
    
}