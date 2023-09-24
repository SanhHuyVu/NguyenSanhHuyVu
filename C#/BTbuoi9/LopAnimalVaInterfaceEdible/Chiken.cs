public class Chiken : Animal, IEdible
{
    public string HowToEat()
    {
        return "Fried chicken!";
    }

    public override string MakeSound()
    {
        return "Chicken sound!";
    }
}