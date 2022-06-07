using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Comentarios = new HashSet<Comentario>();
            PeliculasGeneros = new HashSet<PeliculasGenero>();
            Puntuacions = new HashSet<Puntuacion>();
            Wishlists = new HashSet<Wishlist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Valoration { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<PeliculasGenero> PeliculasGeneros { get; set; }
        public virtual ICollection<Puntuacion> Puntuacions { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
