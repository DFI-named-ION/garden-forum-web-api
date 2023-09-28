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
    public class ArticleLikesController : ControllerBase
    {
        private readonly GardenForumApiDbContext _context;

        public ArticleLikesController(GardenForumApiDbContext context)
        {
            _context = context;
        }

        // GET: api/ArticleLikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleLike>>> GetArticleLikes()
        {
          if (_context.ArticleLikes == null)
          {
              return NotFound();
          }
            return await _context.ArticleLikes.ToListAsync();
        }

        // GET: api/ArticleLikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleLike>> GetArticleLike(long id)
        {
          if (_context.ArticleLikes == null)
          {
              return NotFound();
          }
            var articleLike = await _context.ArticleLikes.FindAsync(id);

            if (articleLike == null)
            {
                return NotFound();
            }

            return articleLike;
        }

        // PUT: api/ArticleLikes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleLike(long id, ArticleLike articleLike)
        {
            if (id != articleLike.Id)
            {
                return BadRequest();
            }

            _context.Entry(articleLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleLikeExists(id))
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

        // POST: api/ArticleLikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticleLike>> PostArticleLike(ArticleLike articleLike)
        {
          if (_context.ArticleLikes == null)
          {
              return Problem("Entity set 'GardenForumApiDbContext.ArticleLikes'  is null.");
          }
            _context.ArticleLikes.Add(articleLike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticleLike", new { id = articleLike.Id }, articleLike);
        }

        // DELETE: api/ArticleLikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleLike(long id)
        {
            if (_context.ArticleLikes == null)
            {
                return NotFound();
            }
            var articleLike = await _context.ArticleLikes.FindAsync(id);
            if (articleLike == null)
            {
                return NotFound();
            }

            _context.ArticleLikes.Remove(articleLike);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleLikeExists(long id)
        {
            return (_context.ArticleLikes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
