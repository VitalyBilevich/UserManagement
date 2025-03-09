using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

namespace Data.InMemoryCache
{
    public class InMemoryCacheService<TKey, TValue> : IInMemoryCacheService<TKey, TValue> where TKey : notnull
    {    
        private readonly IMemoryCache _cache;

        private string PartitionKeyPrefix => $"{TableName}{(!string.IsNullOrWhiteSpace(PartitionKey) ? "-" : "")}{PartitionKey}";

        private ConcurrentDictionary<TKey, TValue> Items => _cache.GetOrCreate(PartitionKeyPrefix, entry => new ConcurrentDictionary<TKey, TValue>())!;

        public InMemoryCacheService(IMemoryCache cache, string tableName)
            : this(cache, tableName, string.Empty)
        {
        }

        public InMemoryCacheService(IMemoryCache cache, string tableName, string partitionKey)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            TableName = tableName;
            PartitionKey = partitionKey;
        }

        public string TableName { get; set; }

        public string PartitionKey { get; set; }

        public IEnumerable<TValue> GetAll() => Items.Values;

        public TValue? GetById(TKey id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            Items.TryGetValue(id, out var value);
            return value;
        }

        public void AddOrUpdate(TKey id, TValue value)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (value == null) throw new ArgumentNullException(nameof(value));

            Items[id] = value;
        }

        public bool Remove(TKey id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return Items.TryRemove(id, out _);
        }

        public bool Exists(TKey id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return Items.ContainsKey(id);
        }
    }
}