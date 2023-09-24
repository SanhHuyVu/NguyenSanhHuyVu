public class Shape
{
    string color = "green";
    bool filled = true;

    public Shape()
    {

    }
    public Shape(string color, bool filled)
    {
        this.color = color;
        this.filled = filled;
    }
    public string GetColor()
    {
        return color;
    }
    public void SetColor(string color)
    {
        this.color = color;
    }
    public bool IsFilled()
    {
        return filled;
    }
    public void SetFilled(bool filled)
    {
        this.filled = filled;
    }

    public virtual void ToString()
    {
        string fill;
        fill = filled ? "filled" : "not filled";
        Console.WriteLine($"A Shape with color of {color} and is {fill}");
    }
}