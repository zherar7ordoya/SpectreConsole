using Integrador.Abstract;

namespace Integrador.Entities;

public class Persona(string dni,
                     string nombre,
                     string apellido) : Entity
{
    public readonly string DNI = dni ?? throw new ArgumentNullException(nameof(dni));
    public readonly string Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
    public readonly string Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
    
    private readonly List<Auto> autos = [];

    public static event Action<string>? PersonaEliminada;

    public IReadOnlyList<Auto> ObtenerAutos() => autos.AsReadOnly();

    public int CantidadAutos => autos.Count;

    public decimal TotalValorAutos => autos.Sum(auto => auto.Precio);

    public void AgregarAuto(Auto auto)
    {
        if (auto.Dueño is not null)
        {
            throw new InvalidOperationException("El auto ya tiene un dueño.");
        }

        autos.Add(auto);
        auto.AsignarDueño(this);
    }

    public void EliminarAuto(Auto auto)
    {
        if (autos.Remove(auto))
        {
            auto.EliminarDueño();
        }
    }

    ~Persona() => PersonaEliminada?.Invoke($"El objeto Persona con DNI {DNI} ha sido eliminado.");
}
