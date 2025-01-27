using Spectre.Console;

namespace Algorithmics.DependencyInjection;

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
