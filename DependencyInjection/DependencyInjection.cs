using Spectre.Console;

namespace Algorithmics.DependencyInjection;

public static class DependencyInjection
{
    public static void Run()
    {
        AnsiConsole.MarkupLine("\n[lime]Ejemplo de inyección de dependencias[/]\n");

        var serviceProvider = new ManualServiceProvider();
        serviceProvider.Register<IDateTime, DateTimeProvider>();
        serviceProvider.Register<Greeter, Greeter>();

        var greeter = serviceProvider.GetService<Greeter>();
        greeter.Greet("Gerardo Tordoya");
    }
}
