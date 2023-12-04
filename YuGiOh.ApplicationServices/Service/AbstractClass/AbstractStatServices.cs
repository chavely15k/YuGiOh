using AutoMapper;
using YuGiOh.ApplicationCore.Repository;

namespace YuGiOh.ApplicationServices.Service
{
    public abstract class AbstractStatServices
    {
         protected readonly IMapper _mapper;
        protected readonly IStatsRepository _statsRepository;

        public AbstractStatServices(IStatsRepository statsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _statsRepository = statsRepository;
        }
    }
}
