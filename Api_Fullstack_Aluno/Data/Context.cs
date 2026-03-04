using Api_Hexagonal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_Hexagonal.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Curso)          // Aluno tem um Curso
                .WithMany(c => c.Alunos)       // Curso tem vários Alunos
                .HasForeignKey(a => a.CursoId) // FK
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}
