using Core.Request;
using Core.Response;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PerfilService : IPerfilService
    {
        private readonly PruebaContext _context;

        public PerfilService(PruebaContext context)
        {
            _context = context;
        }
        public async Task<PerfilDtoOut?> GetPerfilById(int id)
        {
            return await _context.Perfil.Where(p => p.Id == id).Select(p => new PerfilDtoOut
            {
                Id = p.Id,
                Descripcion = p.Descripcion,
                
            }).SingleOrDefaultAsync();
        }

        public async Task<Perfil> Create(PerfilDtoIn perfil)
        {
            var newPerfil = new Perfil();

            
            newPerfil.Descripcion = perfil.Descripcion;
            

            _context.Perfil.Add(newPerfil);
            await _context.SaveChangesAsync();

            return newPerfil;
        }
    }

    
}
