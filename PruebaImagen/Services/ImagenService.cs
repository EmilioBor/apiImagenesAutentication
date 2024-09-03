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

        public async Task<int> SubirImagenes(List<IFormFile> files, int idPerfil)
        {
            if (files == null || files.Count == 0)
            {
                throw new ArgumentException("No se han proporcionado imágenes.");
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

            return imagen.Id;
        }

    }
}
