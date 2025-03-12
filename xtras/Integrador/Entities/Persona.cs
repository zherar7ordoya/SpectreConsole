using Integrador.Abstract;
using System.Text.RegularExpressions;

namespace Integrador.Entities;

public partial class Persona : Entity
{
    public Persona() { }
    public Persona(string dni, string nombre, string apellido)
    {
        DNI = dni ?? throw new ArgumentNullException(nameof(dni));
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
    }

    private string? dni = string.Empty;
    public string? DNI
    {
        get => dni;
        set
        {
            if (string.IsNullOrEmpty(value) || !DniRegex().IsMatch(value))
            {
                throw new ArgumentException("Formato de DNI inválido.");
            }
            dni = value;
        }
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"^\d{7,8}$")]
    public static partial Regex DniRegex();

    public string? Nombre { get; set; }
    public string? Apellido { get; set; }

    private List<Auto> autos = new List<Auto>();
    public IReadOnlyList<Auto> Autos => autos.AsReadOnly();

    public void AgregarAuto(Auto auto)
    {
        if (autos.Contains(auto))
        {
            throw new InvalidOperationException("El auto ya pertenece a la persona.");
        }
        autos.Add(auto);
    }

    public void RemoverAuto(Auto auto)
    {
        if (autos.Remove(auto))
        {
            auto.LiberarDueño();
        }
    }

    public static event Action<string>? PersonaEliminada;
    ~Persona() => PersonaEliminada?.Invoke($"El objeto Persona con DNI {DNI} ha sido eliminado.");
}
