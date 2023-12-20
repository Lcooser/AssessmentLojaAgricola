using AgricolaLoja.Models;

namespace AgricolaLoja.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario);

        void RemoverSessaoDoUsuario();
        Usuario BuscarSessaoDoUsuario();
        
    }
}
