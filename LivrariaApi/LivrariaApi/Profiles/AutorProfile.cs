using AutoMapper;
using LivrariaApi.Data.Dtos.AutorDto;
using LivrariaApi.Models;

namespace LivrariaApi.Profiles
{
    public class AutorProfile : Profile
    {
        public AutorProfile()
        {
            CreateMap<Autor, ReadAutorDto>()
                .ForMember(dest => dest.Livros, opt => opt.MapFrom(
                    src => src.Livros.Select(
                        Livro => new
                        {
                            Livro.Id,
                            Livro.Titulo,
                            Livro.Subtitulo,
                            Livro.Resumo,
                            Livro.QuantidadeDePaginas,
                            Livro.DataDePublicacao,
                            Livro.Editora,
                            Livro.Edicao,
                            Livro.ISBN,
                            Livro.QuantidadeEmEstoque
                        })));
            CreateMap<CreateAutorDto, Autor>();
            CreateMap<UpdateAutorDto, Autor>();

        }
    }
}
