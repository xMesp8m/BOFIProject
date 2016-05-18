using System.Collections.Generic;

namespace BOFI.Contracts.Services
{
    public interface IGenericRepository<T>
    {
        T Add(T entity);
        bool Update(T entity);
        bool Remove(string id);
        IEnumerable<T> GetAll();
        T GetById(string id);
    }
}
