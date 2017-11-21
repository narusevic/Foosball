using FoosballApi.Repositories;
using FoosballApi.Services;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace FoosballApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IPlayerRepository, PlayerRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITeamRepository, TeamRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMatchRepository, MatchRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITournamentRepository, TournamentRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
