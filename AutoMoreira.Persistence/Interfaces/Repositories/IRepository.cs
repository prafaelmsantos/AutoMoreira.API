namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);

        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveRangeAsync(IEnumerable<T> entities);

        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> FindByIdAsync(int id);

        void Dispose();
    }
}
