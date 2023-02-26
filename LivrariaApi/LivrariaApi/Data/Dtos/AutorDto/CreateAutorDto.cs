namespace LivrariaApi.Data.Dtos.AutorDto
{
    public class CreateAutorDto
    {
        public string? Nome { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public string? Nacionalidade { get; set; }
        public string? ResumoBibliografico { get; set; }
        public string? Foto { get; set; }
    }
}
