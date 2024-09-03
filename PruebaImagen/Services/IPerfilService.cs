using Core.Request;
using Core.Response;
using Models.Models;

namespace Services
{
    public interface IPerfilService
    {
        Task<PerfilDtoOut?> GetPerfilById(int id);
        Task<Perfil> Create(PerfilDtoIn perfil);
    }
}