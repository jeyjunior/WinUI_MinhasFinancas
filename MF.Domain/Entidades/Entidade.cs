using JJ.Net.WinUI3_CrossData.Atributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Entidades
{
    [Entidade("Entidade")]
    public class Entidade
    {
        [ChavePrimaria]
        [Obrigatorio]
        [Identity]
        public int PK_Entidade { get; set; }

        [Obrigatorio]
        [TamanhoString(100)]
        public string Nome { get; set; }

        [Obrigatorio]
        [Relacionamento("TipoTransacao", "PK_TipoTransacao")]
        public int FK_TipoTransacao { get; set; }

        [Relacionamento("Usuario", "PK_Usuario")]
        public int? FK_Usuario { get; set; }
    }
}
