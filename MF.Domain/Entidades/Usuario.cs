using JJ.Net.WinUI3_CrossData.Atributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Entidades
{
    [Entidade("Usuario")]
    public class Usuario
    {
        [ChavePrimaria]
        [Obrigatorio]
        [Identity]
        public int PK_Usuario { get; set; }

        [Obrigatorio]
        [TamanhoString(255)]
        [Unique]
        public string Email { get; set; }

        [Obrigatorio]
        [TamanhoString(255)]
        public string Nome { get; set; }

        [TamanhoString(2000)]
        public string LoginApi { get; set; }

        [Obrigatorio]
        [DefaultValue("CURRENT_TIMESTAMP", true)]
        public DateTime DataCadastro { get; set; }
        
        [Obrigatorio]
        [DefaultValue("1")]
        public bool Ativo { get; set; }
    }
}
