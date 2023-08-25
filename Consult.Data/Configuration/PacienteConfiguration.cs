using Consult.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consult.Data.Configuration
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {

            //builder.HasKey(p => p.Id);
            //builder.ToTable("Tb_Pacientes");
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            //builder.Property(p => p.Sexo).HasConversion(
            //    p => p.ToString(),
            //    p => (Sexo)Enum.Parse(typeof(Sexo), p));

        }
    }
}
