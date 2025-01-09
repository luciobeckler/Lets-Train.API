using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Model
{
    public class LetsTrainDbContext : DbContext
    {
        public LetsTrainDbContext(DbContextOptions<LetsTrainDbContext> options) : base(options) { }

        public DbSet<Professor> Professores { get; set; } = null!;
        public DbSet<Aluno> Alunos { get; set; } = null!;
        public DbSet<Aula> Aulas { get; set; } = null!;
        public DbSet<Treino> Treinos { get; set; } = null!;
        public DbSet<Exercicio> Exercicios { get; set; } = null!;
    }
}
