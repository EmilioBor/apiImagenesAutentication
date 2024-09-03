using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Services
{
    public class ImagenService : IImagenService
    {
        private readonly PruebaContext _context;
        
        public ImagenService(PruebaContext context)
        {
            _context = context;
        }
        public async Task<ImagenDtoOut?> GetImagenById(int id)
        {
            return await _context.Imagen
                .Where(p => p.Id == id)
                .Select(p => new ImagenDtoOut
            {
                Id = p.Id,
                Url = p.Url,
                NombrePerfil = p.IdPerfilNavigation.Descripcion,
                

            }).SingleOrDefaultAsync();
        }

        //public async Task<A<Imagen>> Create(IFormFile file)
        //{
        //    //var newImagen = new Imagen();


        //    //newImagen.Url = imagen.Url;
        //    //newImagen.IdPerfil = imagen.IdPerfil;



        //    //_context.Imagen.Add(newImagen);
        //    //await _context.SaveChangesAsync();

        //    //return newImagen;
        //    if (file == null || file.Length == 0)
        //    {
        //        return BadRequest("No se ha proporcionado ninguna imagen.");
        //    }

        //    using var memoryStream = new MemoryStream();
        //    await file.CopyToAsync(memoryStream);
        //    var imagen = new Imagen
        //    {
        //        Nombre = file.FileName,
        //        TipoContenido = file.ContentType,
        //        Datos = memoryStream.ToArray()
        //    };

        //    _context.Imagenes.Add(imagen);
        //    await _context.SaveChangesAsync();

        //    return Ok(new { imagen.Id });
        //}
        
    }
}
