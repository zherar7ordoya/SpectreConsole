using Algorithmics.DependencyInjection;

using Spectre.Console;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithmics.Kaprekar6174;

public static class Kaprekar6174
{
    public static void Run()
    {
        AnsiConsole.MarkupLine("\n[lime]6174: el misterioso número de Kaprekar.[/]\n");

        Console.WriteLine("Ingrese un número de 4 cifras (que no sean todas iguales):");
        string input = Console.ReadLine();

        if (!EsNumeroValido(input))
        {
            Console.WriteLine("Número inválido. Debe tener 4 cifras distintas entre sí.");
            return;
        }

        int numero = int.Parse(input);
        int iteraciones = 0;

        while (numero != 6174)
        {
            numero = PasoKaprekar(numero);
            iteraciones++;
            Console.WriteLine($"Iteración {iteraciones}: {numero}");
        }

        Console.WriteLine($"Llegamos a 6174 en {iteraciones} iteraciones.");
    }

    // Métodos auxiliares

    static bool EsNumeroValido(string num)
    {
        return num.Length == 4 && int.TryParse(num, out _) && !EsRepetitivo(num);
    }

    static bool EsRepetitivo(string num)
    {
        return num.Distinct().Count() == 1;
    }

    static int PasoKaprekar(int numero)
    {
        string numStr = numero.ToString("D4");
        var descendente = new string([.. numStr.OrderByDescending(c => c)]);
        var ascendente = new string([.. numStr.OrderBy(c => c)]);

        int mayor = int.Parse(descendente);
        int menor = int.Parse(ascendente);

        return mayor - menor;
    }
}
