namespace LetsTrain.API.Services.Exercicio
{
    public interface IExercicioService
    {
        Task<IEnumerable<Model.Exercicio>> GetAllAsync();
        Task<Model.Exercicio?> GetByIdAsync(int id);
        Task AddAsync(Model.Exercicio exercicio); 
        Task UpdateAsync(int id, Model.Exercicio exercicio);
        Task DeleteAsync(int id);
    }
}
