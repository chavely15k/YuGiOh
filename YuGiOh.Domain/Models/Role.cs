using YuGiOh.Domain.Enums;

namespace YuGiOh.Domain.Models
{
    public class Role : IEntity
    {
        public int Id {get;set;}
        public int Type { get; set; }

        public object GetById()
        {
            return Id;
        }
    }
}
