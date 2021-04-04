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
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private async void lista_Tapped(object sender, EventArgs e)
        {
            imagemHome.Opacity = 0.5;
            await Task.Delay(100);
            imagemHome.Opacity = 1;
            await Navigation.PushAsync(new HomeCadastroView());
        }
    }
}