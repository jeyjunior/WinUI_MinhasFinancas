using MF.Domain.Entidades;
using MF.Domain.Interfaces.ViewModel;
using MF.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;


namespace MF.Presentation.Views
{
    public sealed partial class FormaPagamentoPage : Page
    {
        #region Interface
        private readonly IFormaPagamentoViewModel _formaPagamentoViewModel;
        #endregion

        #region Construtor
        public FormaPagamentoPage()
        {
            InitializeComponent();

            _formaPagamentoViewModel = Bootstrap.ServiceProvider.GetRequiredService<IFormaPagamentoViewModel>();

            this.DataContext = _formaPagamentoViewModel;
            lstPrincipal.ItemsSource = _formaPagamentoViewModel.FormaPagamentoCollection;
        }
        #endregion
        private void Page_Loading(FrameworkElement sender, object args)
        {
            _formaPagamentoViewModel.CarregarColecoes();
        }

        private void lstPrincipal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _formaPagamentoViewModel.PK_FormaPagamentoSelecionada = 0;

            if (lstPrincipal.SelectedItem != null)
            {
                var formaPagamento = lstPrincipal.SelectedItem as FormaPagamentoGrid;
                if (formaPagamento != null)
                    _formaPagamentoViewModel.PK_FormaPagamentoSelecionada = formaPagamento.PK_FormaPagamento;
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
