using JJ.Net.WinUI3_CrossData.InfraData;
using JJ.Net.WinUI3_CrossData.Interfaces;
using MF.Domain.Entidades;
using MF.Domain.Enumerador;
using MF.Domain.Extensao;
using MF.Domain.Interfaces;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.InfraData.Repository
{
    public class TipoTransacaoRepository : Repository<TipoTransacao>, ITipoTransacaoRepository
    {
        public TipoTransacaoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public string ObterCodigoTipoTransacao(int PK_TipoTransacao)
        {
            if (PK_TipoTransacao == 1)
                return "Todos";

            if (PK_TipoTransacao == 2)
                return "Entrada";

            if (PK_TipoTransacao == 3)
                return "Saída";

            return "";
        }
        public SolidColorBrush ObterPadraoCorTipoTransacao(int PK_TipoTransacao)
        {
            if (PK_TipoTransacao == 1)
                return eCor.Cinza1.ObterCor();

            if (PK_TipoTransacao == 2)
                return eCor.Verde2.ObterCor();

            if (PK_TipoTransacao == 3)
                return eCor.Laranja1.ObterCor();

            return eCor.Transparente.ObterCor();
        }

        public string ObterPadraoIconeTipoTransacao(int PK_TipoTransacao)
        {
            if (PK_TipoTransacao == 1)
                return "\xF129"; 

            if (PK_TipoTransacao == 2)
                return "\xE70E";

            if (PK_TipoTransacao == 3)
                return "\xE70D";

            return "";
        }
    }
}
