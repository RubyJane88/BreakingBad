using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BreakingBad.API.Models;
using BreakingBad.API.Models.Entities;

namespace BreakingBad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeathsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeathsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Deaths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Death>>> GetDeaths()
        {
            return await _context.Deaths.ToListAsync();
        }

        // GET: api/Deaths/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Death>> GetDeath(int id)
        {
            var death = await _context.Deaths.FindAsync(id);

            if (death == null)
            {
                return NotFound();
            }

            return death;
        }

        // PUT: api/Deaths/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeath(int id, Death death)
        {
            if (id != death.DeathId)
            {
                return BadRequest();
            }

            _context.Entry(death).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeathExists(id))
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

        // POST: api/Deaths
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Death>> PostDeath(Death death)
        {
            _context.Deaths.Add(death);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeath", new { id = death.DeathId }, death);
        }

        // DELETE: api/Deaths/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeath(int id)
        {
            var death = await _context.Deaths.FindAsync(id);
            if (death == null)
            {
                return NotFound();
            }

            _context.Deaths.Remove(death);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeathExists(int id)
        {
            return _context.Deaths.Any(e => e.DeathId == id);
        }
    }
}
