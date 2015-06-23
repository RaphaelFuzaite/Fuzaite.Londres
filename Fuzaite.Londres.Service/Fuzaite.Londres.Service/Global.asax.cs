using Autofac;
using Autofac.Integration.WebApi;
using Fuzaite.Londres.Service.Data;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fuzaite.Londres.Service
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class WebApiApplication : System.Web.HttpApplication
    {
        public IRedisClientsManager ClientsManager;
        private const string RedisUri = "localhost";

        protected void Application_Start()
        {
            ClientsManager = new PooledRedisClientManager(RedisUri);
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            ConfigureDependencyResolver(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void ConfigureDependencyResolver(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            /*builder.RegisterTypes()
                .Where(t => t.Name.EndsWith("Repository"))
                .PropertiesAutowired()
                .InstancePerApiRequest();*/

            builder.RegisterType<CampeonatoRepository>()
                .As<ICampeonatoRepository>()
                .PropertiesAutowired()
                .InstancePerApiRequest();

            builder.Register<IRedisClient>(c => ClientsManager.GetClient())
                .InstancePerApiRequest();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }

        protected void Application_OnEnd()
        {
            ClientsManager.Dispose();
        }
    }
}