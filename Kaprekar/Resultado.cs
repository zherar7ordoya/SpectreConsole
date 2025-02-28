namespace Algorithmics.Kaprekar;

public record Resultado(int Numero)
{
    public string Descendente { get; init; } = new string(Numero.ToString("D4").OrderByDescending(c => c).ToArray());
    public string Ascendente { get; init; } = new string(Numero.ToString("D4").OrderBy(c => c).ToArray());
    public int Mayor { get; init; } = int.Parse(new string(Numero.ToString("D4").OrderByDescending(c => c).ToArray()));
    public int Menor { get; init; } = int.Parse(new string(Numero.ToString("D4").OrderBy(c => c).ToArray()));

    public Resultado Calcular() => new(Mayor - Menor);
}
