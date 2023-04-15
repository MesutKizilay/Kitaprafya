using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<T> : IEntityRepository<T> where T:class,IEntity,new()
    {
        LibraryBlogContext context=new LibraryBlogContext();
        DbSet<T> _object;

        public EfEntityRepositoryBase()
        {
            _object=context.Set<T>();
        }

        public void Add(T entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State= EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            var deletedEntity=context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return filter == null
                ? _object.ToList()
                : _object.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            var updatedEntity=context.Entry(entity);
            updatedEntity.State= EntityState.Modified;
            context.SaveChanges();
        }
    }
}
