using Stratos.DomainModel;

namespace Stratos.DataAccess.Repositories
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(IContext context)
            : base(context) { }
    }
}
