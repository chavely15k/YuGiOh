namespace YuGiOh.ApplicationServices.Service {
    public interface ICodeService {
        public Task<string> GenerateAsync();
        public Task<string> GetAsync();
        public Task SetAsync(string text);
    }
}