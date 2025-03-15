using System.Linq.Expressions;

namespace StudentInformationSystem.Infrastructure.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(long id);
        Task<T> GetEntityWithSpec(Expression<Func<T, bool>> expression);

        Task<T> GetEntityWithSpec(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression);
        Task<int> DeleteAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        void DeleteAsync(T entity);
        void UpdateAsync(T entity);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Complete();
    }
}
