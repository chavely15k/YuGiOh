namespace YuGiOh.ApplicationCore.Services {
    public interface ICodeService {
        public Task<string> Generate();
        public Task<string> Get();
        public Task Set(string text);
    }
}