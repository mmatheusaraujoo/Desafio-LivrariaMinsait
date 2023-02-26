using AutoMapper;
using LivrariaApi.Data.Dtos.LivroDto;
using LivrariaApi.Models;

namespace LivrariaApi.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<Livro, ReadLivroDto>()
                .ForMember(dest => dest.Autores, opt => opt.MapFrom(
                    src => src.Autores.Select(
                        autor => new Autor
                        {
                            Id = autor.Id,
                            Nome = autor.Nome,
                            Nacionalidade = autor.Nacionalidade,
                            ResumoBibliografico = autor.ResumoBibliografico
                        })));
            CreateMap<CreateLivroDto, Livro>();
            CreateMap<UpdateLivroDto, Livro>()
                .ForMember(x => x.Autores, opts => opts.Ignore());
        }
    }
}
