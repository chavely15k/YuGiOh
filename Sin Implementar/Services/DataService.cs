using YuGiOh.Infrastructure.Repositories;

namespace YuGiOh.Infrastructure.Services {
    public class DataService {
        protected readonly DataRepository Repository;
        public DataService(DataRepository dataRepository) {
            this.Repository = dataRepository;
        }
    }
}