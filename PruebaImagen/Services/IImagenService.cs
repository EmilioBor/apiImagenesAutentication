using Core.Request;
using Core.Response;

using Models.Models;

namespace Services
{
    public interface IImagenService
    {
        Task<ImagenDtoOut?> GetImagenById(int id);
        //Task<Imagen> Create();
        
    }
}