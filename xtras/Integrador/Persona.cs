namespace Integrador;

public class Persona(string dni,
                     string nombre,
                     string apellido) : Entity
{
    public string DNI { get; init; } = dni ?? throw new ArgumentNullException(nameof(dni));
    public string Nombre { get; set; } = nombre ?? throw new ArgumentNullException(nameof(nombre));
    public string Apellido { get; set; } = apellido ?? throw new ArgumentNullException(nameof(apellido));
    
    private readonly List<Auto> autos = [];

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

    ~Persona() => throw new Exception($"El objeto Persona con DNI {DNI} ha sido eliminado.");
}
