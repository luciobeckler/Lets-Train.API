using LetsTrain.API.Model;

namespace LetsTrain.API.Services.Exercicio
{
    public interface IExercicioService
    {
        Task<List<Exer>> ListarExercicios();

    }
}
