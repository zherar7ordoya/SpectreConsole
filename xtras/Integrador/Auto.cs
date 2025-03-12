namespace Integrador;

public class Auto(string patente,
                  string marca,
                  string modelo,
                  int año,
                  decimal precio) : Entity
{
    public string Patente { get; init; } = patente ?? throw new ArgumentNullException(nameof(patente));
    public string Marca { get; init; } = marca ?? throw new ArgumentNullException(nameof(marca));
    public string Modelo { get; init; } = modelo ?? throw new ArgumentNullException(nameof(modelo));
    public int Año { get; init; } = (año > 1900 && año <= DateTime.Now.Year) ? año : throw new ArgumentException("Año inválido.");
    public decimal Precio { get; init; } = precio > 0 ? precio : throw new ArgumentException("El precio debe ser mayor a 0.");
    public Persona? Dueño { get; private set; }

    public void AsignarDueño(Persona persona)
    {
        if (Dueño is not null)
        {
            throw new InvalidOperationException("El auto ya tiene un dueño.");
        }

        Dueño = persona;
    }

    public void EliminarDueño() => Dueño = null;

    ~Auto() => throw new Exception($"El objeto Auto con Patente {Patente} ha sido eliminado.");
}
