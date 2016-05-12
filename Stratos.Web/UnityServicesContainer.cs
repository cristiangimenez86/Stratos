using Microsoft.Practices.Unity;
using Stratos.DataAccess;
using Stratos.DataAccess.Repositories;
using Stratos.DomainModel;
using Stratos.Service.Contract;
using Stratos.Service.Implementation;

namespace Stratos.Web
{
    public class UnityServicesContainer
    {
        public UnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<IServerService, ServerService>();

            container.RegisterType<IContext, EntityContext>(new PerRequestLifetimeManager());
            container.RegisterType<IRepository<Client>, BaseRepository<Client>>();
            container.RegisterType<IRepository<Server>, BaseRepository<Server>>();
            container.RegisterType<ICryptoService, CryptoService>();

            return container;
        }
    }
}