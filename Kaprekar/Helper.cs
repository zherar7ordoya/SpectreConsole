using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithmics.Kaprekar;

public static class Helper
{
    public static bool EsNumeroValido(string num)
    {
        return num.Length == 4 && int.TryParse(num, out _) && !num.All(c => c == num[0]);
    }
}
