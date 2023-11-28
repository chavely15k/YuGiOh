using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuGiOh.Domain.Models;

namespace YuGiOh.Domain.Configurations
{
    public class ArchetypeConfiguration : IEntityTypeConfiguration<Archetype>
    {

        public void Configure(EntityTypeBuilder<Archetype> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(40);
            builder.HasIndex(a => a.Name).IsUnique(); 
        }

    }
}
