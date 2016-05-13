using System;
using System.Web.Http;

namespace Stratos.Web.Controllers
{
    public class ApiControllerBase<TService> : ApiController where TService : class
    {
        private readonly TService _service;

        protected ApiControllerBase(TService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("The service instance is null");
            }
            _service = service;
        }

        protected TService Service
        {
            get
            {
                return _service;
            }
        }
    }
}