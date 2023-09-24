public class Fan
{
    private const int SLOW = 1;
    private const int MEDIUM = 2;
    private const int FAST = 3;
    private int speed = SLOW;
    private bool on = false;
    private double radius = 5;
    private string color = "blue";

    public Fan()
    {

    }

    public int GetSpeed()
    {
        return speed;
    }
    public bool GetOn()
    {
        return on;
    }
    public double GetRadius()
    {
        return radius;
    }
    public string GetColor()
    {
        return color;
    }

    public void SetSpeed(int speed)
    {
        this.speed = speed;
    }
    public void SetOn(bool on)
    {
        this.on = on;
    }
    public void SetRadius(double radius)
    {
        this.radius = radius;
    }
    public void SetColor(string color)
    {
        this.color = color;
    }


    public void ToString()
    {
        if (on)
        {
            Console.WriteLine("Speed: " + speed);
            Console.WriteLine("color: " + color);
            Console.WriteLine("radius: " + radius);
            Console.WriteLine("Fan is on");
        }
        else
        {
            Console.WriteLine("color: " + color);
            Console.WriteLine("radius: " + radius);
            Console.WriteLine("Fan is off");
        }
    }
}