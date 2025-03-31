namespace LetsTrain.API.Model
{
    public class Treino
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int DuracaoEmMinutos { get; set; }

        //Relacionamentos
        public List<Aula> Aulas { get; set; }
        public List<Exercicio> Exercicios { get; set; }
        public Professor Professor { get; set; }
    }
}
