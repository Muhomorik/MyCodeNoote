// Source: http://www.introtorx.com/content/v1.0.10621.0/03_LifetimeManagement.html

// Creates a scope for a console foreground color. When disposed, will return to 
//  the previous Console.ForegroundColor
public class ConsoleColor : IDisposable
{
    private readonly System.ConsoleColor _previousColor;
    public ConsoleColor(System.ConsoleColor color)
    {
        _previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
    }
    public void Dispose()
    {
        Console.ForegroundColor = _previousColor;
    }
}

// I find this handy for easily switching between colors in little spike console applications: 
Console.WriteLine("Normal color");
using (new ConsoleColor(System.ConsoleColor.Red))
{
    Console.WriteLine("Now I am Red");
    using (new ConsoleColor(System.ConsoleColor.Green))
    {
	    Console.WriteLine("Now I am Green");
    }
    Console.WriteLine("and back to Red");
}
