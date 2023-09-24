public abstract class Animal
{
    protected string weight { get; set; }
    protected string height { get; set; }

    public Animal(string weight, string height)
    {
        this.weight = weight;
        this.height = height;
    }

    public abstract void PrintInfo();
}