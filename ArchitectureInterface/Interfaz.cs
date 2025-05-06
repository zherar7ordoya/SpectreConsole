using Spectre.Console;

namespace SpectreConsole.ArchitectureInterface;

public static class Interfaz
{
    public static void Run()
    {
        AnsiConsole.MarkupLine("\n[lime]La interfaz como base de la arquitectura de software[/]\n");

        ISave saveDB = new SaveDB();
        ISave saveFile = new SaveFile();    
        var beerStock = new BeerStock(saveDB);
        beerStock.Update("Cerveza Artesanal");
        beerStock = new BeerStock(saveFile);
        beerStock.Update("Cerveza Artesanal");
    }
}

public interface ISave
{
    public void Save(string some);
}

public class SaveDB : ISave
{
    public void Save(string some)
    {
        Console.WriteLine($"Saving to DB: {some}");
    }
}

public class SaveFile : ISave
{
    public void Save(string some)
    {
        Console.WriteLine($"Saving to File: {some}");
    }
}

public class BeerStock(ISave save)
{
    private readonly ISave _save = save ?? throw new ArgumentNullException(nameof(save));

    public void Update(string beer)
    {
        Console.WriteLine("Updating beer stock...");
        _save.Save(beer);
    }
}
