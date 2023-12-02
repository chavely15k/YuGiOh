using AutoMapper;
using YuGiOh.ApplicationCore.Repository;

namespace YuGiOh.ApplicationServices.Service
{
    public abstract class AbstractDataServices : AbstractDataRepository
    {
        protected readonly IMapper _mapper;
        public AbstractDataServices(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository)
        {
            _mapper = mapper;
        }
    }
}