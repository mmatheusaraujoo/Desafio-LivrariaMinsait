namespace LivrariaApi.Models
{
    public class AutorLivro
    {

        public int AutorId { get; set; }

        public int LivroId { get; set;  }

        public AutorLivro(int autorId, int livroId)
        {
            AutorId = autorId;
            LivroId = livroId;
        }
       
    }
}
