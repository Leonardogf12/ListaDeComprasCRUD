using ListaDeCompras.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaDeCompras.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeCadastroView : ContentPage
    {
        public ObservableCollection<Produto> _produtos;



        public HomeCadastroView()
        {
            InitializeComponent();

            #region LISTA OS PRODUTOS NO LISTVIEW DE CADASTRO DA HOME

            var produtos = App.DataBase.GetProdutos();
            _produtos = new ObservableCollection<Produto>(produtos);
            listaProdutos.ItemsSource = _produtos;

            #endregion


        }

        private void addProduto_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IncluirView(_produtos));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listaProdutos.ItemsSource = App.DataBase.GetProdutos(e.NewTextValue);
        }

        private void menuItemEditar_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var produto = menuItem.CommandParameter as Produto;
            Navigation.PushAsync(new EditarView(produto));

        }

        private async void menuItemExcluir_Clicked(object sender, EventArgs e)
        {
            var produto = (sender as MenuItem).CommandParameter as Produto;
            var resposta = await DisplayAlert("Tem certeza que deseja excluir? ", $"Produto: { produto.Nome}", "Sim", "Nao");
            if (resposta)
            {
                App.DataBase.RemoverProduto(produto);
                _produtos.Remove(produto);
            }
        }

        private async void removeProduto_Activated(object sender, EventArgs e)
        {
            var produtos = App.DataBase.GetProdutos().Count();
            if (produtos != 0)
            {
                var calc = Convert.ToInt32(produtos);
                var resposta = await DisplayAlert("Atenção!", $"Deseja realmente apagar a lista de compras? Você tem {calc} itens na lista.", "Sim", "Não");
                if (resposta)
                {
                    App.DataBase.RemoverTudo();
                    await Navigation.PopAsync();
                }

                return;

            }
            else if (produtos == 0)
            {
                await DisplayAlert("Lista", "Você não possui itens na lista de compras", "OK");
            }
            return;

        }
    }
}