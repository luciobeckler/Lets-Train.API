using LetsTrain.API.Dto;
using LetsTrain.API.Helper;
using LetsTrain.API.Model;
using LetsTrain.API.Services.Exercicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Controllers.Exercicio
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioService _service;


        public ExercicioController(IExercicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.Exercicio>>> ListarExercicios()
        {
            var exercicios = await _service.GetAllAsync();
            return Ok(exercicios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Exercicio>> BuscarExercicioPorId(int id)
        {
            var exercicio = await _service.GetByIdAsync(id);
            if (exercicio == null)
                return NotFound();

            return Ok(exercicio);
        }

        [HttpPost]
        public async Task<ActionResult<ExercicioDto>> AdicionarExercicio(ExercicioDto exercicioDto)
        {
            var exercicio = new Model.Exercicio()
            {
                Nome = exercicioDto.Nome,
                Repeticoes = exercicioDto.Repeticoes,
            };

            await _service.AddAsync(exercicio);
            return Ok(exercicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarExercicio(int id, ExercicioDto exercicioDto)
        {
            try
            {
                var exercicio = new Model.Exercicio()
                {
                    Nome = exercicioDto.Nome,
                    Repeticoes = exercicioDto.Repeticoes
                };

                await _service.UpdateAsync(id, exercicio);
                return Ok(exercicio);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercicios(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }
        }
    }
}