using MF.Domain.Enumerador;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Extensao
{
    public static class Cor
    {
        public static SolidColorBrush ObterCor(this string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return null;

            var resources = Microsoft.UI.Xaml.Application.Current.Resources;
            if (resources.TryGetValue(key, out var value) && value is SolidColorBrush brush)
                return brush;

            if (resources.TryGetValue("Transparente", out var none) && none is SolidColorBrush noneBrush)
                return noneBrush;

            return null;
        }

        public static SolidColorBrush ObterCor(this eCor cor)
        {
            return cor.ToString().ObterCor();
        }
    }
}
