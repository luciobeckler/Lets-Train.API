using LetsTrain.API.Model;
using LetsTrain.API.Model.Dto;
using LetsTrain.API.Repositories.Exercicio;
using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Repositories.Exercicios
{
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly LetsTrainDbContext _context;

        public ExercicioRepository(LetsTrainDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Model.Exercicio?>> GetAllAsync()
        {

            var result = await _context.Exercicios.ToListAsync();
            return result;
        }

        public async Task<Model.Exercicio?> GetByIdAsync(int id)
        {
            return await _context.Exercicios.FindAsync(id);
        }
        public async Task AddAsync(Model.Exercicio exercicio)
        {
            await _context.Exercicios.AddAsync(exercicio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Model.Exercicio exercicio)
        {
            _context.Entry(exercicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Model.Exercicio exercicio)
        {
            _context.Remove(exercicio);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            bool existe = await _context.Exercicios.AnyAsync(e => e.Id == id);
            
            return existe;
        }
    }
}
