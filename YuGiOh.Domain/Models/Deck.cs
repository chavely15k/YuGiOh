using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;



namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(DeckConfiguration))]
    public class Deck:IEntity
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public int MainDeckSize { get; set; }
        public int SideDeckSize { get; set; }
        public int ExtraDeckSize { get; set; }
        public int PlayerId { get; set; }
        public int ArchetypeId{get;set;}
        public Archetype Archetype { get; set; }
        public User Player { get; set; }
        

        public object GetById()
        {
            return Id;
        }
    }
}