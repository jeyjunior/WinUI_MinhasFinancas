using MF.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Interfaces.ViewModel
{
    public interface IFormaPagamentoViewModel
    {
        ObservableCollection<FormaPagamentoGrid> FormaPagamentoCollection { get; set; }
        int PK_FormaPagamentoSelecionada { get; set; }
        string Titulo { get; }
        void CarregarColecoes();
        bool DeletarFormaPagamentoSelecionada();
        void Ordenar(string campo);
    }
}
