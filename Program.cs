using Algorithmics;
using Spectre.Console;


var examples = new List<(string Title, Action Example)>
{
    ("Inyección de dependencias", DependencyInjection.Run),
    ("Salir", () => Environment.Exit(0))
};

while (true)
{
    AnsiConsole.Write(new Rule("[yellow]ALGORITMIA[/]").RuleStyle("yellow"));

    var selection = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("\n[cyan]Seleccione un ejemplo:[/]")
            .HighlightStyle("lime")
            .AddChoices([.. examples.ConvertAll(e => e.Title)]));
    
    var (Title, Example) = examples.Find(e => e.Title == selection);
    Example();

    AnsiConsole.MarkupLine("\n[cyan](Presione cualquier tecla para volver...)[/]");
    Console.ReadKey(true);
    Console.Clear();
}
