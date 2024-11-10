namespace lld_console_app.FactoryPattern;

public class Rectangle : IShape
{
    public void draw()
    {
        Console.WriteLine("This is Rectangle!");
    }
}