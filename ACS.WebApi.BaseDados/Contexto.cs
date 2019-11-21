using ACS.WebApi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ACS.WebApi.BaseDados
{
    public class Contexto : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Medicao> Medicoes { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteRemedio> PacientesRemedios { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Remedio> Remedios { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Chaves Compostas
            modelbuilder.Entity<PacienteRemedio>().HasKey(t => new
            {
                t.IdPaciente,
                t.IdRemedio
            });
            modelbuilder.Entity<Resposta>().HasKey(t => new
            {
                t.IdPaciente,
                t.IdPergunta
            });

            base.OnModelCreating(modelbuilder);
        }
    }
}
