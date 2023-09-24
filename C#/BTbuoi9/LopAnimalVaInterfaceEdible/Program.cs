class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // animals
        Animal chicken = new Chiken();
        Animal tiger = new Tiger();

        Console.WriteLine("---animals---");
        Console.WriteLine(chicken.MakeSound());
        Console.WriteLine(tiger.MakeSound());
        
        Console.WriteLine();

        Console.WriteLine("---animals/edibels---");
        IEdible chickenE = (Chiken)chicken;
        IEdible tigerE = (Tiger)tiger;

        Console.WriteLine(chickenE.HowToEat());
        Console.WriteLine(tigerE.HowToEat());


        // fruits
        Fruit apple = new Apple();
        Fruit orange = new Orange();
        
        Console.WriteLine();

        Console.WriteLine("---fruits---");
        Console.WriteLine(apple.HowToEat());
        Console.WriteLine(orange.HowToEat());
    }
}