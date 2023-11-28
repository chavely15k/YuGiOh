using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;
namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(TournamentConfiguration))]
    public class Tournament : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public User User { get; set; }

        public object GetById()
        {
            return Id;
        }
    }
}