using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aditya.Models.Repository
{
    public class Repository<T> : IDisposable where T : class
    {
        private bool disposed = false;
        private DatabaseContext context = null;
        protected DbSet<T> DbSet { get; set; }

        public Repository()

        {
            context = new DatabaseContext();
            DbSet = context.Set<T>();
        }

        public Repository(DatabaseContext context)
        {
            this.context = context;
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void SaveChanges()
        {
            try { context.SaveChanges(); }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                context.Dispose();
                disposed = true;
            }
        }
    }
}