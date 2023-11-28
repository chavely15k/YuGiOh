using AutoMapper;
using YuGiOh.ApplicationCore.Repository;

namespace YuGiOh.ApplicationServices.Service
{
    public abstract class AbstractDataService : AbstractDataRepository
    {
        protected readonly IMapper _mapper;
        public AbstractDataService(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository)
        {
            _mapper = mapper;
        }
    }
}