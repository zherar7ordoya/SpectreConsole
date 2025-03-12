using Integrador.Abstract;

namespace Integrador.Entities;

public class Auto(string patente,
                  string marca,
                  string modelo,
                  int año,
                  decimal precio) : Entity
{
    public readonly string Patente = patente ?? throw new ArgumentNullException(nameof(patente));
    public readonly string Marca = marca ?? throw new ArgumentNullException(nameof(marca));
    public readonly string Modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
    public readonly int Año = año > 1900 && año <= DateTime.Now.Year ? año : throw new ArgumentException("Año inválido.");
    public readonly decimal Precio = precio > 0 ? precio : throw new ArgumentException("El precio debe ser mayor a 0.");

    public Persona? Dueño { get; private set; }

    public static event Action<string>? AutoEliminado;

    public void AsignarDueño(Persona persona)
    {
        if (Dueño is not null)
        {
            throw new InvalidOperationException("El auto ya tiene un dueño.");
        }

        Dueño = persona;
    }

    public void EliminarDueño() => Dueño = null;

    public void CambiarDueño(Persona nuevoDueño)
    {
        if (Dueño != null)
        {
            EliminarDueño(); // Si tiene dueño, eliminamos el vínculo previo.
        }
        AsignarDueño(nuevoDueño);
    }

    ~Auto() => AutoEliminado?.Invoke($"El objeto Auto con Patente {Patente} ha sido eliminado.");
}
