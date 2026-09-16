using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atividade_API.Data;
using Atividade_API.Models;

namespace Atividade_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletinsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BoletinsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Boletins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boletim>>> GetBoletim()
        {
          if (_context.Boletim == null)
          {
              return NotFound();
          }
            return await _context.Boletim.ToListAsync();
        }

        // GET: api/Boletins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boletim>> GetBoletim(int id)
        {
          if (_context.Boletim == null)
          {
              return NotFound();
          }
            var boletim = await _context.Boletim.FindAsync(id);

            if (boletim == null)
            {
                return NotFound();
            }

            return boletim;
        }

        // PUT: api/Boletins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoletim(int id, Boletim boletim)
        {
            if (id != boletim.Id)
            {
                return BadRequest();
            }

            _context.Entry(boletim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletimExists(id))
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

        // POST: api/Boletins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Boletim>> PostBoletim(Boletim boletim)
        {
          if (_context.Boletim == null)
          {
              return Problem("Entity set 'AppDbContext.Boletim'  is null.");
          }
            _context.Boletim.Add(boletim);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BoletimExists(boletim.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBoletim", new { id = boletim.Id }, boletim);
        }

        // DELETE: api/Boletins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoletim(int id)
        {
            if (_context.Boletim == null)
            {
                return NotFound();
            }
            var boletim = await _context.Boletim.FindAsync(id);
            if (boletim == null)
            {
                return NotFound();
            }

            _context.Boletim.Remove(boletim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoletimExists(int id)
        {
            return (_context.Boletim?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
