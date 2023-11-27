using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;
namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(CodeConfiguration))]
    public class Code : IEntity
    {
        public Guid Id;
        public string Text { get; set; }

        public object GetById()
        {
            return Id;
        }
    }
}