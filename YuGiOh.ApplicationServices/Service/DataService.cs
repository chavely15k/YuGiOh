using YuGiOh.ApplicationCore.Repository;

namespace YuGiOh.ApplicationServices.Service {
    public abstract class DataService {
        public readonly IDataRepository Repository;
        public DataService(IDataRepository dataRepository) {
            this.Repository = dataRepository;
        }
    }
}