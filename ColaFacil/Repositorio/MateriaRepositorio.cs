using ColaFacil.Banco;
using ColaFacil.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaFacil.Repositorio
{
    public class MateriaRepositorio
    {
        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();
            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }

        public static List<Materia> Get()
        {
            DataBase db = GetDataBase();
            var query = from mat in db.Materias orderby mat.NomeMateria select mat;

            List<Materia> disciplinas = new List<Materia>(query.AsEnumerable());
            return disciplinas;
        }

        public static void Create(Materia pMateria)
        {
            DataBase db = GetDataBase();
            db.Materias.InsertOnSubmit(pMateria);
            db.SubmitChanges();

        }

        public static void Update(Materia pMateria)
        {
            DataBase db = GetDataBase();

            Materia mat = (from c in db.Materias
                           where c.IdMateria == pMateria.IdMateria
                           select c).First();

            mat.NomeMateria = pMateria.NomeMateria;
            mat.NomeProf = pMateria.NomeProf;

            db.SubmitChanges();
        }

        public static void Delete(Materia pMateria)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Materias
                        where c.IdMateria == pMateria.IdMateria
                        select c;

            db.Materias.DeleteOnSubmit(query.ToList()[0]);            
            db.SubmitChanges();
        }
    }
}