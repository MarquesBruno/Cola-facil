using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ColaFacil.Entidades
{
    [Table(Name="Perguntas")]
    public class Pergunta
    {
        [Column(IsPrimaryKey=true, IsDbGenerated=true)]
        public int IdPergunta{ get; set; }


        [Column(CanBeNull = false)]
        public int IdProva { get; set; }
        
        [Column(CanBeNull = false)]
        public string NomePergunta { get; set; }
        
        [Column(CanBeNull = false)]
        public string Resposta{ get; set; }



        
    }
}
