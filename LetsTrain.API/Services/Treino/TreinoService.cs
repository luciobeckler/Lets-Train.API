
using LetsTrain.API.Repositories.Exercicio;
using LetsTrain.API.Repositories.Treino;
using LetsTrain.API.Services.Exercicio;

namespace LetsTrain.API.Services.Treino
{
    public class TreinoService : ITreinoService
    {
        private readonly ITreinoRepository _treinoRepository;
        private readonly IExercicioService _exercicioService;

        public TreinoService(ITreinoRepository treinoRepository, IExercicioService exercicioService)
        {
            _treinoRepository = treinoRepository;
            _exercicioService = exercicioService;
        }

        public async Task AddAsync(Model.Treino treino)
        {
            await _treinoRepository.AddAsync(treino);
        }

        public async Task AddExercicioAoTreino(int idExercicio, int idTreino)
        {
            var treino = await GetByIdAsync(idTreino);
            var exercicio = await _exercicioService.GetByIdAsync(idExercicio);

            if (treino == null)
                throw new KeyNotFoundException("Treino não encontrado");
            if (exercicio == null)
                throw new KeyNotFoundException("Exercício não encontrado.");

            treino.Exercicios.Add(exercicio);
            await UpdateAsync(treino.Id, treino);
        }

        public Task AddProfessorAoTreino(int idProfessor, int idTreino)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var treino = await _treinoRepository.GetByIdAsync(id);
            if (treino == null)
                throw new KeyNotFoundException("Treino não encontrado.");

            await _treinoRepository.DeleteAsync(treino);
        }

        public async Task<IEnumerable<Model.Treino>> GetAllAsync()
        {
            return await _treinoRepository.GetAllAsync();
        }

        public async Task<Model.Treino?> GetByIdAsync(int id)
        {
            return await _treinoRepository.GetByIdAsync(id);
        }

        public async Task RemoveExercicioDoTreino(int idExercicio, int idTreino)
        {
            var treino = await GetByIdAsync(idTreino);
            var exercicio = await _exercicioService.GetByIdAsync(idExercicio);

            if (treino == null)
                throw new KeyNotFoundException("Treino não encontrado");
            if (exercicio == null)
                throw new KeyNotFoundException("Exercício não encontrado.");

            treino.Exercicios.Remove(exercicio);
            await UpdateAsync(treino.Id, treino);
        }

        public Task RemoveProfessorDoTreino(int idProfessor, int idTreino)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, Model.Treino treino)
        {
            if (!await _treinoRepository.ExistsAsync(id))
                throw new KeyNotFoundException("Treino não encontrado.");

            treino.Id = id;
            await _treinoRepository.UpdateAsync(treino);
        }
    }
}
