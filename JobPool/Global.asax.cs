using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Web.Common.WebHost;
using Ninject;
using System.Web.Http;
using JobPool.Models;
using JobPool.UnitOfWorkModel;

namespace JobPool
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()
        {

            var kernel = new StandardKernel();
            GlobalConfiguration.Configuration.DependencyResolver =
    kernel.Get<System.Web.Http.Dependencies.IDependencyResolver>();
            RegisterServices(kernel);

            return kernel;
        }
        private void RegisterServices(IKernel kernel)
        {
            IApplicationDbContext context = new ApplicationDbContext();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>()
                   .WithConstructorArgument("proxy", context);


        }
    }
}
