using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Genero
    {
        public Genero()
        {
            PeliculasGeneros = new HashSet<PeliculasGenero>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PeliculasGenero> PeliculasGeneros { get; set; }
    }
}
