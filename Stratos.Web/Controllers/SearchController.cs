using Stratos.Service.Contract;
using System;
using System.Web.Http;

namespace Stratos.Web.Controllers
{
    public class SearchController : ApiControllerBase<IClientService>
    {
        public SearchController(IClientService service) : base(service)
        {
        }

        public IHttpActionResult Get(string id)
        {
            IHttpActionResult result = InternalServerError();

            try
            {
                result = Ok(base.Service.SearchClients(id));
            }
            catch (Exception)
            {
                //Log errors here
            }

            return result;
        }
    }
}