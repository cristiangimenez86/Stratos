using Stratos.DomainModel;

namespace Stratos.DataAccess.Repositories
{
    public class ServerRepository : BaseRepository<Server>
    {
        public ServerRepository(IContext context)
            : base(context) { }
    }
}
