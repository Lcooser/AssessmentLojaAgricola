
using AgricolaLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgricolaLoja.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly AppDbContext _context;

        public ProdutoRepositorio(AppDbContext context)
        {
            this._context = context;
        }

        public ProdutosModel BuscarPorID(int id)
        {
            return _context.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public List<ProdutosModel> BuscarTodos()
        {
            return _context.Produtos.ToList();
        }

        public ProdutosModel Adicionar(ProdutosModel produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public ProdutosModel Atualizar(ProdutosModel produto)
        {
            ProdutosModel produtoDb = BuscarPorID(produto.Id);

            if (produtoDb == null) throw new Exception("Houve um erro na atualização do contato!");

            produtoDb.Nome = produto.Nome;
            produtoDb.Descricao = produto.Descricao;
            produtoDb.Valor = produto.Valor;
            produtoDb.DataDeLancamento = produto.DataDeLancamento;


            _context.Produtos.Update(produtoDb);
            _context.SaveChanges();

            return produtoDb;
        }

        public bool Apagar(int id)
        {
            ProdutosModel produtoDb = BuscarPorID(id);

            if (produtoDb == null) throw new Exception("Houve um erro na deleção do contato!");

            _context.Produtos.Remove(produtoDb);
            _context.SaveChanges();

            return true;
        }
    }
}