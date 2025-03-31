namespace LetsTrain.API.Repositories.Aluno
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Model.Aluno?>> GetAllAsync();
        Task<Model.Aluno?> GetByIdAsync(int id);
        Task AddAsync(Model.Aluno aluno);
        Task UpdateAsync(Model.Aluno aluno);
        Task DeleteAsync(Model.Aluno aluno);
        Task<bool> ExitsAsync(int id);
    }
}
