using Gerenciadortarefas.Models;
using Gerenciadortarefas.Services.Funcionarios;
using Microsoft.AspNetCore.Mvc;


namespace Gerenciadortarefas.Controllers
{
    public class HomeController : Controller
    {

        private readonly db_gerenciamentoContext _db;
        private readonly IFuncionarioInterface _funcionarioInterface;
        public HomeController(db_gerenciamentoContext db, IFuncionarioInterface funcionarioInterface)
        {
            _db = db;
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.Get("IdFuncionario") != null)
            {
                HttpContext.Session.SetString("IdFuncionario", "");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string nome, string senha)
        {
            try
            {
                var idfuncionario = _funcionarioInterface.ValidaLogin(nome, senha);


                if (idfuncionario != 0)
                {
                    HttpContext.Session.SetInt32("IdFuncionario", idfuncionario);

                    return RedirectToAction("Index", "Funcionario");
                }

                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult CadastrarFuncionario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarFuncionario(string nome, string senha)
        {
            try
            {
                _funcionarioInterface.CriarFuncionario(nome, senha);
                return RedirectToAction("Login");
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
