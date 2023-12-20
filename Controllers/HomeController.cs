using AgricolaLoja.Models;
using AgricolaLoja.Repositorio;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.Collections.Generic;
using AgricolaLoja.Helper;
using ProjetoLojaAgricola.Filters; 
namespace AgricolaLoja.Controllers
{

    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ISessao _sessao;

        public HomeController(ILogger<HomeController> logger, IProdutoRepositorio produtoRepositorio, ISessao sessao)
        {
            _logger = logger;
            _produtoRepositorio = produtoRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            List<ProdutosModel> produtos = _produtoRepositorio.BuscarTodos();

                
            return View(produtos);
        }
   

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult QuemSomos()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}