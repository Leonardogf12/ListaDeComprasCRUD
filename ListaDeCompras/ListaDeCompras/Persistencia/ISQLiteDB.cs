using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDeCompras.Persistencia
{
    public interface ISQLiteDB
    {
        SQLiteConnection GetConnection(); //defeinindo a interface com o SQLite
    }
}
