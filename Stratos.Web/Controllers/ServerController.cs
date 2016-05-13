using Stratos.Service.Contract;
using Stratos.Service.Contract.DTOs;
using System;
using System.Web.Http;

namespace Stratos.Web.Controllers
{
    public class ServerController : ApiControllerBase<IServerService>
    {
        public ServerController(IServerService service) : base(service) { }

        public IHttpActionResult GetServers(int cliendId)
        {
            IHttpActionResult result = InternalServerError();

            try
            {
                result = Ok(base.Service.GetServers(cliendId));
            }
            catch (Exception)
            {
                //Log errors here
            }

            return result;
        }

        public IHttpActionResult Get(int id)
        {
            IHttpActionResult result = InternalServerError();

            try
            {
                result = Ok(base.Service.GetServer(id));
            }
            catch (Exception)
            {
                //Log errors here
            }

            return result;
        }

        public IHttpActionResult Post(ServerDTO server)
        {
            IHttpActionResult result = InternalServerError();

            try
            {
                if (server.Id == 0)
                {
                    base.Service.InsertServer(server);
                    result = Ok();
                }

            }
            catch (Exception)
            {
                //Log errors here
            }

            return result;
        }

        public IHttpActionResult Put(ServerDTO server)
        {
            IHttpActionResult result = InternalServerError();

            try
            {
                base.Service.UpdateServer(server);
                result = Ok();
            }
            catch (Exception)
            {
                //Log errors here
            }

            return result;
        }


        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult result = InternalServerError();

            try
            {
                base.Service.DeleteServer(id);
                result = Ok();
            }
            catch (Exception)
            {
                //Log errors here
            }

            return result;
        }
    }
}