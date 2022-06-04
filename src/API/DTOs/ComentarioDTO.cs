using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ComentarioDTO
    {
        public int Id { get; set; }
        public int? IdPelicula { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public string Description { get; set; }
        public DateTime Fecha { get; set; }
    }
}
