using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DIGPES.Models;
using DIGPES.ViewModel;
using System;
using System.Linq;

namespace DIGPES.Controllers
{
    public class PesquisaController : Controller
    {
        private readonly DIGPESContext _context;

        public PesquisaController(DIGPESContext context)
        {
            _context = context;
        }

       
        public IActionResult Sumarizado()
        {
            var listaOs = _context.PesquisaModel.ToListAsync();
            var vm = new QuestionarioVM();
            var listaquestionario = new List<QuestionarioVM>();
            for (int i = 0; i < listaOs.Result.Count; i++)
            {
                vm = DadosManipulados(listaOs.Result[i]);
                listaquestionario.Add(vm);
            }
            return View(listaquestionario);                   
        }

   
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var pesquisaModel = await _context.PesquisaModel
                .SingleOrDefaultAsync(m => m.id == Id);
            if (pesquisaModel == null)
            {
                return NotFound();
            }
                        

            QuestionarioVM questionarioVm = new QuestionarioVM { Pesquisa = pesquisaModel };

            questionarioVm.Id = Id.Value;

            questionarioVm.QuestaoA = new List<Categoria>() { new Categoria { Id = 1, Valor = "Sim" }, new Categoria { Id = 2, Valor = "Não" } };
            questionarioVm.QuestaoB = new List<Categoria>() { new Categoria { Id = 1, Valor = "Instalação do produto" }, new Categoria { Id = 2, Valor = "Orientações sobre o uso" }, new Categoria { Id = 3, Valor = "Conserto do produto" } };
            questionarioVm.QuestaoC = new List<Categoria>() { new Categoria { Id = 1, Valor = "Lista telefônica" }, new Categoria { Id = 2, Valor = "Viu na rua" }, new Categoria { Id = 3, Valor = "Linha 0800" }, new Categoria { Id = 4, Valor = "Manual do produto" }, new Categoria { Id = 5, Valor = "Indicação de conhecidos" } };
            questionarioVm.QuestaoD = new List<Categoria>()
            {
                new Categoria { Id = 1, Valor = "Muito Satisfeito", Checado =false },
                new Categoria { Id = 2, Valor = "Satisfeito", Checado = false },
                new Categoria { Id = 3, Valor = "Razoavelmente satisfeito", Checado =false } ,
                new Categoria { Id = 4, Valor = "Insatisfeito", Checado =false },
                new Categoria { Id = 5, Valor = "Muito insatisfeito", Checado =false }
            };
            questionarioVm.QuestaoE = new List<Categoria>() { new Categoria { Id = 1, Valor = "Sim" }, new Categoria { Id = 2, Valor = "Não" } };
            

            return View(questionarioVm);
        }

      
        public IActionResult Create()
        {
            return View();
        }

        // POST: PesquisaModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PesquisaModel pesquisaModel)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(pesquisaModel);
                await _context.SaveChangesAsync();

