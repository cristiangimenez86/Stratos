using System;
using System.Web.Http;
using Stratos.Service.Contract;
using Stratos.Service.Contract.DTOs;

namespace Stratos.Web.Controllers
{
    public class ClientController : ApiControllerBase<IClientService>
    {
        public ClientController(IClientService service) : base(service) { }

        public IHttpActionResult Get()
        {
            IHttpActionResult result = InternalServerError();

            try
            {
                result = Ok(base.Service.GetClients());
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
                result = Ok(base.Service.GetClient(id));
            }
            catch (Exception)
            {
                //Log errors here
            }

            return result;
        }


        public IHttpActionResult Post(ClientDTO client)
        {
            IHttpActionResult result = InternalServerError();

            try
            {
                if (client.Id == 0)
                {
                    base.Service.InsertClient(client);
                    result = Ok();
                }

            }
            catch (Exception)
            {
                //Log errors here
            }

            return result;
        }

        public IHttpActionResult Put(ClientDTO client)
        {
            IHttpActionResult result = InternalServerError();

            try
            {
                base.Service.UpdateClient(client);
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
                base.Service.DeleteClient(id);
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