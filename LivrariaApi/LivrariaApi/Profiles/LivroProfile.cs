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
                        autor => new
                        {
                            autor.Id,
                            autor.Nome,
                            autor.Nacionalidade,
                            autor.ResumoBibliografico
                        })));
            CreateMap<CreateLivroDto, Livro>();
            CreateMap<UpdateLivroDto, Livro>();
        }
    }
}
