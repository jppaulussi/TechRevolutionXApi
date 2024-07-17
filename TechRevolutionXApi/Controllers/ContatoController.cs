using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechRevolutionXApi.Interfaces;
using TechRevolutionXApi.Models;

namespace TechRevolutionXApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var resultado = await _contatoService.GetAllAsync();

            if (resultado is null || !resultado.Any())
            {
                return Ok(new List<Contato>());
            }

            return Ok(resultado);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(Contato contato)
        {
            await _contatoService.CreateAsync(contato);
            return Created();
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            await _contatoService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(Contato contato)
        {
            await _contatoService.UpdateAsync(contato);
            return Ok(contato);
        }
    }

 

}
