using Concillius.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Application.Corporativo
{
    public class BaseApplication<T> where T : class
    {
        private GenericRepository<T> repository;

        public BaseApplication(GenericRepository<T> repository):base()
        {
            this.repository = repository;
        }

        public ICollection<T> GetAll()
        {
            return repository.GetAll();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public T Get(int id)
        {
            return repository.Get(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public T FindSingle(Expression<Func<T, bool>> expression)
        {
            return repository.FindSingle(expression);
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> expression)
        {
            return await repository.FindSingleAsync(expression);
        }

        public ICollection<T> Find(Expression<Func<T, bool>> expression)
        {
            return repository.Find(expression);
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> expression)
        {
            return await repository.FindAsync(expression);
        }

        public T Add(T t)
        {
            repository.Add(t);
            return t;
        }

        public T Save(T t)
        {
            repository.Save(t);
            return t;
        }

        public T Update(T updated, int key)
        {
            return repository.Update(updated, key);
        }

        public void Delete(T t)
        {
            repository.Delete(t);
        }

        public int Count()
        {
            return repository.Count();
        }

        public async Task<int> CountAsync()
        {
            return await repository.CountAsync();
        }

        //public async Task<T> AddAsync(T t)
        //{
        //    return await repository.AddAsync(t);
        //}

        //public async Task<int> DeleteAsync(T t)
        //{
        //    return await repository.DeleteAsync(t);
        //}

        //public async Task<T> UpdateAsync(T updated, int key)
        //{
        //    return await repository.UpdateAsync(updated, key);
        //}

    }
}
