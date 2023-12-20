using AgricolaLoja.Helper;
using AgricolaLoja.Models;
using AgricolaLoja.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoLojaAgricola.Filters;

namespace AgricolaLoja.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ISessao _sessao;

        public ProdutosController(IProdutoRepositorio produtoRepositorio, ISessao sessao)
        {
            _produtoRepositorio = produtoRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            List<ProdutosModel> produtos = _produtoRepositorio.BuscarTodos();
            return View(produtos);
        }



        [HttpGet]
        public IActionResult Criar()
        {
           
            return View();
        }

        public IActionResult Editar(int id)
        {
            ProdutosModel produto = _produtoRepositorio.BuscarPorID(id);
            return View(produto);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ProdutosModel produto = _produtoRepositorio.BuscarPorID(id);
            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _produtoRepositorio.Apagar(id);

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
        public IActionResult Criar(ProdutosModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    

                    produto = _produtoRepositorio.Adicionar(produto);

                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu produto, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Editar(ProdutosModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    produto.Id = usuarioLogado.Id;

                    produto = _produtoRepositorio.Atualizar(produto);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu produto, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Detalhes(int id)
        {
            
            ProdutosModel produto = _produtoRepositorio.BuscarPorID(id);

            if (produto == null)
            {
                return NotFound(); 
            }

            return View(produto);
        }

    }
}
    
