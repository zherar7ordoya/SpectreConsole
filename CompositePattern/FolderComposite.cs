namespace Algorithmics.CompositePattern;

// Composite
class FolderComposite(string name) : FileComponent(name)
{
    private readonly List<FileComponent> children = [];
    public void Add(FileComponent component) => children.Add(component);

    public override long GetSize()
    {
        long totalSize = 0;
        foreach (var child in children)
        {
            totalSize += child.GetSize();
        }
        return totalSize;
    }

    public override string GetContent()
    {
        string content = $"Folder: {Name}\n";
        foreach (var child in children)
        {
            content += $"\t{child.GetContent()}\n";
        }
        return content;
    }
}
