using PaparaProject.Data.Abstracts;
using PaparaProject.Data.Context;
using PaparaProject.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace PaparaProject.Data.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        PaparaProjectDbContext Context { get; }

        public Repository(PaparaProjectDbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public int Delete(int id)
        {
            T existData = Context.Set<T>().Find(id);
                existData.Status = false;
                Context.Entry(existData).State = EntityState.Modified;
            return Context.SaveChanges();
        }

        public T GetById(int id)
        {
            return Context.Set<T>()
                .Where(x => x.Id == id && x.Status)
                .FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return Context.Set<T>()
                .Where(x => x.Status)
                .ToList();
        }

        public int HardDelete(int id)
        {
            T existData = Context.Set<T>().Find(id);
            if (existData != null)
            {
                Context.Set<T>().Remove(existData);
                return Context.SaveChanges();
            }
            return -1;
        }

        public int Update(T entity, int id)
        {
            T existData = Context.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (existData != null)
            {
                Context.Set<T>().Update(entity);
                return Context.SaveChanges();
            }
            return -1;
        }
    }
}
