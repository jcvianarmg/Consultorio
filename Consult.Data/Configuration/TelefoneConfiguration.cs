using Consult.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consult.Data.Configuration
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
         public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(p => new { p.PacienteId, p.Numero });
        }
    }
}
