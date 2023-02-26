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
                        Livro => new Livro
                        {
                            Id = Livro.Id,
                            Titulo = Livro.Titulo,
                            Subtitulo = Livro.Subtitulo,
                            Resumo = Livro.Resumo,
                            QuantidadeDePaginas = Livro.QuantidadeDePaginas,
                            DataDePublicacao = Livro.DataDePublicacao,
                            Editora = Livro.Editora,
                            Edicao = Livro.Edicao,
                            ISBN = Livro.ISBN,
                            QuantidadeEmEstoque = Livro.QuantidadeEmEstoque,
                            FotoDaCapa = Livro.FotoDaCapa
                        })));
            CreateMap<CreateAutorDto, Autor>();
            CreateMap<UpdateAutorDto, Autor>()
                .ForMember(x => x.Livros, opts => opts.Ignore());

        }
    }
}
