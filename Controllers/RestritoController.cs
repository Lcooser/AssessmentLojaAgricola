using Microsoft.AspNetCore.Mvc;
using ProjetoLojaAgricola.Filters;

namespace ProjetoLojaAgricola.Controllers
{

    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
