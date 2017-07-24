using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ColaFacil.Entidades
{
    [Table(Name="Materias")]
    public class Materia
    {
        [Column(IsPrimaryKey=true, IsDbGenerated=true)]
        public int IdMateria{ get; set; }

        [Column(CanBeNull=false)]
        public string NomeMateria { get; set; }

        [Column(CanBeNull = false)]
        public string NomeProf{ get; set; }

        
    }
    
}
