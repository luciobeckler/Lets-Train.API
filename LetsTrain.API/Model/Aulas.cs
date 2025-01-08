using LetsTrain.API.Model;

public class Aulas
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public int QuantMaximaAlunos { get; set; }
    public string Local { get; set; } = null!;
    public int? RecorrenciaEmDias { get; set; }

    // Navegação
    public ICollection<Alunos> Alunos { get; set; } = null!;
    public Treinos Treinos { get; set; } = null!;
    public Professores Professores { get; set; } = null!;

    
}

