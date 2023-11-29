using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;
using YuGiOh.Domain.Enums;
namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(RequestConfiguration))]
    public class Request : IEntity
    {
        public int PlayerId { get; set; }
        public User Player { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public int DeckId { get; set; }
        public Deck Deck { get; set; }

        public DateTime Date { get; set; }
        public RequestStatus Status { get; set; }

        public object GetById()
        {
            return new { PlayerId, TournamentId };
        }
    }
    
}