namespace Algorithmics;


public class DateTimeProvider : IDateTime
{
    public DateTime GetCurrentDateTime() => DateTime.Now;
}
