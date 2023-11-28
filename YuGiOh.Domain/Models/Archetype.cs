using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;

namespace YuGiOh.Domain.Models;
[EntityTypeConfiguration(typeof(ArchetypeConfiguration))]
public class Archetype : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public object GetById()
    {
        return Id;
    }
}
