using AgricolaLoja.Models;
using System.Collections.Generic;

namespace AgricolaLoja.Repositorio
{
    public interface IProdutoRepositorio
    {
        List<ProdutosModel> BuscarTodos();
        ProdutosModel BuscarPorID(int id);
        ProdutosModel Adicionar(ProdutosModel produto);
        ProdutosModel Atualizar(ProdutosModel produto);
        bool Apagar(int id);
    }
}