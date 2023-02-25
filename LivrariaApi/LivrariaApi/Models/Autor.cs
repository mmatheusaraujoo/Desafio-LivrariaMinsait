﻿namespace LivrariaApi.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public string ResumoBibliografico { get; set; }
        public string Foto { get; set; }
        public IList<Livro> Livros { get; set; }

    }
}
