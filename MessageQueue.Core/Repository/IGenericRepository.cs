namespace MessageQueue.Core.Repository
{
    public interface IGenericRepository<TEntity, T>
    {
        Task Add(TEntity entity);

        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetById(T id);
        Task Remove(TEntity entity);

        Task Update(TEntity entity);
    }
}
