using Spectre.Console;

namespace Algorithmics.DependencyInjection;

public static class DependencyInjection
{
    public static void Run()
    {
        AnsiConsole.MarkupLine("\n[lime]Ejemplo de inyección de dependencias[/]\n");


        // Configura el ManualServiceProvider y registra las dependencias:
        //     * IDateTime → DateTimeProvider
        //      * Greeter → Greeter
        // Luego solicita una instancia de Greeter y la utiliza para saludar.
        var serviceProvider = new ManualServiceProvider();

        // Aquí, IDateTime es la interfaz y DateTimeProvider la implementación concreta.
        // Este mapeo se guarda en el diccionario _services.
        serviceProvider.Register<IDateTime, DateTimeProvider>();
        serviceProvider.Register<Greeter, Greeter>();
        var greeter = serviceProvider.GetService<Greeter>();
        greeter.Greet("Gerardo Tordoya");
    }
}
