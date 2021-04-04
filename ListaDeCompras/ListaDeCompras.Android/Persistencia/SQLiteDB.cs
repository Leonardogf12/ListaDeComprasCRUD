using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ListaDeCompras.Droid.Persistencia;
using ListaDeCompras.Persistencia;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDB))]
namespace ListaDeCompras.Droid.Persistencia
{
    public class SQLiteDB : ISQLiteDB
    {
        SQLiteConnection ISQLiteDB.GetConnection()
        {
            var caminhoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments); //caminho da pasta do banco
            var caminho = Path.Combine(caminhoPasta, "Listacompras.db3");

            return new SQLiteConnection(caminho);
        }
    }
}