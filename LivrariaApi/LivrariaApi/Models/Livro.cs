namespace LivrariaApi.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Resumo { get; set; }
        public int QuantidadeDePaginas { get; set; }
        public DateTime DataDePublicacao { get; set; }
        public string Editora { get; set; }
        public int? Edicao { get; set; }
        public string ISBN { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public IList<Autor> Autores { get; set; }
    }
}
