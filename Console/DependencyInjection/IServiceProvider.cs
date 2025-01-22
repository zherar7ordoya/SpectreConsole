namespace Algorithmics.DependencyInjection;


public interface IServiceProvider
{
    void Register<TInterface, TImplementation>() where TImplementation : TInterface;
    TInterface GetService<TInterface>();
}
