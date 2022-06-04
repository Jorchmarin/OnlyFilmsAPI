using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class PeliculasGenero
    {
        public int Id { get; set; }
        public int? IdPelicula { get; set; }
        public int? IdGenero { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Pelicula IdPeliculaNavigation { get; set; }
    }
}
