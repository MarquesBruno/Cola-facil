using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ColaFacil.Entidades
{
    [Table(Name="Provas")]
    public class Prova
    {
        [Column(IsPrimaryKey=true, IsDbGenerated=true)]
        public int IdProva{ get; set; }
        

        [Column(CanBeNull=false)]
        public string NomeProva{ get; set; }

       // [Column(CanBeNull = false)]
       // public string Pergunta { get; set; }

      //  [Column(CanBeNull = false)]
       // public string Resposta{ get; set; }



        [Column(CanBeNull = false)]
        public int IdMateria { get; set; }
    }
}
