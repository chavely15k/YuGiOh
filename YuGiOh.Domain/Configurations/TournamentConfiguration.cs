
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuGiOh.Domain.Models;

namespace YuGiOh.Domain.Configurations
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {

        public void Configure(EntityTypeBuilder<Tournament> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(t => t.StartDate)
                .IsRequired();

            builder.HasOne(tournament => tournament.User)
            .WithMany()
            .HasForeignKey(tournament => tournament.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        }

    }
}