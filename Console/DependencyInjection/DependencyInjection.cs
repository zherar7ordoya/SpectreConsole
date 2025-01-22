using Spectre.Console;

namespace Algorithmics.DependencyInjection;

public static class DependencyInjection
{
    public static void Run()
    {
        AnsiConsole.Write(
            new Panel("[yellow]Dependency Injection[/]")
                .Header("[lime]Información[/]")
                .Border(BoxBorder.Double)
                .BorderStyle(new Style(foreground: Color.Green))
                .Expand());

        AnsiConsole.MarkupLine("\n[green]Este ejemplo...[/]\n");

        var serviceProvider = new ManualServiceProvider();
        serviceProvider.Register<IDateTime, DateTimeProvider>();
        serviceProvider.Register<Greeter, Greeter>();

        var greeter = serviceProvider.GetService<Greeter>();
        greeter.Greet("Gerardo Tordoya");
    }
}
