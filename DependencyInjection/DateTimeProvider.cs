namespace Algorithmics.DependencyInjection;


public class DateTimeProvider : IDateTime
{
    public DateTime GetCurrentDateTime() => DateTime.Now;
}
