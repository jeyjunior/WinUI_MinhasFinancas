using Microsoft.UI.Xaml.Controls;
using MF.Domain.Entidades; 

namespace MF.Presentation.Views
{
    public sealed partial class FormaPagamentoDialog : ContentDialog
    {
        public FormaPagamentoDialog()
        {
            this.InitializeComponent();

            this.PrimaryButtonClick += FormaPagamentoDialog_PrimaryButtonClick;
        }

        public FormaPagamento ObjetoResultado { get; private set; }

        private void FormaPagamentoDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                args.Cancel = true;

                txtNome.Header = "Nome da Forma de Pagamento (Obrigatório)";
                return;
            }

            ObjetoResultado = new FormaPagamento
            {
                Nome = txtNome.Text,
                Ativo = chkAtivo.IsChecked ?? false,
                FK_TipoTransacao = cmbTipoTransacao.SelectedIndex + 1
            };
        }
    }
}