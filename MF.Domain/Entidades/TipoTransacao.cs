using JJ.Net.WinUI3_CrossData.Atributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Entidades
{
    [Entidade("TipoTransacao")]
    public class TipoTransacao
    {
        [ChavePrimaria]
        [Obrigatorio]
        [Identity(false)]
        public int PK_TipoTransacao { get; set; }

        [Obrigatorio]
        [TamanhoString(20)]
        [Unique]
        public string Codigo { get; set; }
    }
}
