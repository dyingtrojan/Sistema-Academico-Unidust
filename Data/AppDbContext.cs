using Microsoft.EntityFrameworkCore;
using Atividade_API.Data;
using Atividade_API.Models;
using Atividade_API.Models.Usuarios;

namespace Atividade_API.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>().HasOne(p => p.turma).WithMany().HasForeignKey(p => p.TurmaId).OnDelete(DeleteBehavior.NoAction);
        }


        public DbSet<Atividade_API.Models.Usuarios.Aluno> Aluno { get; set; } = default!;

        public DbSet<Atividade_API.Models.Boletim> Boletim { get; set; } = default!;

        public DbSet<Atividade_API.Models.Turma> Turma { get; set; } = default!;

        public DbSet<Atividade_API.Models.Pessoa> Pessoa { get; set; } = default!;

        public DbSet<Atividade_API.Models.Disciplina> Disciplina { get; set; } = default!;

        public DbSet<Atividade_API.Models.Atividade> Atividade { get; set; } = default!;

        public DbSet<Atividade_API.Models.Usuarios.Professor> Professor { get; set; } = default!;

        public DbSet<Atividade_API.Models.Usuarios.Administrador> Administrador { get; set; } = default!;
    }
}
