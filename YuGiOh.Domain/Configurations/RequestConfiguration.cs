using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuGiOh.Domain.Models;

namespace YuGiOh.Domain.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(m => new { m.PlayerId, m.TournamentId});
            
            builder.HasOne(m => m.Player)
                .WithMany();
                

            builder.HasOne(m => m.Tournament)
                .WithMany();
                
            builder.Property(r => r.Date).IsRequired();
            builder.Property(r => r.Status)
                .IsRequired()
                .HasConversion<string>();

        }
    }
}