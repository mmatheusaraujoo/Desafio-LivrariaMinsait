using LivrariaApi.Models;
using LivrariaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorLivroController : ControllerBase
    {
        public AutorLivroService _autorLivroService{ get; set; }
        public AutorLivroController(AutorLivroService autorLivroService) { _autorLivroService = autorLivroService; }

        [HttpPost("/Autor/{autorId}/Livro/{livroId}")]
        public IActionResult AdicionarVinculoAutorLivro(int autorId, int livroId)
        {
            try
            {
                var vinculoAutorLivro = _autorLivroService.AdicionarVinculoAutorLivro(autorId, livroId);
                return Created($"/Autor/{autorId}/Livro/{livroId}", vinculoAutorLivro);
            }
            catch (ArgumentNullException ex) { return NotFound(ex.Message); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

        }

        [HttpDelete("/Autor/{autorId}/Livro/{livroId}")]
        public IActionResult RemoverVinculoAutorLivro(int autorId, int livroId)
        {
            try
            {
                _autorLivroService.RemoverVinculoAutorLivro(autorId, livroId);
                return NoContent();
            }
            catch (ArgumentNullException ex) { return NotFound(ex.Message); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

        }
    }
}
