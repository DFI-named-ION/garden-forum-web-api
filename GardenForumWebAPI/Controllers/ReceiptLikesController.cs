using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenForumWebAPI.EF;
using GardenForumWebAPI.Models;

namespace GardenForumWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptLikesController : ControllerBase
    {
        private readonly GardenForumApiDbContext _context;

        public ReceiptLikesController(GardenForumApiDbContext context)
        {
            _context = context;
        }

        // GET: api/ReceiptLikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptLike>>> GetReceiptLikes()
        {
          if (_context.ReceiptLikes == null)
          {
              return NotFound();
          }
            return await _context.ReceiptLikes.ToListAsync();
        }

        // GET: api/ReceiptLikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiptLike>> GetReceiptLike(long id)
        {
          if (_context.ReceiptLikes == null)
          {
              return NotFound();
          }
            var receiptLike = await _context.ReceiptLikes.FindAsync(id);

            if (receiptLike == null)
            {
                return NotFound();
            }

            return receiptLike;
        }

        // PUT: api/ReceiptLikes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceiptLike(long id, ReceiptLike receiptLike)
        {
            if (id != receiptLike.Id)
            {
                return BadRequest();
            }

            _context.Entry(receiptLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptLikeExists(id))
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

        // POST: api/ReceiptLikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReceiptLike>> PostReceiptLike(ReceiptLike receiptLike)
        {
          if (_context.ReceiptLikes == null)
          {
              return Problem("Entity set 'GardenForumApiDbContext.ReceiptLikes'  is null.");
          }
            _context.ReceiptLikes.Add(receiptLike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceiptLike", new { id = receiptLike.Id }, receiptLike);
        }

        // DELETE: api/ReceiptLikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceiptLike(long id)
        {
            if (_context.ReceiptLikes == null)
            {
                return NotFound();
            }
            var receiptLike = await _context.ReceiptLikes.FindAsync(id);
            if (receiptLike == null)
            {
                return NotFound();
            }

            _context.ReceiptLikes.Remove(receiptLike);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceiptLikeExists(long id)
        {
            return (_context.ReceiptLikes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
