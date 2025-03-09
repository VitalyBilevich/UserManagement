using Microsoft.Extensions.Caching.Memory;
using Data.InMemoryCache;

namespace UserManagement.Infrastructure.Caching
{
    public class InMemoryCacheServiceFactory : IInMemoryCacheServiceFactory
    {
        private readonly IMemoryCache _cache;

        public InMemoryCacheServiceFactory(IMemoryCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public IInMemoryCacheService<TKey, TValue> Create<TKey, TValue>(string tableName, string partitionKey) where TKey : notnull
        {
            return new InMemoryCacheService<TKey, TValue>(_cache, tableName, partitionKey);
        }
    }
}
