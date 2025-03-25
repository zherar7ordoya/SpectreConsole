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

public class DateTimeProvider : IDateTime
{
    public DateTime GetCurrentDateTime() => DateTime.Now;
}

public class Greeter(IDateTime dateTime)
{
    private readonly IDateTime _dateTime = dateTime;

    public void Greet(string name)
    {
        var currentDateTime = _dateTime.GetCurrentDateTime();
        Console.WriteLine($"\nHello {name}!\nCurrent date and time: {currentDateTime}");
    }
}

public interface IDateTime
{
    DateTime GetCurrentDateTime();
}

public interface IServiceProvider
{
    void Register<TInterface, TImplementation>() where TImplementation : TInterface;
    TInterface GetService<TInterface>();
}

public class ManualServiceProvider : IServiceProvider
{
    private readonly Dictionary<Type, Type> _services = [];

    public void Register<TInterface, TImplementation>() where TImplementation : TInterface
    {
        _services[typeof(TInterface)] = typeof(TImplementation);
    }

    public TInterface GetService<TInterface>()
    {
        return (TInterface)ResolveService(typeof(TInterface));
    }

    private object ResolveService(Type type)
    {
        if (!_services.TryGetValue(type, out var implementationType))
        {
            throw new Exception($"Service {type.Name} not registered.");
        }

        var constructor = implementationType.GetConstructors().FirstOrDefault()
            ?? throw new Exception($"No public constructor found for {implementationType.Name}.");

        Console.WriteLine($"[INFO] Creating instance of {implementationType.Name}...");

        var parameters = constructor.GetParameters()
            .Select(p => ResolveService(p.ParameterType))
            .ToArray();

        // El constructor.Invoke(parameters) es quien realiza el trabajo de
        // instanciar el objeto. Internamente, es como si usara new, pero lo hace
        // de forma dinámica al invocar el constructor con los parámetros resueltos.
        // Así que, aunque no veas new de manera explícita en tu código, el efecto
        // es el mismo porque la reflexión maneja esa parte "mágica".
        return constructor.Invoke(parameters);
    }
}
