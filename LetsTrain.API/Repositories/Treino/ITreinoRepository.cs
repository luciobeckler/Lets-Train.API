namespace LetsTrain.API.Repositories.Treino
{
    public interface ITreinoRepository
    {
        Task<IEnumerable<Model.Treino?>> GetAllAsync();
        Task<Model.Treino?> GetByIdAsync(int id);
        Task AddAsync(Model.Treino treino);
        Task UpdateAsync(Model.Treino treino);
        Task DeleteAsync(Model.Treino treino);
        Task<bool> ExistsAsync(int id);
    }
}
