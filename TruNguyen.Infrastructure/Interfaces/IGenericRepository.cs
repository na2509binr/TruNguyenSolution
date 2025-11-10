namespace TruNguyen.Infrastructure.Interfaces
{
    public interface IGenericRepository<T, K>
    {
        // ASYNC METHOD
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(K id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(K id);
        Task SaveAsync();

        // SYNC METHOD
        IEnumerable<T> GetAll();
        T? GetById(K id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(K id);
        void Save();

        List<T> BuildTree(
            List<T> allItems,
            int? parentId,
            Func<T, int?> getParentId,
            Func<T, int> getId,
            Action<T, List<T>> setChildren);


    }
}
