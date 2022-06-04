using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasGeneroesController : ControllerBase
    {
        private readonly OnlyFilmsContext _context;

        public PeliculasGeneroesController(OnlyFilmsContext context)
        {
            _context = context;
        }

        // GET: api/PeliculasGeneroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeliculasGenero>>> GetPeliculasGeneros()
        {
            return await _context.PeliculasGeneros.ToListAsync();
        }

        // GET: api/PeliculasGeneroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeliculasGenero>> GetPeliculasGenero(int id)
        {
            var peliculasGenero = await _context.PeliculasGeneros.FindAsync(id);

            if (peliculasGenero == null)
            {
                return NotFound();
            }

            return peliculasGenero;
        }

        [HttpGet]
        [Route("/getPelisBy/{IdGenero}")]
        public async Task<ActionResult<List<int>>> GetPeliculasByGenero(int IdGenero)
        {
            var lista = _context.PeliculasGeneros.Where(item => item.IdGenero == IdGenero).ToList();

            List<int> lista2 = new List<int>();
            foreach (PeliculasGenero item in lista)
            {

                lista2.Add((int)item.IdPelicula);

            }


            return lista2;
        }

        // PUT: api/PeliculasGeneroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeliculasGenero(int id, PeliculasGenero peliculasGenero)
        {
            if (id != peliculasGenero.Id)
            {
                return BadRequest();
            }

            _context.Entry(peliculasGenero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculasGeneroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PeliculasGeneroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PeliculasGenero>> PostPeliculasGenero(PeliculasGenero peliculasGenero)
        {
            _context.PeliculasGeneros.Add(peliculasGenero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeliculasGenero", new { id = peliculasGenero.Id }, peliculasGenero);
        }

        // DELETE: api/PeliculasGeneroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeliculasGenero(int id)
        {
            var peliculasGenero = await _context.PeliculasGeneros.FindAsync(id);
            if (peliculasGenero == null)
            {
                return NotFound();
            }

            _context.PeliculasGeneros.Remove(peliculasGenero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeliculasGeneroExists(int id)
        {
            return _context.PeliculasGeneros.Any(e => e.Id == id);
        }
    }
}
