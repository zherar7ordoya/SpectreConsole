namespace Integrador;

public class Persona(string dni,
                     string nombre,
                     string apellido)
{
    public string DNI { get; init; } = dni ?? throw new ArgumentNullException(nameof(dni));
    public string Nombre { get; set; } = nombre ?? throw new ArgumentNullException(nameof(nombre));
    public string Apellido { get; set; } = apellido ?? throw new ArgumentNullException(nameof(apellido));

    private readonly List<Auto> autos = [];

    public List<Auto> ObtenerAutos() => autos;
    public int CantidadAutos => autos.Count;

    public void AgregarAuto(Auto auto)
    {
        if (auto.Dueño != null)
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

    ~Persona() => Console.WriteLine($"El objeto Persona con DNI {DNI} ha sido eliminado.");
}
