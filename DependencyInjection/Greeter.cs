namespace Algorithmics.DependencyInjection;


public class Greeter(IDateTime dateTime)
{
    private readonly IDateTime _dateTime = dateTime;

    public void Greet(string name)
    {
        var currentDateTime = _dateTime.GetCurrentDateTime();
        Console.WriteLine($"\nHello {name}!\nCurrent date and time: {currentDateTime}");
    }
}
