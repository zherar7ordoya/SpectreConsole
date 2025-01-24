namespace Algorithmics.CompositePattern;

// Leaf
class FileLeaf(string name, string content) : FileComponent(name)
{
    private readonly string Content = content;
    public override long GetSize() => Content.Length;
    public override string GetContent() => Content;
}
