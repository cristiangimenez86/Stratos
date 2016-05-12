using Stratos.DomainModel;
using System.Linq;

namespace Stratos.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IKeyedEntity
    {
        private readonly IContext _dbContext;

        public BaseRepository(IContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BaseRepository()
        {
        }

        public T ById(int id)
        {
            return _dbContext.Query<T>().SingleOrDefault(x => x.Id == id);
        }

        public virtual bool Add(T entity)
        {
            _dbContext.Add<T>(entity);
            return true;
        }

        public virtual bool Delete(T entity)
        {
            _dbContext.Delete<T>(entity);
            return true;
        }

        public virtual IQueryable<T> Query()
        {
            return _dbContext.Query<T>().AsQueryable();
        }

        public void Save()
        {
            _dbContext.Save();
        }
    }
}