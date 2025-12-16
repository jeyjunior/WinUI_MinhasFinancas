using MF.Domain.Enumerador;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Provider;

namespace MF.Domain.Extensao
{
    public static class IconeGlyph
    {
        public static Icone ObterPadraoIcone_Ativo(bool ativo)
        {
            Icone icone = new Icone();
            
            if (ativo)
            {
                icone.Codigo = "\xF78C";
                icone.Cor = eCor.Verde2.ObterCor();
            }
            else
            {
                icone.Codigo = "\xF78A";
                icone.Cor = eCor.Vermelho1.ObterCor();
            }

            return icone;
        }
    }

    public class Icone
    {
        public string Codigo { get; set; }
        public SolidColorBrush Cor { get; set; }
    }
}
