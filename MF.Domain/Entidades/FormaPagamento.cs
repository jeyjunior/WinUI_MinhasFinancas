using JJ.Net.WinUI3_CrossData.Atributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Entidades
{
    [Entidade("FormaPagamento")]
    public class FormaPagamento
    {
        [ChavePrimaria]
        [Obrigatorio]
        [Identity]
        public int PK_FormaPagamento { get; set; }

        [Obrigatorio]
        [TamanhoString(100)]
        public string Nome { get; set; }

        [Obrigatorio]
        [Relacionamento("TipoTransacao", "PK_TipoTransacao")]
        public int FK_TipoTransacao { get; set; }

        [Obrigatorio]
        [DefaultValue("1")]
        public bool Ativo { get; set; }

        [Relacionamento("Usuario", "PK_Usuario")]
        public int? FK_Usuario { get; set; }
    }
}
