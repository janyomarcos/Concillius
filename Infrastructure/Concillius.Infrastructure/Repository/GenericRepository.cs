using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Infrastructure.Repository
{
    public class GenericRepository<T> where T : class
    {
        protected DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        public ICollection<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public T FindSingle(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().SingleOrDefault(expression);
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().SingleOrDefaultAsync(expression);
        }

        public ICollection<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).ToList();
        }

        public async Task<ICollection<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().Where(expression).ToListAsync();
        }

        public T Add(T t)
        {
            context.Set<T>().Add(t);
            //context.SaveChanges();
            return t;
        }

        public T Save(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
            return t;
        }
        
        public T Modify(T updated, int key)
        {
            if (updated == null)
                return null;

            T existing = context.Set<T>().Find(key);
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(updated);
                //context.SaveChanges();
            }
            return existing;
        }

        public T Update(T updated, int key)
        {
            if (updated == null)
                return null;

            T existing = context.Set<T>().Find(key);
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(updated);
                context.SaveChanges();
            }
            return existing;
        }

        public void Remove(T t)
        {
            context.Set<T>().Remove(t);
            //context.SaveChanges();
        }

        public void Delete(T t)
        {
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await context.Set<T>().CountAsync();
        }

        //public async Task<T> AddAsync(T t)
        //{
        //    context.Set<T>().Add(t);
        //    await context.SaveChangesAsync();
        //    return t;
        //}

        //public async Task<int> DeleteAsync(T t)
        //{
        //    context.Set<T>().Remove(t);
        //    return await context.SaveChangesAsync();
        //}

        //public async Task<T> UpdateAsync(T updated, int key)
        //{
        //    if (updated == null)
        //        return null;

        //    T existing = await context.Set<T>().FindAsync(key);
        //    if (existing != null)
        //    {
        //        context.Entry(existing).CurrentValues.SetValues(updated);
        //        await context.SaveChangesAsync();
        //    }
        //    return existing;
        //}
    }
}
