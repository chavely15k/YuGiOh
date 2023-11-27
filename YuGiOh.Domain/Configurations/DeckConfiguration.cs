using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuGiOh.Domain.Models;

namespace YuGiOh.Domain.Configurations
{
    public class DeckConfiguration : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(d => d.Archetype)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(d => d.MainDeckSize)
                .IsRequired()
                .HasAnnotation("Range", new[] { 40, 60 });

            builder.Property(d => d.SideDeckSize)
                .IsRequired()
                .HasAnnotation("Range", new[] { 0, 15 });

            builder.Property(d => d.ExtraDeckSize)
                .IsRequired()
                .HasAnnotation("Range", new[] { 0, 15 });

            builder.HasOne(d => d.Player)
                .WithMany()
                .IsRequired();

          
        }
    }

}