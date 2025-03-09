namespace Data.InMemoryCache
{
    public interface IInMemoryCacheService<TKey, TValue> where TKey : notnull
    {
        string TableName { get; set; }

        string PartitionKey { get; set; }

        IEnumerable<TValue> GetAll();

        TValue? GetById(TKey id);

        void AddOrUpdate(TKey id, TValue value);

        bool Remove(TKey id);

        bool Exists(TKey id);
    }

}
