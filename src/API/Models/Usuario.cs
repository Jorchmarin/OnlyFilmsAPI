using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentarios = new HashSet<Comentario>();
            Puntuacions = new HashSet<Puntuacion>();
            Wishlists = new HashSet<Wishlist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nick { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Puntuacion> Puntuacions { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
