using Chapter.WebApi.Contexts;
using Chapter.WebApi.Interface;
using Chapter.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.WebApi.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ChapterContext _chaptercontext;
        public LivroRepository(ChapterContext context) 
        { 
            _chaptercontext = context;
        }

        public void Atualizar(int id, Livro livro)
        {
            Livro livrosbucado = _chaptercontext.Livros.Find(id);

            if (livrosbucado != null)
            {
                livrosbucado.Titulo = livro.Titulo;
                livrosbucado.QuantidadePaginas = livro.QuantidadePaginas;
                livrosbucado.Disponivel = livro.Disponivel;
            }
            _chaptercontext.Livros.Update(livrosbucado);
            _chaptercontext.SaveChanges();
        }

        public Livro BuscarPorId(int id)
        {
            return _chaptercontext.Livros.Find(id);

        }

        public void Cadastrar(Livro livro)
        {
            _chaptercontext.Livros.Add(livro);
            _chaptercontext.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro livro = _chaptercontext.Livros.Find(id);
            
            _chaptercontext.Livros.Remove(livro);
            _chaptercontext.SaveChanges();
        }

        public List<Livro> Ler()
        {
            return _chaptercontext.Livros.ToList();
        }


    }
}
