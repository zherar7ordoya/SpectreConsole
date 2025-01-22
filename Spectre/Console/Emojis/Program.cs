using Spectre.Console;

namespace Emojis;

public static class Program
{
    public static void Main()
    {
        // Show a known emoji
        RenderEmoji();

        // Show a remapped emoji
        Emoji.Remap("globe_showing_europe_africa", Emoji.Known.GrinningFaceWithSmilingEyes);
        RenderEmoji();

        AnsiConsole.WriteLine("Press any key to continue");
        AnsiConsole.Console.Input.ReadKey(false);
    }

    private static void RenderEmoji()
    {
        AnsiConsole.Write(
            new Panel("[yellow]Hello :globe_showing_europe_africa:![/]")
                .RoundedBorder());
    }
}
