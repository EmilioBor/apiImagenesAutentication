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
        //[HttpPost]
        //public async Task<IActionResult> Create(IFormFile file)
        //{
        //    //var newImagen = await _service.Create(file);

        //    //return CreatedAtAction(nameof(GetImagenById), new { id = newImagen.Id }, newImagen);
        //    if (file == null || file.Length == 0)
        //    {
        //        return BadRequest("No se ha proporcionado ninguna imagen.");
        //    }

        //    using var memoryStream = new MemoryStream();
        //    await file.CopyToAsync(memoryStream);
        //    var imagen = new ImagenDtoIn
        //    {
        //        Nombre = file.FileName,
        //        TipoContenido = file.ContentType,
        //        Datos = memoryStream.ToArray()
        //    };

        //    _context.Imagen.Add(imagen);
        //    await _context.SaveChangesAsync();

        //    return Ok(new { imagen.Id });
        //}
        [HttpPost]
        [Route("subir")]
        public async Task<IActionResult> SubirImagenes(List<IFormFile> files, int idPerfil)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No se han proporcionado imágenes.");
            }

            var imagen = new Imagen
            {
                IdPerfil = idPerfil,
                Url = new List<byte[]>()
            };

            foreach (var file in files)
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                imagen.Url.Add(memoryStream.ToArray());
            }

            _context.Imagen.Add(imagen);
            await _context.SaveChangesAsync();

            return Ok(new { imagen.Id });
        }

    }
}
