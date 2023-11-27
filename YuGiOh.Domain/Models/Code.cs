using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;
namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(CodeConfiguration))]
    public class Code : Entity
    {
        public string Text { get; set; }
    }
}