using Chapter.WebApi.Contexts;
using Chapter.WebApi.Interface;
using Chapter.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ChapterContext _chaptercontext;
        public UsuarioRepository(ChapterContext context)
        {
            _chaptercontext = context;
        }

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuariobuscado = _chaptercontext.Usuarios.Find(id);
            if (usuariobuscado != null) 
            {
                usuariobuscado.Email = usuario.Email;
                usuariobuscado.Senha = usuario.Senha;
                usuariobuscado.Tipo = usuario.Tipo; 
            }
            _chaptercontext.Usuarios.Update(usuariobuscado);
            _chaptercontext.SaveChanges();
        }

        public void Cadastrar(Usuario usuario)
        {
            _chaptercontext.Usuarios.Add(usuario);
            _chaptercontext.SaveChanges();
            

        }

        public void Deletar(int id)
        {
            Usuario usuario = _chaptercontext.Usuarios.Find(id);
            _chaptercontext.Usuarios.Remove(usuario);
            _chaptercontext.SaveChanges();

        }

        public Usuario GetById(int id)
        {
           return _chaptercontext.Usuarios.Find(id);

        }

        public List<Usuario> Listar()
        {
           return _chaptercontext.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return _chaptercontext.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
