using CoreSharp.Templates.Blazor.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreSharp.Templates.Blazor.Server.Infrastructure.EntityConfigurations
{
    public class DummyConfiguration : IEntityTypeConfiguration<Dummy>
    {
        //Methods
        public void Configure(EntityTypeBuilder<Dummy> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Description)
                   .HasMaxLength(100);
        }
    }
}
