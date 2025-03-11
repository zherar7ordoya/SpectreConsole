namespace Integrador;

public class Auto(string patente,
                  string marca,
                  string modelo,
                  string año,
                  decimal precio)
{
    public string Patente { get; init; } = patente ?? throw new ArgumentNullException(nameof(patente));
    public string Marca { get; init; } = marca ?? throw new ArgumentNullException(nameof(marca));
    public string Modelo { get; init; } = modelo ?? throw new ArgumentNullException(nameof(modelo));
    public string Año { get; init; } = ValidarAño(año);
    public decimal Precio { get; init; } = precio > 0 ? precio : throw new ArgumentException("El precio debe ser mayor a 0.");
    public Persona? Dueño { get; private set; }

    public void AsignarDueño(Persona persona)
    {
        Dueño = Dueño is null ? persona : throw new InvalidOperationException("El auto ya tiene un dueño.");
    }

    public void EliminarDueño() => Dueño = null;

    private static string ValidarAño(string año) =>
        int.TryParse(año, out int result) && result > 1900 && result <= DateTime.Now.Year
            ? año
            : throw new ArgumentException("Año inválido.");

    ~Auto() => Console.WriteLine($"El objeto Auto con Patente {Patente} ha sido eliminado.");
}
