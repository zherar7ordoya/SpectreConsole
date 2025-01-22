using Spectre.Console;

namespace Figlet;

public static class Program
{
    public static void Main()
    {
        AnsiConsole.Write(new FigletText("Left aligned").LeftJustified().Color(Color.Red));
        AnsiConsole.Write(new FigletText("Centered").Centered().Color(Color.Green));
        AnsiConsole.Write(new FigletText("Right aligned").RightJustified().Color(Color.Blue));

        AnsiConsole.WriteLine("Press any key to continue");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}
