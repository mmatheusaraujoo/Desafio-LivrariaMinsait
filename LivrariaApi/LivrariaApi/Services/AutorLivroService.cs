using LivrariaApi.Data;
using LivrariaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace LivrariaApi.Services
{
    public class AutorLivroService
    {
        public LivrariaDataContext _dbContext { get; set; }

        public AutorLivroService(LivrariaDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AutorLivro AdicionarVinculoAutorLivro(int autorId, int livroId)
        {
            try
            {
                var autor = _dbContext.Autores
                    .FirstOrDefault(x => x.Id == autorId);
                var livro = _dbContext.Livros
                    .FirstOrDefault(x => x.Id == livroId);

                if (autor == null || livro == null) { throw new ArgumentNullException("id", "Não foi possível encontrar um ou mais termos."); }
                if (livro.Autores == null) { livro.Autores = new List<Autor>(); }
                if (autor.Livros == null) { autor.Livros = new List<Livro>(); }
                autor.Livros.Add(livro);
                livro.Autores.Add(autor);
                _dbContext.SaveChanges();
                return new AutorLivro(autorId, livroId);

            }
            catch (ArgumentNullException) { throw; }
            catch (Exception) { throw; }
        }

        public void RemoverVinculoAutorLivro(int autorId, int livroId)
        {
            try
            {
                var autor = _dbContext.Autores.FirstOrDefault(x => x.Id == autorId);
                var livro = _dbContext.Livros.FirstOrDefault(x => x.Id == livroId);

                if (autor == null || livro == null) { throw new ArgumentNullException("id", "Não foi possível encontrar um ou mais termos."); }
                autor.Livros.Remove(livro);
                livro.Autores.Remove(autor);
                _dbContext.SaveChanges();
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception) { throw; }
        }

        public AutorLivro RetornarAutorLivro(int autorId, int livroId)
        {
            try
            {
                var autor = _dbContext.Autores.FirstOrDefault(x => x.Id == autorId);
                var livro = _dbContext.Livros.FirstOrDefault(x => x.Id == livroId);

                if (autor == null || livro == null) { throw new ArgumentNullException("id", "Não foi possível encontrar um ou mais termos."); }
                return new AutorLivro(autorId, livroId);
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception) { throw; }

        }
    }
}
