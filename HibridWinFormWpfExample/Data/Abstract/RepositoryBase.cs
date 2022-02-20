using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HibridWinFormWpfExample.Data.Abstract
{
    public abstract class RepositoryBase<T> : IRepopsitory<T> where T : EntityBase
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        public T Add(T entity) => _context.Set<T>().Add(entity);       

        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        
        public T GetById(int id) => _context.Set<T>().FirstOrDefault(x => x.Id == id);

        public IEnumerable<T> GetAll() => _context.Set<T>();       
        public void Save() => _context.SaveChanges();        
    }
}
