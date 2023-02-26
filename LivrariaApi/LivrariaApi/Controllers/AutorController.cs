using LivrariaApi.Data.Dtos.AutorDto;
using LivrariaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaApi.Controllers
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    [Route("[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        public AutorService _autorService { get; set; }

        public AutorController(AutorService autorService)
        {
            _autorService = autorService;
        }


        [HttpGet]
        public async Task<IActionResult> ListaAutores()
        {
            try
            {
                var autoresDto = await _autorService.ListarAautores();
                if (autoresDto == null)
                {
                    return NotFound();
                }
                return Ok(autoresDto);
            }
            catch (Exception e) { return StatusCode(500, $"{e.Message}\n{e.InnerException.Message}"); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornarAutorPorId(int id)
        {
            try
            {
                var autorDto = await _autorService.RetornarAutorDtoPorId(id);
                return Ok(autorDto);
            }
            catch (ArgumentNullException e) { return NotFound(e.Message); }
            catch (Exception e) { return StatusCode(500, $"{e.Message}\n{e.InnerException.Message}"); }
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovoAutor([FromBody] CreateAutorDto createAutorDto)
        {
            try
            {
                var novoAutorDto = await _autorService.CriarNovoAutor(createAutorDto);
                return CreatedAtAction(nameof(RetornarAutorPorId), new { id = novoAutorDto.Id }, novoAutorDto);
            }
            catch (Exception e) { return StatusCode(500, $"{e.Message}\n{e.InnerException.Message}"); }
        }

        [HttpPut("{id}")]
        public IActionResult AlterarAutor(int id, [FromBody] UpdateAutorDto updateAutorDto)
        {
            try
            {
                _autorService.AtualizarAutorPorId(id, updateAutorDto);
                return NoContent();
            }
            catch (ArgumentNullException e) { return NotFound(e.Message); }
            catch (Exception e) { return StatusCode(500, $"{e.Message}\n{e.InnerException.Message}"); }

        }


        [HttpDelete("{id}")]
        public IActionResult RemoverAutorPorId(int id)
        {
            try
            {
                _autorService.RemoverAutorPorId(id);
                return NoContent();
            }
            catch(ArgumentNullException e) { return NotFound(e.Message); }
            catch(Exception e) { return StatusCode(500, $"{e.Message}\n{e.InnerException.Message}"); }
        }
    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
}
