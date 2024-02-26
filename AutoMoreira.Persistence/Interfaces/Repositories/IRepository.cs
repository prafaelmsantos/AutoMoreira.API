namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);

        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateRangeAsync(IEnumerable<T> entities);

        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveRangeAsync(IEnumerable<T> entities);

        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> FindByIdAsync(int Id);
 
    }
}
