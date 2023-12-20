using AgricolaLoja.Models;


namespace AgricolaLoja.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin(string login);

        List<Usuario> BuscarTodos();
        Usuario BuscarPorID(int id);
        Usuario Adicionar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        bool Apagar(int id);
    }
}
