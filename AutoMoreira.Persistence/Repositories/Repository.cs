using System;

namespace AutoMoreira.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Protected properties
        protected AppDbContext _context;
        protected DbSet<T> Entity;
        #endregion

        #region constructor
        public Repository(AppDbContext context)
        {
            _context = context;
            Entity = _context.Set<T>();
        }
        #endregion

        public virtual async Task<bool> AddAsync(T entity)
        {
            await Entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            await Entity.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return true;
        }


        public virtual async Task<bool> UpdateAsync(T entity)
        {
            Entity.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> UpdateRangeAsync(IEnumerable<T> entities)
        {
            Entity.UpdateRange(entities);
            await _context.SaveChangesAsync();
            return true;
        }


        public virtual async Task<bool> RemoveAsync(T entity)
        {
            Entity.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> RemoveRangeAsync(IEnumerable<T> entities)
        {
            Entity.RemoveRange(entities);
            await _context.SaveChangesAsync();
            return true;
        }


        public virtual IQueryable<T> GetAll() => Entity;

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entity.ToListAsync();
        }


        public virtual async Task<T> FindByIdAsync(int Id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Entity.FindAsync(Id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
