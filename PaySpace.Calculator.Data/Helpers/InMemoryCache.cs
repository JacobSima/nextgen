namespace PaySpace.Calculator.Data.Helpers
{
  using Microsoft.Extensions.Caching.Memory;
  using PaySpace.Calculator.Data.Abstractions;

  public class InMemoryCache(IMemoryCache memoryCache) : IInMemoryCache
  {
    public T? GetValue<T>(string key)
    {
      return memoryCache.TryGetValue(key, out T value) ? value : default!;
    }

    public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> fetchAsync)
    {
      var result = await memoryCache.GetOrCreateAsync(key, async entry =>
      {
        var reponse = await fetchAsync();
        return reponse;
      });

      return result;
    }

    public void SetValue(string key, object value, CachePolicy? cachePolicy = null)
    {
      if (cachePolicy == null)
      {
        memoryCache.Set(key, value);
        return;
      }

      if (cachePolicy!.AbsoluteExpiration.HasValue)
      {
        memoryCache.Set(key, value, cachePolicy.AbsoluteExpiration.Value);
      }
    }

    public void UpdateValue<T>(string key, Func<T, bool> predicate, Func<T, T> updateFunc) where T : class
    {
      if (memoryCache.TryGetValue(key, out List<T>? cachedList) && cachedList != null)
      {
        // Explicit cast
        var index = cachedList.FindIndex(new Predicate<T>(predicate));

        if (index != -1)
        {
          cachedList[index] = updateFunc(cachedList[index]);

          // Store the updated list back in cache
          memoryCache.Set(key, cachedList);
        }
      }
    }

    public void RemoveValue<T>(string key, Func<T, bool> predicate)
      where T : class
    {
      if (memoryCache.TryGetValue(key, out List<T>? cachedList) && cachedList != null)
      {
        cachedList.RemoveAll(predicate.Invoke);

        // Update the cache with the modified list
        memoryCache.Set(key, cachedList);
      }
    }

    public async Task<T?> GetOrCreateByIdAsync<T>(string key, Func<T, bool> predicate, Func<Task<T>> fetchByIdAsync)
        where T : class
    {
      // Try to get the cached list
      if (!memoryCache.TryGetValue(key, out List<T>? cachedList) || cachedList == null)
      {
        // If the cache is empty, initialize a new list
        cachedList = new List<T>();
      }

      // Try to find the item in the cache
      var existingItem = cachedList.FirstOrDefault(predicate);
      if (existingItem != null)
      {
        return existingItem; // Return if found
      }

      // Fetch from DB since not in cache
      var fetchedItem = await fetchByIdAsync();
      if (fetchedItem != null)
      {
        // Add to the cached list
        cachedList.Add(fetchedItem);

        // Update cache
        memoryCache.Set(key, cachedList);
      }

      return fetchedItem;
    }

    public async Task<bool> AddAndCacheAsync<T>(string key, Func<Task<bool>> addToDbAsync, T newItem)
      where T : class
    {
      // Add the new item to the database
      var isAdded = await addToDbAsync();
      if (!isAdded)
      {
        // If DB insertion failed, do not update cache
        return false;
      }

      // Retrieve the cached list or initialize a new list
      if (!memoryCache.TryGetValue(key, out List<T>? cachedList) || cachedList == null)
      {
        cachedList = new List<T>();
      }

      // Add the new item to the cached list
      cachedList.Add(newItem);

      // Update the cache
      memoryCache.Set(key, cachedList);

      // Successfully added to DB and updated cache
      return true;
    }


  }
}
