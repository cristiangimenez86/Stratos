using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Stratos.Service.Contract;
using Stratos.Service.Contract.DTOs;

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
                //var servers = new List<ServerDTO>
                //{
                //    new ServerDTO { Id = 1, ClientId = 4, URL = "URL1", Username = "Username1", Password = "password1"},
                //    new ServerDTO { Id = 2, ClientId = 4, URL = "URL2", Username = "Username2", Password = "password2"},
                //    new ServerDTO { Id = 3, ClientId = 4, URL = "URL3", Username = "Username3", Password = "password3"},
                //    new ServerDTO { Id = 4, ClientId = 4, URL = "URL4", Username = "Username4", Password = "password4"}
                //};
                //result = Ok(servers);
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
                //var server = new ServerDTO { Id = 3, ClientId = 4, URL = "URL3", Username = "Username3", Password = "password3" };
                //result = Ok(server);
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