using Integrador.Entities;

namespace Integrador;

public static class Logic
{
    public static void AsignarAuto(Persona persona, Auto auto)
    {
        if (auto.Dueño is not null)
        {
            throw new InvalidOperationException("El auto ya tiene un dueño.");
        }

        persona.Autos.Add(auto);
        auto.EstablecerDueño(persona);
    }

    public static void DesasignarAuto(Persona persona, Auto auto)
    {
        if (persona.Autos.Remove(auto))
        {
            auto.EstablecerDueño(null);
        }
        else
        {
            throw new InvalidOperationException("El auto no pertenece a la persona.");
        }
    }

    public static List<Auto> GetListaAutos(Persona persona) => persona.Autos;

    public static int GetCantidadAutos(Persona persona) => persona.Autos.Count;

    public static decimal GetValorAutos(Persona persona) => persona.Autos.Sum(auto => auto.Precio);
}
