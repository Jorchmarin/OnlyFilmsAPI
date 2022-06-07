using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Comentario
    {
        public int Id { get; set; }
        public int? IdPelicula { get; set; }
        public int? IdUsuario { get; set; }
        public string Description { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Pelicula IdPeliculaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
