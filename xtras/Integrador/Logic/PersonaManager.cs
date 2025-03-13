using Integrador.Abstract;
using Integrador.Entities;
using Integrador.Persistence;

namespace Integrador.Logic;

public class PersonaManager : CRUD<Persona>
{
    public void CrearPersona(string dni, string nombre, string apellido)
    {
        var persona = new Persona(dni, nombre, apellido);
        ValidateAndCreate(persona, PersonaValidator.Validar);
    }

    public static List<Auto> GetListaAutos(Persona persona) => persona.Autos;

    public static int GetCantidadAutos(Persona persona) => persona.Autos.Count;

    public static decimal GetValorAutos(Persona persona) => persona.Autos.Sum(auto => auto.Precio);
}
