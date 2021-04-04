using ListaDeCompras.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.IO;


namespace ListaDeCompras.Persistencia
{
    public class AcessoDB : IDisposable
    {
        protected static object locker = new object();
        public SQLiteConnection db;



        public AcessoDB()
        {
            //db = DependencyService.Get<ISQLiteDB>().GetConnection();//obtem o contexto de cada implementacao de cada plataforma
            db = DependencyService.Get<ISQLiteDB>().GetConnection();
            db.CreateTable<Produto>();//abre a tabela produto
        }



        //post de insert
        public void InserirProduto(Produto produto)
        {
            lock (locker)
            {
                db.Insert(produto);
            }
        }

        //post de remove
        public void RemoverProduto(Produto produto)
        {
            lock (locker)
            {
                db.Delete(produto);
            }
        }

        //post apaga tudo
        public void RemoverTudo()
        {
            lock (locker)
            {
                db.DeleteAll<Produto>();
            }
        }

        //post de update
        public void AtualizaProduto(Produto produto)
        {
            lock (locker)
            {
                db.Update(produto);
            }
        }



        //get de produto especifico
        public Produto GetProduto(int cod)
        {
            lock (locker)
            {
                return db.Table<Produto>().Where(p => p.Id == cod).FirstOrDefault();
            }
        }

        //get todos produtos
        public List<Produto> GetProdutos()
        {
            lock (locker)
            {
                return db.Table<Produto>().ToList();
            }
        }

        //get de filtro
        public List<Produto> GetProdutos(string nome)
        {
            lock (locker)
            {
                return db.Table<Produto>().Where(p => p.Nome.Contains(nome)).ToList();
            }
        }

       

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
