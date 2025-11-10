using Microsoft.EntityFrameworkCore;
using TruNguyen.Infrastructure.Interfaces;

namespace TruNguyen.Infrastructure.Repositories
{
    public class GenericRepository<T, K> : IGenericRepository<T, K> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        // ASYNC METHOD
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(K id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task DeleteByIdAsync(K id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null) return;

            _context.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }




        // SYNC METHOD
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(K id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        public void DeleteById(K id)
        {
            var entity = GetById(id);

            if (entity == null) return;

            _dbSet.Remove(entity);
            Save();
        }




        public List<T> BuildTree(
            List<T> allItems,
            int? parentId,
            Func<T, int?> getParentId,
            Func<T, int> getId,
            Action<T, List<T>> setChildren)
        {
            var result = allItems
                .Where(x => getParentId(x) == parentId)
                .Select(x =>
                {
                    var item = x;
                    var children = BuildTree(allItems, getId(x), getParentId, getId, setChildren);
                    setChildren(item, children);
                    return item;
                })
                .ToList();

            return result;
        }



    }
}
