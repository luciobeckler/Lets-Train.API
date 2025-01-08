using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Model
{
    public class LetsTrainDbContext : DbContext
    {
        public LetsTrainDbContext(DbContextOptions<LetsTrainDbContext> options) : base(options) { }

        public DbSet<Professores> Professores { get; set; } = null!;
        public DbSet<Alunos> Alunos { get; set; } = null!;
        public DbSet<Aulas> Aulas { get; set; } = null!;
        public DbSet<Treinos> Treinos { get; set; } = null!;
        public DbSet<Exercicios> Exercicios { get; set; } = null!;
    }
}
