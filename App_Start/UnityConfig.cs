using FinalTestAssignment.Module.Interface;
using System.Web.Http;
using TestApplication.Controllers;
using Unity;
using Unity.WebApi;

namespace FinalTestAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IWorkingDays, WorkingDays>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}