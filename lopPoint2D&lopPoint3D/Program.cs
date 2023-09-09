class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Point2D point2D = new Point2D();
        Console.WriteLine("before: "+point2D.ToString());

        point2D.SetXY(7, 5);
        Console.WriteLine("after: "+point2D.ToString());

        Console.WriteLine("---------------------------------------------------------------------------");

        Point3D point3D = new Point3D();
        Console.WriteLine("before: "+point3D.ToString());

        point3D.SetXYZ(5, 6, 8);
        Console.WriteLine("after: "+point3D.ToString());
    }
}