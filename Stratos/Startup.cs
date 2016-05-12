using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Unity.WebApi;

[assembly: OwinStartup(typeof(Stratos.Web.Startup))]
namespace Stratos.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new UnityServicesContainer();
            var config = new HttpConfiguration
            {
                DependencyResolver = new UnityDependencyResolver(container.GetContainer())
            };

            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}