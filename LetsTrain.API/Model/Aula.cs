using LetsTrain.API.Model;

public class Aula
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public int QuantMaximaAlunos { get; set; }
    public string Local { get; set; } = null!;
    public int? RecorrenciaEmDias { get; set; }

    //Relacionamentos
    public Treino Treino { get; set; }
    public Professor Professor { get; set; }
    public List<Aluno> Aluno { get; set; }
}


