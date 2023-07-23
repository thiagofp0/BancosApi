namespace BancosApi.Domain.Base.Adapters
{
    public interface ISqlDatabaseAdapter<T>
    {
        public T GetConnection();
    }
}
