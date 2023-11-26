using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;
namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(TournamentConfiguration))]
    public class Tournament:Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public DateTime StartDate { get; set; }

        public User User{get;set;}

    }
}