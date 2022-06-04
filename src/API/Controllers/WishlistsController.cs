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
    public class WishlistsController : ControllerBase
    {
        private readonly OnlyFilmsContext _context;

        public WishlistsController(OnlyFilmsContext context)
        {
            _context = context;
        }

        // GET: api/Wishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlists()
        {
            return await _context.Wishlists.ToListAsync();
        }

        // GET: api/Wishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(int id)
        {
            var wishlist = await _context.Wishlists.FindAsync(id);

            if (wishlist == null)
            {
                return NotFound();
            }

            return wishlist;
        }

        [HttpGet]
        [Route("/getWishlistBy/{idUser}/{idPeli}")]
        public async Task<ActionResult<Wishlist>> GetWishlistBy(int idUser, int idPeli)
        {
            var wishlist = _context.Wishlists.Where(item => item.IdUsuario == idUser && item.IdPelicula == idPeli).ToList();

            if (wishlist == null)
            {
                return NotFound();
            }

            return Ok(wishlist);
        }


        [HttpGet]
        [Route("/userWishlist/{idUser}")]
        public async Task<ActionResult<Wishlist>> UserWishlist(int idUser)
        {
            var wishlist = _context.Wishlists.Where(item => item.IdUsuario == idUser).ToList();

            if (wishlist == null)
            {
                return NotFound();
            }

            return Ok(wishlist);
        }


        // PUT: api/Wishlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(int id, Wishlist wishlist)
        {
            if (id != wishlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(id))
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

        // POST: api/Wishlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(Wishlist wishlist)
        {
            if (_context.Wishlists.Any(wishlistitem => wishlistitem.IdUsuario == wishlist.IdUsuario && wishlistitem.IdPelicula == wishlist.IdPelicula))
            {
                return BadRequest("El usuario ya ha añadido esa pelicula a su wishlist");

            }
            else
            {
                _context.Wishlists.Add(wishlist);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetWishlist", new { id = wishlist.Id }, wishlist);
        }

        // DELETE: api/Wishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            var wishlist = await _context.Wishlists.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }

            _context.Wishlists.Remove(wishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool WishlistExists(int id)
        {
            return _context.Wishlists.Any(e => e.Id == id);
        }
    }
}
