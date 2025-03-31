using LetsTrain.API.Repositories.Exercicio;

namespace LetsTrain.API.Services.Exercicio
{
    public class ExercicioService : IExercicioService
    {
        private readonly IExercicioRepository _repository;

        public ExercicioService(IExercicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Model.Exercicio?>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Model.Exercicio?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Model.Exercicio exercicio)
        {
            await _repository.AddAsync(exercicio);
        }

        public async Task UpdateAsync(int id, Model.Exercicio exercicio)
        {
            if(!await _repository.ExistsAsync(id))
                throw new KeyNotFoundException("Exercício não encontrado.");
            
            exercicio.Id = id;
            await _repository.UpdateAsync(exercicio);
        }

        public async Task DeleteAsync(int id)
        {
            var exercicio = await _repository.GetByIdAsync(id);
            if (exercicio == null)
                throw new KeyNotFoundException("Exercício não encontrado.");

            await _repository.DeleteAsync(exercicio);
        }

    }
}
