namespace Data.InMemoryCache
{
    public interface IInMemoryCacheServiceFactory
    {
        IInMemoryCacheService<TKey, TValue> Create<TKey, TValue>(string tableName, string partitionKey) where TKey : notnull;
    }
}
