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
    public class ProvaRepositorio
    {
        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();
            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }


     


        public static List<Prova> Get(int pIdMateria)
        {
            DataBase db = GetDataBase();
           //  var query = from prov in db.Provas orderby prov.NomeProva select prov ;
           var query = from prov in db.Provas where prov.IdMateria == pIdMateria orderby prov.NomeProva select prov;
            List<Prova> provinha = new List<Prova>(query.AsEnumerable());
            return provinha;
        }

        public static void Create(Prova pProva)
        {
            DataBase db = GetDataBase();
            db.Provas.InsertOnSubmit(pProva);
            db.SubmitChanges();

        }


        public static void Update(Prova pProva)
        {
            DataBase db = GetDataBase();

            Prova pro = (from p in db.Provas 
                           where p.IdProva == pProva.IdProva
                           select p).First();

            pro.IdMateria = pProva.IdMateria;
            pro.NomeProva = pProva.NomeProva;
           // pro.Pergunta = pProva.Pergunta;
           // pro.Resposta = pProva.Resposta;

            db.SubmitChanges();
        }

        public static void Delete(Prova pProva)
        {
            DataBase db = GetDataBase();
            var query = from p in db.Provas
                        where p.IdProva == pProva.IdProva
                        select p;

            db.Provas.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }
    }
}
   
