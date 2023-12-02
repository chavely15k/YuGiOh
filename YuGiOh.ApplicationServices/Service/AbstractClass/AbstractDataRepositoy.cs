using YuGiOh.ApplicationCore.Repository;

namespace YuGiOh.ApplicationServices.Service
{
    public abstract class AbstractDataRepository
    {
        protected readonly IEntityRepository _dataRepository;

        public AbstractDataRepository(IEntityRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
    }
}
