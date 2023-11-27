using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;
namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(RequestConfiguration))]
    public class Request 
    {
        public Guid PlayerId { get; set; }
        public User Player { get; set; }

        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public Guid DeckId { get; set; }
        public Deck Deck { get; set; }
        
        public DateTime Date { get; set; }
        public RequestStatus Status { get; set; }
    }
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected,
    }
}