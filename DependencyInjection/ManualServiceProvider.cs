using Spectre.Console;


namespace Algorithmics;

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

        var parameters = constructor.GetParameters()
            .Select(p => ResolveService(p.ParameterType))
            .ToArray();

        return constructor.Invoke(parameters);
    }
}
