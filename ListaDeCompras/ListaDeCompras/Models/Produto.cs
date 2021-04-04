using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeCompras.Models
{
    public class Produto : NotifyBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        private string _nome;
        [MaxLength(100)]
        public string Nome
        {
            get { return _nome; }

            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }


        private string _quantidade;
       
        public string Quantidade {
            get { return _quantidade; }
            set
            {
                _quantidade = value;
                OnPropertyChanged();
            }
        }


    }
}
