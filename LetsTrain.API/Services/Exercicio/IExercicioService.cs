
using LetsTrain.API.Model;
using LetsTrain.API.Model.Dto;

namespace LetsTrain.API.Services.Exercicio
{
    public interface IExercicioService
    {
        Task<IEnumerable<Model.Exercicio>> GetAllAsync();
        Task<Model.Exercicio?> GetByIdAsync(int id);
        Task AddAsync(Model.Exercicio exercicioDto);
        Task UpdateAsync(int id, Model.Exercicio exercicioDto);
        Task DeleteAsync(int id);

    }
}
