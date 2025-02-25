namespace PaySpace.Calculator.Data.Abstractions
{
  using PaySpace.Calculator.Data.Helpers;

  public interface IInMemoryCache
  {
    T GetValue<T>(string key);
    void RemoveValue<T>(string key, Func<T, bool> predicate) where T : class;
    Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> fetchAsync);
    void SetValue(string key, object value, CachePolicy? cachePolicy = null);
    void UpdateValue<T>(string key, Func<T, bool> predicate, Func<T, T> updateFunc) where T : class;
    Task<bool> AddAndCacheAsync<T>(string key, Func<Task<bool>> addToDbAsync, T newItem) where T : class;
    Task<T?> GetOrCreateByIdAsync<T>(string listKey, Func<T, bool> predicate, Func<Task<T>> fetchByIdAsync) where T : class;
  }
}
