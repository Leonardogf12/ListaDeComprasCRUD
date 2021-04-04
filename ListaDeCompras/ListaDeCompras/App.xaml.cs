using ListaDeCompras.Persistencia;
using ListaDeCompras.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaDeCompras
{
    public partial class App : Application
    {
        static AcessoDB dbContext;

        public static AcessoDB DataBase
        {
            get
            {
                if (dbContext == null)
                    dbContext = new AcessoDB();

                return dbContext;
            }
        }






        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new HomeCadastroView());
            MainPage = new NavigationPage(new HomeView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
