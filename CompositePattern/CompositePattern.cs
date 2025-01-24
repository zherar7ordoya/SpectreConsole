using Spectre.Console;

namespace Algorithmics.CompositePattern;

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
        Console.WriteLine("--- Folder Content ---");
        Console.WriteLine(root.GetContent());

        Console.WriteLine("--- Folder Sizes ---");
        Console.WriteLine($"{folder1.Name} size: {folder1.GetSize()} bytes");
        Console.WriteLine($"{folder2.Name} size: {folder2.GetSize()} bytes");
        Console.WriteLine($"{folder3.Name} size: {folder3.GetSize()} bytes");
        Console.WriteLine($"Root size: {root.GetSize()} bytes");
    }
}
