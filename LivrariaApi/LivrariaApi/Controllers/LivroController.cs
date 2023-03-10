using LivrariaApi.Data.Dtos.LivroDto;
using LivrariaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaApi.Controllers
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    [Route("[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        public LivroService _livroService { get; set; }

        public LivroController(LivroService livroService)
        {
            _livroService = livroService;
        }


        [HttpGet]
        public async Task<IActionResult> ListaLivros()
        {
            try
            {
                var livrosDto = await _livroService.ListarLivros();
                if (livrosDto == null)
                {
                    return NotFound();
                }
                return Ok(livrosDto);
            }
            catch (Exception e) { return StatusCode(500, $"{e.Message} \n {e.InnerException.Message}"); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarLivroPorId(int id)
        {
            try
            {
                var livroDto = await _livroService.RetornarLivroDtoPorId(id);
                return Ok(livroDto);
            }
            catch (ArgumentNullException e) { return NotFound(e.Message); }
            catch (Exception e) { return StatusCode(500, $"{e.Message} \n {e.InnerException.Message}"); }
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovoLivro([FromBody] CreateLivroDto createLivroDto)
        {
            try
            {
                var novoLivroDto = await _livroService.CriarNovoLivro(createLivroDto);
                return CreatedAtAction(nameof(RetornarLivroPorId), new { id = novoLivroDto.Id }, novoLivroDto);
            }
            catch (Exception e) { return StatusCode(500, $"{e.Message} \n {e.InnerException.Message}"); }
        }

        [HttpPut("{id}")]
        public IActionResult AlterarLivroPorId(int id, [FromBody] UpdateLivroDto updateLivroDto)
        {
            try
            {
                _livroService.AtualizarLivroPorId(id, updateLivroDto);
                return NoContent();
            }
            catch (ArgumentNullException e) { return NotFound(e.Message); }
            catch (Exception e) { return StatusCode(500, $"{e.Message} \n {e.InnerException.Message}"); }

        }

        [HttpDelete("{id}")]
        public IActionResult RemoverLivroPorId(int id)
        {
            try
            {
                _livroService.RemoverLivroPorId(id);
                return NoContent();
            }
            catch (ArgumentNullException e) { return NotFound(e.Message); }
            catch (Exception e) { return StatusCode(500, $"{e.Message} \n {e.InnerException.Message}"); }

        }

#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
