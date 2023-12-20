using AgricolaLoja.Models;
using Microsoft.EntityFrameworkCore;


namespace AgricolaLoja.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly AppDbContext _context;

       public UsuarioRepositorio(AppDbContext context)
        {
            this._context = context;

        }

        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public Usuario BuscarPorID(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id );
        }

        public List<Usuario> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            try
            {
                usuario.DataCadastro = DateTime.UtcNow;
                usuario.SetSenhaHash();
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return usuario;
            }
            catch (DbUpdateException ex)
            {
                
                throw new Exception("Erro ao salvar no banco de dados. Detalhes: " + ex.Message, ex);
            }
        }

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioDb = BuscarPorID(usuario.Id);

            if (usuarioDb == null) throw new Exception("Houve um erro na atualização do usuário!");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.UtcNow; 

            _context.Usuarios.Update(usuarioDb);
            _context.SaveChanges();

            return usuarioDb;
        }


        public bool Apagar(int id)
        {
            Usuario usuarioDb = BuscarPorID(id);

            if (usuarioDb == null) throw new Exception("Houve um erro na deleção do contato!");

            _context.Usuarios.Remove(usuarioDb);
            _context.SaveChanges();

            return true;
        }


    }
}
