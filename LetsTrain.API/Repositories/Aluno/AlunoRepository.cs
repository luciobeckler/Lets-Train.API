
using LetsTrain.API.Model;
using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Repositories.Aluno
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly LetsTrainDbContext _context; 
        public AlunoRepository(LetsTrainDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Model.Aluno?>> GetAllAsync()
        {
            var result = await _context.Alunos.ToListAsync();
            return result;
        }

        public async Task<Model.Aluno?> GetByIdAsync(int id)
        {
            var result = await _context.Alunos.FindAsync(id);
            return result;
        }
        public async Task AddAsync(Model.Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Model.Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Model.Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExitsAsync(int id)
        {
            bool existe = await _context.Alunos.AnyAsync(a => a.Id == id);
            return existe;
        }
    }
}
