using Consult.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Consult.Data.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.PacienteId);
            builder.Property(p => p.Estado).HasConversion(
                p => p.ToString(),
                p => (Estado)Enum.Parse(typeof(Estado), p));
        }
    }
}
