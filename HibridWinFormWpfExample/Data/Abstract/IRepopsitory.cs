using System.Collections.Generic;

namespace HibridWinFormWpfExample.Data.Abstract
{
    public interface IRepopsitory<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
        void Delete(T entity);
        T GetById(int id);
        void Save();
    }
}
