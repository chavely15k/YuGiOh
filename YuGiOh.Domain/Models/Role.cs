using YuGiOh.Domain.Enums;

namespace YuGiOh.Domain.Models
{
    public class Role : Entity
    {
        public int enumValue { get; set; }
        public List<UserRole> Users { get; set; }
    }
}
