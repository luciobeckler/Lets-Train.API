namespace LetsTrain.API.Model
{
    public class Treino
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int DuracaoEmMinutos { get; set; }

        public ICollection<Exercicio> Exercicios { get; set; } = null!;
    }
}
