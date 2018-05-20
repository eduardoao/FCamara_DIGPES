using DIGPES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIGPES.ViewModel
{
    public class QuestionarioVM
    {
        public PesquisaModel Pesquisa { get; set;  }
        public int Id { get; set; }
        public int OS { get; set; }
        public string Nome { get; set; }
        public string CodigoProduto { get; set; }
        public DateTime Data { get; set; }
        public List<Categoria> QuestaoA { get; set; }
        public List<Categoria> QuestaoB { get; set; }
        public List<Categoria> QuestaoC { get; set; }
        public List<Categoria> QuestaoD { get; set; }
        public List<Categoria> QuestaoE { get; set; }
        public string Justificativa { get; set; }

    }
}
