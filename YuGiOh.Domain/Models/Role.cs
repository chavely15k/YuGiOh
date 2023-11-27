using YuGiOh.Domain.Enums;

namespace YuGiOh.Domain.Models
{
    public class Role : IEntity
    {
        public Guid Id {get;set;}
        public int enumValue { get; set; }

        public object GetById()
        {
            return Id;
        }
    }
}
