using JJ.Net.WinUI3_CrossData.Atributo;
using MF.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain
{
    public static class EntidadeManager
    {
        private static readonly List<Type> _entidadesOrdenadas = new List<Type>
        {
            // Tabelas independentes (sem FK) primeiro
            typeof(Usuario),
            typeof(TipoTransacao),
        
            // Tabelas que dependem das anteriores
            typeof(Categoria),
            typeof(FormaPagamento),
            typeof(Entidade),
        
            // Tabelas que dependem de múltiplas outras (últimas)
            typeof(TransacaoFinanceira)
        };

        public static List<Type> ObterTodasEntidades()
        {
            return _entidadesOrdenadas.ToList(); 
        }

        public static void AdicionarEntidade(Type entidade)
        {
            if (!_entidadesOrdenadas.Contains(entidade))
            {
                _entidadesOrdenadas.Add(entidade);
            }
        }

        public static void AdicionarEntidades(params Type[] entidades)
        {
            foreach (var entidade in entidades)
            {
                AdicionarEntidade(entidade);
            }
        }
        private static List<Type> ObterTodasEntidadesPorAssembly()
        {
            var assembly = Assembly.GetExecutingAssembly(); 
            var entidades = assembly.GetTypes()
                .Where(t => t.GetCustomAttribute<EntidadeAttribute>() != null)
                .ToList();

            return entidades;
        }
        private static List<Type> ObterTodasEntidadesPorNamespace()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var entidades = assembly.GetTypes()
                .Where(t => t.Namespace != null &&
                           (t.Namespace.Contains(".Entities") ||
                            t.Namespace.Contains(".Models") ||
                            t.Namespace.Contains(".Domain")))
                .Where(t => t.IsClass && !t.IsAbstract)
                .ToList();

            return entidades;
        }
    }
}
