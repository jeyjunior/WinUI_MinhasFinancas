using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MF.Domain;
using MF.Domain.Entidades;
using MF.Domain.Interfaces;
using MF.InfraData.Repository;
using JJ.Net.WinUI3_CrossData.Data;
using JJ.Net.WinUI3_CrossData.Enumerador;
using JJ.Net.WinUI3_CrossData.InfraData;
using JJ.Net.WinUI3_CrossData.Interfaces;

namespace MF.ViewModel
{
    public static class Bootstrap
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Iniciar()
        {
            try
            {
                var host = Host.CreateDefaultBuilder()
                    .ConfigureServices((context, services) =>
                    {
                        services.AddScoped<IUnitOfWork, UnitOfWork>();
                        services.AddScoped<IUnitOfWork>(provider => new UnitOfWork(JJ.Net.WinUI3_CrossData.Enumerador.TipoBancoDados.SQLServer));

                        RegistrarServicos(services);
                    })
                    .Build();

                ServiceProvider = host.Services;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro na inicialização: {ex}");
            }
        }
        private static void RegistrarServicos(IServiceCollection services)
        {
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<ITipoTransacaoRepository, TipoTransacaoRepository>();
            services.AddSingleton<ICategoriaRepository, CategoriaRepository>();
            services.AddSingleton<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddSingleton<IEntidadeRepository, EntidadeRepository>();
            services.AddSingleton<ITransacaoFinanceiraRepository, TransacaoFinanceiraRepository>();
        }
    }
}
