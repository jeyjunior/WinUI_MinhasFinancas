using MF.Domain.Entidades;
using MF.Domain.Enumerador;
using MF.Domain.Extensao;
using MF.Domain.Interfaces;
using MF.Domain.Interfaces.ViewModel;
using MF.InfraData.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.ViewModel.ViewModel
{
    public class FormaPagamentoViewModel : ViewModelBase, IFormaPagamentoViewModel
    {
        #region Interfaces
        private readonly ITipoTransacaoRepository _tipoTransacaoRepository;
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;
        #endregion

        #region Construtor
        public FormaPagamentoViewModel()
        {
            _tipoTransacaoRepository = Bootstrap.ServiceProvider.GetRequiredService<ITipoTransacaoRepository>();
            _formaPagamentoRepository = Bootstrap.ServiceProvider.GetRequiredService<IFormaPagamentoRepository>();
        }
        #endregion

        #region Collection
        public ObservableCollection<FormaPagamentoGrid> FormaPagamentoCollection { get; set; } = new ObservableCollection<FormaPagamentoGrid>();
        #endregion

        #region Titulo
        public string Titulo { get => $"Forma de pagamento ({FormaPagamentoCollection.Count.ToString("N0")})"; }
        #endregion
        #region Item Selecionado
        private int _pk_FormaPagamentoSelecionada;
        public int PK_FormaPagamentoSelecionada { get => _pk_FormaPagamentoSelecionada; set { _pk_FormaPagamentoSelecionada = value; PropriedadeAlterada(nameof(HabilitarBotaoEditarExcluir)); } }
        #endregion

        #region Botões
        public bool HabilitarBotaoEditarExcluir
        {
            get => (FormaPagamentoCollection.Count > 0 && PK_FormaPagamentoSelecionada > 0);
        }
        #endregion

        #region Metodos Publicos
        public void CarregarColecoes()
        {
            CarregarFormaPagamentoCollection();
        }
        #endregion

        #region Metodos
        private void CarregarFormaPagamentoCollection()
        {
            if (FormaPagamentoCollection == null)
                FormaPagamentoCollection = new ObservableCollection<FormaPagamentoGrid>();

            if (FormaPagamentoCollection.Any())
                FormaPagamentoCollection.Clear();

            var ret = _formaPagamentoRepository.ObterLista().ToList();

            TipoTransacao tipoTransacao = null;

            foreach (FormaPagamento item in ret)
            {
                Icone ativo = IconeGlyph.ObterPadraoIcone_Ativo(item.Ativo);

                var formaPagamentoGrid = new FormaPagamentoGrid
                {
                    PK_FormaPagamento = item.PK_FormaPagamento,
                    FormaPagamento = item.Nome,
                    TipoTransacao = _tipoTransacaoRepository.ObterCodigoTipoTransacao(item.FK_TipoTransacao),
                    TipoTransacaoCor = _tipoTransacaoRepository.ObterPadraoCorTipoTransacao(item.FK_TipoTransacao),
                    AtivoIcone = ativo.Codigo,
                    AtivoCor = ativo.Cor
                };

                FormaPagamentoCollection.Add(formaPagamentoGrid);
            }

            PropriedadeAlterada(nameof(FormaPagamentoCollection));
            PropriedadeAlterada(nameof(Titulo));
        }

        #endregion
    }
}
