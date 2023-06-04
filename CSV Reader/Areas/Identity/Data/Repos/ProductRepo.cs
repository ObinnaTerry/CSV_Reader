using CSV_Reader.Data;
using CSV_Reader.Entities;
using CSV_Reader.Interfaces;

namespace CSV_Reader.Areas.Identity.Data.Repos
{
    public class ProductRepo : GenericRepo<Product>, IDisposable, IProductRepo
    {
        private readonly ApplicationContext _context;

        public ProductRepo(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public void DropTable(string tableName)
        {
            _context.DropTable(tableName);
        }

        public void Insert(List<Product> entity)
        {
            _dbSet.AddRange(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
