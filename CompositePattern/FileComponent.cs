namespace Algorithmics.CompositePattern;

// Component
abstract class FileComponent(string name)
{
    public string Name { get; protected set; } = name;
    public abstract long GetSize();
    public abstract string GetContent();
}
