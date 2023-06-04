using CSV_Reader.Data;
using CSV_Reader.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSV_Reader.Areas.Identity.Data.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private ApplicationContext _context;
        internal DbSet<T> _dbSet;
        public GenericRepo(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void CreateDataBase()
        {
            _context.Database.EnsureCreated();
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T? entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T? entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual IQueryable<T> GetAll()
        {
            // Go to the Dbcontext and get the dataset  that is associated with type T
            return _dbSet.AsQueryable();
        }

        public async virtual Task<T?> GetByIDAsync(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}
