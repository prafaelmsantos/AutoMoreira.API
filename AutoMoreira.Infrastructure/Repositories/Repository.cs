namespace AutoMoreira.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Protected properties
        protected AppDbContext _context;
        protected DbSet<T> _entity;
        #endregion

        #region constructor

        public Repository(AppDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        #endregion

        #region Public methods

        public virtual async Task<T> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _entity.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _entity.UpdateRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public virtual async Task<bool> RemoveAsync(T entity)
        {
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> RemoveRangeAsync(IEnumerable<T> entities)
        {
            _entity.RemoveRange(entities);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual IQueryable<T> GetAll() => _entity;

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public virtual async Task<T?> FindByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Protected methods
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null!;
                }
                if (_entity != null)
                {
                    _entity = null!;
                }
            }
        }

        #endregion
    }
}
