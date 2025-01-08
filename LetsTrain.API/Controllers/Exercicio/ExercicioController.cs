 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LetsTrain.API.Model;

namespace LetsTrain.API.Controllers.Exercicio
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly LetsTrainDbContext _context;

        public ExercicioController(LetsTrainDbContext context)
        {
            _context = context;
        }

        // GET: api/Exercicio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercicios>>> GetExercicios()
        {
            return await _context.Exercicios.ToListAsync();
        }

        // GET: api/Exercicio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercicios>> GetExercicios(int id)
        {
            var exercicios = await _context.Exercicios.FindAsync(id);

            if (exercicios == null)
            {
                return NotFound();
            }

            return exercicios;
        }

        // PUT: api/Exercicio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercicios(int id, Exercicios exercicios)
        {
            if (id != exercicios.Id)
            {
                return BadRequest();
            }

            _context.Entry(exercicios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciciosExists(id))
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

        // POST: api/Exercicio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exercicios>> PostExercicios(Exercicios exercicios)
        {
            _context.Exercicios.Add(exercicios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercicios", new { id = exercicios.Id }, exercicios);
        }

        // DELETE: api/Exercicio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercicios(int id)
        {
            var exercicios = await _context.Exercicios.FindAsync(id);
            if (exercicios == null)
            {
                return NotFound();
            }

            _context.Exercicios.Remove(exercicios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExerciciosExists(int id)
        {
            return _context.Exercicios.Any(e => e.Id == id);
        }
    }
}
