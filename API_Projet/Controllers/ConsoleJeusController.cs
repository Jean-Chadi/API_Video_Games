using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Projet.Data;
using API_Projet.Models;

namespace API_Projet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsoleJeusController : ControllerBase
    {
        private readonly API_ProjetContext _context;

        public ConsoleJeusController(API_ProjetContext context)
        {
            _context = context;
        }

        // GET: api/ConsoleJeus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsoleJeu>>> GetConsoleJeu()
        {
            return await _context.ConsoleJeu.ToListAsync();
        }

        // GET: api/ConsoleJeus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsoleJeu>> GetConsoleJeu(int id)
        {
            var consoleJeu = await _context.ConsoleJeu.FindAsync(id);

            if (consoleJeu == null)
            {
                return NotFound();
            }

            return consoleJeu;
        }

        // PUT: api/ConsoleJeus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsoleJeu(int id, ConsoleJeu consoleJeu)
        {
            if (id != consoleJeu.Id)
            {
                return BadRequest();
            }

            _context.Entry(consoleJeu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsoleJeuExists(id))
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

        // POST: api/ConsoleJeus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsoleJeu>> PostConsoleJeu(ConsoleJeu consoleJeu)
        {
            _context.ConsoleJeu.Add(consoleJeu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsoleJeu", new { id = consoleJeu.Id }, consoleJeu);
        }

        // DELETE: api/ConsoleJeus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsoleJeu(int id)
        {
            var consoleJeu = await _context.ConsoleJeu.FindAsync(id);
            if (consoleJeu == null)
            {
                return NotFound();
            }

            _context.ConsoleJeu.Remove(consoleJeu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsoleJeuExists(int id)
        {
            return _context.ConsoleJeu.Any(e => e.Id == id);
        }
    }
}
