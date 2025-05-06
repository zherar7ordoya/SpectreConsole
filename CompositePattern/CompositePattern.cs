using Spectre.Console;

namespace SpectreConsole.CompositePattern;

public static class CompositePattern
{
    public static void Run()
    {
        AnsiConsole.MarkupLine("\n[lime]Ejemplo del patrón composite[/]\n");

        // Create files
        var file1 = new FileLeaf("File1.txt", "\t\t[Hello Gerardo from File1]");
        var file2 = new FileLeaf("File2.txt", "\t\t[Content of File2: List of Guests]");
        var file3 = new FileLeaf("File3.txt", "\t\t[Data in File3]");

        // Create folders
        var folder1 = new FolderComposite("Folder1"); // Empty folder
        var folder2 = new FolderComposite("Folder2");
        var folder3 = new FolderComposite("Folder3");

        // Add files to folders
        folder2.Add(file1);
        folder3.Add(file2);
        folder3.Add(file3);

        // Root folder
        var root = new FolderComposite("Root");
        root.Add(folder1);
        root.Add(folder2);
        root.Add(folder3);

        // Display results
        Console.WriteLine("--- Folder Content ---\n");
        Console.WriteLine(root.GetContent());

        Console.WriteLine("--- Folder Sizes ---");
        Console.WriteLine($"{folder1.Name} size: {folder1.GetSize()} bytes");
        Console.WriteLine($"{folder2.Name} size: {folder2.GetSize()} bytes");
        Console.WriteLine($"{folder3.Name} size: {folder3.GetSize()} bytes");
        Console.WriteLine($"Root size: {root.GetSize()} bytes");
    }
}

abstract class FileComponent(string name)
{
    public string Name { get; protected set; } = name;
    public abstract long GetSize();
    public abstract string GetContent();
}

class FileLeaf(string name, string content) : FileComponent(name)
{
    private readonly string Content = content;
    public override long GetSize() => Content.Length;
    public override string GetContent() => Content;
}

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
