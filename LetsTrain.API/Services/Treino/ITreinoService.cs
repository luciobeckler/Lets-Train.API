namespace LetsTrain.API.Services.Treino
{
    public interface ITreinoService
    {
        Task<IEnumerable<Model.Treino>> GetAllAsync();
        Task<Model.Treino?> GetByIdAsync(int id);
        Task AddAsync(Model.Treino treino); 
        Task UpdateAsync(int id, Model.Treino treino);
        Task DeleteAsync(int id);
        Task AddExercicioAoTreino(int idExercicio, int idTreino);
        Task RemoveExercicioDoTreino(int idExercicio, int idTreino);
        Task AddProfessorAoTreino(int idProfessor, int idTreino);
        Task RemoveProfessorDoTreino(int idProfessor, int idTreino);
    }
}
