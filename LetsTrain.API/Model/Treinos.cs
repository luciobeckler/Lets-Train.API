namespace LetsTrain.API.Model
{
    public class Treinos
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int DuracaoEmMinutos { get; set; }

        public ICollection<Exercicios> Exercicios { get; set; } = null!;
    }
}
