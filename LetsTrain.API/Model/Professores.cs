namespace LetsTrain.API.Model
{
    public class Professores
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public string? Graduacao { get; set; }
        public bool IsAtivo { get; set; }

        // Navegação
        public ICollection<Aulas> Aulas { get; set; } = new List<Aulas>();
        public ICollection<Treinos> Treinos { get; set; } = new List<Treinos>();
    }
}
