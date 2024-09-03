using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PruebaImagen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _service;
        public PerfilController(IPerfilService service)
        {
            _service = service;
        }
        [HttpGet("api/v1/perfil/{id}")]
        public async Task<ActionResult<PerfilDtoOut>> GetPerfilById(int id)
        {
            var perfil = await _service.GetPerfilById(id);
            if (perfil is null)
            {
                return NotFound(id);
            }
            return perfil;
        }
        [HttpPost]
        public async Task<IActionResult> Create(PerfilDtoIn perfilDto)
        {
            var newPerfil = await _service.Create(perfilDto);

            return CreatedAtAction(nameof(GetPerfilById), new { id = newPerfil.Id }, newPerfil);
        }
    }
}
