using LetsTrain.API.Helper;
using LetsTrain.API.Model;
using LetsTrain.API.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.Exercicio>>> GetExercicios()
        {
           return Ok(await _context.Exercicios.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Exercicio>> GetExercicios(int id)
        {
            var exercicio = await _context.Exercicios.FindAsync(id);

            if (VerificacoesHelper.IsNull(exercicio))
            {
                return NotFound();
            }

            return exercicio;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercicios(int id, ExercicioDto exercicioDto)
        {
            Model.Exercicio exercicio = new Model.Exercicio()
            {
                Id = id,
                Nome = exercicioDto.Nome,
                Repeticoes = exercicioDto.Repeticoes
            };

            _context.Entry(exercicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercicioExists(id))
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
        public async Task<ActionResult<ExercicioDto>> PostExercicios(ExercicioDto exercicioDto)
        {
            Model.Exercicio exercicio = new Model.Exercicio() 
            {
                Nome = exercicioDto.Nome,
                Repeticoes = exercicioDto.Repeticoes,
            };

            _context.Exercicios.Add(exercicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercicios", new { id = exercicio.Id }, exercicioDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercicios(int id)
        {
            var exercicio = await _context.Exercicios.FindAsync(id);
            if (exercicio == null)
            {
                return NotFound();
            }

            _context.Exercicios.Remove(exercicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExercicioExists(int id)
        {
            return _context.Exercicios.Any(e => e.Id == id);
        }
    }
}
