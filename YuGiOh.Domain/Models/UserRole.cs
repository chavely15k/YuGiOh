using Microsoft.EntityFrameworkCore;
using YuGiOh.Domain.Configurations;

namespace YuGiOh.Domain.Models
{
    [EntityTypeConfiguration(typeof(UserRoleConfiguration))]
    public class UserRole : IEntity
    {

        public UserRole(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public object GetById()
        {
            return new { UserId, RoleId };
        }
    }
}
