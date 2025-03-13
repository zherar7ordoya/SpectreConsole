using Integrador.Abstract;

namespace Integrador.Entities;

public class Auto : Entity
{
    public Auto() { }

    public Auto(string patente, string marca, string modelo, int año, decimal precio)
    {
        Patente = patente;
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Precio = precio;
    }

    //--------------------------------------------------------------------------

    public string? Patente { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public int Año { get; set; }
    public decimal Precio { get; set; }

    public Persona? Dueño { get; internal set; }
    internal void EstablecerDueño(Persona? nuevoDueño) => Dueño = nuevoDueño;

    //--------------------------------------------------------------------------

    public static event Action<string>? AutoEliminado;
    ~Auto() => AutoEliminado?.Invoke($"El objeto Auto con Patente {Patente} ha sido eliminado.");
}
