using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using Stratos.DataAccess.Mappings;

namespace Stratos.DataAccess
{
    public class EntityContext : DbContext, IContext
    {
        public EntityContext() : base(ConfigurationManager.ConnectionStrings["StratosConnectionString"].ToString())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ClientMapping());
            modelBuilder.Configurations.Add(new ServerMapping());
        }

        public void Save()
        {
            SaveChanges();
        }

        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }

        public void Update<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}