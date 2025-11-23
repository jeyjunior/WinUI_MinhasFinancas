using JJ.Net.WinUI3_CrossData.Atributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Entidades
{
    [Entidade("TransacaoFinanceira")]
    public class TransacaoFinanceira
    {
        [ChavePrimaria]
        [Obrigatorio]
        [Identity]
        public long PK_TransacaoFinanceira { get; set; }

        [Obrigatorio]
        [Relacionamento("TipoTransacao", "PK_TipoTransacao")]
        public int FK_TipoTransacao { get; set; }


        [Obrigatorio]
        [TamanhoDecimal(18, 2)]
        [DefaultValue("0.00")]
        public decimal Valor { get; set; }

        [Obrigatorio]
        [TamanhoString(300)]
        public string Descricao { get; set; }

        public DateTime? DataTransacao { get; set; }
        public DateTime? DataVencimento { get; set; }


        [Relacionamento("Categoria", "PK_Categoria")]
        public int FK_Categoria { get; set; }

        [Relacionamento("FormaPagamento", "PK_FormaPagamento")]
        public int FK_FormaPagamento { get; set; }

        [Relacionamento("Entidade", "PK_Entidade")]
        public int FK_Entidade { get; set; }

        [Obrigatorio]
        [DefaultValue("0")]
        public bool Recorrente { get; set; }


        [Relacionamento("Usuario", "PK_Usuario")]
        public int? FK_Usuario { get; set; }


        [Obrigatorio]
        [DefaultValue("CURRENT_TIMESTAMP", true)]
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
