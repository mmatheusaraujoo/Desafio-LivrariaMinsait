using LivrariaApi.Models;

namespace LivrariaApi.Data.Dtos.AutorDto
{
    public class ReadAutorDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public string? Nacionalidade { get; set; }
        public string? ResumoBibliografico { get; set; }
        public string? Foto { get; set; }
        public List<Livro>? Livros { get; set; }
    }
}
