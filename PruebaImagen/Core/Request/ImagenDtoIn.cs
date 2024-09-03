using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class ImagenDtoIn
    {
        //public int Id { get; set; }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public byte[]? Datos { get; set; }
        public string? TipoContenido { get; set; }
    }
}
