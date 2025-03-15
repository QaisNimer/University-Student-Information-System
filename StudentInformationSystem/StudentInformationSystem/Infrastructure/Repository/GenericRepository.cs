using Microsoft.EntityFrameworkCore;
using SkiaSharp;
using StudentInformationSystem.Infrastructure.Database;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;
using System.Linq.Expressions;

namespace StudentInformationSystem.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ApplicationContext _Context;

        public GenericRepository(ApplicationContext Context)
        {
            _Context = Context;
        }
        public void DeleteAsync(T entity)
        {
            _Context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _Context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _Context.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetByIdAsync(long id)
        {
            try
            {
                return await _Context.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        //Specification Pattern
        public async Task<T> GetEntityWithSpec(Expression<Func<T, bool>> expression)
        {
            return ApplySpecification(expression).FirstOrDefault();
        }

        public async Task<T> GetEntityWithSpec(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _Context.Set<T>().Where(expression);

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task<int> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = _Context.Set<T>().Where(expression);
            _Context.RemoveRange(query);
            return await _Context.SaveChangesAsync(); 
        }


        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return ApplySpecification(expression).ToList();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _Context.Set<T>();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }


        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return ApplySpecification(expression).Count();
        }
        private IQueryable<T> ApplySpecification(Expression<Func<T, bool>> expression)
        {
            return _Context.Set<T>().Where(expression).AsQueryable();
        }

        public void Add(T entity)
        {
            _Context.Add<T>(entity);
        }

        public void Update(T entity)
        {
            _Context.Attach<T>(entity);
            _Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);
        }

        public int Complete()
        {
            return _Context.SaveChanges();
        }



    }
}
