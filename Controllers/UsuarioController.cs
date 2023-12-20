using AgricolaLoja.Models;
using AgricolaLoja.Repositorios;
using Microsoft.AspNetCore.Mvc;
using ProjetoLojaAgricola.Filters;

namespace AgricolaLoja.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = _usuarioRepositorio.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }
         
        public IActionResult Editar(int id)
        {
            Usuario  usuario = _usuarioRepositorio.BuscarPorID(id);
            return View(usuario);
        }



        public IActionResult ApagarConfirmacao(int id)
        {
            Usuario usuario = _usuarioRepositorio.BuscarPorID(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                    TempData["MensagemSucesso"] = "Produto apagado com sucesso!";
                else
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu produto, tente novamente!";

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu produto, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]

        public IActionResult Criar(Usuario usuario)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);

                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenha usuarioSemSenha)
        {
            try
            {
                Usuario usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new Usuario()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil
                    };

                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");   
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
