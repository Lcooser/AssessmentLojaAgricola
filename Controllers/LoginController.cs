using AgricolaLoja.Helper;
using AgricolaLoja.Models;
using AgricolaLoja.Repositorios;
using Microsoft.AspNetCore.Mvc;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgricolaLoja.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }


        public IActionResult Index()
        {
            

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);



                    if(usuario != null)
                    {

                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente:";
                    }

                    TempData["MensagemErro"] = $"Usuáiro e/ou senha inválida(s). Por favor, tente novamente:";
                    
                }
                return View("Index");
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos efetuar seu login, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
