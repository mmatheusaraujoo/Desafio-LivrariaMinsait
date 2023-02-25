using AutoMapper;
using LivrariaApi.Data.Dtos.LivroDto;
using LivrariaApi.Data;
using LivrariaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaApi.Services
{
    public class LivroService
    {
        public LivrariaDataContext _dbContext { get; set; }

        public IMapper _mapper { get; set; }

        public LivroService(LivrariaDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        internal async Task<List<ReadLivroDto>> ListarLivros()
        {
            try
            {
                List<Livro> livros;

                livros = await _dbContext.Livros
                    .AsNoTracking()
                    .ToListAsync();

                var LivrosDto = _mapper.Map<List<ReadLivroDto>>(livros);
                return LivrosDto;
            }
            catch (Exception e) { throw new Exception("Imposivel retornar os livros.", e); }
        }

        internal async Task<ReadLivroDto?> RetornarLivroDtoPorId(int id)
        {
            try
            {
                var livro = await _dbContext.Livros
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (livro == null) { throw new ArgumentNullException("id", "Não foi possível localizar um livro com esse id."); }

                var readLivroDto = _mapper.Map<ReadLivroDto>(livro);
                return readLivroDto;
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception e) { throw new Exception("Imposivel retornar livro.", e); }
        }

        internal async Task<ReadLivroDto> CriarNovoLivro(CreateLivroDto livroDto)
        {
            try
            {
                Livro novoLivro;

                novoLivro = _mapper.Map<Livro>(livroDto);

                await _dbContext.Livros.AddAsync(novoLivro);
                await _dbContext.SaveChangesAsync();

                var novoLivroDto = _mapper.Map<ReadLivroDto>(novoLivro);
                return novoLivroDto;
            }
            catch (Exception e) { throw new Exception("Não foi possível cadastrar novo livro.", e); }
        }


        internal async void RemoverLivroPorId(int id)
        {
            try
            {
                var livro = await BuscarLivroPorId(id);
                _dbContext.Livros.Remove(livro);
                await _dbContext.SaveChangesAsync();
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception e) { throw new Exception("Não foi possível remover o livro.", e); }
        }

        internal async void AtualizaLivroPorId(int id, UpdateLivroDto livroDto)
        {
            try
            {
                var livro = BuscarLivroPorId(id);
                await _mapper.Map(livroDto, livro);
                await _dbContext.SaveChangesAsync();
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception e) { throw new Exception("Não foi possível Atualizar o livro.", e); }
        }

        internal async Task<ReadLivroDto> RelacionarLivroAoAutor(int livroId, int autorId)
        {
            try
            {
                var livro = await _dbContext.Livros.FirstOrDefaultAsync(x => x.Id == livroId);
                var autor = await _dbContext.Autores.FirstOrDefaultAsync(x => x.Id == autorId);

                if (livro == null || autor == null)
                {
                    throw new ArgumentNullException();
                }
                livro.Autores.Add(autor);
                autor.Livros.Add(livro);
                await _dbContext.SaveChangesAsync();

                var livroDto = _mapper.Map<ReadLivroDto>(livro);
                return livroDto;
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception e) { throw new Exception("Não foi possível relacionar o autor com o livro.", e); }

        }

        public async Task<Livro> BuscarLivroPorId(int id)
        {
            try
            {
                var livro = await _dbContext.Livros.FirstOrDefaultAsync(x => x.Id == id);
                if (livro == null) { throw new ArgumentNullException("id", "Não foi possível localizar um livro com esse id."); }
                return livro;
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception e) { throw new Exception("não foi possivel encontrar o livro.", e); }
        }

    }
}
