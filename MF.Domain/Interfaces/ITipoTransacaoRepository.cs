using JJ.Net.WinUI3_CrossData.Interfaces;
using MF.Domain.Entidades;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Interfaces
{
    public interface ITipoTransacaoRepository : IRepository<TipoTransacao>
    {
        string ObterCodigoTipoTransacao(int PK_TipoTransacao);
        SolidColorBrush ObterPadraoCorTipoTransacao(int PK_TipoTransacao);
        string ObterPadraoIconeTipoTransacao(int PK_TipoTransacao);
    }
}
