using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;

namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(MatchConfiguration))]
    public class Match : IEntity
    {
        public Guid PlayerOneId { get; set; }
        public User PlayerOne { get; set; }

        public Guid PlayerTwoId { get; set; }
        public User PlayerTwo { get; set; }

        public DateTime Date { get; set; }

        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public int PlayerOneResult { get; set; }
        public int PlayerTwoResult { get; set; }
        public int Round { get; set; }

        public object GetById()
        {
            return new { PlayerOneId, Date };
        }
    }

}