using YuGiOh.Domain.Enums;

namespace YuGiOh.Domain.Models
{
    public class Role : Entity
    {
        public RoleType Type { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
