using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Models.Models;

namespace Services
{
    public interface IImagenService
    {
        Task<ImagenDtoOut?> GetImagenById(int id);
        //Task<Imagen> Create();
        Task<int> SubirImagenes(List<IFormFile> files, int idPerfil);
    }
}