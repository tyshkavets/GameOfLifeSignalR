using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Threading;
using Tyshka.GameOfLife.Models;

namespace Tyshka.GameOfLife
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            LaunchGenerations();
        }

        private void LaunchGenerations()
        {
            var w = new GameThread();

            var threadDelegate = new ThreadStart(w.GenerationCycle);
            GameThreadContainer.StartThread(threadDelegate);
        }
    }
}