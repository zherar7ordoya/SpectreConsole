using Integrador.Abstract;

namespace Integrador.Entities;

public class Persona : Entity
{
    public Persona() { }

    public Persona(string dni, string nombre, string apellido)
    {
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
    }

    //--------------------------------------------------------------------------

    public string? DNI { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }

    public List<Auto> Autos { get; } = [];

    //--------------------------------------------------------------------------

    public static event Action<string>? PersonaEliminada;
    ~Persona() => PersonaEliminada?.Invoke($"El objeto Persona con DNI {DNI} ha sido eliminado.");
}
