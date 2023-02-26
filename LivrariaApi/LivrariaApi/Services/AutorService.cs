using AutoMapper;
using LivrariaApi.Data.Dtos.AutorDto;
using LivrariaApi.Data;
using LivrariaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaApi.Services
{
    public class AutorService
    {
        public LivrariaDataContext _dbContext { get; set; }
        public IMapper _mapper { get; set; }

        public AutorService(LivrariaDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        internal async Task<List<ReadAutorDto>> ListarAautores()
        {
            try
            {
                List<Autor> autores;

                autores = await _dbContext.Autores
                    .AsNoTracking()
                    .Include(x=>x.Livros)
                    .ToListAsync();

                var AutoresDto = _mapper.Map<List<ReadAutorDto>>(autores);
                return AutoresDto;
            }
            catch (Exception e) { throw new Exception("Imposivel retornar os Autores.", e); }
        }

        internal async Task<ReadAutorDto?> RetornarAutorDtoPorId(int id)
        {
            try
            {
                var autor = await _dbContext.Autores
                    .AsNoTracking()
                    .Include(x=>x.Livros)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (autor == null) { throw new ArgumentNullException("id", "Não foi possível localizar um Autor com esse id."); }

                var readAutorDto = _mapper.Map<ReadAutorDto>(autor);
                return readAutorDto;
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception e) { throw new Exception("Imposivel retornar Autor.", e); }
        }

        internal async Task<ReadAutorDto> CriarNovoAutor(CreateAutorDto autorDto)
        {
            try
            {
                Autor novoAutor;

                novoAutor = _mapper.Map<Autor>(autorDto);

                await _dbContext.Autores.AddAsync(novoAutor);
                await _dbContext.SaveChangesAsync();

                var novoAutorDto = _mapper.Map<ReadAutorDto>(novoAutor);
                return novoAutorDto;
            }
            catch (Exception e) { throw new Exception("Não foi possível cadastrar novo Autor.", e); }
        }


        internal void RemoverAutorPorId(int id)
        {
            try
            {
                var autor = BuscarAutorPorId(id);
                _dbContext.Autores.Remove(autor);
                _dbContext.SaveChanges();
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception e) { throw new Exception("Não foi possível remover o autor.", e); }
        }

        internal void AtualizarAutorPorId(int id, UpdateAutorDto autorDto)
        {
            try
            {
                var autor = _dbContext.Autores.Find(id);
                _mapper.Map(autorDto, autor);
                _dbContext.SaveChanges();
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception e) { throw new Exception("Não foi possível Atualizar o autor.", e); }
        }

        public Autor BuscarAutorPorId(int id)
        {
            try
            {
                var autor = _dbContext.Autores
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (autor == null) { throw new ArgumentNullException("id", "Não foi possível localizar um autor com esse id."); }

                return autor;
            }
            catch (ArgumentNullException) { throw; }
            catch (Exception e) { throw new Exception("não foi possivel encontrar o autor.", e); }
        }
    }
}
