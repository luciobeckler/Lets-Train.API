using LetsTrain.API.Model.Dto;

namespace LetsTrain.API.Repositories.Exercicio
{
    public interface IExercicioRepository
    {
        Task<IEnumerable<Model.Exercicio?>> GetAllAsync();
        Task<Model.Exercicio?> GetByIdAsync(int id);
        Task AddAsync(Model.Exercicio exercicio);
        Task UpdateAsync(Model.Exercicio exercicio);
        Task DeleteAsync(Model.Exercicio exercicio);
        Task<bool> ExistsAsync(int id);
    }
}
