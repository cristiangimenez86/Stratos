using System.Linq;

namespace Stratos.DataAccess
{
    public interface IContext
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        IQueryable<T> Query<T>() where T : class;
        void Save();
    }
}
