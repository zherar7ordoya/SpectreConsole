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

    //--------------------------------------------------------------------------

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

    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
        
    public List<Auto> Autos = [];

    //--------------------------------------------------------------------------

    [System.Text.RegularExpressions.GeneratedRegex(@"^\d{7,8}$")]
    private static partial Regex DniRegex();

    //--------------------------------------------------------------------------

    public static event Action<string>? PersonaEliminada;
    ~Persona() => PersonaEliminada?.Invoke($"El objeto Persona con DNI {DNI} ha sido eliminado.");
}