               var  id = pesquisaModel.id;
                return RedirectToAction("Details", new { id });

            }        

            return View(pesquisaModel);
        }


    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(PesquisaModel questionarioVM)
        {            
            if (ModelState.IsValid)
            {
                _context.Update(questionarioVM);                
                await _context.SaveChangesAsync();              
                return RedirectToAction("Sumarizado");
            }

            return View(questionarioVM);
        }

        public IActionResult Grafico()
        {
            var listaOs = _context.PesquisaModel.ToListAsync();


            return View();
        }
        

        private QuestionarioVM DadosManipulados(PesquisaModel pesquisa)
        {
            var questionarioVm = new QuestionarioVM();

            questionarioVm.OS = pesquisa.OS;
            questionarioVm.CodigoProduto = pesquisa.CodigoProduto;
            questionarioVm.Nome = pesquisa.Nome;
            questionarioVm.Data = pesquisa.Data;


            if (pesquisa.QuestaoA.HasValue)
            {
                if ((pesquisa.QuestaoA.Value == 1))
                {
                    questionarioVm.QuestaoA = new List<Categoria>() { new Categoria { Id = 1, Valor = "Sim" } };
                }
                else
                {
                    questionarioVm.QuestaoA = new List<Categoria>() { new Categoria { Id = 1, Valor = "Náo" } };
                }
            }


            switch (pesquisa.QuestaoB)
            {
                case 1:
                    questionarioVm.QuestaoB = new List<Categoria>() { new Categoria { Id = 1, Valor = "Instalação do produto" } };
                    break;
                case 2:
                    questionarioVm.QuestaoB = new List<Categoria>() { new Categoria { Id = 2, Valor = "Orientações sobre o uso" } };
                    break;
                case 3:
                    questionarioVm.QuestaoB = new List<Categoria>() { new Categoria { Id = 3, Valor = "Conserto do produto" } };
                    break;
                default:
                    break;
            }


            switch (pesquisa.QuestaoC)
            {
                case 1:
                    questionarioVm.QuestaoC = new List<Categoria>() { new Categoria { Id = 1, Valor = "Lista telefônica" } };
                    break;
                case 2:
                    questionarioVm.QuestaoC = new List<Categoria>() { new Categoria { Id = 2, Valor = "Viu na rua" } };
                    break;
                case 3:
                    questionarioVm.QuestaoC = new List<Categoria>() { new Categoria { Id = 3, Valor = "Linha 0800" } };
                    break;
                case 4:
                    questionarioVm.QuestaoC = new List<Categoria>() { new Categoria { Id = 4, Valor = "Manual do produto" } };
                    break;
                case 5:
                    questionarioVm.QuestaoC = new List<Categoria>() { new Categoria { Id = 5, Valor = "Indicação de conhecido" } };
                    break;
                default:
                    break;
            }


            // var valorcheckbox = pesquisa.QuestaoD.Split(",");
            // foreach (var item in pesquisa.QuestaoD)
            {
                switch (pesquisa.QuestaoD)
                {
                    case 1:
                        questionarioVm.QuestaoD = new List<Categoria>() { new Categoria { Id = 1, Valor = "Muito Satisfeito" } };
                        break;
                    case 2:
                        questionarioVm.QuestaoD = new List<Categoria>() { new Categoria { Id = 2, Valor = "Satisfeito" } };
                        break;
                    case 3:
                        questionarioVm.QuestaoD = new List<Categoria>() { new Categoria { Id = 3, Valor = "Razoavelmente satisfeito" } };
                        break;
                    case 4:
                        questionarioVm.QuestaoD = new List<Categoria>() { new Categoria { Id = 3, Valor = "Insatisfeito" } };
                        break;

                    case 5:
                        questionarioVm.QuestaoD = new List<Categoria>() { new Categoria { Id = 3, Valor = "Muito insatisfeito" } };
                        break;
                    default:
                        break;
                }
            }


            questionarioVm.Justificativa = pesquisa.Justificativa;


            if (pesquisa.QuestaoE.HasValue)
            {
                if ((pesquisa.QuestaoE.Value == 1))
                {
                    questionarioVm.QuestaoE = new List<Categoria>() { new Categoria { Id = 1, Valor = "Sim" } };
                }
                else
                {
                    questionarioVm.QuestaoE = new List<Categoria>() { new Categoria { Id = 1, Valor = "Não" } };
                }
            }      


            return questionarioVm;

        }

             
        public JsonResult GraficoA()
        {            
            var Total = _context.PesquisaModel.ToArray().Length;
            var sumQuestaoAS = _context.PesquisaModel.Where(x => x.QuestaoA == 1).Sum(x => x.QuestaoA.Value);

            var total = new List<SomaGraficoModel>();
                total.Add(new SomaGraficoModel{  Resposta ="Sim", Valor  = sumQuestaoAS });
                total.Add(new SomaGraficoModel { Resposta = "Nao", Valor = Total - sumQuestaoAS });

            return Json(total);
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
