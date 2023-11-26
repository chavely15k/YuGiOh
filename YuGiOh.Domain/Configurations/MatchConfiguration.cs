using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuGiOh.Domain.Models;

namespace YuGiOh.Domain.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(m => new { m.PlayerOneId, m.Date });
            
            builder.HasOne(m => m.PlayerOne)
                .WithMany()
                .HasForeignKey(m => m.PlayerOneId);

            builder.HasOne(m => m.PlayerTwo)
                .WithMany()
                .HasForeignKey(m => m.PlayerTwoId);

            builder.HasOne(m => m.Tournament)
                .WithMany()
                .HasForeignKey(m => m.TournamentId);


        }
    }
}
