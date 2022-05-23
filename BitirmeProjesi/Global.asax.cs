using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using BitirmeProjesi.Data;
using BitirmeProjesi.LightInject;
using BitirmeProjesi.LightInject.Mvc;

namespace BitirmeProjesi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var container = new LightInject.ServiceContainer();
            container.RegisterControllers();
            container.Register(typeof(BitirmeProjesiEntities), new PerRequestLifeTime());
            container.Register<Infrastructure.ICacheService, Infrastructure.Web.InMemoryCache>(new PerRequestLifeTime());
            System.Net.ServicePointManager.SecurityProtocol |=
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            container.Register(typeof(BitirmeProjesi.Services.User.Security.SecurityService), new PerRequestLifeTime());
            container.Register(typeof(BitirmeProjesi.Services.User.AddQuestionService), new PerRequestLifeTime());
            container.Register(typeof(BitirmeProjesi.Services.User.QuestionService), new PerRequestLifeTime());
            container.Register(typeof(BitirmeProjesi.Services.User.AnimalsService), new PerRequestLifeTime());
            container.Register(typeof(BitirmeProjesi.Services.User.VetService), new PerRequestLifeTime());
            container.Register(typeof(BitirmeProjesi.Services.User.ProfileService), new PerRequestLifeTime());


            //VET
            container.Register(typeof(BitirmeProjesi.Services.Vet.SecurityService), new PerRequestLifeTime());
            container.Register(typeof(BitirmeProjesi.Services.Vet.QuestionService), new PerRequestLifeTime());




            container.EnableMvc();
        }
    }
}
