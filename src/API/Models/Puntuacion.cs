using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Puntuacion
    {
        public int Id { get; set; }
        public int? IdPelicula { get; set; }
        public int? IdUsuario { get; set; }
        public decimal Puntuacion1 { get; set; }

        public virtual Pelicula IdPeliculaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
