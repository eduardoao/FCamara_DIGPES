using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIGPES.Models
{
    [Table("Pesquisa")]
    public class PesquisaModel
    {
        [Key]
        public int id { get; set; }
        public int OS { get; set; }

        [Column("Codigo_Produto")]
        public string CodigoProduto { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }

        public int? QuestaoA { get; set; }
        public int? QuestaoB { get; set; }
        public int? QuestaoC { get; set; }
        public int? QuestaoD { get; set; }
        

        public string Justificativa { get; set; }
        public int? QuestaoE { get; set; }

        

    }
}
