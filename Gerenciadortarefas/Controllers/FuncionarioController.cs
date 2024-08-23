
using Microsoft.AspNetCore.Mvc;

using Gerenciadortarefas.Services.Funcionarios;
using Gerenciadortarefas.Models;
using GerenciamentoDeTarefas.Dto.Grupo;
using GerenciamentoDeTarefas.Dto.Tarefa;
using Microsoft.AspNetCore.Http;

namespace Gerenciadortarefas.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioInterface _funcionarioInterface;

        public FuncionarioController(IFuncionarioInterface funcionariointerface)
        {
            _funcionarioInterface = funcionariointerface;
        }


        [HttpGet]
        public IActionResult Index()
        {

            try
            {
                int IdFuncionario = (int)HttpContext.Session.GetInt32("IdFuncionario");

                var grupos = _funcionarioInterface.ListarGrupos(IdFuncionario);

                return View(grupos);

            }
            catch
            {
                return NotFound();
            }

        }

        [HttpGet]
        public IActionResult AdicionarGrupo() => View();

        [HttpPost]
        public IActionResult AdicionarGrupo(CriarGrupoDto grupoDto)
        {
            try
            {

                _funcionarioInterface.AdicionarGrupo(grupoDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult EditarGrupo(int id)
        {
            try
            {
                var grupo = _funcionarioInterface.ObterGrupoPorId(id);
                return View(grupo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult EditarGrupo(Grupos grupo)
        {
            try
            {
                _funcionarioInterface.AtualizarGrupo(grupo);
                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult RemoverGrupo(int id)
        {
            try
            {
                var grupo = _funcionarioInterface.ObterGrupoPorId(id);

                return View(grupo);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult RemoverGrupo(Grupos grupos)
        {
            try
            {
                _funcionarioInterface.RemoverGrupo(grupos);
                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult VisualizarGrupo(int id)
        {
            try
            {
                var grupo = _funcionarioInterface.ObterGrupoPorId(id);

                return View(grupo);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult RemoverTarefa(int id, int idgrupo)
        {
            try
            {


                _funcionarioInterface.RemoverTarefa(id);


                return RedirectToAction("VisualizarGrupo", "Funcionario", new { id = idgrupo });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult AdicionarTarefa(int id)
        {
            try
            {
                return View(new CriarTarefaDto { idgrupo = id });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult AdicionarTarefa(CriarTarefaDto criarTarefaDto)
        {
            try
            {
                _funcionarioInterface.AdicionarTarefa(criarTarefaDto);

                return RedirectToAction("VisualizarGrupo", "Funcionario", new { id = criarTarefaDto.idgrupo });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult EditarTarefa(int id)
        {
            try
            {


                var tarefa = _funcionarioInterface.ObterTarefaPorId(id);
                return View(tarefa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult EditarTarefa(Tarefas tarefa)
        {
            try
            {
                _funcionarioInterface.AtualizarTarefa(tarefa);

                return RedirectToAction("VisualizarGrupo", "Funcionario", new { id = tarefa.IdGrupo });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult ConcluirTarefa(int id, int idgrupo)
        {
            try
            {
                _funcionarioInterface.ConcluirTarefa(id);

                return RedirectToAction("VisualizarGrupo", "Funcionario", new { id = idgrupo });
            }
            catch
            {
                return BadRequest();
            }

        }

    }
}





