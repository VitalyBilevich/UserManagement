namespace UserManagement.Application.Constants
{
    public static class UserRepositoryTypes
    {
        public const string ConfigKey = "UserRepositoryType";

        public const string InMemoryCache = "InMemoryCache";
        public const string InMemory = "InMemory";

        public static readonly string[] All = { InMemoryCache, InMemory };
    }
}
