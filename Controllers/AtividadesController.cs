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
    public class AtividadesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AtividadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Atividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atividade>>> GetAtividade()
        {
          if (_context.Atividade == null)
          {
              return NotFound();
          }
            return await _context.Atividade.Include(a => a.professor).Include(a => a.professor)
        .Include(a => a.turma)
        .Include(a => a.disciplina).ToListAsync();
        }

        // GET: api/Atividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atividade>> GetAtividade(int id)
        {
          if (_context.Atividade == null)
          {
              return NotFound();
          }
            var atividade = await _context.Atividade.Include(a => a.professor).Include(a => a.professor)
        .Include(a => a.turma)
        .Include(a => a.disciplina).FirstOrDefaultAsync(a => a.Id == id);

            if (atividade == null)
            {
                return NotFound();
            }

            return atividade;
        }

        // PUT: api/Atividades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtividade(int id, Atividade atividade)
        {
            if (id != atividade.Id)
            {
                return BadRequest();
            }

            _context.Entry(atividade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtividadeExists(id))
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

        // POST: api/Atividades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atividade>> PostAtividade(Atividade atividade)
        {
          if (_context.Atividade == null)
          {
              return Problem("Entity set 'AppDbContext.Atividade'  is null.");
          }
            if (atividade.professor != null){
                

                var professorDoBanco = await _context.Professor.FirstOrDefaultAsync(
                    p => p.Id == atividade.ProfessorID
                );

                atividade.professor = professorDoBanco;
            }
            _context.Atividade.Add(atividade);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AtividadeExists(atividade.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAtividade", new { id = atividade.Id }, atividade);
        }

        // DELETE: api/Atividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtividade(int id)
        {
            if (_context.Atividade == null)
            {
                return NotFound();
            }
            var atividade = await _context.Atividade.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }

            _context.Atividade.Remove(atividade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtividadeExists(int id)
        {
            return (_context.Atividade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
