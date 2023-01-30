using Chapter.WebApi.Models;

namespace Chapter.WebApi.Interface
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        void Cadastrar(Usuario usuario);

        void Atualizar(int id, Usuario usuario);

        void Deletar(int id);

        Usuario GetById(int id);

        Usuario Login(string login, string senha);
    }
}
