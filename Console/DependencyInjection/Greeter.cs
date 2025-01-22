namespace Algorithmics.DependencyInjection;


public class Greeter(IDateTime dateTime)
{
    private readonly IDateTime _dateTime = dateTime;

    public void Greet(string name)
    {
        var currentDateTime = _dateTime.GetCurrentDateTime();
        Console.WriteLine($"Hello {name}! Current date and time: {currentDateTime}");
    }
}
