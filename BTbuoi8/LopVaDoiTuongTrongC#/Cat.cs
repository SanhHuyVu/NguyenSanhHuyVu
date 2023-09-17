public class Cat : Animal
{
    string name { get; set; }

    public Cat(string weight, string height, string name) : base(weight, height){
        this.name = name;
    }

    public override void PrintInfo()
    {
        Console.WriteLine("AnimalType: cat");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("weight: " + weight);
        Console.WriteLine("height: " + height);
    }
}