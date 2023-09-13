using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consult.Data.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(k => k.Login);
    }
}