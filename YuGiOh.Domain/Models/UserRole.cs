using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;

namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(UserRoleConfiguration))]
    public class UserRole : IEntity
    {

        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public object GetById()
        {
            return new { UserId, RoleId };
        }
    }
}
