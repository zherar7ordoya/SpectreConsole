using Integrador.Entities;
using Integrador.Persistence;

namespace Integrador.Logic;

public class AutoManager : CRUD<Auto>
{
    public void CrearAuto(string patente, string marca, string modelo, int año, decimal precio)
    {
        var auto = new Auto(patente, marca, modelo, año, precio);
        ValidateAndCreate(auto, AutoValidator.Validar);
    }
}
