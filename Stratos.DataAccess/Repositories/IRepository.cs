using System.Linq;

namespace Stratos.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        T ById(int id);
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        IQueryable<T> Query();
        void Save();
    }
}
