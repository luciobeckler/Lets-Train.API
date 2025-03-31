
using LetsTrain.API.Model;
using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Repositories.Treino
{
    public class TreinoRepository : ITreinoRepository
    {
        private readonly LetsTrainDbContext _context;
        public TreinoRepository(LetsTrainDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Model.Treino treino)
        {
            await _context.Treinos.AddAsync(treino);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Model.Treino treino)
        {
            _context.Treinos.Remove(treino);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            bool existe = await _context.Treinos.AnyAsync(x => x.Id == id);
            return existe; 
        }

        public async Task<IEnumerable<Model.Treino?>> GetAllAsync()
        {
            return await _context.Treinos.ToListAsync();
        }

        public async Task<Model.Treino?> GetByIdAsync(int id)
        {
            return await _context.Treinos.FindAsync(id);
        }

        public Task UpdateAsync(Model.Treino treino)
        {
            _context.Entry(treino).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
