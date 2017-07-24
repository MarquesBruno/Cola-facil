using ColaFacil.Banco;
using ColaFacil.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows;

namespace ColaFacil.Repositorio
{
    public class PerguntaRepositorio
    {
        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();
            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }


     


        public static List<Pergunta> Get(int pIdProva)
        {
            DataBase db = GetDataBase();
           //  var query = from prov in db.Provas orderby prov.NomeProva select prov ;
           var query = from perg in db.Perguntas where perg.IdProva == pIdProva orderby perg.NomePergunta select perg;
            List<Pergunta> perguntinha = new List<Pergunta>(query.AsEnumerable());
            return perguntinha;
        }

        public static void Create(Pergunta pPergunta)
        {
            DataBase db = GetDataBase();
            db.Perguntas.InsertOnSubmit(pPergunta);
            db.SubmitChanges();

        }


        public static void Update(Pergunta pPergunta)
        {
            DataBase db = GetDataBase();

            Pergunta perg = (from p in db.Perguntas
                         where p.IdPergunta == pPergunta.IdPergunta
                           select p).First();


            perg.IdProva = pPergunta.IdProva;
            perg.NomePergunta = pPergunta.NomePergunta;
            perg.Resposta = pPergunta.Resposta;

           
            db.SubmitChanges();
        }

        public static void Delete(Pergunta pPergunta)
        {
            DataBase db = GetDataBase();
            var query = from p in db.Perguntas
                        where p.IdPergunta == pPergunta.IdPergunta
                        select p;

            db.Perguntas.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }
    }
}
   
