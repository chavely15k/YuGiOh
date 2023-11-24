using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationCore.Map;

namespace YuGiOh.ApplicationServices.Service {
    public abstract class DataService {
        public readonly IDataRepository Repository;
        public readonly YuGiOhAutoMapper AutoMapper;
        public DataService(IDataRepository dataRepository, YuGiOhAutoMapper autoMapper) {
            this.Repository = dataRepository;
            this.AutoMapper = autoMapper;
        }
    }
}