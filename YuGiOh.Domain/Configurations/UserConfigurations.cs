using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuGiOh.Domain.Models;

namespace YuGiOh.Domain.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nick)
                .IsRequired()
                .HasMaxLength(30);
                
            builder.HasIndex(u => u.Nick)
                .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(16);
                
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Province)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Township)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(u => u.Roles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
