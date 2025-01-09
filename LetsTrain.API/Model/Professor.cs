namespace LetsTrain.API.Model
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public string? Graduacao { get; set; }
        public bool IsAtivo { get; set; }

        // Navegação
        public ICollection<Aula> Aulas { get; set; } = new List<Aula>();
        public ICollection<Treino> Treinos { get; set; } = new List<Treino>();
    }
}
