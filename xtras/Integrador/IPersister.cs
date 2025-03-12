namespace Integrador;

public interface IPersister<T> where T : IEntity
{
    IList<T> Read();
    bool Write(IList<T> datos);
}