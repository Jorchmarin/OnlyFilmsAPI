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
    public class ComentariosController : ControllerBase
    {
        private readonly OnlyFilmsContext _context;

        public ComentariosController(OnlyFilmsContext context)
        {
            _context = context;
        }

        // GET: api/Comentarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentarios()
        {
            return await _context.Comentarios.ToListAsync();
        }

        // GET: api/Comentarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return comentario;
        }

        [HttpGet]
        [Route("/comentariosPeli/{idPelicula}")]

        public async Task<IActionResult> ComentariosDePelis(int idPelicula)
        {
            var comentarios = _context.Comentarios.Where(item => item.IdPelicula == idPelicula).ToList();


            if (comentarios == null)
            {
                return NotFound();
            }
            var listaComentarios = new List<ComentarioDTO>();
            
            foreach (var comentario in comentarios){
                listaComentarios.Add(new ComentarioDTO { Description = comentario.Description, Fecha = comentario.Fecha, 
                    Id = comentario.Id, IdPelicula = comentario.IdPelicula, Usuario = await GetUserById((int)comentario.IdUsuario)

                });
            }
            return Ok(listaComentarios);
        }

        private async Task<UsuarioDTO> GetUserById(int idUsuario)
        {
            var usuario = _context.Usuarios.Where(item => item.Id == idUsuario).ToList().First();

            return new UsuarioDTO {Id = usuario.Id , Email = usuario.Email , Name = usuario.Name , Nick = usuario.Nick , Password = usuario.Password };
        }

        // PUT: api/Comentarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentario(int id, Comentario comentario)
        {
            if (id != comentario.Id)
            {
                return BadRequest();
            }

            _context.Entry(comentario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
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

        // POST: api/Comentarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comentario>> PostComentario(Comentario comentario)
        {
            if(comentario.Description.Length >= 7)
            {
                comentario.Fecha = DateTime.Now;
                _context.Comentarios.Add(comentario);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetComentario", new { id = comentario.Id }, comentario);
            }
            else
            {
                return BadRequest();
            }
           
        }

        // DELETE: api/Comentarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComentarioExists(int id)
        {
            return _context.Comentarios.Any(e => e.Id == id);
        }
    }
}
