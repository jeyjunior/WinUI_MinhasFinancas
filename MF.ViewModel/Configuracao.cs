using JJ.Net.WinUI3_CrossData.Interfaces;
using MF.Domain;
using MF.Domain.Entidades;
using MF.Domain.Interfaces;
using MF.InfraData.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JJ.Net.WinUI3_CrossData.Data;
using JJ.Net.WinUI3_CrossData.Extensao;

namespace MF.ViewModel
{
    public static class Configuracao
    {
        public static void Iniciar()
        {
            RegistrarEntidades();
            RegistrarTipoTransacaoValoresIniciais();
        }
        public static void RegistrarEntidades()
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var todasEntidades = EntidadeManager.ObterTodasEntidades();

                    var statusTabelas = uow.Connection.VerificarEntidadeExiste(todasEntidades);
                    var entidadesParaCriar = todasEntidades
                        .Where(entidade => !statusTabelas[entidade])
                        .ToList();

                    if (!entidadesParaCriar.Any())
                        return;

                    uow.Begin();

                    foreach (var entidade in entidadesParaCriar)
                    {
                        try
                        {
                            uow.Connection.CriarTabela(entidade, uow.Transaction);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Erro ao criar tabela {entidade.Name}: {ex.Message}", ex);
                        }
                    }

                    uow.Commit();
                }
                catch (SqlException ex)
                {
                    uow.Rollback();
                    throw new Exception("Erro ao criar as entidades no banco de dados", ex);
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    throw new Exception("Erro inesperado ao criar as entidades", ex);
                }
            }
        }
        public static void RegistrarTipoTransacaoValoresIniciais()
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var tipoTransacaoRepository = new TipoTransacaoRepository(uow);

                    if (tipoTransacaoRepository.ObterLista("TipoTransacao.Codigo = 'Entrada'").FirstOrDefault() == null)
                    {
                        uow.Begin();

                        tipoTransacaoRepository.Adicionar(new TipoTransacao { PK_TipoTransacao = 1, Codigo = "Todos" });
                        tipoTransacaoRepository.Adicionar(new TipoTransacao { PK_TipoTransacao = 2, Codigo = "Entrada" });
                        tipoTransacaoRepository.Adicionar(new TipoTransacao { PK_TipoTransacao = 3, Codigo = "Saída" });

                        uow.Commit();
                    }
                }
                catch (SqlException ex)
                {
                    uow.Rollback();
                    throw new Exception("Erro ao inserir valores iniciais na base de dados.\n", ex);
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    throw new Exception("Erro inesperado ao tentar inserir valores iniciais na base de dados.\n", ex);
                }
            }
        }
    }
}
