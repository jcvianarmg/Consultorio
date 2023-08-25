using Consult.Core.Domain;
using Consult.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Consult.Data.Context
{
    public class ConsultContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }

        public ConsultContext(DbContextOptions options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PacienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
            //modelBuilder.ApplyConfiguration(new MedicoConfiguration());

        }
    }
}
