public class Tiger : Animal, IEdible
{
    public string HowToEat()
    {
        return "grilled tiger!";
    }

    public override string MakeSound()
    {
        return "Tiger sound!";
    }
}