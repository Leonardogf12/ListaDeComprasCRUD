using ListaDeCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaDeCompras.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarView : ContentPage
    {

        Produto produtoEditado;

        public EditarView(Produto produto)
        {

            if(produto == null)
            {
                throw new ArgumentException();
                DisplayAlert("Falha", "Este produto nao existe", "OK");
            }
            produtoEditado = produto;
            BindingContext = produto;

            InitializeComponent();
        }

        private void Editar_Clicked(object sender, EventArgs e)
        {
            produtoEditado.Nome = entryNome.Text;
            produtoEditado.Quantidade = entryQtd.Text;

            App.DataBase.AtualizaProduto(produtoEditado);
            Navigation.PopAsync();
        }

        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}