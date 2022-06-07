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
    public class PuntuacionsController : ControllerBase
    {
        private readonly OnlyFilmsContext _context;

        public PuntuacionsController(OnlyFilmsContext context)
        {
            _context = context;
        }

        // GET: api/Puntuacions
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Puntuacion>>> GetPuntuacions()
        {
            return await _context.Puntuacions.ToListAsync();
        }


        [HttpGet]
        [Route("/media/{idPeli}")]
        public async Task<ActionResult<decimal>> GetMediaBy(int idPeli)
        {
            var lista = _context.Puntuacions.Where(item => item.IdPelicula == idPeli).ToList();
            decimal sum = 0;
            decimal count = 0;
            decimal average = 0;
            foreach (Puntuacion item in lista)
            {
                sum += item.Puntuacion1;
                count++;
            }
            average = sum / count;
            return decimal.Round(average, 2);
        }

        // GET: api/Puntuacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puntuacion>> GetPuntuacion(int id)
        {
            var puntuacion = await _context.Puntuacions.FindAsync(id);

            if (puntuacion == null)
            {
                return NotFound();
            }

            return puntuacion;
        }

        // PUT: api/Puntuacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuntuacion(int id, Puntuacion puntuacion)
        {
            puntuacion.Id = id;
            if (id != puntuacion.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(puntuacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuntuacionExists(id))
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



        
        [HttpPost]
        public async Task<ActionResult<int>> PostPuntuacion(Puntuacion puntuacion)
        {
           
            if (_context.Puntuacions.Any(punt => punt.IdUsuario == puntuacion.IdUsuario && punt.IdPelicula == puntuacion.IdPelicula)){


                var puntuaciones = _context.Puntuacions.Where(item => item.IdUsuario == puntuacion.IdUsuario && item.IdPelicula == puntuacion.IdPelicula).ToList().First();

                puntuacion.Id = puntuaciones.Id;

                return puntuacion.Id;
            } 
            

                _context.Puntuacions.Add(puntuacion);
                await _context.SaveChangesAsync(); 

            return CreatedAtAction("GetPuntuacion", new { id = puntuacion.Id }, puntuacion);
        }



        // DELETE: api/Puntuacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuntuacion(int id)
        {
            var puntuacion = await _context.Puntuacions.FindAsync(id);
            if (puntuacion == null)
            {
                return NotFound();
            }

            _context.Puntuacions.Remove(puntuacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuntuacionExists(int id)
        {
            return _context.Puntuacions.Any(e => e.Id == id);
        }
    }
}
