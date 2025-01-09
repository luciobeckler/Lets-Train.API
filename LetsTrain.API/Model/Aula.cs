using LetsTrain.API.Model;

public class Aula
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public int QuantMaximaAlunos { get; set; }
    public string Local { get; set; } = null!;
    public int? RecorrenciaEmDias { get; set; }

    // Navegação
    public ICollection<Aluno> Alunos { get; set; } = null!;
    public Treino Treinos { get; set; } = null!;
    public Professor Professores { get; set; } = null!;

    
}

