using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;



namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(DeckConfiguration))]
    public class Deck:Entity
    {
        public string Name { get; set; }
        public string Archetype { get; set; }
        public int MainDeckSize { get; set; }
        public int SideDeckSize { get; set; }
        public int ExtraDeckSize { get; set; }
        
        public User Player { get; set; }
    }
}