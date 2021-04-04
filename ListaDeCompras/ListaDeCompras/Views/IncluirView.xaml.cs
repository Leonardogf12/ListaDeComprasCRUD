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
    public partial class IncluirView : ContentPage
    {
        ObservableCollection<Produto> colecaoProdutos;

        public IncluirView(ObservableCollection<Produto> _produtos)
        {
            colecaoProdutos = _produtos;

            InitializeComponent();
        }

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.Nome = entryNome.Text;
            produto.Quantidade = entryQtd.Text;

            App.DataBase.InserirProduto(produto);
            colecaoProdutos.Add(produto);
            Navigation.PopAsync();

        }

        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}