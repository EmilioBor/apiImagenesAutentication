using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Services;

namespace PruebaImagen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        private readonly IImagenService _service;
        private readonly PruebaContext _context;

        public ImagenController(IImagenService service, PruebaContext context)
        {
            _service = service;
            _context = context; 
        }
        [HttpGet("api/v1/imagen/{id}")]
        public async Task<ActionResult<ImagenDtoOut>> GetImagenById(int id)
        {
            var imagen = await _service.GetImagenById(id);
            if (imagen is null)
            {
                return NotFound(id);
            }
            return imagen;
        }

        [HttpPost]
        [Route("subir")]
        public async Task<IActionResult> SubirImagenes(List<IFormFile> files, int idPerfil)
        {
            try
            {
                var imagenId = await _service.SubirImagenes(files, idPerfil);
                return Ok(new { Id = imagenId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
