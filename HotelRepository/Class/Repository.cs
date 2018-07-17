using HotelEntity.Class;
using HotelRepository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.Class
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public DataContext context = new DataContext();

        public int Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public int Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
          //  DbSet.Attach();
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
