using Integrador.Abstract;
using System.Text.RegularExpressions;

namespace Integrador.Entities;

public partial class Auto : Entity
{
    public Auto() { }
    public Auto(string patente, string marca, string modelo, int año, decimal precio)
    {
        Patente = patente ?? throw new ArgumentNullException(nameof(patente));
        Marca = marca ?? throw new ArgumentNullException(nameof(marca));
        Modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
        Año = año > 1900 && año <= DateTime.Now.Year ? año : throw new ArgumentException("Año inválido.");
        Precio = precio > 0 ? precio : throw new ArgumentException("El precio debe ser mayor a 0.");
    }

    //--------------------------------------------------------------------------

    private string? patente = string.Empty;
    public string? Patente
    {
        get => patente;
        set
        {
            if (string.IsNullOrEmpty(value) || !PatenteRegex().IsMatch(value))
            {
                throw new ArgumentException("Formato de patente inválido.");
            }
            patente = value;
        }
    }

    public string? Marca { get; }
    public string? Modelo { get; }
    public int Año { get; }
    public decimal Precio { get; }

    public Persona? Dueño { get; internal set; }
    internal void EstablecerDueño(Persona? nuevoDueño) => Dueño = nuevoDueño;

    //--------------------------------------------------------------------------

    [System.Text.RegularExpressions.GeneratedRegex(@"^[A-Z]{2}\d{3}[A-Z]{2}$|^[A-Z]{3}\d{3}$")]
    private static partial Regex PatenteRegex();

    //--------------------------------------------------------------------------

    public static event Action<string>? AutoEliminado;
    ~Auto() => AutoEliminado?.Invoke($"El objeto Auto con Patente {Patente} ha sido eliminado.");
}
