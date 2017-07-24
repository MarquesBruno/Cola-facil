using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using ColaFacil.Entidades;

namespace ColaFacil.Banco
{
    public class DataBase : DataContext
    {
        public static string DBConnectionString =
            "Data Source = 'isostore:provaDB.sdf'";

        public DataBase()
            : base(DBConnectionString)
        {
        }

        public Table<Materia> Materias
        {
            get { return this.GetTable<Materia>(); }
        }

        public Table<Prova> Provas
        {
            get { return this.GetTable<Prova>(); }
        }

        public Table<Pergunta> Perguntas
        {
            get { return this.GetTable<Pergunta>(); }
        }

    }
 


  
}
