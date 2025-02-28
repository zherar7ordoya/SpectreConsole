using Spectre.Console;
using System;
using System.Linq;

namespace Algorithmics.Kaprekar;

public static class Kaprekar
{
    public static void Run()
    {
        AnsiConsole.MarkupLine("\n[lime]6174: el misterioso número de Kaprekar.[/]\n");

        Console.WriteLine("\nIngrese un número de 4 cifras (que no sean todas iguales):\n");
        string? input = Console.ReadLine();

        Console.WriteLine();

        if (input == null || !Helper.EsNumeroValido(input))
        {
            Console.WriteLine("Número inválido. Deben ser 4 cifras que no pueden ser todas iguales.");
            return;
        }

        Resultado resultado = new(int.Parse(input));
        int iteracion = 0;

        while (resultado.Numero != 6174)
        {
            iteracion++;
            Console.WriteLine($"Iteración {iteracion}: {resultado.Descendente} - {resultado.Ascendente} = {resultado.Mayor - resultado.Menor}");
            resultado = resultado.Calcular();
        }

        Console.WriteLine($"\nLlegamos a 6174 en {iteracion} iteraciones.");
    }
}
